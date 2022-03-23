using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Configuration;

public class ServiceConfiguration
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
        PaletteDark = new MudBlazor.Palette()
        {
            Primary = "#0078d7",
            Secondary = "#003864",
            AppbarBackground = "#0078d7",
            AppbarText = "#fff",
        }
    };

    public bool UseApplicationManager { get; set; } = false;

    public MudBlazor.Services.MudServicesConfiguration MudBlazorConfigurations { get; set; }
}
