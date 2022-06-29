using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using EficazFramework.Application;

namespace EficazFramework.Components;
public partial class MdiHost : MudBlazor.MudBaseBindableItemsControl<MdiWindow, ApplicationInstance>
{
    /// <summary>
    /// IApplicationManager service instance, if available on DI
    /// </summary>
    [Inject] public EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }

    /// <summary>
    /// Current MDI Section (for multi tenant purposes)
    /// </summary>
    [Parameter] public long CurrentSection { get; set; } = 0;

    /// <summary>
    /// Breakpoint that defines the view on Frames (windows) or Full Screen
    /// </summary>
    [Parameter] public MudBlazor.Breakpoint Breakpoint { get; set; } = MudBlazor.Breakpoint.Xs;

    /// <summary>
    /// The Start Menu Icon
    /// </summary>
    [Parameter] public string StartMenuIcon { get; set; } = Icons.Brands.Eficaz;

    /// <summary>
    /// Start Menu Footer content
    /// </summary>
    [Parameter] public RenderFragment StartMenuFooter { get; set; }
    
    /// <summary>
    /// Aditional left tabs for Start Menu
    /// </summary>
    [Parameter] public RenderFragment StartMenuTabs { get; set; }

    /// <summary>
    /// Gets and Sets the available Application Menu Height. <br/>
    /// It's possible to use CSS expressions, like calc. <br/>
    /// Ex: calc(100vh - 428px) (default value)
    /// </summary>
    [Parameter] public string StartMenuAppsHostHeight { get; set; } = "calc(100vh - 428px)";

    private string _appSearchFilter = "";
    /// <summary>
    /// The literal for searching for applications on the list
    /// </summary>
    [Parameter] public string AppSearchFilter
    {
        get => _appSearchFilter;
        set
        {
            _appSearchFilter = value;
            StateHasChanged();
        }
    }


    #region Classes And Styles

    /// <summary>
    /// Css classes for main div element
    /// </summary>
    protected string Classname =>
                new CssBuilder()
                    .AddClass(Class)
                    .AddClass("d-flex flex-column")
                    .AddClass("flex-grow-1")
                    .AddClass("ef-mdi-host")
                    .Build();

    /// <summary>
    /// Styles for main div element
    /// </summary>
    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .Build();

    /// <summary>
    /// Style builder for the Start Menu Button
    /// </summary>
    private string StartMenuButtonStyle() =>
            new StyleBuilder()
                .AddStyle("padding", "8px")
                .AddStyle("padding-left", "9px")
                .AddStyle("padding-right", "9px")
                .AddStyle("border-radius", "0px")
                .AddStyle("border", "solid 3px transparent")
                .Build();

    /// <summary>
    /// Style builder for the TaskBar Applications' Tiles
    /// </summary>
    private string TaskBarAppInstanceButtonStyle(ApplicationInstance item) =>
                new StyleBuilder()
                    .AddStyle("padding", "8px")
                    .AddStyle("padding-left", "12px")
                    .AddStyle("padding-right", "12px")
                    .AddStyle("border-radius", "0px")
                    .AddStyle("border-top", "solid 3px transparent")
                    .AddStyle("border-bottom", "solid 3px transparent")
                    .AddStyle("border-top", "solid 3px var(--mud-palette-primary)", object.ReferenceEquals(_selectedApp, item))
                    .Build();

    #endregion
    

    #region Start Menu

    private bool _startMenuIsOpen = false;
    public bool StartMenuIsOpen => _startMenuIsOpen;
    
    /// <summary>
    /// Toggle the Start Menu on Open and Closed states.
    /// </summary>
    /// <param name="onlyClose">Just act as closing the menu</param>
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
    /// <summary>
    /// Toggle between Full and Compact (list) Application Menu
    /// </summary>
    public void ToggleStartMenuView()
    {
        _startMenuIsCompact = !_startMenuIsCompact;
        StateHasChanged();
    }

    private MudBlazor.MudTabs _tabsHost;

    /// <summary>
    /// Style builder for the Application Menu
    /// </summary>
    private string StartMenuAppsHostStyle() =>
        new StyleBuilder()
            .AddStyle("overflow-y", "auto")
            .AddStyle("overflow-x", "hidden")
            .AddStyle("height", StartMenuAppsHostHeight)
            .Build();

    #endregion



    #region Applications

    internal ApplicationInstance? _selectedApp = null;

    /// <summary>
    /// Add a new MdiWindow to the Host
    /// </summary>
    public override void AddItem(MdiWindow item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            MoveTo(Items.IndexOf(item));
            item.zIndex = Items.Count + 1;
        }
    }

    /// <summary>
    /// Get's the filtered application list for Menu. Uses the AppSearchFilter as literal.
    /// </summary>
    private IEnumerable<IGrouping<string, ApplicationDefinition>> FilteredApplications() =>
        ApplicationManager!.AllApplications.Where(app => (app.Title ?? "").ToLower().Contains((_appSearchFilter ?? "").ToString().ToLower())).GroupBy(app => app.Group).ToList();

    /// <summary>
    /// Running applications (MdiWindow) for the Current Section (ou public apps_
    /// </summary>
    private IEnumerable<ApplicationInstance> RunningApplications() =>
        ItemsSource.Where(app => app.SessionID == 0 || app.SessionID == CurrentSection).ToList();

    /// <summary>
    /// Start a new application instance (from <paramref name="app"/> metadata) and adds it to the host.
    /// </summary>
    public void LoadApplication(ApplicationDefinition app)
    {
        if (app.IsPublic == false && CurrentSection == 0)
            return;

        ApplicationInstance? newinstance;
        
        if (ApplicationManager != null)
        {
            newinstance = ApplicationManager!.Activate(app);
        }
        else
        {
            newinstance = ApplicationInstance.Create(app, CurrentSection);
            
            if (ItemsSource == null)
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                Items.Add(new MdiWindow() { ApplicationInstance = newinstance });
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
            else
                (ItemsSource as IList<ApplicationInstance>)!.Add(newinstance);
        }

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("Position"))
            newinstance.Targets["Blazor"].Properties.Add("Position", new System.Drawing.Size(15, 15));

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("Size"))
            newinstance.Targets["Blazor"].Properties.Add("Size", new System.Drawing.Size(425, 250));

        _selectedApp = newinstance;

        var container = Items.SingleOrDefault(ct => object.ReferenceEquals(ct.ApplicationInstance, newinstance));
        if (container != null)
            container.MoveToMe();

        StateHasChanged();
        ToggleStartMenuOpen(true);
    }

    /// <summary>
    /// Closes the application from the <paramref name="appHost"/> parameter.
    /// </summary>
    public void CloseApplication(MdiWindow appHost)
    {      
        if (ItemsSource == null)
            Items.Remove(appHost);
        else
        {
            (ItemsSource as IList<ApplicationInstance>)!.Remove(appHost.ApplicationInstance);
            StateHasChanged();
        }

        foreach (var service in appHost.ApplicationInstance.Services)
            (service.Value as IDisposable)!.Dispose();

        var resultingItems = Items.Where(item => !object.ReferenceEquals(item, appHost)).ToList();

        if (resultingItems.Count > 0)
            _selectedApp = resultingItems.LastOrDefault()!.ApplicationInstance; ;

    }

    #endregion

}
