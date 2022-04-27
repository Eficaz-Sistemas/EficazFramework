using Microsoft.AspNetCore.Components;

namespace EficazFramework.Tests.Blazor.Views.Resources.Mocks;

public class NavigationManager : Microsoft.AspNetCore.Components.NavigationManager
{
    public NavigationManager() : base() =>
        this.Initialize("http://localhost:2112/", "http://localhost:2112/test");

    protected override void NavigateToCore(string uri, bool forceLoad) =>
        this.WasNavigateInvoked = true;

    public bool WasNavigateInvoked { get; private set; }

}
