using Microsoft.AspNetCore.Components;

namespace Blazor.Client.Pages;

public partial class Home
{
    [Inject] EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }


    private EficazFramework.Components.MdiHost? _mdiHost;
    private EficazFramework.Components.StartMenu? _startMenu;

    private IEnumerable<EficazFramework.Application.ApplicationDefinition> _mainApps = [];
    private IEnumerable<EficazFramework.Application.ApplicationDefinition> _uiApps = [];

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _mainApps = Apps.Mapping.MapApplications();

            if (!(_startMenu?.IsOpen ?? true))
                _startMenu?.ToggleOpen();
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    private void AppClick(EficazFramework.Application.ApplicationDefinition app)
    {
        _startMenu!.ToggleOpen(true);
        _mdiHost!.LoadApplication(app);
    }

}