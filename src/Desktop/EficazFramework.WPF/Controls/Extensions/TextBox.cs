using System.ComponentModel;

namespace EficazFramework.Controls.AttachedProperties;
public partial class TextBox
{

    #region SelectAllOnFocus

    [ExcludeFromCodeCoverage]
    public static bool GetSelectAllOnFocus([DisallowNull] DependencyObject element) =>
        (bool)element.GetValue(SelectAllOnFocusProperty);

    [ExcludeFromCodeCoverage]
    public static void SetSelectAllOnFocus([DisallowNull] DependencyObject element, bool value) =>
        element.SetValue(SelectAllOnFocusProperty, value);

    public static readonly DependencyProperty SelectAllOnFocusProperty = DependencyProperty.RegisterAttached("SelectAllOnFocus", typeof(bool), typeof(TextBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, OnSelectAllOnFocusChanged));

    private static void OnSelectAllOnFocusChanged(object source, DependencyPropertyChangedEventArgs e)
    {
        if (source is not System.Windows.Controls.TextBox)
            return;

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
        if (sender is not System.Windows.Controls.TextBox)
            return;
        //if (Controls.Calculator.GetTransportEnabled(tb) == true & Controls.CalculatorUtilities.TransportValue.HasValue)
        //{
        //    if (!(tb is Controls.NumberInputBox))
        //    {
        //        string currenttext = Conversions.ToString(tb.GetValue(System.Windows.Controls.TextBox.TextProperty) ?? "");
        //        if (string.IsNullOrEmpty(currenttext))
        //            currenttext = Controls.CalculatorUtilities.TransportValue ?? "";
        //        else
        //            currenttext = string.Format("{0} {1}", currenttext.TrimEnd(), Controls.CalculatorUtilities.TransportValue ?? "");
        //        tb.SetValue(System.Windows.Controls.TextBox.TextProperty, currenttext);
        //    }
        //    else
        //    {
        //        tb.SetValue(System.Windows.Controls.TextBox.TextProperty, Math.Round(Math.Abs(Controls.CalculatorUtilities.TransportValue ?? 0), ((Controls.NumberInputBox)tb).DecimalPlaces).ToString());
        //    }

        //    if (Controls.CalculatorUtilities.Instance is object)
        //    {
        //        Controls.CalculatorUtilities.Instance.SetValue(Controls.Calculator.IsTransportingPropertyKey, false);
        //    }
        //    else
        //    {
        //        Controls.CalculatorUtilities.Instance = null;
        //        Controls.CalculatorUtilities.TransportValue = null;
        //    }
        //}

        if (sender is not System.Windows.Controls.TextBox tb)
            return;
        tb.SelectionStart = 0;
        tb.SelectionLength = tb.Text.Length;
        tb.ScrollToEnd();
    }

    #endregion


    #region Start Element

    [ExcludeFromCodeCoverage]
    public static object GetStartElement([DisallowNull] DependencyObject element) =>
        element.GetValue(StartElementProperty);

    [ExcludeFromCodeCoverage]
    public static void SetStartElement([DisallowNull] DependencyObject element, object value) =>
        element.SetValue(StartElementProperty, value);

    public static readonly DependencyProperty StartElementProperty = DependencyProperty.RegisterAttached("StartElement", typeof(object), typeof(TextBox), new PropertyMetadata(null));

    #endregion


    #region End Element

    [ExcludeFromCodeCoverage]
    public static object GetEndElement([DisallowNull] DependencyObject element) =>
    element.GetValue(EndElementProperty);

    [ExcludeFromCodeCoverage]
    public static void SetEndElement([DisallowNull] DependencyObject element, object value) =>
        element.SetValue(EndElementProperty, value);

    public static readonly DependencyProperty EndElementProperty = DependencyProperty.RegisterAttached("EndElement", typeof(object), typeof(TextBox), new PropertyMetadata(null));

    #endregion

}