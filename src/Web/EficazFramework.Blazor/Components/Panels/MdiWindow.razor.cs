using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Utilities;
using System.Drawing;
using EficazFramework.Application;
using Microsoft.JSInterop;

namespace EficazFramework.Components;

public partial class MdiWindow: MudBlazor.MudComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    
    [Parameter] public string Title { get; set; }

    [Parameter] public string Icon { get; set; } = EficazFramework.Icons.Brands.Eficaz;
        
    [Parameter] public ApplicationInstance ApplicationInstance { get; set; }

    [Parameter] public bool IsMaximized { get; set; } = false;

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

    private object myRef;

    //internal Size FrameSize() =>
    //    (Size)ApplicationInstance.Targets["Blazor"].Properties["Size"] ?? new Size(300, 250)


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
                    .AddStyle("left", $"{(int)ApplicationInstance.Targets["Blazor"].Properties["OffsetX"]}px", !IsMaximized)
                    .AddStyle("top", $"{(int)ApplicationInstance.Targets["Blazor"].Properties["OffsetY"]}px", !IsMaximized)
                    .AddStyle("width", $"{(int)ApplicationInstance.Targets["Blazor"].Properties["Width"]}px", !IsMaximized)
                    .AddStyle("height", $"{(int)ApplicationInstance.Targets["Blazor"].Properties["Height"]}px", !IsMaximized)
                    .AddStyle("z-index", $"{(int)ApplicationInstance.Targets["Blazor"].Properties["ZIndex"]}")
                    .Build();

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

    private double offsetX, offsetY;
    private bool isDragging = false;

    /// <summary>
    /// Set this instance as SelectedItem on the host when it's clicked
    /// </summary>
    /// <param name="e"></param>
    private void OnClick(MouseEventArgs e) =>
        MdiHost.MoveTo(ApplicationInstance);


    /// <summary>
    /// Starts a Drag operation for move
    /// </summary>
    private void OnPointerDown(PointerEventArgs args)
    {
        if ((args.PointerType == "mouse" && args.Button == 0)
            || args.PointerType == "touch")
        {
            MdiHost.MoveTo(ApplicationInstance);
            isDragging = true;
            offsetX = (int)ApplicationInstance.Targets["Blazor"].Properties["OffsetX"];
            offsetY = (int)ApplicationInstance.Targets["Blazor"].Properties["OffsetY"];
        }
    }

    ///// <summary>
    ///// Start a Drag operation for move
    ///// </summary>
    //private void OnDragStart(DragEventArgs args)
    //{
    //    //Utilities.JsInterop.SetDragImage(JsRutinme, args);
    //    MdiHost.MoveTo(ApplicationInstance);
    //    isDragging = true;
    //    startX = args.OffsetX;
    //    startY = args.OffsetY;
    //}

    /// <summary>
    /// Smoothly Drags this instance
    /// </summary>
    private void OnPointerMove(PointerEventArgs args)
    {
        if (isDragging)
        {

#if NET7_0_OR_GREATER
            offsetX += args.MovementX;
            offsetY += args.MovementY;
#else
            double deltaX = args.ClientX - offsetX;
            double deltaY = args.ClientY - offsetY;
            offsetX += deltaX;
            offsetY += deltaY;
#endif
            ApplicationInstance.Targets["Blazor"].Properties["OffsetX"] = (int)offsetX;
            ApplicationInstance.Targets["Blazor"].Properties["OffsetY"] = (int)offsetY;
        }
    }


    /// <summary>
    /// Ends a Drag operation and update the screen coordinates of this instance.
    /// </summary>
    private void OnPointerUp(PointerEventArgs args)
    {
        isDragging = false;

        //offsetX += args.OffsetX - startX;
        //if (offsetX < 0)
        //    offsetX = 0;

        //offsetY += args.OffsetY - startY;
        //if (offsetY < 0)
        //    offsetY = 0;

    }

    ///// <summary>
    ///// Ends a Drag operation and update the screen coordinates of this instance.
    ///// </summary>
    //private void OnDragEnd(DragEventArgs args)
    //{
    //    isDragging = false;

    //    //offsetX += args.OffsetX - startX;
    //    //if (offsetX < 0)
    //    //    offsetX = 0;

    //    //offsetY += args.OffsetY - startY;
    //    //if (offsetY < 0)
    //    //    offsetY = 0;

    //    ApplicationInstance.Targets["Blazor"].Properties["OffsetX"] = (int)offsetX;
    //    ApplicationInstance.Targets["Blazor"].Properties["OffsetY"] = (int)offsetY;
    //}

    /// <summary>
    /// Close Button Click action
    /// </summary>
    private void OnClose()
    {
        MdiHost.SelectedApp = ApplicationInstance;
        MdiHost.CloseApplication(this);
    }


    public void OverrideFrameParameters(RenderFragment? customHeader = null,
        bool scrolable = false)
    {
        HeaderContent = customHeader;
        Scrollable = scrolable;
        StateHasChanged();
    }
}

public enum WindowState
{
    Normal = 0,
    Maximized = 1
}