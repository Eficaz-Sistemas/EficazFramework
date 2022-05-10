﻿namespace EficazFramework.Generators.XAML;

[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
internal class IconSourceAttribute : System.Attribute
{
}


[Generator]
public class XamlIconsGenerator : ISourceGenerator
{
    void ISourceGenerator.Initialize(GeneratorInitializationContext context)
    {
        const string attribute = @"// <auto-generated />
namespace EficazFramework.Generators.XAML
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class IconSourceAttribute : System.Attribute
    {
    }

    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal class IconPackMemberAttribute : System.Attribute
    {
    }
}";

        context.RegisterForPostInitialization(context => context.AddSource("IconPackSource.Generated.cs", SourceText.From(attribute, Encoding.UTF8)));
        context.RegisterForSyntaxNotifications(() => new XamlIconServicesReceiver());
    }

    void ISourceGenerator.Execute(GeneratorExecutionContext context)
    {
        Console.WriteLine($"Execution started at {DateTime.Now}");

        if (((XamlIconServicesReceiver)context.SyntaxContextReceiver).ClassesToRegister.Count() <= 0)
        {
            Console.WriteLine("Any registered classes");
            return;
        }


        foreach (var reg in ((XamlIconServicesReceiver)context.SyntaxContextReceiver).ClassesToRegister)
        {
            string className = reg.Key.Identifier.Text.Trim();
            Console.WriteLine("==============================");
            Console.WriteLine($"Generating resource for {className}");

            StringBuilder code = new();
            code.AppendLine($"<!--Auto Generated @ {DateTime.Now}-->");
            code.AppendLine("<ResourceDictionary xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"");
            code.AppendLine("                    xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">");

            var valueStr = ((ObjectCreationExpressionSyntax)reg.Value.ExpressionBody.Expression).Initializer.ToString();
            valueStr = valueStr.Replace("{", "").Replace(", \"", ",\"").Replace("\",", "\",").Replace("}", "").Replace("\",\"", "\":"); //.Replace(", ", ",");
            //Console.WriteLine(valueStr);

            var items = valueStr.Split(new[] { "\"," }, StringSplitOptions.None);
            foreach (var item in items)
            {
                try
                {
                    var pair = item.Split(':');
                    var key = pair[0].Replace(Environment.NewLine, "").Replace("\"", "").Trim();
                    var value = pair[1].Replace(Environment.NewLine, "").Replace("\"", "").Trim();
                    code.AppendLine("");
                    code.AppendLine($"    <Geometry x:Key=\"Icon.{className}.{key}\" >");
                    code.AppendLine($"        {value}");
                    code.AppendLine($"    </Geometry>");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Failed at {item}");
                }
            }

            code.AppendLine("");
            code.AppendLine("</ResourceDictionary>");
            context.AddSource($"{className}.Generated.xaml", SourceText.From(code.ToString(), Encoding.UTF8));

            Console.WriteLine(code.ToString());
            Console.WriteLine($"Resource for {className} generated successful");
            Console.WriteLine("==============================");
        }
    }

}
