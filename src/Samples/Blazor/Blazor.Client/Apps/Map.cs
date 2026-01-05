namespace Blazor.Client.Apps;

internal static class Mapping
{
    internal static IEnumerable<EficazFramework.Application.IApplicationDefinition> MapApplications()
    {
        var vendors = new EficazFramework.Application.ApplicationDefinition
        {
            Group = "CRUD",
            IsPublic = true,
            Title = "Vendors",
        };
        vendors.Targets.Add("Blazor", new EficazFramework.Application.BlazorApplicationTarget
        {
            Icon = MudBlazor.Icons.Material.Filled.PersonPinCircle,
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

        var customers = new EficazFramework.Application.ApplicationDefinition
        {
            Group = "CRUD",
            IsPublic = true,
            Title = "Customers",
        };
        customers.Targets.Add("Blazor", new EficazFramework.Application.BlazorApplicationTarget
        {
            Icon = MudBlazor.Icons.Material.Filled.People,
            StartupUriOrType = typeof(Pages.Customer),
            InitialSize = new(560, 450)
        });

        var tags = new EficazFramework.Application.ApplicationDefinition
        {
            Group = "CRUD",
            IsPublic = true,
            Title = "Tags",
        };
        tags.Targets.Add("Blazor", new EficazFramework.Application.BlazorApplicationTarget
        {
            Icon = MudBlazor.Icons.Material.Filled.Tag,
            StartupUriOrType = typeof(Pages.Tag),
            InitialSize = new(560, 350)
        });

        var tenant = new EficazFramework.Application.ApplicationDefinition
        {
            Group = "Tenant",
            IsPublic = false,
            Title = "Per Section App",
        };
        tenant.Targets.Add("Blazor", new EficazFramework.Application.BlazorApplicationTarget
        {
            Icon = MudBlazor.Icons.Material.Filled.Apps,
            StartupUriOrType = typeof(Pages.Tenant),
            InitialSize = new(560, 350)
        });

        var groupingTest = new EficazFramework.Application.GroupApplicationDefinition
        {
            Group = "Grouping Test",
            Title = "People",
        };
        groupingTest.Applications.AddRange([
                vendors,
                customers
        ]);
        groupingTest.Targets.Add("Blazor", new EficazFramework.Application.BlazorApplicationTarget
        {
            Icon = MudBlazor.Icons.Material.Filled.People,
        });

        return
        [
            vendors,
            products,
            customers,
            tags,
            tenant,
            groupingTest
        ];
    }
}
