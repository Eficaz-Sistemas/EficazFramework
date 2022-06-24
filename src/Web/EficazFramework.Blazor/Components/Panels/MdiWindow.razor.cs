using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Utilities;
using System.Drawing;
using EficazFramework.Application;
using Microsoft.JSInterop;

namespace EficazFramework.Components;

public partial class MdiWindow: MudBlazor.MudComponentBase, IDisposable
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    
    [Parameter] public string Title { get; set; }

    [Parameter] public string Icon { get; set; } = EficazFramework.Icons.Brands.Eficaz;
    
    [Parameter] public Size StartupPosition { get; set; } = new(0, 0);
    
    [Parameter] public ApplicationInstance ApplicationInstance { get; set; }

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
                        .AddClass("ef-mdi-window")
                        .AddClass("ef-mdi-window-active", object.ReferenceEquals(MdiHost._selectedApp, ApplicationInstance))
                        .Build();

    /// <summary>
    /// Styles for main div element
    /// </summary>
    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .AddStyle("left", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Position"]).Width}px")
                    .AddStyle("top", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Position"]).Height}px")
                    .AddStyle("width", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Size"]).Width}px")
                    .AddStyle("height", $"{((Size)ApplicationInstance.Targets["Blazor"].Properties["Size"]).Height}px")
                    .AddStyle("z-index", $"{zIndex}")
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
        //Utilities.JsInterop.SetDragImage(JsRutinme, args);
        MoveToMe();
        isDragging = true;
        startX = args.ClientX;
        startY = args.ClientY;
    }

    /// <summary>
    /// Ends a Drag operation and update the screen coordinates of this instance.
    /// </summary>
    private void OnDragEnd(DragEventArgs args)
    {
        isDragging = false;

        offsetX += args.ClientX - startX;
        if (offsetX < 0)
            offsetX = 0;

        offsetY += args.ClientY - startY;
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
