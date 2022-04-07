namespace EficazFramework.XAML.Resources.Generator;

[Generator]
public class XamlIconsGenerator : ISourceGenerator
{
    void ISourceGenerator.Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new ServicesReceiver());
    }

    void ISourceGenerator.Execute(GeneratorExecutionContext context)
    {
        Console.WriteLine($"Executed at {DateTime.Now}");

        StringBuilder code = new();
        code.AppendLine($"<!--Auto Generated @ {DateTime.Now}-->");
        code.AppendLine("<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
        code.AppendLine("                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">");
        
        foreach (var classToRead in ((ServicesReceiver)context.SyntaxContextReceiver).ClassesToRegister)
        {
            code.AppendLine("");
            code.AppendLine($"    <Geometry x:Key=\"Icon.{classToRead.ToString()}.{"iconName"}\" />");
            code.AppendLine($"        {"iconName"}");
            code.AppendLine($"    </Geometry>");
            code.AppendLine("");
        }

        code.AppendLine("</ResourceDictionary>");

        context.AddSource("MaterialIcons.xaml", SourceText.From(code.ToString(), Encoding.UTF8));
    }

}
