using System.ComponentModel;
using System.Linq;

namespace EficazFramework.Controls;

[TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_MoveThumb", Type = typeof(XAML.Behaviors.MDIWindowMoveThumb))]
public sealed partial class MDIWindow : HeaderedContentControl
{
    static MDIWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MDIWindow), new FrameworkPropertyMetadata(typeof(MDIWindow)));
    }

    public MDIWindow()
    {
        if (DesignerProperties.GetIsInDesignMode(this))
            return;
        var isselected_descriptor = DependencyPropertyDescriptor.FromProperty(IsSelectedProperty, typeof(MDIWindow));
        isselected_descriptor?.AddValueChanged(this, OnIsSelectedChanged);
        Loaded += OnLoaded;
        var leftDescriptor = DependencyPropertyDescriptor.FromProperty(Canvas.LeftProperty, typeof(MDIContainer));
        leftDescriptor.AddValueChanged(this, (_, __) => OnMove());
        var topDescriptor = DependencyPropertyDescriptor.FromProperty(Canvas.TopProperty, typeof(MDIContainer));
        topDescriptor.AddValueChanged(this, (_, __) => OnMove());
    }


    private Button _closeButton = null;
    private MDIContainer _container = null;
    internal static bool _lockCanvasUpdate = false;
    public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(MDIWindow), new UIPropertyMetadata(false));
    public static readonly DependencyProperty WindowStateProperty = DependencyProperty.Register("WindowState", typeof(WindowState), typeof(MDIWindow), new PropertyMetadata(WindowState.Normal, OnWindowStateChanged));
    public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register("CanClose", typeof(bool), typeof(MDIWindow), new FrameworkPropertyMetadata(true));
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(MDIWindow), new PropertyMetadata(null));
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MDIWindow), new PropertyMetadata("MDIWindow - Title"));
    public static readonly RoutedEvent ClosingEvent = EventManager.RegisterRoutedEvent("Closing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MDIWindow));
    public static readonly RoutedEvent ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MDIWindow));
    public static readonly RoutedEvent FocusChangedEvent = EventManager.RegisterRoutedEvent("FocusChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MDIWindow));
    public static readonly RoutedEvent WindowStateChangedEvent = EventManager.RegisterRoutedEvent("WindowStateChanged", RoutingStrategy.Bubble, typeof(WindowStateChangedRoutedEventHandler), typeof(MDIWindow));



    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public WindowState WindowState
    {
        get => (WindowState)GetValue(WindowStateProperty);
        set => SetValue(WindowStateProperty, value);
    }

    public bool CanClose
    {
        get => (bool)GetValue(CanCloseProperty);
        set => SetValue(CanCloseProperty, value);
    }

    public object Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public Application.ApplicationInstance AppDefinition { get; internal set; } = null;

    // TabStop With Enter Key Attached

    public static bool TabStopWithEnterKey { get; set; } = false;
    public static readonly DependencyProperty AcceptEnterKeyNavigationProperty = DependencyProperty.RegisterAttached("AcceptEnterKeyNavigation", typeof(bool), typeof(MDIWindow), new PropertyMetadata(true));
    public static bool GetAcceptEnterKeyNavigation(DependencyObject element)
    {
        if (element is null)
            throw new ArgumentNullException(nameof(element));

        return (bool)element.GetValue(AcceptEnterKeyNavigationProperty);
    }
    public static void SetAcceptEnterKeyNavigation(DependencyObject element, bool value)
    {
        if (element is null)
            throw new ArgumentNullException(nameof(element));

        element.SetValue(AcceptEnterKeyNavigationProperty, value);
    }



    public override void OnApplyTemplate()
    {
        _closeButton = GetTemplateChild("PART_CloseButton") as Button;
        if (_closeButton != null)
            _closeButton.Click += CloseWindow;

        _container = XAML.Utilities.VisualTreeHelpers.FindAnchestor<MDIContainer>(this);
        if (_container != null)
            _container.SizeChanged += OnContainerSizeChanged;
        MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        Focus();
    }

    protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
    {
        base.OnGotKeyboardFocus(e);
        IsSelected = true;
        RaiseEvent(new RoutedEventArgs(FocusChangedEvent, DataContext));
        if (e.OriginalSource is MDIWindow)
            MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }

    private IInputElement _focused = default;
    private readonly Type[] _skipControlTypes = new[] { typeof(Button), typeof(RichTextBox) };

    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        base.OnPreviewKeyDown(e);
        if (e.Key == Key.Enter & e.KeyboardDevice.Modifiers == ModifierKeys.None)
        {
            if (!TabStopWithEnterKey)
                return;
            _focused = Keyboard.FocusedElement;
        }
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);
        if (e.Handled == true)
            return;
        if (e.Key == Key.Enter & e.KeyboardDevice.Modifiers == ModifierKeys.None)
        {
            if (!TabStopWithEnterKey)
                return;
            IInputElement currentFocused = Keyboard.FocusedElement;
            if (currentFocused is null || _focused is null)
                return;
            if (GetAcceptEnterKeyNavigation((DependencyObject)currentFocused) == false)
                return;
            if (!_skipControlTypes.Contains(currentFocused.GetType()))
            {
                if (object.ReferenceEquals(_focused, currentFocused))
                    ((FrameworkElement)currentFocused).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                e.Handled = true;
            }
        }
    }


    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }

    private void OnContainerSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (DesignerProperties.GetIsInDesignMode(this) == true)
            return;
        if (WindowState == WindowState.Maximized)
        {
            try
            {
                Width += e.NewSize.Width - e.PreviousSize.Width;
            }
            catch
            {
                Width = 0;
            }

            try
            {
                Height += e.NewSize.Height - e.PreviousSize.Height;
            }
            catch
            {
                Height = 0;
            }
            // ElseIf Me.WindowState = WindowState.Minimized Then
            // Canvas.SetTop(Me, Me._container.ActualHeight - 32)
        }
    }

    private static void OnWindowStateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        if (obj is MDIWindow window)
        {
            var args = new Events.WindowStateChangedEventArgs(WindowStateChangedEvent, (WindowState)e.OldValue, (WindowState)e.NewValue);
            window.RaiseEvent(args);
            if (window.WindowState < WindowState.Maximized)
                return;
            window._container ??= XAML.Utilities.VisualTreeHelpers.FindAnchestor<MDIContainer>(window);
            if (window._container is null)
                return;
            window.Width = window._container.ActualWidth;
            window.Height = window._container.ActualHeight - MDIContainer.TaskIconSizeValue - 1;
            Canvas.SetLeft(window, 0);
            Canvas.SetTop(window, 0);
        }
    }

    public void CloseWindow(object sender, RoutedEventArgs e)
    {
        var canCloseBinding = BindingOperations.GetBindingExpression(this, CanCloseProperty);
        canCloseBinding?.UpdateTarget();

        if (CanClose)
        {
            var token = new RoutedEventArgs(ClosingEvent);
            RaiseEvent(token);
            if (token.Handled == true)
                return;
            // Me.RemoveBehaviors()
            //UIElement finalref;
            //if (AppDefinition == null)
            //    AppDefinition.RaiseAppClosed();
            //{
            //   if (Content is ContentPresenter)
            //        finalref = (UIElement)((ContentPresenter)Content).Content;
            //    else
            //        finalref = (UIElement)Content;
            //}
            //else { finalref = (UIElement)AppDefinition.Content; }

            //if (finalref != null)
            //{
            //    if (typeof(IDisposable).IsAssignableFrom(finalref.GetType()))
            //    {
            //        IDisposable i = (IDisposable)finalref;
            //        i.Dispose();
            //    }
            //}

            token.RoutedEvent = ClosedEvent;
            RaiseEvent(token);
            AppDefinition?.Close();
        }
    }

    private void OnIsSelectedChanged(object sender, EventArgs e)
    {
        try
        {
            if (IsSelected == true)
            {
                _container?.SyncTabZIndex(Content);
            }
        }
        catch
        {
        }
    }

    private void OnMove()
    {
        if (_lockCanvasUpdate == true) return;
        if (Content == null) return;

        if (Content is DependencyObject)
        {
            var pt = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
            if (!double.IsNaN(pt.X))
                Canvas.SetLeft((UIElement)Content, pt.X);
            if (!double.IsNaN(pt.Y))
                Canvas.SetTop((UIElement)Content, pt.Y);
        }
        else if (Content is Application.ApplicationDefinition)
        {
            if (AppDefinition.Content == null) return;
            var pt = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
            if (!double.IsNaN(pt.X))
                Canvas.SetLeft((UIElement)AppDefinition.Content, pt.X);
            if (!double.IsNaN(pt.Y))
                Canvas.SetTop((UIElement)AppDefinition.Content, pt.Y);
        }
    }


    public event RoutedEventHandler FocusChanged
    {
        add
        {
            AddHandler(FocusChangedEvent, value);
        }

        remove
        {
            RemoveHandler(FocusChangedEvent, value);
        }
    }

    void OnFocusChanged(object sender, RoutedEventArgs e) => RaiseEvent(e);

    public event WindowStateChangedRoutedEventHandler WindowStateChanged
    {
        add
        {
            AddHandler(WindowStateChangedEvent, value);
        }

        remove
        {
            RemoveHandler(WindowStateChangedEvent, value);
        }
    }

    void OnWindowStateChanged(object sender, RoutedEventArgs e) => RaiseEvent(e);

    public event RoutedEventHandler Closing
    {
        add
        {
            AddHandler(ClosingEvent, value);
        }

        remove
        {
            RemoveHandler(ClosingEvent, value);
        }
    }

    void OnClosing(object sender, RoutedEventArgs e) => RaiseEvent(e);

    public event RoutedEventHandler Closed
    {
        add
        {
            AddHandler(ClosedEvent, value);
        }

        remove
        {
            RemoveHandler(ClosedEvent, value);
        }
    }

    void OnClosed(object sender, RoutedEventArgs e) => RaiseEvent(e);


    public delegate void WindowStateChangedRoutedEventHandler(object sender, Events.WindowStateChangedEventArgs e);


}

// MDI Code-Base from Hammer UI KIT
// http://andrassebo.blogspot.com.br/p/hammer.html