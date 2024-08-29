namespace Blazor.Client.Apps;

internal static class Mapping
{
    internal static IEnumerable<EficazFramework.Application.ApplicationDefinition> MapApplications()
    {
        var vendors = new EficazFramework.Application.ApplicationDefinition
        {
            Group = "CRUD",
            IsPublic = true,
            Title = "Vendors",
        };
        vendors.Targets.Add("Blazor", new EficazFramework.Application.BlazorApplicationTarget
        {
            Icon = MudBlazor.Icons.Material.Filled.People,
            StartupUriOrType = typeof(Pages.Vendor),
            InitialSize = new(560, 350)
        });

        var products = new EficazFramework.Application.ApplicationDefinition
        {
            Group = "CRUD",
            IsPublic = true,
            Title = "Products",
        };
        products.Targets.Add("Blazor", new EficazFramework.Application.BlazorApplicationTarget
        {
            Icon = MudBlazor.Icons.Material.Filled.Fastfood,
            StartupUriOrType = typeof(Pages.Product),
            InitialSize = new(620, 420)
        });


        return
        [
            vendors,
            products,
        ];
    }
}
