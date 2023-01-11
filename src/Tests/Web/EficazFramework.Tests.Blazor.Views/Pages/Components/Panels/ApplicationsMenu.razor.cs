using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EficazFramework.Tests.Blazor.Views.Pages.Components.Panels;

public partial class ApplicationsMenu
{
    [Inject] public EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }
    [Inject] public MudBlazor.ISnackbar? Snackbar { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        EficazFramework.Tests.Blazor.Views.Resources.Mocks.Applications.GenerateApps(ApplicationManager);
    }


}
