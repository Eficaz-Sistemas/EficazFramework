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


    public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat", typeof(string), typeof(InteractiveTextBox), new PropertyMetadata(null));

    internal static readonly DependencyProperty CommandContentTemplateProperty = DependencyProperty.Register("CommandContentTemplate", typeof(DataTemplate), typeof(InteractiveTextBox), new PropertyMetadata(null));
    private static readonly DependencyPropertyKey CommandPopupPropertyKey = DependencyProperty.RegisterReadOnly("CommandPopup", typeof(EficazFramework.Commands.CommandBase), typeof(InteractiveTextBox), new PropertyMetadata(null));
    public static readonly DependencyProperty CommandPopupProperty = CommandPopupPropertyKey.DependencyProperty;
    public static readonly DependencyProperty FindButtonVisibilityProperty = DependencyProperty.Register("FindButtonVisibility", typeof(Visibility), typeof(InteractiveTextBox), new PropertyMetadata(Visibility.Visible));
    
    public static readonly DependencyProperty PopupContentTemplateProperty = DependencyProperty.Register("PopupContentTemplate", typeof(DataTemplate), typeof(InteractiveTextBox), new PropertyMetadata(null));

    internal Popup _PART_Popup = null;   
    public static readonly DependencyProperty PopupHorizontalAlignmentProperty = DependencyProperty.Register("PopupHorizontalAlignment", typeof(HorizontalAlignment), typeof(InteractiveTextBox), new PropertyMetadata(HorizontalAlignment.Left));
    public static readonly DependencyProperty PopupMaxWidthProperty = DependencyProperty.Register("PopupMaxWidth", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));
    public static readonly DependencyProperty PopupMaxHeightProperty = DependencyProperty.Register("PopupMaxHeight", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));
    public static readonly DependencyProperty PopupMinHeightProperty = DependencyProperty.Register("PopupMinHeight", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));
    public static readonly DependencyProperty PopupMinWidthProperty = DependencyProperty.Register("PopupMinWidth", typeof(double), typeof(InteractiveTextBox), new PropertyMetadata(double.NaN));

    private static readonly DependencyPropertyKey IsEmptyAndNotFocusedPropertyKey = DependencyProperty.RegisterReadOnly("IsEmptyAndNotFocused", typeof(bool), typeof(InteractiveTextBox), new PropertyMetadata(true));
    public static readonly DependencyProperty IsEmptyAndNotFocusedProperty = IsEmptyAndNotFocusedPropertyKey.DependencyProperty;


    [Category("Appearance")]
    public DataTemplate CommandContentTemplate
    {
        get => (DataTemplate)GetValue(CommandContentTemplateProperty);
        set => SetValue(CommandContentTemplateProperty, value);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public EficazFramework.Commands.CommandBase CommandPopup => (Commands.CommandBase)GetValue(CommandPopupProperty);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsEmptyAndNotFocused => (bool)GetValue(IsEmptyAndNotFocusedProperty);

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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsPopupOpened => _PART_Popup?.IsOpen ?? false;

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

    public FrameworkElement PopupContent
    {
        get
        {
            if (_PART_Popup == null)
                return null;

            return XAML.Utilities.VisualTreeHelpers.FindVisualChild<FrameworkElement>(_PART_Popup.Child);
        }
    }

    private void PopupCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e)
        {
            if (IsReadOnly == false & IsEnabled == true & IsPopupOpened == false & _PART_Popup != null)  // Open
            {
                f12pressed = true;
                OpenPopup((e.Parameter as bool?) ?? false);
            }
        }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _PART_Popup = (Popup)GetTemplateChild("PART_Popup");
        if (_PART_Popup != null)
            _PART_Popup.PlacementTarget = this;
    }

    internal bool f12pressed = false;

    private void OpenPopup(bool? movefocus = true)
    {
        _PART_Popup.IsOpen = true;
        MDIWindow.SetAcceptEnterKeyNavigation(this, false);
        try
        {
            if (movefocus == true)
                _PART_Popup.Child.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }
        catch { }
    }

    internal void ClosePopup(bool movefocus = true)
    {
        _PART_Popup.IsOpen = false;
        MDIWindow.SetAcceptEnterKeyNavigation(this, true);
        var focused = Keyboard.FocusedElement;
        if (focused is not TextBox)
            if (movefocus) MoveFocus(new TraversalRequest(FocusNavigationDirection.First));

    }

    internal abstract void CommitSelection();

    private void UpdateIsEmpty() =>
        SetValue(IsEmptyAndNotFocusedPropertyKey, ((!System.Text.RegularExpressions.Regex.IsMatch(Text, "[A-Za-z0-9]")) && (!IsFocused)) || (string.IsNullOrEmpty(Text) && (!IsFocused)));

    protected override void OnPreviewKeyUp(KeyEventArgs e)
    {
        base.OnPreviewKeyUp(e);
        f12pressed = false;
        if (e.KeyboardDevice.Modifiers == ModifierKeys.None)
        {
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

    protected override void OnGotFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        UpdateIsEmpty();
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        UpdateIsEmpty();
    }

    protected override void OnTextInput(TextCompositionEventArgs e)
    {
        base.OnTextInput(e);
        UpdateIsEmpty();
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);
        UpdateIsEmpty();
    }
}
