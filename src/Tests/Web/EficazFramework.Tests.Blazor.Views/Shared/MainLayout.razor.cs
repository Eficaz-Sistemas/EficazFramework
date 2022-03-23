namespace EficazFramework.Tests.Blazor.Views.Shared;

public partial class MainLayout
{
    bool drawerOpen = true;
    void DocsDrawerToggle()
    {
        drawerOpen = !drawerOpen;
    }
}
