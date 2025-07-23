using EficazFramework.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Utilities;

namespace EficazFramework.Components;
public partial class MdiHost : MudComponentBase, IBrowserViewportObserver
{

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await BrowserViewportService.SubscribeAsync(this, true);
    }

    public async ValueTask DisposeAsync()
    {
        if (IsJSRuntimeAvailable)
            await BrowserViewportService.UnsubscribeAsync(this);
    }


    private Breakpoint _breakpoint;
    private bool _iscompact = false;
    private MudBlazor.Interop.BoundingClientRect _hostArea;
    ElementReference MdiHostArea;

    [Inject] protected IBrowserViewportService BrowserViewportService { get; set; } = null!;

    Guid IBrowserViewportObserver.Id { get; } = Guid.NewGuid();

    async Task IBrowserViewportObserver.NotifyBrowserViewportChangeAsync(BrowserViewportEventArgs browserViewportEventArgs)
    {
        _breakpoint = browserViewportEventArgs.Breakpoint;
        _iscompact = await BrowserViewportService.IsBreakpointWithinReferenceSizeAsync(Breakpoint, _breakpoint);
        _hostArea = await MdiHostArea.MudGetBoundingClientRectAsync() ?? new()
        {
            Width = 900,
            Height = 700,
        }; ;

        if (!_iscompact)
            FixAppsLocationOnResize();

        await InvokeAsync(StateHasChanged);
    }

    private void FixAppsLocationOnResize()
    {
        var source = ApplicationsSource as IList<ApplicationInstance> ?? [];
        foreach (ApplicationInstance app in source!)
        {
            if (app.Blazor()!.OffsetX > _hostArea.Width)
                app.Blazor()!.OffsetX = ((((int)_hostArea.Width) - app.Blazor()!.InitialSize.Width) / 2) - (int)_hostArea.AbsoluteLeft;

            if (app.Blazor()!.OffsetY > _hostArea.Height)
                app.Blazor()!.OffsetY = ((((int)_hostArea.Height) - app.Blazor()!.InitialSize.Height) / 2) - (int)_hostArea.AbsoluteTop;
        }
    }


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


    //! Selected MdiWindow drag move & resize
    internal double offsetX, offsetY;
    internal double width, height;
    internal MdiWindow? _movingWindow;
    /// <summary>
    /// Ends a Drag operation for Current Application
    /// </summary>
    private void OnHeaderPointerUpOrLeave(PointerEventArgs args)
    {
        _movingWindow?.CancelMove();
        _movingWindow?.CancelResize();
        _movingWindow = null;
    }

    /// <summary>
    /// Smoothly Drags this instance
    /// </summary>
    private void OnHeaderPointerMove(PointerEventArgs args)
    {
        if (_movingWindow?.IsMoving ?? false)
        {
            DragSeletedWindow(args);
            return;
        }

        if ((_movingWindow?.IsResizing ?? false) && !(_movingWindow?.IsMoving ?? false))
            ResizeSeletedWindow(args);
    }

    private void DragSeletedWindow(PointerEventArgs args)
    {
#if NET7_0_OR_GREATER
        offsetX += args.MovementX;
        offsetY += args.MovementY;
#else
            double deltaX = args.OffsetX - offsetX;
            double deltaY = args.OffsetY - offsetY;
            offsetX += deltaX;
            offsetY += deltaY;
#endif
        if (SelectedApp != null)
        {
            SelectedApp.Blazor()!.OffsetX = (int)offsetX;
            SelectedApp.Blazor()!.OffsetY = (int)offsetY;
        }
    }

    private void ResizeSeletedWindow(PointerEventArgs args)
    {
#if NET7_0_OR_GREATER
        width += args.MovementX;
        height += args.MovementY;
#else
            double deltaX = args.OffsetX - width;
            double deltaY = args.OffsetY - height;
            width += deltaX;
            height += deltaY;
#endif
        if (SelectedApp != null)
        {
            SelectedApp.Blazor()!.Width = (int)width;
            SelectedApp.Blazor()!.Height = (int)height;
        }
    }



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
            SelectLastApplication();
        }
    }


    [Parameter] public IEnumerable<ApplicationInstance>? ApplicationsSource { get; set; }

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
    /// Running applications (MdiWindow) for the Current Section (ou public apps_
    /// </summary>
    private IEnumerable<ApplicationInstance> RunningApplications() =>
        ApplicationsSource?.Where(app => app.SessionID == 0 || app.SessionID == CurrentSection).ToList() ?? new List<ApplicationInstance>();


    /// <summary>
    /// Start a new application instance (from <paramref name="app"/> metadata) and adds it to the host.
    /// </summary>
    public async void LoadApplication(ApplicationDefinition app)
    {
        if (app.IsPublic == false && CurrentSection == 0)
            return;

        _hostArea = await MdiHostArea.MudGetBoundingClientRectAsync() ?? new()
        {
            Width = 900,
            Height = 700,
        };
        ApplicationInstance? instance = ApplicationsSource?.FirstOrDefault(a => a.Metadata == app && (a.SessionID == 0 || a.SessionID == CurrentSection));
        if (instance == null)
        {
            instance = ApplicationInstance.Create(app, CurrentSection);
            instance.Blazor()!.ZIndex = (ApplicationsSource?.Count() ?? 0) + 1;
            instance.Blazor()!.Width = instance.Blazor()!.InitialSize.Width;
            instance.Blazor()!.Height = instance.Blazor()!.InitialSize.Height;
            instance.Blazor()!.OffsetX = ((((int)_hostArea.Width) - instance.Blazor()!.InitialSize.Width) / 2) - (int)_hostArea.AbsoluteLeft;
            instance.Blazor()!.OffsetY = ((((int)_hostArea.Height) - instance.Blazor()!.InitialSize.Height) / 2) - (int)_hostArea.AbsoluteTop;
            (ApplicationsSource as IList<ApplicationInstance>)?.Add(instance);
        }

        SelectApplication(instance);
    }

    /// <summary>
    /// Move o foco para a Instância de aplicativo <paramref name="app"/>
    /// </summary>
    /// <param name="app"></param>
    public void SelectApplication(ApplicationInstance app)
    {
        var runningAps = RunningApplications();
        foreach(var anotherApp in runningAps.Where(a => !object.ReferenceEquals(a, app)))
        {
            int zIndex = anotherApp.Blazor()!.ZIndex;
            anotherApp.Blazor()!.ZIndex = Math.Max(1, zIndex -= 1);
        }

        if (app != null)
            app.Blazor()!.ZIndex = runningAps.Count();

        SelectedApp = app;
        StateHasChanged();
    }


    /// <summary>
    /// Move o foco para o último aplicativo válido de <see cref="RunningApplications"/>
    /// </summary>
    /// <param name="app"></param>
    public void SelectLastApplication()
    {
        var last = RunningApplications().LastOrDefault();
        if (last != null)
            SelectApplication(last);
        else
        {
            SelectedApp = null;
            StateHasChanged();
        }
    }


    /// <summary>
    /// Closes the application from the <paramref name="appHost"/> parameter.
    /// </summary>
    public void CloseApplication(MdiWindow appHost)
    {
        appHost.ApplicationInstance.Dispose();
        (ApplicationsSource as IList<ApplicationInstance>)?.Remove(appHost.ApplicationInstance);
        SelectLastApplication();
    }

    #endregion
}