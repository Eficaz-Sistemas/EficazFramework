using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace EficazFramework.Layouts;

public partial class MudAppBarDrawerLayout
{

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Auth = await AuthState.GetAuthenticationStateAsync();
            if (Auth?.User?.Identity == null) return;
            UserLine1 = Auth?.User?.Identity?.Name;
            UserLine2 = Auth?.User?.Identity?.Name;
        }
    }

    public bool DrawerOpen { get; private set; }
    void DrawerToggle()
    {
        DrawerOpen = !DrawerOpen;
    }

    [Parameter] public string Title { get; set; }
    [Parameter] public string? UserLine1 { get; set; } = "UserName";
    [Parameter] public string? UserLine2 { get; set; } = "Secondary Text";

    //IDENTIDADE
    private long _clientId = 0;
    [Inject] AuthenticationStateProvider AuthState { get; set; }
    protected AuthenticationState Auth;


    [Parameter] public RenderFragment CustomAppBarContent { get; set; }
    public void SetAppBarCustomContent(string title, RenderFragment component)
    {
        Title = title;
        CustomAppBarContent = component;
    }

    public void UpdateState()
    {
        StateHasChanged();
    }
}
