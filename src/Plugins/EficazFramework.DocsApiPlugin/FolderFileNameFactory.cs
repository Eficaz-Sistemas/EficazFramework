using DefaultDocumentation;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;

namespace EficazFramework.DocsApiPlugin;

[ExcludeFromCodeCoverage]
public sealed class FolderFileNameFactory : IFileNameFactory
{
    public string Name => "Folder";

    public void Clean(IGeneralContext context)
    {
        // Substitui o método Debug por Log com LogLevel apropriado
        context.Settings.Logger.Log(
            LogLevel.Debug,
            new EventId(0, "CleanOutputFolder"),
            $"Cleaning output folder \"{context.Settings.OutputDirectory}\"",
            null,
            (state, ex) => state.ToString()
        );

        if (context.Settings.OutputDirectory.Exists)
        {
            IEnumerable<FileInfo> files = context.Settings.OutputDirectory.EnumerateFiles("*.md", SearchOption.AllDirectories).Where(f => !string.Equals(f.Name, "readme.md", StringComparison.OrdinalIgnoreCase));

            int i;

            foreach (FileInfo file in files)
            {
                i = 3;
            start:
                try
                {
                    file.Delete();
                }
                catch
                {
                    if (--i > 0)
                    {
                        Thread.Sleep(100);
                        goto start;
                    }

                    throw;
                }
            }

            i = 3;
            while (files.Any() && i-- > 0)
            {
                Thread.Sleep(1000);
            }
        }
    }

    public string GetFileName(IGeneralContext context, DocItem item)
    {
        return PathCleaner.Clean(item is AssemblyDocItem ? item.FullName : string.Join("/", item.GetParents().Skip(1).Select(p => p.Name).Concat(Enumerable.Repeat(item.Name, 1))), PathCleaner.GetInvalidCharReplacement(context)) + ".md";
    }
}

