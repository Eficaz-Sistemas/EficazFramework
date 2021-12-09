﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using DefaultDocumentation;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace EficazFramework.DocsApiPlugin;

[ExcludeFromCodeCoverage]
public sealed class FolderFileNameFactory : IFileNameFactory
{
    public string Name => "Folder";

    public void Clean(IGeneralContext context)
    {
        context.Settings.Logger.Debug($"Cleaning output folder \"{context.Settings.OutputDirectory}\"");

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
        return (item is AssemblyDocItem ? item.FullName : string.Join("/", item.GetParents().Skip(1).Select(p => p.Name).Concat(Enumerable.Repeat(item.Name, 1)))) + ".md";
    }
}