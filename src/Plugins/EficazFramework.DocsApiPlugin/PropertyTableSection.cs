using DefaultDocumentation;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;

namespace EficazFramework.DocsApiPlugin;

[ExcludeFromCodeCoverage]
public sealed class PropertyTableSection : ISection
{

    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public string Name => "PropertiesTable";


    /// <summary>
    /// Gets the children of a <see cref="DocItem"/> to write.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to write its children.</param>
    /// <returns>The children to write.</returns>
    internal IEnumerable<DocItem> GetProperties(IGeneralContext context, DocItem item) => context.Items.Values.Where(i => i is PropertyDocItem && i.Parent == item).ToList();

    /// <summary>
    /// Gets the children of a <see cref="DocItem"/> to write.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to write its children.</param>
    /// <returns>The children to write.</returns>
    internal IEnumerable<DocItem> GetMethods(IGeneralContext context, DocItem item) => context.Items.Values.Where(i => i is MethodDocItem && i.Parent == item).ToList();
    

    public void Write(IWriter writer)
    {
        bool titleWritten = false;
        int counter = 1;
        writer.TrimEnd();
        writer.AppendLine("");

        var props = GetProperties(writer.Context, writer.Context.DocItem) ?? Array.Empty<DocItem>();
        if (props.Count() > 0)
        {
            writer.AppendLine("### Properties");
            foreach (DocItem item in props)
            {
                var prop = item as PropertyDocItem;
                string nulltype = string.Format("<{0}>", string.Join(",", prop.Property!.ReturnType!.TypeArguments!.Select(r => r.Name).ToList())) ?? "";
                nulltype = nulltype == "<>" ? "" : nulltype;

                bool showNumberColumn = (item.Documentation?.Element("registrosped") != null);

                if (!titleWritten)
                {
                    if (showNumberColumn)
                    {
                        writer
                            .AppendLine()
                            .AppendLine($"| # | Name | Type | |")
                            .AppendLine("| ---: | :--- | :---: | :--- |");
                    }
                    else
                    {
                        writer
                            .AppendLine()
                            .AppendLine($"| Name | Type | |")
                            .AppendLine("| :--- | :---: | :--- |");
                    }

                    titleWritten = true;
                }

                counter++;
                var innerXml = item.Documentation?.Element("summary")?.Nodes()?.Select(n => n.ToString()).ToList();
                string summary = string.Concat(innerXml! ?? new List<string>()) ?? "";
                
                if (showNumberColumn)
                    writer.AppendLine($"| {counter:#00} | {item.Name} | `{prop.Property?.ReturnType?.Name ?? ""}{nulltype}` | {(summary ?? "").Replace(Environment.NewLine, "").Trim()} |");
                else
                    writer.AppendLine($"| {item.Name} | `{prop.Property?.ReturnType?.Name ?? ""}{nulltype}` | {(summary ?? "").Replace(Environment.NewLine, "").Trim()} |");

            }
        }

        //titleWritten = false;
        //var methods = GetMethods(writer.Context, writer.DocItem) ?? Array.Empty<DocItem>();
        //if (methods.Count() > 0)
        //{
        //    writer.AppendLine("### Methods");
        //    foreach (DocItem item in GetMethods(writer.Context, writer.DocItem) ?? Array.Empty<DocItem>())
        //    {
        //        var method = item as MethodDocItem;
        //        string nulltype = string.Format("<{0}>", string.Join(",", method.Method!.ReturnType!.TypeArguments!.Select(r => r.Name).ToList())) ?? "";
        //        nulltype = nulltype == "<>" ? "" : nulltype;
                
        //        if (!titleWritten)
        //        {
        //            writer
        //                .AppendLine()
        //                .AppendLine($"| Name | Return Type | |")
        //                .AppendLine("| :--- | :---: | :--- |");

        //            titleWritten = true;
        //        }

        //        var innerXml = item.Documentation?.Element("summary")?.Nodes()?.Select(n => n.ToString()).ToList();
        //        string summary = string.Concat(innerXml! ?? new List<string>()) ?? "";
        //        writer.AppendLine($"| {item.Name} | `{method.Method?.ReturnType?.Name ?? ""}{nulltype}` | {(summary ?? "").Replace(Environment.NewLine, "").Trim()} |");
        //    }
        //}
    }
}