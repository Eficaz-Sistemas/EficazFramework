using EficazFramework.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EficazFramework.Controls;

public partial class DataGridAutoCompleteColumn : System.Windows.Controls.DataGridTextColumn
{
    public DataGridAutoCompleteColumn() =>
        EditingElementStyle = (Style)System.Windows.Application.Current.FindResource("Style.AutoComplete.DataGridCellEditor");

    public TextAlignment Alignment
    {
        get => (TextAlignment)GetValue(AlignmentProperty);
        set => SetValue(AlignmentProperty, value);
    }
    public static readonly DependencyProperty AlignmentProperty = DependencyProperty.Register("Alignment", typeof(TextAlignment), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(TextAlignment.Justify));

    public string ContentPath
    {
        get => (string)GetValue(ContentPathProperty);
        set => SetValue(ContentPathProperty, value);
    }
    public static readonly DependencyProperty ContentPathProperty = DependencyProperty.Register("ContentPath", typeof(string), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(null));

    public BindingBase ValueBinding
    {
        get => (BindingBase)GetValue(ValueBindingProperty);
        set => SetValue(ValueBindingProperty, value);
    }
    public static readonly DependencyProperty ValueBindingProperty = DependencyProperty.Register("ValueBinding", typeof(BindingBase), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(null));

    public string ValuePath
    {
        get => (string)GetValue(ValuePathProperty);
        set => SetValue(ValuePathProperty, value);
    }
    public static readonly DependencyProperty ValuePathProperty = DependencyProperty.Register("ValuePath", typeof(string), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(null));

    public bool ValueIgnores
    {
        get => (bool)GetValue(ValueIgnoresProperty);
        set => SetValue(ValueIgnoresProperty, value);
    }
    public static readonly DependencyProperty ValueIgnoresProperty = DependencyProperty.Register("ValueIgnores", typeof(bool), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(true));

    public Action<object, Events.FindRequestEventArgs> FindAction
    {
        get => (Action<object, Events.FindRequestEventArgs>)GetValue(FindActionProperty);
        set => SetValue(FindActionProperty, value);
    }
    public static readonly DependencyProperty FindActionProperty = DependencyProperty.Register("FindAction", typeof(Action<object, Events.FindRequestEventArgs>), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(null));

    public Action<object, SelectionChangedEventArgs> SelectionChangedAction
    {
        get => (Action<object, SelectionChangedEventArgs>)GetValue(SelectionChangedActionProperty);
        set => SetValue(SelectionChangedActionProperty, value);
    }
    public static readonly DependencyProperty SelectionChangedActionProperty = DependencyProperty.Register("SelectionChangedAction", typeof(Action<object, SelectionChangedEventArgs>), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(null));

    public bool FreeText
    {
        get => (bool)GetValue(FreeTextProperty);
        set => SetValue(FreeTextProperty, value);
    }
    public static readonly DependencyProperty FreeTextProperty = DependencyProperty.Register("FreeText", typeof(bool), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(false));

    public double PopupMaxWidth
    {
        get => (double)GetValue(PopupMaxWidthProperty);
        set => SetValue(PopupMaxWidthProperty, value);
    }
    public static readonly DependencyProperty PopupMaxWidthProperty = DependencyProperty.Register("PopupMaxWidth", typeof(double), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(double.NaN));

    public double PopupMinWidth
    {
        get => (double)GetValue(PopupMinWidthProperty);
        set => SetValue(PopupMinWidthProperty, value);
    }
    public static readonly DependencyProperty PopupMinWidthProperty = DependencyProperty.Register("PopupMinWidth", typeof(double), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(double.NaN));

    public double PopupMinHeight
    {
        get => (double)GetValue(PopupMinHeightProperty);
        set => SetValue(PopupMinHeightProperty, value);
    }
    public static readonly DependencyProperty PopupMinHeightProperty = DependencyProperty.Register("PopupMinHeight", typeof(double), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(double.NaN));

    public double PopupMaxHeight
    {
        get => (double)GetValue(PopupMaxHeightProperty);
        set => SetValue(PopupMaxHeightProperty, value);
    }
    public static readonly DependencyProperty PopupMaxHeightProperty = DependencyProperty.Register("PopupMaxHeight", typeof(double), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(double.NaN));

    public object Tag
    {
        get => (object)GetValue(TagProperty);
        set => SetValue(TagProperty, value);
    }
    public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(object), typeof(DataGridAutoCompleteColumn), new PropertyMetadata(null));


    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
        TextBlock blck = base.GenerateElement(cell, dataItem) as TextBlock;
        blck.TextAlignment = Alignment;
        return blck;
    }

    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
        AutoComplete tb = new();
        tb.FreeText = FreeText;
        if (FreeText == false)
        {
            tb.ContentPath = ContentPath;
            tb.ValuePath = ValuePath;
            tb.ValueIgnores = ValueIgnores;
            if (Binding != null) tb.SetBinding(AutoComplete.ContentProperty, Binding);
            if (ValueBinding != null) tb.SetBinding(AutoComplete.ValueProperty, ValueBinding);
        }
        else
        {
            tb.SetBinding(AutoComplete.TextProperty, Binding);
        }
        tb.Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
        tb.Tag = Tag;
        tb.PopupMinWidth = PopupMinWidth;
        tb.PopupMaxWidth = PopupMaxWidth;
        tb.PopupMinHeight = PopupMinHeight;
        tb.PopupMaxHeight = PopupMaxHeight;
        tb.TextAlignment = Alignment;
        if (EditingElementStyle != null) tb.Style = EditingElementStyle;
        tb.FindAction = FindAction;
        tb.SelectionChangedAction += SelectionChangedAction;
        return tb;
    }

}
