using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Utilities;
using System.Drawing;
using EficazFramework.Application;

namespace EficazFramework.Components;

public partial class MdiWindow: MudBlazor.MudComponentBase, IDisposable
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    
    [Parameter] public string Title { get; set; }

    [Parameter] public string Icon { get; set; } = EficazFramework.Icons.Brands.Eficaz;
    
    [Parameter] public Size Size { get; set; }

    [Parameter] public ApplicationDefinition Application { get; set; }

    [CascadingParameter] public MdiHost<ApplicationDefinition> MdiHost { get; set; }

    protected string Classname =>
                    new CssBuilder()
                        .AddClass(Class)
                        .AddClass("d-flex")
                        .AddClass("flex-column")
                        .AddClass("ef-mdi-window")
                        .AddClass("ef-mdi-window-active", MdiHost.SelectedContainer == this)
                        .Build();
   
    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .AddStyle("top", $"{offsetY}px")
                    .AddStyle("left", $"{offsetX}px")
                    .AddStyle("width", $"{Size.Width}px", Size.Width != int.MaxValue)
                    .AddStyle("height", $"{Size.Height}px", Size.Height != int.MaxValue)
                    .Build();

    protected override void OnInitialized()
    {
        MdiHost.AddItem(this);
        base.OnInitialized();
    }

    private double startX, startY, offsetX, offsetY;
    private bool isDragging = false;

    private void OnClick(MouseEventArgs e)
    {
        MdiHost.MoveTo(MdiHost.Items.IndexOf(this));
    }

    private void OnDragStart(DragEventArgs args)
    {
        MdiHost.MoveTo(MdiHost.Items.IndexOf(this));
        isDragging = true;
        startX = args.ClientX;
        startY = args.ClientY;
        args.DataTransfer.EffectAllowed = "move";
        args.DataTransfer.DropEffect = "move";
    }

    private void OnDragEnd(DragEventArgs args)
    {
        isDragging = false;

        offsetX += args.ClientX - startX;
        if (offsetX < 0)
            offsetX = 0;

        offsetY += args.ClientY - startY;
        if (offsetY < 0)
            offsetY = 0;
    }
    
    public void Dispose()
    {
        MdiHost.Items.Remove(this);
    }
        
}
