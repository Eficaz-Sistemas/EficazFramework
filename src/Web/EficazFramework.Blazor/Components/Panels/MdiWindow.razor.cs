using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Utilities;
using System.Drawing;
using EficazFramework.Application;
using Microsoft.JSInterop;

namespace EficazFramework.Components;

public partial class MdiWindow: MudBlazor.MudComponentBase, IDisposable
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    
    [Parameter] public string Title { get; set; }

    [Parameter] public string Icon { get; set; } = EficazFramework.Icons.Brands.Eficaz;
    
    [Parameter] public Size StartupPosition { get; set; } = new(0, 0);
    
    [Parameter] public ApplicationInstance ApplicationInstance { get; set; }

    [Parameter] public bool IsMaximized { get; set; } = false;

    /// <summary>
    /// Gets or Sets if ef-mdi-window-host element should render a vertical scrollbar
    /// </summary>
    public bool Scrollable { get; set; } = false;

    /// <summary>
    /// Custom Header Frame Content. Will use Icon + Title if null
    /// </summary>
    public RenderFragment? HeaderContent { get; set; }


    [CascadingParameter] public MdiHost MdiHost { get; set; }

    [Inject] IJSRuntime JsRutinme { get; set; }

    private object myRef;

    internal int zIndex = 1;

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
                        .AddClass("ef-mdi-window-active", object.ReferenceEquals(MdiHost._selectedApp, ApplicationInstance))
                        .AddClass("flex-grow-1")
                        .Build();

    /// <summary>
    /// Styles for main div element
    /// </summary>
    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .AddStyle("left", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Position"]).Width}px", !IsMaximized)
                    .AddStyle("top", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Position"]).Height}px", !IsMaximized)
                    .AddStyle("width", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Size"]).Width}px", !IsMaximized)
                    .AddStyle("height", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Size"]).Height}px", !IsMaximized)
                    .AddStyle("z-index", $"{zIndex}")
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
                        .Build();

    protected override void OnInitialized()
    {
        MdiHost.AddItem(this);
        base.OnInitialized();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender)
        {
            offsetX = StartupPosition.Width;
            offsetY = StartupPosition.Height;
        }
    }

    private double startX, startY, offsetX, offsetY;
    private bool isDragging = false;

    /// <summary>
    /// Set this instance as SelectedItem on the host when it's clicked
    /// </summary>
    /// <param name="e"></param>
    private void OnClick(MouseEventArgs e) =>
        MoveToMe();

    /// <summary>
    /// Start a Drag operation for move
    /// </summary>
    private void OnDragStart(DragEventArgs args)
    {
        //if (ApplicationInstance.Targets["Blazor"].Properties["State"] = 1)
        //    return;

        //Utilities.JsInterop.SetDragImage(JsRutinme, args);
        MoveToMe();
        isDragging = true;
        startX = args.OffsetX;
        startY = args.OffsetY;
    }

    //private void OnDragging(DragEventArgs args)
    //{
    //    if (!isDragging)
    //        return;

    //    offsetX += args.OffsetX - startX;
    //    if (offsetX < 0)
    //        offsetX = 0;

    //    offsetY += args.OffsetY - startY;
    //    if (offsetY < 0)
    //        offsetY = 0;

    //    ApplicationInstance.Targets["Blazor"].Properties["Position"] = new Size((int)offsetX, (int)offsetY);
    //}

    /// <summary>
    /// Ends a Drag operation and update the screen coordinates of this instance.
    /// </summary>
    private void OnDragEnd(DragEventArgs args)
    {
        isDragging = false;

        offsetX += args.OffsetX - startX;
        if (offsetX < 0)
            offsetX = 0;

        offsetY += args.OffsetY - startY;
        if (offsetY < 0)
            offsetY = 0;

        ApplicationInstance.Targets["Blazor"].Properties["Position"] = new Size((int)offsetX, (int)offsetY);
    }
    
    /// <summary>
    /// Request the host to update the selected item to this instance.
    /// </summary>
    internal void MoveToMe()
    {
        zIndex = MdiHost.Items.Count;

        foreach (var item in MdiHost.Items.Where(it => !object.ReferenceEquals(this, it)))
            item.zIndex = Math.Max(1, item.zIndex -= 1);

        MdiHost._selectedApp = this.ApplicationInstance;
        MdiHost.MoveTo(MdiHost.Items.IndexOf(this));
    }

    /// <summary>
    /// Close Button Click action
    /// </summary>
    private void OnClose()
    {
        MoveToMe();
        MdiHost.CloseApplication(this);
    }

    /// <summary>
    /// Remove this instance from host.
    /// </summary>
    public void Dispose()
    {
        MdiHost.Items.Remove(this);
    }
        
}

public enum WindowState
{
    Normal = 0,
    Maximized = 1
}