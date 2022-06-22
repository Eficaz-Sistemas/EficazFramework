using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using EficazFramework.Application;

namespace EficazFramework.Components;
public partial class MdiHost : MudBlazor.MudBaseBindableItemsControl<MdiWindow, ApplicationInstance>
{
    [Inject] public EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }

    [Parameter] public long CurrentSection { get; set; } = 0;

    [Parameter] public RenderFragment Footer { get; set; }
    [Parameter] public RenderFragment Tabs { get; set; }


    #region Classes And Styles

    protected string Classname =>
                new CssBuilder()
                    .AddClass(Class)
                    .AddClass("d-flex flex-column")
                    .AddClass("flex-grow-1")
                    .AddClass("ef-mdi-host")
                    .Build();

    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .Build();

    private string StartMenuButtonStyle() =>
            new StyleBuilder()
                .AddStyle("padding", "8px")
                .AddStyle("padding-left", "9px")
                .AddStyle("padding-right", "9px")
                .AddStyle("border-radius", "0px")
                .AddStyle("border", "solid 3px transparent")
                .Build();

    private string StartApplicationMenuButtonStyle() =>
        new StyleBuilder()
            .AddStyle("margin", "8px")
            .Build();

    private string TaskBarButtonStyle(MdiWindow item) =>
                new StyleBuilder()
                    .AddStyle("padding", "8px")
                    .AddStyle("padding-left", "12px")
                    .AddStyle("padding-right", "12px")
                    .AddStyle("border-radius", "0px")
                    .AddStyle("border-top", "solid 3px transparent")
                    .AddStyle("border-bottom", "solid 3px transparent")
                    .AddStyle("border-top", "solid 3px var(--mud-palette-primary)", SelectedContainer == item)
                    .Build();

    #endregion

    
    
    #region Start Menu

    private bool _startMenuIsOpen = false;
    public void ToggleStartMenuOpen(bool onlyClose = false)
    {
        if (onlyClose)
            _startMenuIsOpen = false;
        else
            _startMenuIsOpen = !_startMenuIsOpen;

        AppSearchFilter = "";
        _tabsHost?.ActivatePanel(0, false);
        StateHasChanged();
    }

    
    private bool _startMenuIsCompact = false;
    public void ToggleStartMenuView()
    {
        _startMenuIsCompact = !_startMenuIsCompact;
        StateHasChanged();
    }

    private MudBlazor.MudTabs _tabsHost;

    #endregion


    
    #region Applications

    public override void AddItem(MdiWindow item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            MoveTo(Items.IndexOf(item));
        }
    }

    private string _appSearchFilter = "";

    private string AppSearchFilter
    {
        get => _appSearchFilter;
        set
        {
            _appSearchFilter = value;
            StateHasChanged();
        }
    }

    private IEnumerable<IGrouping<string, ApplicationDefinition>> FilteredApplications() =>
        ApplicationManager!.AllApplications.Where(app => (app.Title ?? "").ToLower().Contains((_appSearchFilter ?? "").ToString().ToLower())).GroupBy(app => app.Group).ToList();

    private IEnumerable<ApplicationInstance> RunningApplications() =>
    ItemsSource.Where(app => app.SessionID == 0 || app.SessionID == CurrentSection).ToList();
    
    private IEnumerable<MdiWindow> TaskBarItems() =>
        Items.Where(app => app.ApplicationInstance.SessionID == 0 || app.ApplicationInstance.SessionID == CurrentSection).ToList();

    public void LoadApplication(ApplicationDefinition app)
    {
        if (ApplicationManager != null)
        {
            if (app.IsPublic == false && ApplicationManager.SectionManager.CurrentSection.ID == 0)
                return;

            var appInstance = ApplicationManager!.Activate(app);
            var container = Items.SingleOrDefault(ct => object.ReferenceEquals(ct.ApplicationInstance, appInstance));
            if (container != null)
                MoveTo(Items.IndexOf(container));
        }

        ToggleStartMenuOpen(true);
    }

    #endregion

}
