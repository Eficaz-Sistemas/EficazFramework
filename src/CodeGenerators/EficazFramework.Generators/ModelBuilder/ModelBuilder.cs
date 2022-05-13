﻿using EficazFramework.Extensions;

namespace EficazFramework.Generators.EntityFrameworkCore;

[Generator]
public class ModelBuilder : ISourceGenerator
{
    void ISourceGenerator.Initialize(GeneratorInitializationContext context) 
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            Debugger.Launch();
        }
#endif         
    }

    void ISourceGenerator.Execute(GeneratorExecutionContext context)
    {
        bool useSqlServer = context.Compilation.References.Any(r => r.Display == "EficazFramework.Data.MsSqlServer");
        bool useMySql = context.Compilation.References.Any(r => r.Display == "EficazFramework.Data.MySql");
        bool usePostgreSql = context.Compilation.References.Any(r => r.Display == "EficazFramework.Data.PostgreSql");
        bool useOracleSql = context.Compilation.References.Any(r => r.Display == "EficazFramework.Data.OracleSql");
        bool useSqlite = context.Compilation.References.Any(r => r.Display == "EficazFramework.Data.SqlLite");
        bool useInMemory = context.Compilation.References.Any(r => r.Display == "EficazFramework.Data.InMemory");
        bool shouldGenerate = useSqlServer || useMySql || usePostgreSql || useOracleSql || useSqlite || useInMemory;

        if (!shouldGenerate)
            return;

        // find anything that matches .efmodel
        var myFiles = context.AdditionalFiles.Where(at => at.Path.EndsWith(".efmodel"));
        foreach (var file in myFiles)
        { 
            Models.EfModel.ModelClass model = null;
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Models.EfModel.ModelClass));
                var content = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(file.GetText(context.CancellationToken).ToString()));
                model = (Models.EfModel.ModelClass)reader.Deserialize(content);
                content.Close();
                content.Dispose();
            }
            catch
            {
                continue;
            }
            if (model is null)
                continue;

            StringBuilder code = new();
            code.AppendLine("using EficazFramework.Entities;");
            code.AppendLine("using EficazFramework.Extensions;");
            code.AppendLine("using Microsoft.EntityFrameworkCore;");
            code.AppendLine("using Microsoft.EntityFrameworkCore.Metadata.Builders;");

            code.AppendLine($"namespace {model.Namespace}");
            code.AppendLine("{");
            code.AppendLine($"    public partial class {model.Name}" + $"{(!string.IsNullOrEmpty(model.BaseClass) ? $" : {model.BaseClass}" : string.Empty)}");
            code.AppendLine("    {");
            code.AppendLine("        ");
            
            if (useSqlServer)
                GenerateForMsSqlServer(code, model);
            
            code.AppendLine("    }");
            code.AppendLine("}");
                    

            context.AddSource($"{model.Name}.Map.g.cs", code.ToString());
        }
    }

    void GenerateForMsSqlServer(StringBuilder code, Models.EfModel.ModelClass model)
    {
        code.AppendLine("        #region Ms SQL Server Entity Mapping");
        code.AppendLine("        ");
        code.AppendLine($"        public EntityTypeBuilder<{model.Name}> MapForMsSqlServer(EntityTypeBuilder<{model.Name}> builder. string overrideTableSchema)");
        code.AppendLine("        {");
        
        code.AppendLine("            // Table Mapping");
        code.AppendLine($"            builder.ToTable(\"{model.TableName}\"{(!string.IsNullOrEmpty(model.TableSchema) ? $", {model.TableSchema}" : string.Empty)});");

        code.AppendLine("            // Primary Keys");
        var pks = model.Properties.Where(f => f.Key == true).Select(f => string.Format("e.{0}", f.Name)).ToArray();
        if (pks.Count() > 0)
            code.AppendLine($"            builder.HasKey(pk => new {{ {string.Join(",", pks)} }});");

        code.AppendLine("            // Column Mapping");
        foreach (var prop in model.Properties.Where(f => f.NotMap == false && (f.IsRequired | f.IsReadOnly | f.Ignore | (!string.IsNullOrEmpty(f.DefaultValue)) | f.Lenght.HasValue | f.Identity | (!string.IsNullOrEmpty(f.ValueGenerated)))).ToList())
        {
            if (prop.Ignore || (prop.IsReadOnly && (!prop.ComputedValue)))
            {
                code.AppendLine($"            builder.Ignore(e => e.{prop.Name});");
                continue;
            }
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append($"            entry.Property((e) => e.{prop.Name})");

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

            string result = builder.ToString();
            builder = null;
            if (!string.IsNullOrEmpty(result))
                code.AppendLine(result);
        }
        code.AppendLine($"            EntityMappingConfigurator.MapBaseClassProperties(builder);");

        code.AppendLine("            // RelationShips");
        GenerateRelationShips(code, model);

        code.AppendLine("            ");
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

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("builder");
            builder.Append($".{rel.Left}((left) => ");

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
                        builder.Append("((right) => new {");
                    else
                        builder.Append("((right) => ");
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

                builder.Append("((pk) => ");
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

                builder.Append("((fk) => ");
                if (righfkprops.Count() > 1)
                    builder.Append("new {");

                builder.Append(string.Join(", ", righfkprops.Select(fk => string.Format("fk.{0}", fk)).ToList()));
                if (righfkprops.Count() > 1)
                    builder.Append("}");

                builder.Append(")");
            }

            if (rel.DeleteBehavior != "NoAction")
                builder.Append($".OnDelete(DeleteBehavior.{rel.DeleteBehavior})");

            string resultstr = builder.ToString();
            builder = null;

            code.AppendLine($"            {resultstr}");
        }
    }
}