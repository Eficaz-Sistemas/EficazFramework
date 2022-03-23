using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Services;

public interface IThemeProvider
{
    public MudBlazor.MudTheme Theme { get; set; }
}

internal class ThemeProvider : IThemeProvider
{
    internal ThemeProvider(MudBlazor.MudTheme? theme)
    {
#pragma warning disable CS8601 // Possível atribuição de referência nula.
        if(theme != null)
            Theme = theme;
#pragma warning restore CS8601 // Possível atribuição de referência nula.
    }

    public MudBlazor.MudTheme Theme { get; set; } = new MudBlazor.MudTheme()
    {
        Palette = new MudBlazor.Palette()
        {

            Primary = "#0078d7",
            Secondary = "#003864",
            AppbarBackground = "#0078d7",
            AppbarText = "#fff",
        },
    };
}
