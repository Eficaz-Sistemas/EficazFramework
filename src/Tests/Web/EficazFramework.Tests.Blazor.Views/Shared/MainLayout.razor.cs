using Microsoft.AspNetCore.Components;

namespace EficazFramework.Tests.Blazor.Views.Shared;

public partial class MainLayout
{
    bool drawerOpen = false;
    void DocsDrawerToggle()
    {
        drawerOpen = !drawerOpen;
    }

    [Inject] NavigationManager? NavigationManager { get; set; }
    bool IsSubGroupExpanded(string groupRoute)
    {
        return NavigationManager?.Uri.Contains(groupRoute) ?? false;
    }
}
