namespace EficazFramework.Generators.EntityFrameworkCore;

[Generator]
public class ModelBuilder : ISourceGenerator
{
    void ISourceGenerator.Initialize(GeneratorInitializationContext context) 
    {
//#if DEBUG
//        if (!Debugger.IsAttached)
//        {
//            Debugger.Launch();
//        }
//#endif         
    }

    void ISourceGenerator.Execute(GeneratorExecutionContext context)
    {
        bool useSqlServer = context.Compilation.References.Any(r => (r.Display ?? "").Contains("EficazFramework.Data.MsSqlServer"));
        bool useMySql = context.Compilation.References.Any(r => (r.Display ?? "").Contains("EficazFramework.Data.MySql"));
        bool usePostgreSql = context.Compilation.References.Any(r => (r.Display ?? "").Contains("EficazFramework.Data.PostgreSql"));
        bool useOracleSql = context.Compilation.References.Any(r => (r.Display ?? "").Contains("EficazFramework.Data.OracleSql"));
        bool useSqlite = context.Compilation.References.Any(r => (r.Display ?? "").Contains("EficazFramework.Data.SqlLite"));
        bool useInMemory = context.Compilation.References.Any(r => (r.Display ?? "").Contains("EficazFramework.Data.InMemory"));
        bool shouldGenerate = useSqlServer || useMySql || usePostgreSql || useOracleSql || useSqlite || useInMemory;

        if (!shouldGenerate)
        {
            context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB001", "No data providers available", "Any EficazFramework.Data provider is referenced by the project.", "EficazFramework Model Builder", DiagnosticSeverity.Warning, true), Location.None));
            return;
        }

        if (context.AdditionalFiles.Count() <= 0)
            context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB002", "No additional files.", "Any AdditionalFiles is found on the project.", "EficazFramework Model Builder", DiagnosticSeverity.Warning, true), Location.None));
        
        // find anything that matches .efmodel
        var myFiles = context.AdditionalFiles.Where(at => at.Path.EndsWith(".efmodel"));
        int counter = 0;
        foreach (var file in myFiles)
        {
            counter += 1;
            Models.EfModel.ModelClass model = null;
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new (typeof(Models.EfModel.ModelClass));
                var content = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(file.GetText(context.CancellationToken).ToString()));
                model = (Models.EfModel.ModelClass)reader.Deserialize(content);
                content.Close();
                content.Dispose();
            }
            catch
            {
                context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Invalid efmodel", "Can't read efmodel file.", "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
                continue;
            }
            if (model is null)
            {
                context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Invalid efmodel", "Can't read efmodel file.", "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
                continue;
            }

            try
            {
                StringBuilder code = new();
                code.AppendLine("using EficazFramework.Entities;");
                code.AppendLine("using EficazFramework.Extensions;");
                code.AppendLine("using Microsoft.EntityFrameworkCore;");
                code.AppendLine("using Microsoft.EntityFrameworkCore.Metadata.Builders;");

                code.AppendLine($"namespace {model.Namespace}");
                code.AppendLine("{");
                code.AppendLine($"    public static class {model.Name}Builder");
                code.AppendLine("    {");
                code.AppendLine("        ");

                if (useInMemory)
                    GenerateForInMemory(code, model);

                if (useSqlServer)
                    GenerateForMsSqlServer(code, model);

                if (useMySql)
                    GenerateForMySqlOrMariaDb(code, model);

                code.AppendLine("    }");
                code.AppendLine("}");


                context.AddSource($"{model.Name}.Map.g.cs", code.ToString());
            }
            catch (Exception mainEx)
            {
                context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Model Builder Exception", mainEx.ToString(), "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
            }

        }
    }

    void GenerateForInMemory(StringBuilder code, Models.EfModel.ModelClass model)
    {
        code.AppendLine("        #region InMemory Entity Mapping");
        code.AppendLine("        ");
        code.AppendLine($"        public static EntityTypeBuilder<{model.Name}> MapForInMemory(EntityTypeBuilder<{model.Name}> builder, string overrideTableSchema)");
        code.AppendLine("        {");

        code.AppendLine("            // Table Mapping");
        code.AppendLine($"            builder.ToTable(\"{model.TableName}\"{(!string.IsNullOrEmpty(model.TableSchema) ? $", \"{model.TableSchema}\"" : string.Empty)});");

        var pks = model.Properties.Where(f => f.Key == true).Select(f => string.Format("pk.{0}", f.Name)).ToArray();
        if (pks.Count() > 0)
        {
            code.AppendLine("            // Primary Keys");
            code.AppendLine($"            builder.HasKey(pk => new {{ {string.Join(",", pks)} }});");
        }

        code.AppendLine("            // Column Mapping");
        foreach (var prop in model.Properties.Where(f => f.NotMap == false && (f.IsRequired | f.IsReadOnly | f.Ignore | (!string.IsNullOrEmpty(f.DefaultValue)) | f.Lenght.HasValue | f.Identity | (!string.IsNullOrEmpty(f.ValueGenerated)))).ToList())
        {
            if (prop.Ignore || (prop.IsReadOnly && (!prop.ComputedValue)))
            {
                code.AppendLine($"            builder.Ignore(e => e.{prop.Name});");
                continue;
            }
            System.Text.StringBuilder builder = new();
            builder.Append($"            builder.Property(e => e.{prop.Name})");

            if (prop.Key & (!string.IsNullOrEmpty(prop.ValueGenerated)))
                builder.Append($".ValueGenerated{prop.ValueGenerated}()");

            if (prop.Identity)
                builder.Append(".UseIdentityColumn()");

            if (prop.IsRequired)
                builder.Append(".IsRequired()");

            if (prop.Lenght.HasValue)
                builder.Append($".HasMaxLength({prop.Lenght.Value})");

            //if ((!string.IsNullOrEmpty(prop.DefaultValue)) & prop.ComputedValue == false)
            //    builder.Append($".HasDefaultValue({prop.DefaultValue})");

            //if ((!string.IsNullOrEmpty(prop.DefaultValue)) & prop.ComputedValue == true)
            //    builder.Append($".HasComputedColumn(\"{prop.DefaultValue}\")");

            builder.Append(";");
            string result = builder.ToString();
            builder = null;
            if (!string.IsNullOrEmpty(result))
                code.AppendLine(result);
        }
        code.AppendLine($"            EntityMappingConfigurator.MapBaseClassProperties(builder);");

        if (model.Relationships.Count > 0)
        {
            code.AppendLine("            // Relationships");
            GenerateRelationShips(code, model);
        }

        code.AppendLine("            // Finish");
        code.AppendLine("            return builder;");
        code.AppendLine("        }");
        code.AppendLine("        ");
        code.AppendLine("        #endregion");
        code.AppendLine("        ");
        code.AppendLine("        ");
    }
    

    void GenerateForMsSqlServer(StringBuilder code, Models.EfModel.ModelClass model)
    {
        code.AppendLine("        #region Ms SQL Server Entity Mapping");
        code.AppendLine("        ");
        code.AppendLine($"        public static EntityTypeBuilder<{model.Name}> MapForMsSqlServer(EntityTypeBuilder<{model.Name}> builder, string overrideTableSchema)");
        code.AppendLine("        {");
        
        code.AppendLine("            // Table Mapping");
        code.AppendLine($"            builder.ToTable(\"{model.TableName}\"{(!string.IsNullOrEmpty(model.TableSchema) ? $", \"{model.TableSchema}\"" : string.Empty)});");

        var pks = model.Properties.Where(f => f.Key == true).Select(f => string.Format("pk.{0}", f.Name)).ToArray();
        if (pks.Count() > 0)
        {
            code.AppendLine("            // Primary Keys");
            code.AppendLine($"            builder.HasKey(pk => new {{ {string.Join(",", pks)} }});");
        }

        code.AppendLine("            // Column Mapping");
        foreach (var prop in model.Properties.Where(f => f.NotMap == false && (f.IsRequired | f.IsReadOnly | f.Ignore | (!string.IsNullOrEmpty(f.DefaultValue)) | f.Lenght.HasValue | f.Identity | (!string.IsNullOrEmpty(f.ValueGenerated)))).ToList())
        {
            if (prop.Ignore || (prop.IsReadOnly && (!prop.ComputedValue)))
            {
                code.AppendLine($"            builder.Ignore(e => e.{prop.Name});");
                continue;
            }
            System.Text.StringBuilder builder = new();
            builder.Append($"            builder.Property(e => e.{prop.Name})");

            if (prop.Key & (!string.IsNullOrEmpty(prop.ValueGenerated)))
                builder.Append($".ValueGenerated{prop.ValueGenerated}()");

            if (prop.Identity)
                builder.Append(".UseIdentityColumn()");

            if (prop.IsRequired)
                builder.Append(".IsRequired()");

            if (prop.Lenght.HasValue)
                builder.Append($".HasMaxLength({prop.Lenght.Value})");

            if ((!string.IsNullOrEmpty(prop.DefaultValue)) & prop.ComputedValue == false)
                builder.Append($".HasDefaultValueSql({prop.DefaultValue})");

            if ((!string.IsNullOrEmpty(prop.DefaultValue)) & prop.ComputedValue == true)
                builder.Append($".HasComputedColumnSql(\"{prop.DefaultValue}\")");

            builder.Append(";");
            string result = builder.ToString();
            builder = null;
            if (!string.IsNullOrEmpty(result))
                code.AppendLine(result);
        }
        code.AppendLine($"            EntityMappingConfigurator.MapBaseClassProperties(builder);");

        if (model.Relationships.Count > 0)
        {
            code.AppendLine("            // Relationships");
            GenerateRelationShips(code, model);
        }

        code.AppendLine("            // Finish");
        code.AppendLine("            return builder;");
        code.AppendLine("        }");
        code.AppendLine("        ");
        code.AppendLine("        #endregion");
        code.AppendLine("        ");
        code.AppendLine("        ");
    }


    void GenerateForMySqlOrMariaDb(StringBuilder code, Models.EfModel.ModelClass model)
    {
        code.AppendLine("        #region MySQL/MariaDB Entity Mapping");
        code.AppendLine("        ");
        code.AppendLine($"        public static EntityTypeBuilder<{model.Name}> MapForMsSqlServer(EntityTypeBuilder<{model.Name}> builder, string overrideTableSchema)");
        code.AppendLine("        {");

        code.AppendLine("            // Table Mapping");
        code.AppendLine($"            builder.ToTable(\"{model.TableName}\"{(!string.IsNullOrEmpty(model.TableSchema) ? $", \"{model.TableSchema}\"" : string.Empty)});");

        var pks = model.Properties.Where(f => f.Key == true).Select(f => string.Format("pk.{0}", f.Name)).ToArray();
        if (pks.Count() > 0)
        {
            code.AppendLine("            // Primary Keys");
            code.AppendLine($"            builder.HasKey(pk => new {{ {string.Join(",", pks)} }});");
        }

        code.AppendLine("            // Column Mapping");
        foreach (var prop in model.Properties.Where(f => f.NotMap == false && (f.IsRequired | f.IsReadOnly | f.Ignore | (!string.IsNullOrEmpty(f.DefaultValue)) | f.Lenght.HasValue | f.Identity | (!string.IsNullOrEmpty(f.ValueGenerated)))).ToList())
        {
            if (prop.Ignore || (prop.IsReadOnly && (!prop.ComputedValue)))
            {
                code.AppendLine($"            builder.Ignore(e => e.{prop.Name});");
                continue;
            }
            System.Text.StringBuilder builder = new();
            builder.Append($"            builder.Property(e => e.{prop.Name})");

            if (prop.Key & (!string.IsNullOrEmpty(prop.ValueGenerated)))
                builder.Append($".ValueGenerated{prop.ValueGenerated}()");

            if (prop.Identity)
                builder.Append(".UseIdentityColumn()");

            if (prop.IsRequired)
                builder.Append(".IsRequired()");

            if (prop.Lenght.HasValue)
                builder.Append($".HasMaxLength({prop.Lenght.Value})");

            if ((!string.IsNullOrEmpty(prop.DefaultValue)) & prop.ComputedValue == false)
                builder.Append($".HasDefaultValueSql({prop.DefaultValue})");

            if ((!string.IsNullOrEmpty(prop.DefaultValue)) & prop.ComputedValue == true)
                builder.Append($".HasComputedColumnSql(\"{prop.DefaultValue}\")");

            builder.Append(";");
            string result = builder.ToString();
            builder = null;
            if (!string.IsNullOrEmpty(result))
                code.AppendLine(result);
        }
        code.AppendLine($"            EntityMappingConfigurator.MapBaseClassProperties(builder);");

        if (model.Relationships.Count > 0)
        {
            code.AppendLine("            // Relationships");
            GenerateRelationShips(code, model);
        }

        code.AppendLine("            // Finish");
        code.AppendLine("            return builder;");
        code.AppendLine("        }");
        code.AppendLine("        ");
        code.AppendLine("        #endregion");
        code.AppendLine("        ");
        code.AppendLine("        ");
    }



    void GenerateRelationShips(StringBuilder code, Models.EfModel.ModelClass model)
    {
        foreach (var rel in model.Relationships)
        {
            string[] leftprops = (rel.LeftExpression ?? "").Replace(" ", "").Split(';').Where(p => !string.IsNullOrEmpty(p)).ToArray();
            string[] righprops = (rel.RightExpression ?? "").Replace(" ", "").Split(';').Where(p => !string.IsNullOrEmpty(p)).ToArray();
            string[] righfkprops = (rel.RightFkExpression ?? "").Replace(" ", "").Split(';').Where(p => !string.IsNullOrEmpty(p)).ToArray();
            string[] leftfkprops = (rel.LeftFkExpression ?? "").Replace(" ", "").Split(';').Where(p => !string.IsNullOrEmpty(p)).ToArray();

            System.Text.StringBuilder builder = new();
            builder.Append("builder");
            builder.Append($".{rel.Left}(left => ");

            if (leftprops.Count() > 1)
                builder.Append("new {");

            builder.Append(string.Join(", ", leftprops.Select(left => $"left.{left}").ToList()));
            if (leftprops.Count() > 1)
                builder.Append("}");

            builder.Append(")");

            if (!string.IsNullOrEmpty(rel.Right))
            {
                builder.Append($".{rel.Right}");
                if (righprops.Count() == 0)
                    builder.Append("()");
                else
                {
                    if (righprops.Count() > 1)
                        builder.Append("(right => new {");
                    else
                        builder.Append("(right => ");
                    builder.Append(string.Join(", ", righprops.Select(right => $"right.{right}").ToList()));
                }
                if (righprops.Count() > 1)
                    builder.Append("}");

                if (righprops.Count() > 0)
                    builder.Append(")");
            }

            if (rel.LeftHasFK)
            {
                builder.Append(".HasPrincipalKey");
                if (rel.Left == "HasOne" && rel.Right == "WithOne" && string.IsNullOrEmpty(rel.RightExpression))
                    builder.Append($"<{model.Properties.Where(f => f.Name == rel.LeftExpression).Select(f => f.DataType).FirstOrDefault()}>");

                builder.Append("(pk => ");
                if (leftfkprops.Count() > 1)
                    builder.Append("new {");

                builder.Append(string.Join(", ", leftfkprops.Select(fk => string.Format("pk.{0}", fk)).ToList()));
                if (leftfkprops.Count() > 1)
                    builder.Append("}");
                builder.Append(")");
            }

            if (rel.RightHasFK)
            {
                builder.Append(".HasForeignKey");
                if (rel.Left == "HasOne" && rel.Right == "WithOne" && string.IsNullOrEmpty(rel.RightExpression))
                    builder.Append($"<{model.Name}>");

                builder.Append("(fk => ");
                if (righfkprops.Count() > 1)
                    builder.Append("new {");

                builder.Append(string.Join(", ", righfkprops.Select(fk => string.Format("fk.{0}", fk)).ToList()));
                if (righfkprops.Count() > 1)
                    builder.Append("}");

                builder.Append(")");
            }

            if (rel.DeleteBehavior != "NoAction")
                builder.Append($".OnDelete(DeleteBehavior.{rel.DeleteBehavior})");

            builder.Append(";");
            string resultstr = builder.ToString();
            builder = null;

            code.AppendLine($"            {resultstr}");
        }
    }
}