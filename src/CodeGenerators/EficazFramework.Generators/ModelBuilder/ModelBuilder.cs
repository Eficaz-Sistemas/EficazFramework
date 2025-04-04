﻿using Microsoft.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;

namespace EficazFramework.Generators.EntityFrameworkCore;

[Generator(LanguageNames.CSharp)]
public class ModelBuilder : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // find all additional files that end with .txt
        IncrementalValuesProvider<AdditionalText> efModelFiles = context.AdditionalTextsProvider.Where(static file => file.Path.EndsWith(".efmodel"));

        // read their contents and save their name
        IncrementalValuesProvider<(string name, string content)> namesAndContents = efModelFiles.Select((text, cancellationToken) => (name: Path.GetFileNameWithoutExtension(text.Path), content: text.GetText(cancellationToken)!.ToString()));

        // write source code
        ExecuteClass(context, namesAndContents);
        ExecuteMappings(context, namesAndContents);
    }

    void ExecuteClass(
        IncrementalGeneratorInitializationContext context,
        IncrementalValuesProvider<(string name, string content)> efModels)
    {

        IncrementalValuesProvider<string> referencies = context.MetadataReferencesProvider
            //.Where(r => r.Display.Contains("EficazFramework.Data."))
            .Select((cmp, cancelationToken) => cmp.Display);


        // check referencies
        bool useSqlServer = false;
        bool useMySql = false;
        bool usePostgreSql = false;
        bool useOracleSql = false;
        bool useSqlite = false;
        bool useInMemory = false;
        context.RegisterImplementationSourceOutput(referencies, (writer, reference) =>
        {
            switch (reference)
            {
                case string e when e.Contains("EficazFramework.Data.MsSqlServer"):
                    useSqlServer = true; break;

                case string e when e.Contains("EficazFramework.Data.MySql"):
                    useMySql = true; break;

                case string e when e.Contains("EficazFramework.Data.PostgreSql"):
                    usePostgreSql = true; break;

                case string e when e.Contains("EficazFramework.Data.OracleSql"):
                    useOracleSql = true; break;

                case string e when e.Contains("EficazFramework.Data.SqlLite"):
                    useSqlite = true; break;

                case string e when e.Contains("EficazFramework.Data.InMemory"):
                    useInMemory = true; break;
            }
        });


        // generate code
        context.RegisterSourceOutput(efModels, (spc, efModel) =>
        {
            Models.EfModel.ModelClass model = null;
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new(typeof(Models.EfModel.ModelClass));
                var content = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(efModel.content));
                model = (Models.EfModel.ModelClass)reader.Deserialize(content);
                content.Close();
                content.Dispose();
            }
            catch
            {
                spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Invalid efmodel", "Can't read efmodel file.", "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
            }
            if (model is null)
            {
                spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Invalid efmodel", "Can't read efmodel file.", "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
            }

            bool shouldGenerate = !useSqlServer && !useMySql && !usePostgreSql && !useOracleSql && !useSqlite && !useInMemory || !model.SkipOnProviderProject;
            if (!shouldGenerate)
                return;

            try
            {
                StringBuilder code = new();
                code.AppendLine("using EficazFramework.Entities;");
                code.AppendLine("using EficazFramework.Extensions;");
                code.AppendLine("using System.ComponentModel.DataAnnotations;");
                code.AppendLine("");

                code.AppendLine($"namespace {model.Namespace};");
                code.AppendLine("");
                code.AppendLine($"public partial class {model.Name}{GenerateBaseClass(model)}{GenerateInterfaceImplementation(model)}");
                code.AppendLine("{");
                code.AppendLine("   ");

                foreach (var prop in model.Properties)
                {
                    WriteProperty(code, prop, model);

                    if (!object.ReferenceEquals(prop, model.Properties.LastOrDefault()))
                    {
                        code.AppendLine("   ");
                        code.AppendLine("   ");
                    }
                }

                code.AppendLine("   ");
                code.AppendLine("}");


                spc.AddSource($"{model.Name}.Entity.g.cs", SourceText.From(code.ToString(), Encoding.UTF8));
            }
            catch (Exception mainEx)
            {
                spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Model Builder Exception", mainEx.ToString(), "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
            }
        });
    }

    void WriteProperty(StringBuilder code, 
        Models.EfModel.ModelProperty prop, 
        Models.EfModel.ModelClass model)
    {
        if (model.ImplementsINotify)
            WriteFullProperty(code, prop, model);
        else
            WriteAutoProperty(code, prop, model);
    }

    void WriteFullProperty(StringBuilder code, 
        Models.EfModel.ModelProperty prop, 
        Models.EfModel.ModelClass model)
    {
        string propType = GeneratePropertyType(prop, model);
        string propDefaultValue = GeneratePropertyDefaultValue(prop, model);

        //BACKING FIELD
        if (!prop.IsReadOnly)
        {
            string backingfield = $"   private {propType} _{prop.Name?.ToLower()}{propDefaultValue}";
            if (!backingfield.Contains(";"))
                backingfield = $"{backingfield};";

            code.AppendLine(backingfield);
            code.AppendLine("   ");
        }

        // XML / JSON IGNORE:
        WritePropertyIgnores(code, prop);

        // DISPLAY / GROUP/ RESOURCE STRING NAME:
        WritePropertyDisplay(code, prop, model);

        // FULL PROPERTY BODY
        string modifier = GeneratePropertyModifier(prop);
        code.AppendLine($"   {modifier}{propType} {prop.Name}{(prop.IsReadOnly && !string.IsNullOrEmpty(propDefaultValue) ? $" => {propDefaultValue.Replace(" = ", "")}" : "")}");
        if (!prop.IsReadOnly)
        {
            code.AppendLine("   {");
            code.AppendLine($"      get => _{prop.Name?.ToLower()};");
            code.AppendLine("      set");
            code.AppendLine("      {");
            code.AppendLine($"          _{prop.Name?.ToLower()} = value;");

            if (model.ImplementsINotify)
                code.AppendLine($"          ReportPropertyChanged(nameof({prop.Name}));");

            code.AppendLine("      }");
            code.AppendLine("   }");
        }
    }

    void WriteAutoProperty(StringBuilder code, 
        Models.EfModel.ModelProperty prop, 
        Models.EfModel.ModelClass model)
    {
        // XML / JSON IGNORE:
        WritePropertyIgnores(code, prop);

        // DISPLAY / GROUP/ RESOURCE STRING NAME:
        WritePropertyDisplay(code, prop, model);

        // DECLARATION
        string modifier = GeneratePropertyModifier(prop);
        string propType = GeneratePropertyType(prop, model);
        string propDefaultValue = GeneratePropertyDefaultValue(prop, model);
        code.AppendLine($"   {modifier}{propType} {prop.Name} {{ get; {(!prop.IsReadOnly ? "set; " : "")}}}{propDefaultValue}");
    }

    private string GenerateBaseClass(Models.EfModel.ModelClass model) =>
        $"{(!string.IsNullOrEmpty(model.BaseClass) ? $" : {model.BaseClass}" : "")}";

    private string GenerateInterfaceImplementation(Models.EfModel.ModelClass model) =>
        $"{(!string.IsNullOrEmpty(model.Interface) ? $" : {(!string.IsNullOrEmpty(model.BaseClass) ? $", {model.Interface}" : $"{model.Interface}")}" : "")}";


    private void WritePropertyIgnores(StringBuilder code,
        Models.EfModel.ModelProperty prop)
    {
        if (prop.IgnoreOnSerialization || prop.IsReadOnly)
        {
            code.AppendLine("   [System.Text.Json.Serialization.JsonIgnore]");
            code.AppendLine("   [System.Xml.Serialization.XmlIgnore]");
        }
    }

    private void WritePropertyDisplay(StringBuilder code,
        Models.EfModel.ModelProperty prop,
        Models.EfModel.ModelClass model)
    {
        if (!string.IsNullOrEmpty(prop.DisplayName))
        {
            string category = !string.IsNullOrEmpty(prop.Category) ? $", GroupName={($"\"{prop.Category}\"")}" : "";
            code.AppendLine($"   [Display({(model.Localizable ? $"ResourceType={model.LocalizationResourceClass}, Name=\"{prop.DisplayName}\"{category}" : $"Name=\"{prop.DisplayName}\"{category}")})]");
        }
    }

    private string GeneratePropertyModifier(Models.EfModel.ModelProperty prop) =>
        $"public {(prop.Virtual ? "virtual " : (prop.Override ? "override " : ""))}";

    private string GeneratePropertyType(Models.EfModel.ModelProperty prop,
        Models.EfModel.ModelClass model) =>
            !prop.IsList ? prop.DataType : (model.CollectionType ?? "").Replace("<T>", $"<{prop.DataType}>");

    private string GeneratePropertyDefaultValue(Models.EfModel.ModelProperty prop,
        Models.EfModel.ModelClass model) =>
            prop.IsList ? $" = new {(model.CollectionInitializationType ?? "").Replace("<T>", $"<{prop.DataType}>")}();" : $"{(prop.IsReadOnly ? $" = {prop.ReadOnlyExpression};" : "")}";


    void ExecuteMappings(
        IncrementalGeneratorInitializationContext context,
        IncrementalValuesProvider<(string name, string content)> efModels)
    {
        IncrementalValuesProvider<string> referencies = context.MetadataReferencesProvider
            .Where(r => r.Display.Contains("EficazFramework.Data."))
            .Select((cmp, cancelationToken) => cmp.Display);


        bool useSqlServer = false;
        bool useMySql = false;
        bool usePostgreSql = false;
        bool useOracleSql = false;
        bool useSqlite = false;
        bool useInMemory = false;
        context.RegisterImplementationSourceOutput(referencies, (writer, reference) =>
        {
            //writer.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB999", "Reference", reference, "EficazFramework Model Builder", DiagnosticSeverity.Warning, true), Location.None));
            switch (reference)
            {
                case string e when e.Contains("EficazFramework.Data.MsSqlServer"):
                    useSqlServer = true; break;

                case string e when e.Contains("EficazFramework.Data.MySql"):
                    useMySql = true; break;

                case string e when e.Contains("EficazFramework.Data.PostgreSql"):
                    usePostgreSql = true; break;

                case string e when e.Contains("EficazFramework.Data.OracleSql"):
                    useOracleSql = true; break;

                case string e when e.Contains("EficazFramework.Data.SqlLite"):
                    useSqlite = true; break;

                case string e when e.Contains("EficazFramework.Data.InMemory"):
                    useInMemory = true; break;
            }
        });
        bool shouldGenerate = useSqlServer || useMySql || usePostgreSql || useOracleSql || useSqlite || useInMemory;

        // generate code
        context.RegisterSourceOutput(efModels, (spc, efModel) =>
        {
            //if (!shouldGenerate)
            //{
            //    spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB001", "No data providers available", $"Any EficazFramework.Data provider is referenced by the project. {DateTime.Now:HH:mm:ss.FFF}", "EficazFramework Model Builder", DiagnosticSeverity.Warning, true), Location.None));
            //    return;
            //}

            Models.EfModel.ModelClass model = null;
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new(typeof(Models.EfModel.ModelClass));
                var content = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(efModel.content));
                model = (Models.EfModel.ModelClass)reader.Deserialize(content);
                content.Close();
                content.Dispose();
            }
            catch
            {
                spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Invalid efmodel", "Can't read efmodel file.", "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
            }
            if (model is null)
            {
                spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Invalid efmodel", "Can't read efmodel file.", "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
            }

            try
            {
                StringBuilder code = new();
                code.AppendLine("using EficazFramework.Entities;");
                code.AppendLine("using EficazFramework.Extensions;");
                code.AppendLine("using Microsoft.EntityFrameworkCore;");
                code.AppendLine("using Microsoft.EntityFrameworkCore.Metadata.Builders;");
                //if (useMySql)
                //    code.AppendLine("using MySql.EntityFrameworkCore.Extensions;");

                code.AppendLine($"namespace {model.Namespace}");
                code.AppendLine("{");
                code.AppendLine($"    public static class {model.Name}Builder");
                code.AppendLine("    {");
                code.AppendLine("        ");

                if (useInMemory)
                {
                    spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB002", "Reference", $"Mapping for InMemory at {DateTime.Now:HH:mm:ss.FFF}", "EficazFramework Model Builder", DiagnosticSeverity.Warning, true), Location.None));
                    GenerateForInMemory(code, model);
                }

                if (useSqlServer)
                {
                    spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB002", "Reference", $"Mapping for MsSqlServer at {DateTime.Now:HH:mm:ss.FFF}", "EficazFramework Model Builder", DiagnosticSeverity.Warning, true), Location.None));
                    GenerateForMsSqlServer(code, model);
                }

                if (useMySql)
                {
                    spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB002", "Reference", $"Mapping for MySql/MariaDb at {DateTime.Now:HH:mm:ss.FFF}", "EficazFramework Model Builder", DiagnosticSeverity.Warning, true), Location.None));
                    GenerateForMySqlOrMariaDb(code, model);
                }

                code.AppendLine("    }");
                code.AppendLine("}");


                spc.AddSource($"{model.Name}.Map.g.cs", code.ToString());
            }
            catch (Exception mainEx)
            {
                spc.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("EfMB003", "Model Builder Exception", mainEx.ToString(), "EficazFramework Model Builder", DiagnosticSeverity.Error, true), Location.None));
            }
        });
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
        code.AppendLine($"        public static EntityTypeBuilder<{model.Name}> MapForMySql(EntityTypeBuilder<{model.Name}> builder, string overrideTableSchema)");
        code.AppendLine("        {");

        code.AppendLine("            // Table Mapping");
        code.AppendLine($"            builder.ToTable(\"{model.TableName}\");");

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
                builder.Append($".UseMySqlIdentityColumn()");

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

    public static String NewLine
    {
        get
        {
#if !PLATFORM_UNIX
            return "\r\n";
#else
        return "\n";
#endif // !PLATFORM_UNIX
        }
    }
}
