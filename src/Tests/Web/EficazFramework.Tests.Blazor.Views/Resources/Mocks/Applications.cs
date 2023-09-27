using EficazFramework.Application;

namespace EficazFramework.Tests.Blazor.Views.Resources.Mocks;

public static class Applications
{
    private static EficazFramework.Application.ApplicationDefinition? appHello;
    private static EficazFramework.Application.ApplicationDefinition? appHello2;
    private static EficazFramework.Application.ApplicationDefinition? appAnother;
    private static EficazFramework.Application.ApplicationDefinition? appAnother2;
    private static EficazFramework.Application.ApplicationDefinition? appPerSection;
    private static EficazFramework.Application.ApplicationDefinition? appPerSection2;
    private static EficazFramework.Application.ApplicationDefinition? appEmptyIcon;
    private static EficazFramework.Application.ApplicationDefinition? appDataGrid;
    private static EficazFramework.Application.ApplicationDefinition? appDataGrid2;

    public static void GenerateApps(EficazFramework.Application.IApplicationManager? applicationManager)
    {
        if (applicationManager!.AllApplications.Count != 0)
            return;

        appHello = new()
        {
            LongTitle = $"My App 1",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"My App 1",
        };
        appHello.Targets.Add("Blazor", new BlazorApplicationTarget()
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
        appAnother.Targets.Add("Blazor", new BlazorApplicationTarget()
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
        appPerSection.Targets.Add("Blazor", new BlazorApplicationTarget()
        {
            Icon = MudBlazor.Icons.Custom.Brands.GitHub,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiScopedApp)
        });

        appHello2 = new()
        {
            LongTitle = $"Full Screen App",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"Full Screen",
        };
        appHello2.Targets.Add("Blazor", new BlazorApplicationTarget()
        {
            Icon = MudBlazor.Icons.Custom.Brands.Microsoft,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiIconApp),
            IsMaximized = true,
        });

        appAnother2 = new()
        {
            LongTitle = $"My New App 2",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"My New App 2",
        };
        appAnother2.Targets.Add("Blazor", new BlazorApplicationTarget()
        {
            Icon = MudBlazor.Icons.Custom.Brands.Google,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.AnotherCoolApp),
            InitialSize = new(200, 225),
            Resizable = false
        });

        appPerSection2 = new()
        {
            LongTitle = $"New Scoped App",
            IsPublic = false,
            Group = "Paid Apps",
            Title = $"New Scoped App",
        };
        appPerSection2.Targets.Add("Blazor", new BlazorApplicationTarget()
        {
            Icon = MudBlazor.Icons.Custom.Brands.Linux,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiScopedApp)
        });

        appEmptyIcon = new()
        {
            LongTitle = $"Default Icon",
            IsPublic = true,
            Group = "Paid Apps",
            Title = $"Default Icon",
        };
        appEmptyIcon.Targets.Add("Blazor", new BlazorApplicationTarget()
        {
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiScopedApp)
        });

        appDataGrid = new()
        {
            LongTitle = $"DataGrid App",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"DataGrid App",
        };
        appDataGrid.Targets.Add("Blazor", new BlazorApplicationTarget()
        {
            Icon = MudBlazor.Icons.Material.Filled.DataArray,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiDataGridApp)
        });

        appDataGrid2 = new()
        {
            LongTitle = $"DataGrid App FS",
            IsPublic = true,
            Group = "Free Apps",
            Title = $"DataGrid App (Full Scrren)",
        };
        appDataGrid2.Targets.Add("Blazor", new BlazorApplicationTarget()
        {
            Icon = MudBlazor.Icons.Material.Filled.DataArray,
            StartupUriOrType = typeof(EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps.MdiDataGridApp),
            IsMaximized = true
        });


        applicationManager.AllApplications.Add(appHello);
        applicationManager.AllApplications.Add(appAnother);
        applicationManager.AllApplications.Add(appPerSection);
        applicationManager.AllApplications.Add(appPerSection2);
        applicationManager.AllApplications.Add(appHello2);
        applicationManager.AllApplications.Add(appAnother2);
        applicationManager.AllApplications.Add(appEmptyIcon);
        applicationManager.AllApplications.Add(appDataGrid);
        applicationManager.AllApplications.Add(appDataGrid2);
    }
}
