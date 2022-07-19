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
    public sealed class PropertyTableSection<PropertyDocItem> : ISection
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

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (DocItem item in GetProperties(writer.Context, writer.DocItem) ?? Array.Empty<DocItem>())
            {
                if (!titleWritten)
                {
                    writer
                        .AppendLine()
                        .AppendLine($"| {"### Properties".Trim('#', ' ')} | |")
                        .AppendLine("| :--- | :--- |");

                    titleWritten = true;
                }

                writer.AppendLine($"| {item.Name} | {item.Documentation.Element("summary").Value} |");
            }
        }
    }
}