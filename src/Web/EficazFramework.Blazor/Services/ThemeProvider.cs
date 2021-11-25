using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Services;

public class ThemeProvider
{
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
