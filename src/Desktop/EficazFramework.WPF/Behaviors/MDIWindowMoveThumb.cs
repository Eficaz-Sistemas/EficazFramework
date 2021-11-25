using EficazFramework.Controls;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

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
        if (window != null)
            window.Focus();
        base.OnMouseDown(e);
    }

    MDIWindow window = null;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        window = Utilities.VisualTreeHelpers.FindAnchestor<Controls.MDIWindow>(this);
    }

    // Protected Overrides Sub OnMouseDoubleClick(e As MouseButtonEventArgs)
    // Dim window = Utilities.VisualTreeHelpers.FindAnchestor(Of Controls.MDIWindow)(Me)
    // If window IsNot Nothing AndAlso window.Container IsNot Nothing Then
    // Select Case window.WindowState
    // Case WindowState.Maximized
    // window.Normalize()
    // Exit Select
    // Case WindowState.Normal
    // window.Maximize()
    // Exit Select
    // Case WindowState.Minimized
    // window.Normalize()
    // Exit Select
    // Case Else
    // Throw New InvalidOperationException("Unsupported WindowsState mode")
    // End Select
    // End If

    // e.Handled = True
    // End Sub

    private void OnMoveThumbDragDelta(object sender, DragDeltaEventArgs e)
    {
        if (window != null)
        {
            if (window.WindowState != WindowState.Maximized)
            {
                Canvas.SetLeft(window, Canvas.GetLeft(window) + e.HorizontalChange);
                Canvas.SetTop(window, Canvas.GetTop(window) + e.VerticalChange);
            }
        }
    }
}

// Code-Base from Hammer UI KIT
// http://andrassebo.blogspot.com.br/p/hammer.html