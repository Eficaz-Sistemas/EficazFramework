
namespace Blazor.Client.Pages;

public partial class Home
{
    private EficazFramework.Components.MdiHost? _mdiHost;
    private EficazFramework.Components.StartMenu? _startMenu;

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            if (!(_startMenu?.IsOpen ?? true))
                _startMenu?.ToggleOpen();

        return base.OnAfterRenderAsync(firstRender);
    }
}