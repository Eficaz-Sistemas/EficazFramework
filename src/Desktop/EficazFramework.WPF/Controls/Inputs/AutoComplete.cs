using EficazFramework.Extensions;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Controls;

public partial class AutoComplete : Primitives.InteractiveTextBox
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public AutoComplete() : base()
    {
        SetValue(ClearCommandPropertyKey, new EficazFramework.Commands.CommandBase(ClearCommand_Execute));
    }

    private bool _passliteral = false;
    private System.Threading.CancellationTokenSource _cancellationTokenSource;
    private ListView _PART_ListView = null;
    private ProgressBar _PART_ProgreessBar = null;
    private bool _lockSyncText = false;
    private bool _executed = false;
    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(AutoComplete), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueOrContentChanged, null, true, UpdateSourceTrigger.PropertyChanged));
    public static readonly DependencyProperty ValuePathProperty = DependencyProperty.Register("ValuePath", typeof(string), typeof(AutoComplete), new PropertyMetadata(null));
    public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(AutoComplete), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueOrContentChanged, null, true, UpdateSourceTrigger.PropertyChanged));
    public static readonly DependencyProperty ContentPathProperty = DependencyProperty.Register("ContentPath", typeof(string), typeof(AutoComplete), new PropertyMetadata(null));
    public static readonly DependencyProperty ContentStringFormatProperty = DependencyProperty.Register("ContentStringFormat", typeof(string), typeof(AutoComplete), new PropertyMetadata(null));
    public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(AutoComplete), new PropertyMetadata(null));
    public static readonly DependencyProperty ItemsPanelProperty = DependencyProperty.Register("ItemsPanel", typeof(ItemsPanelTemplate), typeof(AutoComplete), new PropertyMetadata(null));
    private static readonly DependencyPropertyKey ClearCommandPropertyKey = DependencyProperty.RegisterReadOnly("ClearCommand", typeof(EficazFramework.Commands.CommandBase), typeof(AutoComplete), new PropertyMetadata(null));
    public static readonly DependencyProperty ClearCommandProperty = ClearCommandPropertyKey.DependencyProperty;
    public static readonly DependencyProperty ValueIgnoresProperty = DependencyProperty.Register("ValueIgnores", typeof(bool), typeof(AutoComplete), new PropertyMetadata(true));
    public static readonly DependencyProperty FreeTextProperty = DependencyProperty.Register("FreeText", typeof(bool), typeof(AutoComplete), new PropertyMetadata(false));
    public static readonly DependencyProperty FindActionProperty = DependencyProperty.Register("FindAction", typeof(Action<object, Events.FindRequestEventArgs>), typeof(AutoComplete), new PropertyMetadata(null));
    public static readonly DependencyProperty SelectionChangedActionProperty = DependencyProperty.Register("SelectionChangedAction", typeof(Action<object, SelectionChangedEventArgs>), typeof(AutoComplete), new PropertyMetadata(null));

    public bool FreeText
    {
        get => (bool)GetValue(FreeTextProperty);
        set => SetValue(FreeTextProperty, value);
    }

    public object Value
    {
        get => GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public string ValuePath
    {
        get => (string)GetValue(ValuePathProperty);
        set => SetValue(ValuePathProperty, value);
    }

    public bool ValueIgnores
    {
        get => (bool)GetValue(ValueIgnoresProperty);
        set => SetValue(ValueIgnoresProperty, value);
    }

    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public string ContentPath
    {
        get => (string)GetValue(ContentPathProperty);
        set => SetValue(ContentPathProperty, value);
    }

    public string ContentStringFormat
    {
        get => (string)GetValue(ContentStringFormatProperty);
        set => SetValue(ContentStringFormatProperty, value);
    }

    public DataTemplate ItemTemplate
    {
        get => (DataTemplate)GetValue(ItemTemplateProperty);
        set => SetValue(ItemTemplateProperty, value);
    }

    public ItemsPanelTemplate ItemsPanel
    {
        get => (ItemsPanelTemplate)GetValue(ItemsPanelProperty);
        set => SetValue(ItemsPanelProperty, value);
    }

    public EficazFramework.Commands.CommandBase ClearCommand => (Commands.CommandBase)GetValue(ClearCommandProperty);

    private static void OnValueOrContentChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        AutoComplete input = (AutoComplete)source;
        input.SyncText();
    }

    private void ClearCommand_Execute(object sender, EficazFramework.Events.ExecuteEventArgs e)
    {
        Value = null;
        Content = null;
        Text = null;
        _cancellationTokenSource = new System.Threading.CancellationTokenSource();
        if (IsPopupOpened == true)
            ClosePopup();
        MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }

    private void PopupOpened(object sender, EventArgs e)
    {
        _PART_ListView = ((Grid)((Border)PopupContent).Child).Children[1] as ListView;
        _PART_ListView.ItemsSource = null;
        _PART_ListView.ItemTemplate = ItemTemplate;

        _PART_ProgreessBar = ((Grid)((Border)PopupContent).Child).Children[0] as ProgressBar;

        if (_PART_Popup != null)
            _PART_Popup.Width = Math.Max((Double.IsNaN(ActualWidth) ? 0 : ActualWidth), (Double.IsNaN(PopupMaxWidth) ? 0 : PopupMaxWidth));

        if (_PART_ProgreessBar.Visibility == Visibility.Collapsed)
            _PART_ProgreessBar.Visibility = Visibility.Visible;

        if (DesignerProperties.GetIsInDesignMode(this) == false)
            StartFind();
    }

    private void PopupClosed(object sender, EventArgs e) =>
        _passliteral = false;

    public Action<object, Events.FindRequestEventArgs> FindAction
    {
        get => (Action<object, Events.FindRequestEventArgs>)GetValue(FindActionProperty);
        set => SetValue(FindActionProperty, value);
    }

    public Action<object, SelectionChangedEventArgs> SelectionChangedAction
    {
        get => (Action<object, SelectionChangedEventArgs>)GetValue(SelectionChangedActionProperty);
        set => SetValue(SelectionChangedActionProperty, value);
    }

    private void SyncText()
    {
        if (FreeText == true)
            return;

        if (_lockSyncText == true)
            return;

        string valueString = null;
        string contentString = null;
        if (Content != null)
        {
            if (string.IsNullOrEmpty(ContentStringFormat))
                contentString = Content.ToString();
            else
                contentString = string.Format(ContentStringFormat, Content);
        }

        if (Value != null)
            valueString = Convert.ToString(Value);

        string resultingText;
        if (string.IsNullOrEmpty(StringFormat) | string.IsNullOrEmpty(valueString))
            resultingText = contentString;
        else
            resultingText = string.Format(StringFormat, valueString, contentString);
        if (Text != resultingText)
            Text = resultingText;
    }

    private async void StartFind()
    {
        if (_cancellationTokenSource != null)
            _cancellationTokenSource.Cancel();

        await Task.Delay(100); // assegurando que a Task será cancelada a tempo...
        _cancellationTokenSource = new System.Threading.CancellationTokenSource();
        try
        {
            await EficazFramework.Commands.DelayedAction.InvokeAsync(Find, 125, _cancellationTokenSource.Token);
        }
        catch (OperationCanceledException)
        {
            _executed = false;
        }
    }

    private async void Find()
    {
        Dispatcher.Invoke(() =>
        {
            if (_PART_ProgreessBar.Visibility == Visibility.Collapsed)
                _PART_ProgreessBar.Visibility = Visibility.Visible;
        });

        try
        {
            string literal = "";
            await Dispatcher.InvokeAsync(() =>
            {
                if (_passliteral == true)
                    if (f12pressed == false) literal = Text;
            });

            System.Threading.CancellationToken tk = default;
            if (_cancellationTokenSource != null)
                tk = _cancellationTokenSource.Token;

            var args = new Events.FindRequestEventArgs(literal, tk);
            if (_cancellationTokenSource?.Token.IsCancellationRequested == true)
                return;

            if (_executed == true)
                return;

            var rr = await Dispatcher.InvokeAsync(() =>
            {
                _executed = true;
                FindAction?.Invoke(this, args);
                return true;
            });

            // TODO: RaiseEvent for Find data...
            while (args.Completed == false)
                await Task.Delay(1);

            if (_cancellationTokenSource?.Token.IsCancellationRequested == true)
                return;

            Dispatcher.Invoke(() =>
            {
                _PART_ListView.ItemsSource = (IEnumerable)args.Data;
                _PART_ProgreessBar.Visibility = Visibility.Collapsed;
                _executed = false;
            });
            _executed = false;
        }
        catch (OperationCanceledException)
        {
            _executed = false;
        }
        catch (Exception ex)
        {
            _executed = false;
            Debug.WriteLine(ex.ToString());
        }
        finally
        {
        }

        Dispatcher.Invoke(() =>
        {
            if (FreeText == true)
                if (_PART_ListView.ItemsSource != null)
                {
                    try
                    {
                        if (((IList)_PART_ListView.ItemsSource).Count > 0)
                            CommandPopup.Execute(false);
                        else
                            ClosePopup();
                    }
                    catch
                    {
                        ClosePopup();
                    }
                }
                else
                    ClosePopup();
        }); // ex As Exception

        if (_cancellationTokenSource != null)
            _cancellationTokenSource.Dispose();
        _cancellationTokenSource = null;
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _PART_Popup = GetTemplateChild("PART_Popup") as System.Windows.Controls.Primitives.Popup;

        if (double.IsNaN(PopupMaxWidth)) PopupMaxWidth = RenderSize.Width;
        if (_PART_Popup != null)
        {
            _PART_Popup.Opened += PopupOpened;
            _PART_Popup.Closed += PopupClosed;
        }
        //if (_PART_ListView != null)
        //{
        //    _PART_ListView = (ListView)((Grid)PopupContent).Children[0];
        //    _PART_ListView.SetBinding(ListView.ItemsSourceProperty, new Binding("ItemsSource") { Source = this });
        //    _PART_ListView.SetBinding(ListView.ItemTemplateProperty, new Binding("ItemTemplate") { Source = this });
        //}

        //if (PopupContent != null)
        //{
        //    var loader = (ProgressBar)((Grid)PopupContent).Children[1];
        //    var loader_binding = new Binding("IsLoading") { Source = this, Converter = (IValueConverter)FindResource("BooleanToVisibilityConverter") };
        //    loader.SetBinding(ProgressBar.VisibilityProperty, loader_binding);
        //}
    }

    protected override Size MeasureOverride(Size constraint)
    {
        Size result = base.MeasureOverride(constraint);
        if (double.IsNaN(PopupMaxWidth)) PopupMaxWidth = result.Width;
        return result;
    }

    protected override void OnTextInput(TextCompositionEventArgs e)
    {
        base.OnTextInput(e);
        _passliteral = true;
        if (e.Text != ((char)13).ToString())
        {
            if (Text.Length > 0)
            {
                if (FreeText == false)
                {
                    if (_PART_Popup != null && _PART_Popup.IsOpen == false)
                        CommandPopup.Execute(false);
                    else
                        StartFind();
                }
                else
                {
                    StartFind();
                }
            }
            else
            {
                ClosePopup();
                //SyncText();
                SetValue(ContentProperty, null);
                SetValue(ValueProperty, null);
            }
        }
    }

    protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
        base.OnPreviewLostKeyboardFocus(e);
        if (_PART_Popup == null)
            return;

        if (_PART_Popup.IsKeyboardFocusWithin)
            return;

        if (FreeText == false)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Value = null;
                Content = null;
            }
            else if (IsPopupOpened == false || _PART_Popup.IsKeyboardFocusWithin == false)
                SyncText();
        }

        if (_cancellationTokenSource != null)
            _cancellationTokenSource.Cancel();
    }

    protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
    {
        base.OnMouseDoubleClick(e);
        ListViewItem it = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor<ListViewItem>((DependencyObject)e.Source);
        if (it != null)
            CommitSelection();
    }

    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        base.OnPreviewKeyDown(e);
        _passliteral = true;
        if (e.Key == Key.Back)
        {
            if (Text.Length > 0)
            {
                if (FreeText == false)
                {
                    if (_PART_Popup.IsOpen == false)
                        CommandPopup.Execute(false);
                    else
                        StartFind();
                }
                else
                {
                    StartFind();
                }
            }
            else
            {
                ClosePopup();
                //SyncText();
                SetValue(ContentProperty, null);
                SetValue(ValueProperty, null);
            }

            return;
        }

        if (IsPopupOpened == false)
            return;
        if (IsPopupOpened == true)
        {
            if (e.Key == Key.Up)
            {
                if (_PART_ListView.Items.CurrentPosition > 0)
                    _PART_ListView.Items.MoveCurrentToPrevious();
            }
            else if (e.Key == Key.Down)
            {
                if (_PART_ListView.Items.CurrentPosition < _PART_ListView.Items.Count - 1)
                    _PART_ListView.Items.MoveCurrentToNext();
            }
            else if (e.Key == Key.Home)
            {
                _PART_ListView.Items.MoveCurrentToFirst();
            }
            else if (e.Key == Key.End)
            {
                _PART_ListView.Items.MoveCurrentToLast();
            }

            try
            {
                _PART_ListView.ScrollIntoView(_PART_ListView.SelectedItem);
            }
            catch (Exception)
            {
            }
        }
    }

    internal override void CommitSelection()
    {
        // TODO: Get selected item from list...
        _lockSyncText = true;
        if (_PART_ListView.SelectedItem != null)
        {
            try
            {
                object item = _PART_ListView.SelectedItem;
                if (FreeText == false)
                {
                    if (!string.IsNullOrEmpty(ValuePath))
                        SetValue(ValueProperty, ObjectExtensions.GetPropertyValue(item, ValuePath));
                    else
                    {
                        if (ValueIgnores == false)
                            SetValue(ValueProperty, item);
                        else
                            SetValue(ValueProperty, default);
                    }

                    if (!string.IsNullOrEmpty(ContentPath))
                        SetValue(ContentProperty, ObjectExtensions.GetPropertyValue(item, ContentPath));
                    else
                        SetValue(ContentProperty, item);
                }
                else if (item != null)
                {
                    if (!string.IsNullOrEmpty(ContentPath))
                    {
                        SetValue(TextProperty, ObjectExtensions.GetPropertyValue(item, ContentPath));
                    }
                    else
                    {
                        SetValue(TextProperty, item.ToString());
                    }

                    CaretIndex = (Text ?? "").Length;
                    ScrollToEnd();
                    // If item IsNot Nothing Then Me.SetValue(TextProperty, item.ToString) Else Me.SetValue(TextProperty, Nothing)
                };
                SelectionChangedAction?.Invoke(this, new SelectionChangedEventArgs(System.Windows.Controls.Primitives.Selector.SelectionChangedEvent, Array.Empty<object>().ToList(), (new object[] { item }).ToList()));
            }
            catch (Exception)
            {
                SetValue(ValueProperty, default);
                SetValue(ContentProperty, default);
            }
        }

        _lockSyncText = false;
        SyncText();
        ClosePopup();
    }
}
