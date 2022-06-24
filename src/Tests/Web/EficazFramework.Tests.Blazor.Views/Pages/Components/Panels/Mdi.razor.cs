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
            Group = "Free Apps",
            Title = $"My App 1",
        };
        appHello.Targets.Add("Blazor", new()
        {
            Icon = MudBlazor.Icons.Custom.Brands.WhatsApp,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiAppHelloWorld) 
        });

        appAnother = new()
        {
            LongTitle = $"My App 2",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"My App 2",
        };
        appAnother.Targets.Add("Blazor", new()
        {
            Icon = MudBlazor.Icons.Custom.Brands.Facebook,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiAnotherApp)
        });

        appPerSection = new()
        {
            LongTitle = $"My Scoped App",
            IsPublic = false,
            Group = "Paid Apps",
            Title = $"My Scoped App",
        };
        appPerSection.Targets.Add("Blazor", new()
        {
            Icon = MudBlazor.Icons.Custom.Brands.GitHub,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiPerSectionApp)
        });

        appHello2 = new()
        {
            LongTitle = $"My New App 1",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"My New App 1",
        };
        appHello2.Targets.Add("Blazor", new()
        {
            Icon = MudBlazor.Icons.Custom.Brands.Microsoft,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiIconApp)
        });

        appAnother2 = new()
        {
            LongTitle = $"My New App 2",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"My New App 2",
        };
        appAnother2.Targets.Add("Blazor", new()
        {
            Icon = MudBlazor.Icons.Custom.Brands.Google,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.AnotherCoolApp)
        });


        ApplicationManager.AllApplications.Add(appHello);
        ApplicationManager.AllApplications.Add(appAnother);
        ApplicationManager.AllApplications.Add(appPerSection);
        ApplicationManager.AllApplications.Add(appHello2);
        ApplicationManager.AllApplications.Add(appAnother2);
        ApplicationManager.AllApplications.Add(appHello);
        ApplicationManager.AllApplications.Add(appAnother);
        ApplicationManager.AllApplications.Add(appPerSection);
        ApplicationManager.AllApplications.Add(appHello2);
        ApplicationManager.AllApplications.Add(appAnother2);

    }

    private EficazFramework.Application.ApplicationDefinition? appHello;
    private EficazFramework.Application.ApplicationDefinition? appHello2;
    private EficazFramework.Application.ApplicationDefinition? appAnother;
    private EficazFramework.Application.ApplicationDefinition? appAnother2;
    private EficazFramework.Application.ApplicationDefinition? appPerSection;

    private EficazFramework.Components.MdiHost? _mdi;

}
