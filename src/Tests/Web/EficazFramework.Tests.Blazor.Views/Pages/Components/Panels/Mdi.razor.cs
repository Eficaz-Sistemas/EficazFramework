using Microsoft.AspNetCore.Components;

namespace EficazFramework.Tests.Blazor.Views.Pages.Components.Panels;

public partial class Mdi
{
    [Inject] public EficazFramework.Application.IApplicationManager ApplicationManager { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        
        appHello = new()
        {
            LongTitle = $"My App 1",
            IsPublic = true,
            Title = $"My App 1",
        };
        appHello.Targets.Add("Blazor", new()
        {
            Icon = EficazFramework.Icons.Brands.Eficaz,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiAppHelloWorld) 
        });

        appAnother = new()
        {
            LongTitle = $"My App 2",
            IsPublic = true,
            Title = $"My App 2",
        };
        appAnother.Targets.Add("Blazor", new()
        {
            Icon = EficazFramework.Icons.Brands.EficazLegacy,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiAnotherApp)
        });

        appPerSection = new()
        {
            LongTitle = $"My Scoped App",
            IsPublic = false,
            Title = $"My Scoped App",
        };
        appPerSection.Targets.Add("Blazor", new()
        {
            Icon = MudBlazor.Icons.Custom.Brands.GitHub,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiPerSectionApp)
        });

    }

    void OnFab1Click()
    {
        _mdi!.LoadApplication(appHello!);
    }

    void OnFab2Click()
    {
        _mdi!.LoadApplication(appAnother!);
    }

    void OnFab3Click()
    {
        _mdi!.LoadApplication(appPerSection!);
    }

    private EficazFramework.Application.ApplicationDefinition? appHello;
    private EficazFramework.Application.ApplicationDefinition? appAnother;
    private EficazFramework.Application.ApplicationDefinition? appPerSection;

    private EficazFramework.Components.MdiHost? _mdi;

}
