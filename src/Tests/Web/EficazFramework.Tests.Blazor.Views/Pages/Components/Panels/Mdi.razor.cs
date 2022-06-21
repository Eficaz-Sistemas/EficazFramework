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
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiAppHelloWorld)
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
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiAnotherApp)
        });


        if (!ApplicationManager.AllApplications.Contains(appHello))
            ApplicationManager.AllApplications.Add(appHello);

        if (!ApplicationManager.AllApplications.Contains(appAnother))
        ApplicationManager.AllApplications.Add(appAnother);

        if (!ApplicationManager.AllApplications.Contains(appPerSection))
        ApplicationManager.AllApplications.Add(appPerSection);

        if (!ApplicationManager.AllApplications.Contains(appHello2))
            ApplicationManager.AllApplications.Add(appHello2);

        if (!ApplicationManager.AllApplications.Contains(appAnother2))
            ApplicationManager.AllApplications.Add(appAnother2);

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
    private EficazFramework.Application.ApplicationDefinition? appHello2;
    private EficazFramework.Application.ApplicationDefinition? appAnother;
    private EficazFramework.Application.ApplicationDefinition? appAnother2;
    private EficazFramework.Application.ApplicationDefinition? appPerSection;

    private EficazFramework.Components.MdiHost? _mdi;

}
