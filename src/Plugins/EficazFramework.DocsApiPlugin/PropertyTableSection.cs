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

namespace EficazFramework.DocsApiPlugin
{
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

            var props = GetProperties(writer.Context, writer.DocItem) ?? Array.Empty<DocItem>();
            if (props.Count() > 0)
            {
                writer.AppendLine("### Properties");
                foreach (DocItem item in props)
                {
                    if (!titleWritten)
                    {
                        writer
                            .AppendLine()
                            .AppendLine($"| # | Name | |")
                            .AppendLine("| ---: | :--- | :--- |");

                        titleWritten = true;
                    }

                    counter++;
                    var innerXml = item.Documentation?.Element("summary")?.Nodes()?.Select(n => n.ToString()).ToList();
                    string summary = string.Concat(innerXml! ?? new List<string>()) ?? "";
                    writer.AppendLine($"| {counter:#00} | {item.Name} | {(summary ?? "").Replace(Environment.NewLine, "").Trim()} |");
                }
            }

            titleWritten = false;
            var methods = GetMethods(writer.Context, writer.DocItem) ?? Array.Empty<DocItem>();
            if (methods.Count() > 0)
            {
                writer.AppendLine("### Methods");
                foreach (DocItem item in GetMethods(writer.Context, writer.DocItem) ?? Array.Empty<DocItem>())
                {
                    if (!titleWritten)
                    {
                        writer
                            .AppendLine()
                            .AppendLine($"| Name | |")
                            .AppendLine("| :--- | :--- |");

                        titleWritten = true;
                    }

                    var innerXml = item.Documentation?.Element("summary")?.Nodes()?.Select(n => n.ToString()).ToList();
                    string summary = string.Concat(innerXml! ?? new List<string>()) ?? "";
                    writer.AppendLine($"| {item.Name} | {(summary ?? "").Replace(Environment.NewLine, "").Trim()} |");
                }
            }
        }
    }
}