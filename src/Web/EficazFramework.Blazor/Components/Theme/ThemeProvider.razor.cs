using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Components;

public partial class ThemeProvider
{
    public string Palette_Papper = "#FAFAFA";

    public string BuildTheme()
    {
        var theme = new StringBuilder();
        theme.AppendLine("<style>");
        theme.Append(":root");
        theme.AppendLine("{");
        GenerateTheme(theme);
        theme.AppendLine("}");
        theme.AppendLine("</style>");
        return theme.ToString();
    }

    protected virtual void GenerateTheme(StringBuilder theme)
    {
        //Paper
        theme.AppendLine($"--mud-palette-paper: {Palette_Papper};");
    }
}
