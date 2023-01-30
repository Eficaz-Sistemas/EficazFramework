using EficazFramework.Controls;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace EficazFramework.XAML.Behaviors;

public sealed partial class MDIWindowMoveThumb : Thumb
{
    static MDIWindowMoveThumb()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MDIWindowMoveThumb), new FrameworkPropertyMetadata(typeof(MDIWindowMoveThumb)));
    }

    public MDIWindowMoveThumb()
    {
        if (DesignerProperties.GetIsInDesignMode(this))
            return;
        DragDelta += OnMoveThumbDragDelta;
    }

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        var window = Utilities.VisualTreeHelpers.FindAnchestor<Controls.MDIWindow>(this);
        window?.Focus();
        base.OnMouseDown(e);
    }

    MDIWindow window = null;

    [ExcludeFromCodeCoverage]
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        window = Utilities.VisualTreeHelpers.FindAnchestor<Controls.MDIWindow>(this);
    }

    private void OnMoveThumbDragDelta(object sender, DragDeltaEventArgs e)
    {
        bool canMove = true;
        UIElement element = (UIElement)sender;
        if (window != null)
        {
            element = window;
            if (window.WindowState == WindowState.Maximized)
                canMove = false;
        }
        if (canMove)
        {
            Canvas.SetLeft(element, Canvas.GetLeft(element) + e.HorizontalChange);
            Canvas.SetTop(element, Canvas.GetTop(element) + e.VerticalChange);
        }
    }
}

// Code-Base from Hammer UI KIT
// http://andrassebo.blogspot.com.br/p/hammer.html