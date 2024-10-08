﻿using EficazFramework.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Utilities;
using System.Data.SqlTypes;

namespace EficazFramework.Components;

public partial class MdiWindow: MudBlazor.MudComponentBase
{
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
    /// Close Button Click action
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
}

public enum WindowState
{
    Normal = 0,
    Maximized = 1
}