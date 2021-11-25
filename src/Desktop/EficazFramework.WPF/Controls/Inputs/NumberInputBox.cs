using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EficazFramework.Controls;

public partial class NumberInputBox : TextBox
{

    public NumberInputBox() : base()
    {
        // Dim dpd As DependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(Number.StringFormatProperty, GetType(NumberInputBox))
        // If dpd Is Nothing Then Exit Sub
        // dpd.AddValueChanged(Me, AddressOf CoerceText)
        DataObject.AddPastingHandler(this, Pasting);
    }

    public static readonly DependencyProperty DecimalPlacesProperty = DependencyProperty.Register("DecimalPlaces", typeof(int), typeof(NumberInputBox), new PropertyMetadata(0));
    public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(NumberInputBox), new PropertyMetadata(double.NaN));
    public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(NumberInputBox), new PropertyMetadata(double.MaxValue));
    private System.Text.RegularExpressions.Regex validchars = new("^[0-9]*$");

    public double? Value
    {
        get
        {
            if (string.IsNullOrEmpty(Text) | !double.TryParse(Text, out _)) return default;
            return Convert.ToDouble(Text);
        }
    }

    [Category("Range")]
    public int DecimalPlaces
    {
        get
        {
            return (int)GetValue(DecimalPlacesProperty);
        }

        set
        {
            SetValue(DecimalPlacesProperty, value);
        }
    }

    [Category("Range")]
    public double Minimum
    {
        get
        {
            return (double)GetValue(MinimumProperty);
        }

        set
        {
            SetValue(MinimumProperty, value);
        }
    }

    [Category("Range")]
    public double Maximum
    {
        get
        {
            return (double)GetValue(MaximumProperty);
        }

        set
        {
            SetValue(MaximumProperty, value);
        }
    }

    private void Pasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            string pastedText = (string)e.DataObject.GetData(typeof(string));
            if (!double.TryParse(pastedText, out _))
            {
                e.CancelCommand();
                return;
            }

            pastedText ??= "".Replace(Environment.NewLine, string.Empty);
            var selectedText = SelectedText;
            if (string.IsNullOrEmpty(selectedText))
            {
                SetValue(NumberInputBox.TextProperty, Math.Round(Convert.ToDouble(pastedText), DecimalPlaces).ToString());
            }
            else
            {
                SetValue(NumberInputBox.TextProperty, (GetValue(NumberInputBox.TextProperty) ?? "").ToString().Replace(selectedText, Math.Round(Convert.ToDouble(pastedText), DecimalPlaces).ToString()));
            }
        }

        e.CancelCommand();
    }

    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
    {
        if (SelectionLength == 0)
        {
            if (e.Text == System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator)
            {
                if (!(Text.Contains(System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator) | DecimalPlaces <= 0))
                {
                    base.OnPreviewTextInput(e);
                    return;
                }
            }
            else if (e.Text == "-")
            {
                if (!double.IsNaN(Minimum))
                {
                    if (Minimum < 0d)
                    {
                        if (!Text.Contains('-'))
                        {
                            if (Text.Length <= 0)
                            {
                                base.OnPreviewTextInput(e);
                                return;
                            }
                        }
                    }
                }
            }
            else if (e.Text == "." | e.Text == ",")
            {
                if (!Text.Contains(System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator))
                {
                    TextCompositionManager.StartComposition(new TextComposition(InputManager.Current, this, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator));
                }
            }
            else if (!Text.Contains(System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator))
            {
                if (validchars.IsMatch(e.Text)) // IsNumeric(e.Text) = True Then
                {
                    base.OnPreviewTextInput(e);
                    return;
                }
            }
            else
            {
                string[] data = Text.Split(System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator);
                if (data[1].Length < DecimalPlaces | SelectionLength >= Text.Length)
                {
                    if (validchars.IsMatch(e.Text)) // IsNumeric(e.Text) = True Then
                    {
                        base.OnPreviewTextInput(e);
                        return;
                    }
                }
            }
        }
        else if (e.Text == System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator)
        {
            if (DecimalPlaces > 0)
                base.OnPreviewTextInput(e);
            return;
        }
        else if (e.Text == "-")
        {
            if (!double.IsNaN(Minimum))
            {
                if (Minimum < 0d)
                {
                    base.OnPreviewTextInput(e);
                    return;
                }
            }
        }
        else if (e.Text == "." | e.Text == ",")
        {
            if (!Text.Contains(System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator))
            {
                TextCompositionManager.StartComposition(new TextComposition(InputManager.Current, this, System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator));
            }
        }
        else if (validchars.IsMatch(e.Text)) // IsNumeric(e.Text) = True Then
        {
            base.OnPreviewTextInput(e);
            return;
        }

        e.Handled = true;
    }

}
