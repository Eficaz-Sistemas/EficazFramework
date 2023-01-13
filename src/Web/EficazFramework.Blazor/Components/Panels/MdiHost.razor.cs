using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using EficazFramework.Application;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Services;

namespace EficazFramework.Components;
public partial class MdiHost : MudBlazor.MudBaseBindableItemsControl<MdiWindow, ApplicationInstance>
{

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var subscriptionResult = await BreakpointListener.Subscribe((breakpoint) =>
            {
                _breakpoint = breakpoint;
                InvokeAsync(StateHasChanged);
            }, new ResizeOptions
            {
                ReportRate = 250,
                NotifyOnBreakpointOnly = true,
            });
            _breakpoint = subscriptionResult.Breakpoint;
            _subscriptionId = subscriptionResult.SubscriptionId;
            StateHasChanged();
        }
    }


    private Breakpoint _breakpoint;
    private Guid _subscriptionId;
    [Inject] public MudBlazor.Services.IBreakpointService BreakpointListener { get; set; }

    /// <summary>
    /// Breakpoint that defines the view on Frames (windows) or Full Screen
    /// </summary>
    [Parameter] public MudBlazor.Breakpoint Breakpoint { get; set; } = MudBlazor.Breakpoint.SmAndDown;


    /// <summary>
    /// Content to be rendered at Toolbar's left side.
    /// </summary>
    [Parameter] public RenderFragment? ToolbarLeftContent { get; set; }


    /// <summary>
    /// Content to be rendered at Toolbar's right side.
    /// </summary>
    [Parameter] public RenderFragment? ToolbarRightContent { get; set; }


    private long _currentSection = 0;
    /// <summary>
    /// Current MDI Section (for multi tenant purposes)
    /// </summary>
    [Parameter] public long CurrentSection 
    { 
        get => _currentSection;
        set
        {
            _currentSection = value;
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
    /// Style builder for the TaskBar Applications' Tiles
    /// </summary>
    private string TaskBarAppInstanceButtonStyle(ApplicationInstance item) =>
                new StyleBuilder()
                    .AddStyle("border-top", "solid 3px transparent")
                    .AddStyle("border-bottom", "solid 3px var(--mud-palette-primary)", object.ReferenceEquals(SelectedApp, item))
                    .AddStyle("border-radius", "3px")
                    .Build();

    #endregion


    #region Applications

    public ApplicationInstance? SelectedApp { get; internal set; } = null;

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
        
        //if (ApplicationManager != null)
        //{
        //    newinstance = ApplicationManager!.Activate(app);
        //}
        //else
        //{
            newinstance = ApplicationInstance.Create(app, CurrentSection);
            
            if (ItemsSource == null)
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                Items.Add(new MdiWindow() { ApplicationInstance = newinstance });
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
            else
                (ItemsSource as IList<ApplicationInstance>)!.Add(newinstance);
        //}

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("IsMaximized"))
            newinstance.Targets["Blazor"].Properties.Add("IsMaximized", false);

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("Position"))
            newinstance.Targets["Blazor"].Properties.Add("Position", new System.Drawing.Size(15, 15));

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("Size"))
            newinstance.Targets["Blazor"].Properties.Add("Size", new System.Drawing.Size(425, 250));

        SelectedApp = newinstance;

        var container = Items.SingleOrDefault(ct => object.ReferenceEquals(ct.ApplicationInstance, newinstance));
        container?.MoveToMe();

        StateHasChanged();
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
            SelectedApp = resultingItems.LastOrDefault()!.ApplicationInstance; ;

    }

    #endregion


}