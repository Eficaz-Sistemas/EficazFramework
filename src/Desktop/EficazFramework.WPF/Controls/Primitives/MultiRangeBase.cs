using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices; // Install-Package Microsoft.VisualBasic

namespace EficazFramework.Controls.Primitives;

/// <summary>Represents an element that has a start and end value within a specific range. </summary>
public abstract partial class MultiRangeBase : Control
{
    public static readonly RoutedEvent StartValueChangedEvent;
    public static readonly RoutedEvent EndValueChangedEvent;
    public static readonly DependencyProperty MinimumProperty;
    public static readonly DependencyProperty MaximumProperty;
    public static readonly DependencyProperty StartValueProperty;
    public static readonly DependencyProperty EndValueProperty;
    public static readonly DependencyProperty LargeChangeProperty;
    public static readonly DependencyProperty SmallChangeProperty;

    [Bindable(true)]
    [Category("Behavior")]
    public double Minimum
    {
        get
        {
            return Conversions.ToDouble(GetValue(MinimumProperty));
        }

        set
        {
            SetValue(MinimumProperty, value);
        }
    }

    [Bindable(true)]
    [Category("Behavior")]
    public double Maximum
    {
        get
        {
            return Conversions.ToDouble(GetValue(MaximumProperty));
        }

        set
        {
            SetValue(MaximumProperty, value);
        }
    }

    [Bindable(true)]
    [Category("Behavior")]
    public double StartValue
    {
        get
        {
            return Conversions.ToDouble(GetValue(StartValueProperty));
        }

        set
        {
            SetValue(StartValueProperty, value);
        }
    }

    [Bindable(true)]
    [Category("Behavior")]
    public double EndValue
    {
        get
        {
            return Conversions.ToDouble(GetValue(EndValueProperty));
        }

        set
        {
            SetValue(EndValueProperty, value);
        }
    }

    [Bindable(true)]
    [Category("Behavior")]
    public double LargeChange
    {
        get
        {
            return Conversions.ToDouble(GetValue(LargeChangeProperty));
        }

        set
        {
            SetValue(LargeChangeProperty, value);
        }
    }

    [Bindable(true)]
    [Category("Behavior")]
    public double SmallChange
    {
        get
        {
            return Conversions.ToDouble(GetValue(SmallChangeProperty));
        }

        set
        {
            SetValue(SmallChangeProperty, value);
        }
    }

    static MultiRangeBase()
    {
        StartValueChangedEvent = EventManager.RegisterRoutedEvent("StartValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double>), typeof(MultiRangeBase));
        EndValueChangedEvent = EventManager.RegisterRoutedEvent("EndValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double>), typeof(MultiRangeBase));
        MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(MultiRangeBase), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(OnMinimumChanged)), new ValidateValueCallback(IsValidDoubleValue));
        MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(MultiRangeBase), new FrameworkPropertyMetadata(1, new PropertyChangedCallback(OnMaximumChanged), new CoerceValueCallback(CoerceMaximum)), new ValidateValueCallback(IsValidDoubleValue));
        StartValueProperty = DependencyProperty.Register("StartValue", typeof(double), typeof(MultiRangeBase), new FrameworkPropertyMetadata(0.25d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(OnStartValueChanged), new CoerceValueCallback(CoerceToRange)), new ValidateValueCallback(IsValidDoubleValue));
        EndValueProperty = DependencyProperty.Register("EndValue", typeof(double), typeof(MultiRangeBase), new FrameworkPropertyMetadata(0.75d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(OnEndValueChanged), new CoerceValueCallback(CoerceToRange)), new ValidateValueCallback(IsValidDoubleValue));
        LargeChangeProperty = DependencyProperty.Register("LargeChange", typeof(double), typeof(MultiRangeBase), new FrameworkPropertyMetadata(1), new ValidateValueCallback(IsValidChange));
        SmallChangeProperty = DependencyProperty.Register("SmallChange", typeof(double), typeof(MultiRangeBase), new FrameworkPropertyMetadata(0.1d), new ValidateValueCallback(IsValidChange));
        // UIElement.IsEnabledProperty.OverrideMetadata(GetType(MultiRangeBase), New UIPropertyMetadata(New PropertyChangedCallback(AddressOf Control.OnVisualStatePropertyChanged)))
        // UIElement.IsMouseOverPropertyKey.OverrideMetadata(GetType(MultiRangeBase), New UIPropertyMetadata(New PropertyChangedCallback(AddressOf Control.OnVisualStatePropertyChanged)))
    }

    private static object CoerceMaximum(DependencyObject d, object value)
    {
        double minimum = ((MultiRangeBase)d).Minimum;
        if (Conversions.ToDouble(value) >= minimum)
        {
            return value;
        }

        return minimum;
    }

    internal static object CoerceToRange(DependencyObject d, object value)
    {
        MultiRangeBase MultiRangeBase = (MultiRangeBase)d;
        double minimum = MultiRangeBase.Minimum;
        double num = Conversions.ToDouble(value);
        if (num < minimum)
        {
            return minimum;
        }

        double maximum = MultiRangeBase.Maximum;
        if (num <= maximum)
        {
            return value;
        }

        return maximum;
    }

    private static bool IsValidChange(object value)
    {
        double num = Conversions.ToDouble(value);
        if (!IsValidDoubleValue(value))
        {
            return false;
        }

        return num >= 0d;
    }

    private static bool IsValidDoubleValue(object value)
    {
        double num = Conversions.ToDouble(value);
        if (double.IsNaN(num))
            return false;
        return !double.IsInfinity(num);
    }

    private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MultiRangeBase element = (MultiRangeBase)d;
        element.CoerceValue(StartValueProperty);
        element.CoerceValue(EndValueProperty);
        element.OnMaximumChanged(Conversions.ToDouble(e.OldValue), Conversions.ToDouble(e.NewValue));
    }

    protected virtual void OnMaximumChanged(double oldMaximum, double newMaximum)
    {
    }

    private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MultiRangeBase element = (MultiRangeBase)d;
        element.CoerceValue(MaximumProperty);
        element.CoerceValue(StartValueProperty);
        element.CoerceValue(EndValueProperty);
        element.OnMinimumChanged(Conversions.ToDouble(e.OldValue), Conversions.ToDouble(e.NewValue));
    }

    protected virtual void OnMinimumChanged(double oldMinimum, double newMinimum)
    {
    }

    private static void OnStartValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MultiRangeBase element = (MultiRangeBase)d;
        element.OnStartValueChanged(Conversions.ToDouble(e.OldValue), Conversions.ToDouble(e.NewValue));
    }

    protected virtual void OnStartValueChanged(double oldValue, double newValue)
    {
        var routedPropertyChangedEventArg = new RoutedPropertyChangedEventArgs<double>(oldValue, newValue) { RoutedEvent = StartValueChangedEvent };
        RaiseEvent(routedPropertyChangedEventArg);
    }

    private static void OnEndValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MultiRangeBase element = (MultiRangeBase)d;
        element.OnEndValueChanged(Conversions.ToDouble(e.OldValue), Conversions.ToDouble(e.NewValue));
    }

    protected virtual void OnEndValueChanged(double oldValue, double newValue)
    {
        var routedPropertyChangedEventArg = new RoutedPropertyChangedEventArgs<double>(oldValue, newValue) { RoutedEvent = EndValueChangedEvent };
        RaiseEvent(routedPropertyChangedEventArg);
    }

    public override string ToString()
    {
        string str = GetType().ToString();
        double minimum = double.NaN;
        double maximum = double.NaN;
        double startvalue = double.NaN;
        double endvalue = double.NaN;
        bool flag = false;
        if (!CheckAccess())
        {
            Dispatcher.Invoke(DispatcherPriority.Send, new TimeSpan(0, 0, 0, 0, 20), new DispatcherOperationCallback((o) =>
            {
                minimum = Minimum;
                maximum = Maximum;
                startvalue = StartValue;
                endvalue = EndValue;
                flag = true;
                return null;
            }), null);
        }
        else
        {
            minimum = Minimum;
            maximum = Maximum;
            startvalue = StartValue;
            endvalue = EndValue;
            flag = true;
        }

        if (!flag)
        {
            return str;
        }

        return string.Format("Min.: {0} | Start: {1} | End: {2} | Máx: {3}", str, minimum, maximum, startvalue, endvalue);
    }

    [Category("Behavior")]
    public event RoutedPropertyChangedEventHandler<double> StartValueChanged
    {
        add
        {
            AddHandler(StartValueChangedEvent, value);
        }

        remove
        {
            RemoveHandler(StartValueChangedEvent, value);
        }
    }

    void OnStartValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        RaiseEvent(e);
    }

    [Category("Behavior")]
    public event RoutedPropertyChangedEventHandler<double> EndValueChanged
    {
        add
        {
            AddHandler(EndValueChangedEvent, value);
        }

        remove
        {
            RemoveHandler(EndValueChangedEvent, value);
        }
    }

    void OnEndValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        RaiseEvent(e);
    }
}
