namespace EficazFramework.Generators.Svg;

[Generator]
public class ModelBuilder : ISourceGenerator
{
    void ISourceGenerator.Initialize(GeneratorInitializationContext context) { }

    void ISourceGenerator.Execute(GeneratorExecutionContext context)
    {
        StringBuilder code = new();
        code.AppendLine($"// Auto Generated @ {DateTime.Now}");
        code.AppendLine("namespace EficazFramework.Icons");
        code.AppendLine("{");

        // find anything that matches our files
        var files = context.AdditionalFiles.Select(s => s.Path).ToList();
        var myFiles = context.AdditionalFiles.Where(at => at.Path.EndsWith(".svg"));
        Console.WriteLine($"Found {myFiles.Count()} svg file(s)");
        foreach (var file in myFiles)
        {
            string className = file.Path.Substring(file.Path.LastIndexOf("\\") + 1).Replace(".svg", "").Replace("/", "").Replace("\\", "");
            Console.WriteLine($"Generating {className} class");
            code.AppendLine($"    public static class {className}");
            code.AppendLine("    {");
            code.AppendLine("        [EficazFramework.Generators.XAML.IconPackMember]");
            code.AppendLine("        public static Dictionary<string, string> Icons => new Dictionary<string, string>");
            code.AppendLine("        {");

            var content = file.GetText(context.CancellationToken);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content.ToString());
            XmlNodeList items = doc.DocumentElement.GetElementsByTagName("glyph");
            Console.WriteLine($"Found {items.Count} glyph(s) for class {className}");
            int row = 0;
            for (row = 0; row < items.Count; row++)
            {
                try
                {
                    bool last = row == items.Count - 1;
                    XmlNode item = items[row];
                    string title = (item.Attributes["glyph-name"].Value ?? "").Replace("_", " ").Replace("ic ", "").ToTitleCase().Replace(" ", "");
                    string data = (item.Attributes["d"].Value ?? "").Replace("\r", "").Replace("\n", ""); ;
                    code.Append($"            {{ \"{title ?? ""}\", \"{data ?? ""}");
                    code.Append("\"");
                    code.Append("}");
                    if (!last)
                        code.AppendLine(",");
                }
                catch { }
            }
            code.AppendLine("        };"); // member
            code.AppendLine("    }"); // class
            code.AppendLine("}"); // namespace
            context.AddSource($"{className}.Generated.cs", code.ToString());
        }
    }
}