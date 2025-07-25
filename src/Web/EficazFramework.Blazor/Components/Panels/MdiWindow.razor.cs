using EficazFramework.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Utilities;
using static MudBlazor.CategoryTypes;

namespace EficazFramework.Components;

public partial class MdiWindow: MudBlazor.MudComponentBase
{
    internal const string DIALOGSVC = "Dialog";
    internal const string SNACKBARSVC = "SnackBar";

    private DialogInfo? _dialog;
    private SnackbarService? _snackbarService;

    [Inject] public NavigationManager? NavigationManager { get; set; }

    [Parameter] public RenderFragment? ChildContent { get; set; }
    
    [Parameter] public string Title { get; set; }

    [Parameter] public string Icon { get; set; } = EficazFramework.Icons.Brands.Eficaz;
        
    [Parameter] public ApplicationInstance ApplicationInstance { get; set; }

    [Parameter] public bool IsMaximized { get; set; } = false;


    /// <summary>
    /// Gets or Sets if user can resize the MdiWindow content
    /// </summary>
    [Parameter] public bool Resizable { get; set; } = true;


    /// <summary>
    /// Gets or Sets if ef-mdi-window-host element should render a vertical scrollbar
    /// </summary>
    [Parameter] public bool Scrollable { get; set; } = false;

    /// <summary>
    /// Custom Header Frame Content. Will use Icon + Title if null
    /// </summary>
    [Parameter] public RenderFragment? HeaderContent { get; set; }

    [CascadingParameter] public MdiHost MdiHost { get; set; }

    [Inject] IJSRuntime JsRutinme { get; set; }


    /// <summary>
    /// Css classes for main div element
    /// </summary>
    protected string Classname =>
                    new CssBuilder()
                        .AddClass(Class)
                        .AddClass("d-flex")
                        .AddClass("flex-column")
                        .AddClass("ef-mdi-window", !IsMaximized)
                        .AddClass("ef-mdi-window-maximized", IsMaximized)
                        .AddClass("ef-mdi-window-active", object.ReferenceEquals(MdiHost.SelectedApp, ApplicationInstance) && !IsMaximized)
                        .AddClass("ef-mdi-window-active-maximized", object.ReferenceEquals(MdiHost.SelectedApp, ApplicationInstance) && IsMaximized)
                        .AddClass("flex-grow-1")
                        .Build();

    /// <summary>
    /// Styles for main div element
    /// </summary>
    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .AddStyle("left", $"{ApplicationInstance.Blazor()!.OffsetX}px", !IsMaximized)
                    .AddStyle("top", $"{ApplicationInstance.Blazor()!.OffsetY}px", !IsMaximized)
                    .AddStyle("width", $"{ApplicationInstance.Blazor()!.Width}px", !IsMaximized)
                    .AddStyle("height", $"{ApplicationInstance.Blazor()!.Height}px", !IsMaximized)
                    .AddStyle("z-index", $"{ApplicationInstance.Blazor()!.ZIndex}")
                    .AddStyle("-webkit-user-select", "none", !IsMoving)
                    .AddStyle("-ms-user-select", "none", !IsMoving)
                    .AddStyle("user-select", "none", !IsMoving)
                    .AddStyle("cursor", "move", Resizable)
                    .AddStyle("outline", "5px solid transparent")
                    .AddStyle("outline-offset", "-5px")
                    .Build();
                    //.AddStyle("resize", "both", Resizable && !IsMaximized)
                    //.AddStyle("overflow", "auto", Resizable && !IsMaximized)


    /// <summary>
    /// Css classes app host div
    /// </summary>
    protected string HostClassname =>
                    new CssBuilder()
                        .AddClass(Class)
                        .AddClass("d-flex")
                        .AddClass("flex-column")
                        .AddClass("flex-grow-1")
                        .AddClass("overflow-auto", Scrollable)
                        .AddClass("h-inherit")
                        .AddClass("w-inherit")
                        .Build();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        if (ApplicationInstance.Services.TryGetValue(DIALOGSVC, out var dialogObject) && dialogObject is DialogInfo dialog)
            _dialog = dialog;

        if (ApplicationInstance.Services.TryGetValue(SNACKBARSVC, out var snackbarObject) && snackbarObject is SnackbarService snackbarService)
            _snackbarService = snackbarService;

        if(_snackbarService is null)
        {
            _snackbarService = new SnackbarService(NavigationManager!);
            ApplicationInstance.Services[SNACKBARSVC] = _snackbarService;
        }
    }


    /// <summary>
    /// Set this instance as SelectedItem on the host when it's clicked
    /// </summary>
    /// <param name="e"></param>
    private void OnClick(MouseEventArgs e) =>
        MdiHost.SelectApplication(ApplicationInstance);

    /// <summary>
    /// Set a header custom content
    /// </summary>
    /// <param name="customHeader"></param>
    /// <param name="scrollable"></param>
    public void OverrideFrameParameters(RenderFragment? customHeader = null,
        bool scrollable = false)
    {
        HeaderContent = customHeader;
        Scrollable = scrollable;
        StateHasChanged();
    }


    /// <summary>
    /// CloseDialog Button Click action
    /// </summary>
    private void OnClose()
    {
        CancelMove();
        MdiHost.SelectedApp = ApplicationInstance;
        MdiHost.CloseApplication(this);
    }


    //! Move Behavior

    internal bool IsMoving { get; private set; } = false;

    /// <summary>
    /// Starts a Drag operation for move
    /// </summary>
    private void OnHeaderPointerDown(PointerEventArgs args)
    {
        if ((args.PointerType == "mouse" && args.Button == 0)
            || args.PointerType == "touch")
        {
            if (IsMaximized)
                return;

            MdiHost.SelectApplication(ApplicationInstance);
            MdiHost._movingWindow = this;
            IsMoving = true;
            IsResizing = false;
            MdiHost.offsetX = ApplicationInstance.Blazor()!.OffsetX;
            MdiHost.offsetY = ApplicationInstance.Blazor()!.OffsetY;
        }
    }

    /// <summary>
    /// Ends a Drag operation and update the screen coordinates of this instance.
    /// </summary>
    private void OnHeaderPointerUp(PointerEventArgs args) =>
        CancelMove();

    /// <summary>
    /// Cancels a dragging operation by external component
    /// </summary>
    internal void CancelMove() =>
        IsMoving = false;


    //! Resize Behavior
    internal bool IsResizing { get; private set; } = false;
    internal double width, height;
    /// <summary>
    /// Starts a Drag operation for resize
    /// </summary>
    private void OnBorderPointerDown(PointerEventArgs args)
    {
        if ((args.PointerType == "mouse" && args.Button == 0)
            || args.PointerType == "touch")
        {
            if (IsMaximized || !Resizable)
                return;

            MdiHost.SelectApplication(ApplicationInstance);
            MdiHost._movingWindow = this;
            IsResizing = true;
            MdiHost.width = ApplicationInstance.Blazor()!.Width;
            MdiHost.height = ApplicationInstance.Blazor()!.Height;
        }
    }

    /// <summary>
    /// Ends a Drag operation and update the measures of this instance.
    /// </summary>
    private void OnBorderPointerUp(PointerEventArgs args) =>
        CancelResize();

    /// <summary>
    /// Cancels a dragging operation by external component
    /// </summary>
    internal void CancelResize() =>
        IsResizing = false;


    private EficazFramework.Components.AbsoluteDialogContainer _dialogContainer;
    /// <summary>
    /// Exibe um diálogo modal com o conteúdo fornecido.
    /// </summary>
    public async Task<DialogInfo?> ShowDialogAsync<T>(
        string title,
        MudBlazor.DialogParameters? parameters = null,
        MudBlazor.DialogOptions? options = null)
    {
        DialogInfo dialog = new()
        {
            Type = typeof(T),
            Title = title,
            Parameters = parameters?.ToDictionary() ?? [],
            Options = options
        };
        ApplicationInstance.Services[DIALOGSVC] = dialog;
        _dialog = dialog;
        await ValueTask.CompletedTask;
        StateHasChanged();
        _dialog.Result.ContinueWith(t =>
        {
            return InvokeAsync(() =>
            {
                _dialog = null;
                ApplicationInstance.Services.Remove(DIALOGSVC);
                StateHasChanged();
            });
        }).CatchAndLog();
        return _dialog;
    }

    /// <summary>
    /// Closes the dialog with the specified result.
    /// </summary>
    internal void CloseDialog(MudBlazor.DialogResult? result)
    {
        if (_dialog is null)
            return;

        _dialog.Close(result);
    }


    /// <summary>
    /// Exibe uma notificação (snackbar) com a mensagem fornecida.
    /// </summary>
    public void AddSnackbar(
        MarkupString message, 
        Severity severity = Severity.Normal, 
        Action<SnackbarOptions>? configure = null, 
        string? key = null) =>
        _snackbarService?.Add(message, severity, configure, key);

    /// <summary>
    /// Exibe uma notificação (snackbar) com a mensagem fornecida.
    /// </summary>
    public void AddSnackbar(
        string message,
        Severity severity = Severity.Normal,
        Action<SnackbarOptions>? configure = null,
        string? key = null) =>
        _snackbarService?.Add(message, severity, configure, key);

    /// <summary>
    /// Exibe uma notificação (snackbar) com a mensagem fornecida.
    /// </summary>
    public void AddSnackbar(
        RenderFragment message,
        Severity severity = Severity.Normal,
        Action<SnackbarOptions>? configure = null,
        string? key = null) =>
        _snackbarService?.Add(message, severity, configure, key);

    public void ConfigureSnackBar(MudBlazor.SnackbarConfiguration snackbarConfiguration)
    {
        if (_snackbarService is null)
            return;

        _snackbarService.Configuration.BackgroundBlurred = snackbarConfiguration.BackgroundBlurred;
        _snackbarService.Configuration.ClearAfterNavigation = snackbarConfiguration.ClearAfterNavigation;
        _snackbarService.Configuration.ErrorIcon = snackbarConfiguration.ErrorIcon;
        _snackbarService.Configuration.HideTransitionDuration = snackbarConfiguration.HideTransitionDuration;
        _snackbarService.Configuration.IconSize = snackbarConfiguration.IconSize;
        _snackbarService.Configuration.InfoIcon = snackbarConfiguration.InfoIcon;
        _snackbarService.Configuration.MaxDisplayedSnackbars = snackbarConfiguration.MaxDisplayedSnackbars;
        _snackbarService.Configuration.MaximumOpacity = snackbarConfiguration.MaximumOpacity;
        _snackbarService.Configuration.NewestOnTop = snackbarConfiguration.NewestOnTop;
        _snackbarService.Configuration.NormalIcon = snackbarConfiguration.NormalIcon;
        _snackbarService.Configuration.PositionClass = snackbarConfiguration.PositionClass;
        _snackbarService.Configuration.PreventDuplicates = snackbarConfiguration.PreventDuplicates;
        _snackbarService.Configuration.RequireInteraction = snackbarConfiguration.RequireInteraction;
        _snackbarService.Configuration.ShowCloseIcon = snackbarConfiguration.ShowCloseIcon;
        _snackbarService.Configuration.ShowTransitionDuration = snackbarConfiguration.ShowTransitionDuration;
        _snackbarService.Configuration.SnackbarVariant = snackbarConfiguration.SnackbarVariant;
        _snackbarService.Configuration.SuccessIcon = snackbarConfiguration.SuccessIcon;
        _snackbarService.Configuration.VisibleStateDuration = snackbarConfiguration.VisibleStateDuration;
        _snackbarService.Configuration.WarningIcon = snackbarConfiguration.WarningIcon;
    }
}

public enum WindowState
{
    Normal = 0,
    Maximized = 1
}