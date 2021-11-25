using Microsoft.AspNetCore.Components;

namespace EficazFramework.Templates;

public partial class StartMenu
{
    protected string IndexPanelCss =>
                        new MudBlazor.Utilities.CssBuilder("mdicontainer-startmenu_index")
                        .AddClass("ma-5")
                        .AddClass("d-flex")
                        .AddClass("flex-grow-1")
                        .AddClass("flex-column")
                        .Build();

    private MudBlazor.MudTabs _tabsHost;
    private EficazFramework.Templates.Applications _appsMenu;

    [Parameter] public string AppsTabIcon { get; set; } = MudBlazor.Icons.Material.Filled.Apps;
    [Parameter] public RenderFragment InitialTabsContent { get; set; }
    [Parameter] public RenderFragment HeaderContent { get; set; }
    [Parameter] public RenderFragment TabsContent { get; set; }

    [CascadingParameter] MudBlazor.MudDialogInstance MudDialog { get; set; }
    [CascadingParameter(Name = "MDIContainer")] Components.MDIContainer MDI { get; set; }

    public void MoveTo(int index)
    {
        _tabsHost.ActivatePanel(index);
    }

    public void OpenApp(EficazFramework.Application.ApplicationDefinition app)
    {
        MDI?.Activate(app);
    }


}
