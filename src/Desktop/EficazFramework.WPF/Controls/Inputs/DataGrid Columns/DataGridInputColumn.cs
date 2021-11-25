using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EficazFramework.Controls;

public partial class DataGridInputColumn : System.Windows.Controls.DataGridTextColumn
{

    public DataGridInputColumn()
    {
        DateStringFormat = DateInputBox.SetupDatePatternByCulture();
    }


    public int MaxLength
    {
        get
        {
            return Convert.ToInt32(GetValue(MaxLengthProperty));
        }

        set
        {
            SetValue(MaxLengthProperty, value);
        }
    }
    public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(DataGridInputColumn), new PropertyMetadata(int.MaxValue));

    public TextAlignment Alignment
    {
        get
        {
            return (TextAlignment)GetValue(AlignmentProperty);
        }

        set
        {
            SetValue(AlignmentProperty, value);
        }
    }
    public static readonly DependencyProperty AlignmentProperty = DependencyProperty.Register("Alignment", typeof(TextAlignment), typeof(DataGridInputColumn), new PropertyMetadata(TextAlignment.Justify));

    public bool Multiline
    {
        get
        {
            return Convert.ToBoolean(GetValue(MultilineProperty));
        }

        set
        {
            SetValue(MultilineProperty, value);
        }
    }
    public static readonly DependencyProperty MultilineProperty = DependencyProperty.Register("Multiline", typeof(bool), typeof(DataGridInputColumn), new PropertyMetadata(false));

    public InputMode InputMode
    {
        get { return (InputMode)GetValue(InputModeProperty); }
        set { SetValue(InputModeProperty, value); }
    }
    public static readonly DependencyProperty InputModeProperty = DependencyProperty.Register("InputMode", typeof(InputMode), typeof(DataGridInputColumn), new PropertyMetadata(InputMode.Default));



    #region NumberInput

    public int NumberDecimalPlaces
    {
        get
        {
            return Convert.ToInt32(GetValue(NumberDecimalPlacesProperty));
        }

        set
        {
            SetValue(NumberDecimalPlacesProperty, value);
        }
    }
    public static readonly DependencyProperty NumberDecimalPlacesProperty = DependencyProperty.Register("NumberDecimalPlaces", typeof(int), typeof(DataGridInputColumn), new PropertyMetadata(0));

    public double NumberMinimum
    {
        get
        {
            return Convert.ToDouble(GetValue(NumberMinimumProperty));
        }

        set
        {
            SetValue(NumberMinimumProperty, value);
        }
    }
    public static readonly DependencyProperty NumberMinimumProperty = DependencyProperty.Register("NumberMinimum", typeof(double), typeof(DataGridInputColumn), new PropertyMetadata(double.NaN));

    public double NumberMaximum
    {
        get
        {
            return Convert.ToDouble(GetValue(NumberMaximumProperty));
        }

        set
        {
            SetValue(NumberMaximumProperty, value);
        }
    }
    public static readonly DependencyProperty NumberMaximumProperty = DependencyProperty.Register("NumberMaximum", typeof(double), typeof(DataGridInputColumn), new PropertyMetadata(double.MaxValue));

    #endregion



    #region DateTimeInput

    public string DateStringFormat
    {
        get
        {
            return Convert.ToString(GetValue(DateStringFormatStringFormatProperty));
        }

        set
        {
            SetValue(DateStringFormatStringFormatProperty, value);
        }
    }
    public static readonly DependencyProperty DateStringFormatStringFormatProperty = DependencyProperty.Register("DateStringFormat", typeof(string), typeof(DataGridInputColumn), new PropertyMetadata("dd/MM/yyyy"));

    #endregion



    #region Documento

    public EDocumentos Documento
    {
        get
        {
            return (EDocumentos)GetValue(DocumentoProperty);
        }

        set
        {
            SetValue(DocumentoProperty, value);
        }
    }
    public static readonly DependencyProperty DocumentoProperty = DependencyProperty.Register("Documento", typeof(EDocumentos), typeof(DataGridInputColumn), new PropertyMetadata(EDocumentos.Custom));

    public string DocumentoUF
    {
        get
        {
            return Convert.ToString(GetValue(UFProperty));
        }

        set
        {
            SetValue(UFProperty, value);
        }
    }
    public static readonly DependencyProperty UFProperty = DependencyProperty.Register("DocumentoUF", typeof(string), typeof(DataGridInputColumn), new PropertyMetadata(null));

    #endregion


    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
        TextBlock blck = base.GenerateElement(cell, dataItem) as TextBlock;
        blck.TextAlignment = Alignment;
        return blck;
    }

    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
        switch (InputMode)
        {
            case InputMode.Default:
            default:
                TextBox tb = base.GenerateEditingElement(cell, dataItem) as TextBox;
                tb.Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
                tb.MaxLength = MaxLength;
                tb.TextAlignment = Alignment;
                tb.Style = EditingElementStyle;
                if (Multiline)
                {
                    tb.AcceptsReturn = true;
                }
                return tb;

            case InputMode.Number:
                var numtb = new NumberInputBox
                {
                    Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
                };
                numtb.SetBinding(NumberInputBox.TextProperty, Binding);
                numtb.DecimalPlaces = NumberDecimalPlaces;
                numtb.TextAlignment = Alignment;
                numtb.Maximum = NumberMaximum;
                numtb.Minimum = NumberMinimum;
                numtb.Style = EditingElementStyle;

                return numtb;

            case InputMode.Date:
                var dtbox = new DateInputBox
                {
                    Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
                };
                BindingOperations.ClearBinding(dtbox, DateInputBox.TextProperty);
                dtbox.SetBinding(DateInputBox.ValueProperty, Binding);
                dtbox.TextAlignment = Alignment;
                dtbox.StringFormat = DateStringFormat;
                dtbox.Style = EditingElementStyle;
                return dtbox;


            case InputMode.Time:
                return base.GenerateEditingElement(cell, dataItem);

            case InputMode.Documento:
                var doctb = new DocumentoInputBox
                {
                    Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentUICulture.IetfLanguageTag)
                };
                doctb.SetBinding(DocumentoInputBox.ValueProperty, Binding);
                doctb.TextAlignment = Alignment;
                doctb.Documento = Documento;
                doctb.UF = DocumentoUF;
                doctb.Style = EditingElementStyle;
                return doctb;

        }
    }
}

public enum InputMode
{
    Default = 0,
    Number = 1,
    Date = 2,
    Time = 3,
    Documento = 4,
}
