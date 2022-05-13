using EficazFramework.Extensions;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;

namespace EficazFramework.Controls;

public partial class DateInputBox : EficazFramework.Controls.Primitives.InteractiveTextBox
{
    public DateInputBox() : base()
    {
        // # MASK BEHAVIOR:
        var behaviorsColl = Microsoft.Xaml.Behaviors.Interaction.GetBehaviors(this);
        _maskBehavior = new EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior();
        behaviorsColl.Add(_maskBehavior);
        var dpd = DependencyPropertyDescriptor.FromProperty(DateInputBox.StringFormatProperty, typeof(DateInputBox));
        if (dpd is null)
            return;
        dpd.AddValueChanged(this, (_, __) => SyncStringFormatAndMask());
        StringFormat = SetupDatePatternByCulture();
    }

    private char[] _dateMasks = new[] { '/', '-' };
    private EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior _maskBehavior = default;
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(DateTime?), typeof(DateInputBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged, null, true, UpdateSourceTrigger.PropertyChanged));

    public DateTime? Value
    {
        get => (DateTime?)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    private static void OnValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        DateInputBox input = (DateInputBox)source;
        string formated_value = null;
        if (string.IsNullOrEmpty(input.StringFormat))
            input.StringFormat = SetupDatePatternByCulture();
        if (e.NewValue is object)
            formated_value = string.Format("{0:" + input.StringFormat + "}", e.NewValue);
        if (input.Text != formated_value)
            input.Text = formated_value;
    }

    internal static string SetupDatePatternByCulture()
    {
        string pattern = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern; // MULTI LANGUAGE SUPPORT "dd/MM/yyyy"
        var p = pattern.Split(Convert.ToChar(System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.DateSeparator));
        var resultPattern = new StringBuilder();
        for (int i = 0, loopTo = p.Length - 1; i <= loopTo; i++)
        {
            if (p[i].Length == 1)
                p[i] = p[i] + p[i];
            resultPattern.Append(p[i]);
            if (!(i == p.Length - 1))
                resultPattern.Append(System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.DateSeparator);
        }

        string finalStrMask = resultPattern.ToString();
        return finalStrMask;
    }

    private void SyncStringFormatAndMask()
    {
        if (string.IsNullOrEmpty(StringFormat))
        {
            _maskBehavior.InputMask = null;
            return;
        }

        var mask = new StringBuilder();
        string resultformat = StringFormat;
        if (resultformat == "d") { resultformat = SetupDatePatternByCulture(); }

        for (int i = 0, loopTo = resultformat.Length - 1; i <= loopTo; i++)
        {
            if (!_dateMasks.Contains(resultformat[i]))
                mask.Append('0');
            else
                mask.Append(resultformat[i]);
        }

        _maskBehavior.InputMask = mask.ToString();
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        if (IsKeyboardFocusWithin == true)
            return;
        if (string.IsNullOrEmpty(Text))
        {
            if (Value.HasValue == true)
                SetValue(ValueProperty, default);
        }
        else
        {
            DateTime tmp_date;
            if (DateTime.TryParse(Text.Replace(_maskBehavior.PromptChar, new char()), out tmp_date))
            {
                if (StringFormat == "MM/yyyy")
                {
                    SetValue(ValueProperty, tmp_date.MonthStartDate());
                }
                else if (StringFormat == "yyyy")
                {
                    SetValue(ValueProperty, tmp_date.YearEndDate());
                }
                else
                {
                    SetValue(ValueProperty, tmp_date);
                }
            }
            else
            {
                SetValue(ValueProperty, default);
                Text = null;
            }
        }
    }

    protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
    {
        base.OnMouseDoubleClick(e);
        CalendarDayButton cdbt = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor<CalendarDayButton>((DependencyObject)e.Source);
        if (cdbt is object)
            CommitSelection();
    }

    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        base.OnPreviewKeyDown(e);
        if (Value.HasValue == false)
            return;
        bool shift = e.KeyboardDevice.Modifiers == ModifierKeys.Shift;
        bool ctrl = e.KeyboardDevice.Modifiers == ModifierKeys.Control;
        if (e.Key == Key.Up)
        {
            if (shift == false)
            {
                if (ctrl == false)
                    Value = Value.Value.AddDays(1d);
                else
                    Value = Value.Value.AddYears(1);
            }
            else
            {
                if (shift == true)
                    Value = Value.Value.AddMonths(1);
            }

            e.Handled = true;
        }
        else if (e.Key == Key.Down)
        {
            if (shift == false)
            {
                if (ctrl == false)
                    Value = Value.Value.AddDays(-1);
                else
                    Value = Value.Value.AddYears(-1);
            }
            else
            {
                if (shift == true)
                    Value = Value.Value.AddMonths(-1);
            }

            e.Handled = true;
        }
    }

    internal override void CommitSelection()
    {
        SetValue(ValueProperty, ((System.Windows.Controls.Calendar)PopupContent).SelectedDate);
        ClosePopup();
    }

}
