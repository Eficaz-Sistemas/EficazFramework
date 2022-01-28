using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace EficazFramework.Controls.Primitives;

[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
public abstract partial class InteractiveTextBox : TextBox
{

    public InteractiveTextBox()
    {
        SetValue(CommandPopupPropertyKey, new EficazFramework.Commands.CommandBase(PopupCommand_Executed));
    }

    internal Popup _PART_Popup = null;
    internal static readonly DependencyProperty CommandContentProperty = DependencyProperty.Register("CommandContent", typeof(object), typeof(InteractiveTextBox), new PropertyMetadata(null));
    public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat", typeof(string), typeof(InteractiveTextBox), new PropertyMetadata(null));
    private static readonly DependencyPropertyKey CommandPopupPropertyKey = DependencyProperty.RegisterReadOnly("CommandPopup", typeof(EficazFramework.Commands.CommandBase), typeof(InteractiveTextBox), new PropertyMetadata(null));
    public static readonly DependencyProperty CommandPopupProperty = CommandPopupPropertyKey.DependencyProperty;
    public static readonly DependencyProperty FindButtonVisibilityProperty = DependencyProperty.Register("FindButtonVisibility", typeof(Visibility), typeof(InteractiveTextBox), new PropertyMetadata(Visibility.Visible));
    public static readonly DependencyProperty PopupContentTemplateProperty = DependencyProperty.Register("PopupContentTemplate", typeof(DataTemplate), typeof(InteractiveTextBox), new PropertyMetadata(null));
    public static readonly DependencyProperty PopupContentProperty = DependencyProperty.Register("PopupContent", typeof(object), typeof(InteractiveTextBox), new PropertyMetadata(null));
    private static readonly DependencyPropertyKey IsPopupOpenedPropertyKey = DependencyProperty.RegisterReadOnly("IsPopupOpened", typeof(bool), typeof(InteractiveTextBox), new PropertyMetadata(false));
    public static readonly DependencyProperty IsPopupOpenedProperty = IsPopupOpenedPropertyKey.DependencyProperty;
    public static readonly DependencyProperty PopupHorizontalAlignmentProperty = DependencyProperty.Register("PopupHorizontalAlignment", typeof(HorizontalAlignment), typeof(InteractiveTextBox), new PropertyMetadata(HorizontalAlignment.Left));
    public static readonly DependencyProperty PopupMaxWidthProperty = DependencyProperty.Register("PopupMaxWidth", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));
    public static readonly DependencyProperty PopupMaxHeightProperty = DependencyProperty.Register("PopupMaxHeight", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));
    public static readonly DependencyProperty PopupMinHeightProperty = DependencyProperty.Register("PopupMinHeight", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));
    public static readonly DependencyProperty PopupMinWidthProperty = DependencyProperty.Register("PopupMinWidth", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));

    [Category("Appearance")]
    public object CommandContent
    {
        get => GetValue(CommandContentProperty);
        set => SetValue(CommandContentProperty, value);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public EficazFramework.Commands.CommandBase CommandPopup => (Commands.CommandBase)GetValue(CommandPopupProperty);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsPopupOpened
    {
        get => (bool)GetValue(IsPopupOpenedProperty);
        private set => SetValue(IsPopupOpenedPropertyKey, value);
    }

    [Category("Data")]
    public string StringFormat
    {
        get => (string)GetValue(StringFormatProperty);
        set => SetValue(StringFormatProperty, value);
    }

    [Category("Appearance")]
    public Visibility FindButtonVisibility
    {
        get => (Visibility)GetValue(FindButtonVisibilityProperty);
        set => SetValue(FindButtonVisibilityProperty, value);
    }

    public object PopupContent
    {
        get => (object)GetValue(PopupContentProperty);
        set => SetValue(PopupContentProperty, value);
    }

    public DataTemplate PopupContentTemplate
    {
        get => (DataTemplate)GetValue(PopupContentTemplateProperty);
        set => SetValue(PopupContentTemplateProperty, value);
    }

    public HorizontalAlignment PopupHorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(PopupHorizontalAlignmentProperty);
        set => SetValue(PopupHorizontalAlignmentProperty, value);
    }

    public double PopupMinWidth
    {
        get => (double)GetValue(PopupMinWidthProperty);
        set => SetValue(PopupMinWidthProperty, value);
    }

    public double PopupMinHeight
    {
        get => (double)GetValue(PopupMinHeightProperty);
        set => SetValue(PopupMinHeightProperty, value);
    }

    public double PopupMaxWidth
    {
        get => (double)GetValue(PopupMaxWidthProperty);
        set => SetValue(PopupMaxWidthProperty, value);
    }

    public double PopupMaxHeight
    {
        get => (double)GetValue(PopupMaxHeightProperty);
        set => SetValue(PopupMaxHeightProperty, value);
    }

    private void PopupCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e)
    {
        if (IsReadOnly == false & IsEnabled == true & IsPopupOpened == false & _PART_Popup != null)  // Open
        {
            OpenPopup((e.Parameter as bool?) ?? false);
        }
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _PART_Popup = (Popup)GetTemplateChild("PART_Popup");
        //FrameworkElement pp = (FrameworkElement)GetValue(PopupContentProperty);
        //var ppstyle = GetValue(PopupContentStyleProperty);
        //if (ppstyle != null) pp.Style = (Style)ppstyle;
        if (PopupContent != null && _PART_Popup != null)
        {
            //_PART_Popup.Child = pp;
            _PART_Popup.PlacementTarget = this;
        }
    }

    internal bool f12pressed = false;
    protected override void OnPreviewKeyUp(KeyEventArgs e)
    {
        base.OnPreviewKeyUp(e);
        f12pressed = false;
        if (e.KeyboardDevice.Modifiers == ModifierKeys.None)
        {
            Debug.WriteLine($"Key: {e.Key} | Popup: {IsPopupOpened}");


            if (e.Key == Key.F12 & IsReadOnly == false & IsEnabled == true & IsPopupOpened == false & _PART_Popup != null)  // Open
            {
                f12pressed = true;
                OpenPopup(false);
            }
            else if (e.Key == Key.Enter & IsPopupOpened == true) // Commit Selection
            {
                CommitSelection();
                ClosePopup();
                e.Handled = true; // Supress MDIWindow FocusManager
            }
            else if (e.Key == Key.Escape & IsPopupOpened == true) // Commit Selection
            {
                ClosePopup();
                e.Handled = true; // Supress MDIWindow FocusManager
            }
        }
    }

    protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
        base.OnLostKeyboardFocus(e);
        if (_PART_Popup == null || _PART_Popup.IsKeyboardFocusWithin) return;
        //var focused = FocusManager.GetFocusedElement(System.Windows.Application.Current.MainWindow);
        //if (!object.ReferenceEquals(focused, this))
        ClosePopup(false);
    }

    private void OpenPopup(bool? movefocus = true)
    {
        //_PART_Popup.IsOpen = true;
        SetValue(IsPopupOpenedPropertyKey, true);
        MDIWindow.SetAcceptEnterKeyNavigation(this, false);
        try
        {
            if (movefocus == true)
                _PART_Popup.Child.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }
        catch
        {
        }
        Debug.WriteLine($"Popup Opened (from InteractiveTextBox). Autofocus {movefocus}");
    }

    internal void ClosePopup(bool movefocus = true)
    {
        SetValue(IsPopupOpenedPropertyKey, false);
        MDIWindow.SetAcceptEnterKeyNavigation(this, true);
        var focused = Keyboard.FocusedElement;
        if (focused is not TextBox)
            if (movefocus) MoveFocus(new TraversalRequest(FocusNavigationDirection.First));

        Debug.WriteLine("Popup Closed (from InteractiveTextBox)");

    }

    internal abstract void CommitSelection();

}
