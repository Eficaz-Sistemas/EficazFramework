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

    }

    void OnFab1Click()
    {
        ApplicationManager.Activate(appHello);
    }

    void OnFab2Click()
    {
        ApplicationManager.Activate(appAnother);
    }

    private EficazFramework.Application.ApplicationDefinition? appHello;
    private EficazFramework.Application.ApplicationDefinition? appAnother;

    private EficazFramework.Components.MdiHost? _mdi;

}
