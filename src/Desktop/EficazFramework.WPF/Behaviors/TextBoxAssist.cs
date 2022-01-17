using System;
using System.ComponentModel;
using System.Windows;
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace EficazFramework.XAML.Behaviors;

public partial class TextBox
{

    public static bool GetSelectAllOnFocus(DependencyObject element)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element));
        }
        return (bool)element.GetValue(SelectAllOnFocusProperty);
    }
    public static void SetSelectAllOnFocus(DependencyObject element, bool value)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element));
        }
        element.SetValue(SelectAllOnFocusProperty, value);
    }
    public static readonly DependencyProperty SelectAllOnFocusProperty = DependencyProperty.RegisterAttached("SelectAllOnFocus", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, OnSelectAllOnFocusChanged));

    private static void OnSelectAllOnFocusChanged(object source, DependencyPropertyChangedEventArgs e)
    {
        if (source is not System.Windows.Controls.TextBox tb)
            return;

        var dpd = DependencyPropertyDescriptor.FromProperty(System.Windows.UIElement.IsKeyboardFocusedProperty, typeof(System.Windows.Controls.TextBox));
        if (dpd is null)
            return;
  
        if ((bool)e.NewValue == true)
            dpd.AddValueChanged(tb, TextBox_GotKeyboardFocus);
        else
            dpd.RemoveValueChanged(tb, TextBox_GotKeyboardFocus);
    }

    private static void TextBox_GotKeyboardFocus(object sender, EventArgs e)
    {
        if (sender is not System.Windows.Controls.TextBox tb)
            return;

        tb.SelectionStart = 0;
        tb.SelectionLength = tb.Text.Length;
        tb.ScrollToEnd();
    }
}
