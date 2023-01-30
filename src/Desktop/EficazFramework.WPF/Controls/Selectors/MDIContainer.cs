using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace EficazFramework.Controls;

[TemplatePart(Name = "PART_TaskBarAppsHost", Type = typeof(ItemsControl))]
public class MDIContainer : Selector
{

    // Properties
    public static Application.ApplicationInstance GetApplicationDefinition(DependencyObject obj) => (Application.ApplicationInstance)obj.GetValue(ApplicationDefinitionProperty);
    public static void SetApplicationDefinition(DependencyObject obj, Application.ApplicationInstance value)
    {
        obj.SetValue(ApplicationDefinitionProperty, value);
    }
    public static readonly DependencyProperty ApplicationDefinitionProperty =
        DependencyProperty.RegisterAttached("ApplicationDefinition", typeof(Application.ApplicationInstance), typeof(MDIContainer), new PropertyMetadata(null));

    public object CustomTaskBarLeftContent
    {
        get => (object)GetValue(CustomTaskBarLeftContentProperty);
        set => SetValue(CustomTaskBarLeftContentProperty, value);
    }
    public static readonly DependencyProperty CustomTaskBarLeftContentProperty =
        DependencyProperty.Register("CustomTaskBarLeftContent", typeof(object), typeof(MDIContainer), new PropertyMetadata(null));


    public DataTemplate CustomTaskBarLeftContentTemplate
    {
        get { return (DataTemplate)GetValue(CustomTaskBarLeftContentTemplateProperty); }
        set { SetValue(CustomTaskBarLeftContentTemplateProperty, value); }
    }
    public static readonly DependencyProperty CustomTaskBarLeftContentTemplateProperty =
        DependencyProperty.Register("CustomTaskBarLeftContentTemplate", typeof(DataTemplate), typeof(MDIContainer), new PropertyMetadata(null));

    public object CustomTaskBarRightContent
    {
        get { return (object)GetValue(CustomTaskBarRightContentProperty); }
        set { SetValue(CustomTaskBarRightContentProperty, value); }
    }
    public static readonly DependencyProperty CustomTaskBarRightContentProperty =
        DependencyProperty.Register("CustomTaskBarRightContent", typeof(object), typeof(MDIContainer), new PropertyMetadata(null));


    public DataTemplate CustomTaskBarRightContentTemplate
    {
        get { return (DataTemplate)GetValue(CustomTaskBarRightContentTemplateProperty); }
        set { SetValue(CustomTaskBarRightContentTemplateProperty, value); }
    }
    public static readonly DependencyProperty CustomTaskBarRightContentTemplateProperty =
        DependencyProperty.Register("CustomTaskBarRightContentTemplate", typeof(DataTemplate), typeof(MDIContainer), new PropertyMetadata(null));


    // Fields and Constants
    public const double TaskIconSizeValue = 46D;
    public static GridLength TaskIconSizeValueRow = new(TaskIconSizeValue, GridUnitType.Pixel);
    protected Guid MyInstanceID = Guid.NewGuid(); //RadioButton group by instance...

    private ItemsControl _PART_TaskBarHost = null;

    // Overrides
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _PART_TaskBarHost = GetTemplateChild("PART_TaskBarAppsHost") as ItemsControl;
        _PART_TaskBarHost.ItemContainerGenerator.StatusChanged += OnTaskBarStatusChanged;
    }

    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is MDIWindow;
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new MDIWindow();
    }

    protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
    {
        base.PrepareContainerForItemOverride(element, item);
        if (DesignerProperties.GetIsInDesignMode(this))
            return;

        UIElement target = null;

        if (element is MDIWindow window)
        {
            window.FocusChanged += OnWindowFocusChanged;
            window.Closed += OnWindowClosed;
            if (item is not MDIWindow)
            {
                Application.ApplicationInstance appinfo = null;

                // EficazFramework Application manager:
                if (item is Application.ApplicationInstance instance)
                {
                    appinfo = instance;
                    if (appinfo.Content == null)
                    {
                        appinfo.IsLoading = true;
                        LoadApplication(appinfo);
                    }
                    else
                    {
                        _refreshAll = true;
                    }
                }

                // Custom UIElement item:
                else if (item is DependencyObject dp)
                {
                    appinfo = GetApplicationDefinition(dp);
                }

                if (appinfo != null)
                {
                    window.AppDefinition = appinfo;
                    window.Title = appinfo.LongTitle ?? appinfo.Title;
                    window.WindowState = (WindowState)(appinfo.Targets["WPF"].Properties[Application.ApplicationDefinition.STARTWINDOWSTATE] ?? WindowState.Normal);
                    target = (UIElement)(appinfo.Content ?? appinfo.Targets["WPF"].SplashScreen);
                }
                else
                {
                    // Custom CLR element:
                    window.Title = item.ToString();
                }

            }
            else { target = (UIElement)item; }

            if (window.WindowState != WindowState.Maximized)
            {
                double top = 0D;
                double left = 0D;

                if (target != null)
                {
                    top = Canvas.GetTop(target);
                    if (double.IsNaN(top))
                    {
                        window.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                        top = (ActualHeight - Margin.Top - Margin.Bottom - window.DesiredSize.Height) / 2;
                    }

                    left = Canvas.GetLeft(target);
                    if (double.IsNaN(left))
                        left = (ActualWidth - Margin.Left - Margin.Right - window.DesiredSize.Width) / 2;
                }
                else
                {
                    top = Canvas.GetTop(window);
                    if (double.IsNaN(top))
                    {
                        window.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                        top = (ActualHeight - Margin.Top - Margin.Bottom - window.DesiredSize.Height) / 2;
                    }

                    left = Canvas.GetLeft(window);
                    if (double.IsNaN(left))
                        left = (ActualWidth - Margin.Left - Margin.Right - window.DesiredSize.Width) / 2;
                }
                Canvas.SetTop(window, top);
                Canvas.SetLeft(window, left);
            }

            window.Focus();
        }
    }

    // Handlers

    //// Applications
    internal void SyncTabZIndex(object added)
    {
        MDIWindow win = (MDIWindow)ItemContainerGenerator.ContainerFromItem(added);
        int currentzindex = Panel.GetZIndex(win);
        foreach (object it in Items)
        {
            if (added == it)
            {
                Panel.SetZIndex((UIElement)ItemContainerGenerator.ContainerFromItem(it), Items.Count - 1);
                if (SelectedItem != it) SelectedItem = it;

            }
            else
            {
                var container = ItemContainerGenerator.ContainerFromItem(it);
                if (container == null) continue;
                int nonselectedcurrentZindex = Panel.GetZIndex((UIElement)container);
                if (nonselectedcurrentZindex > currentzindex)
                    Panel.SetZIndex((UIElement)ItemContainerGenerator.ContainerFromItem(it), nonselectedcurrentZindex - 1);
            }
            if (win.IsSelected == false) { win.IsSelected = true; }
        }
    }

    protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    {
        base.OnSelectionChanged(e);
        if (e.AddedItems.Count > 0) SyncTabZIndex(e.AddedItems[0]);
        foreach (object it in e.RemovedItems)
        {
            MDIWindow container = ((MDIWindow)ItemContainerGenerator.ContainerFromItem(it));
            if (container != null) container.IsSelected = false;
        }

    }

    private void OnWindowClosed(object sender, RoutedEventArgs e)
    {
        if (sender is MDIWindow window)
        {
            //RadioButton taskbt = (from b in _taskBarAppsCollection
            //                      where b.DataContext == window | b.DataContext == window.Content
            //                      select b).FirstOrDefault;
            //if (taskbt != null)
            //    taskbt.DataContext = null;
            //if (taskbt != null)
            //    _taskBarAppsCollection.Remove(taskbt);


            if (ItemsSource != null)
            {
                if (ItemsSource is ListCollectionView lcv)
                {
                    if (window.AppDefinition != null)
                        ((IList)lcv.SourceCollection).Remove(window.AppDefinition);
                    else
                        ((IList)lcv.SourceCollection).Remove(window.Content);
                }
                else
                {
                    if (window.AppDefinition != null)
                        ((IList)ItemsSource).Remove(window.AppDefinition);
                    else
                        ((IList)ItemsSource).Remove(window.Content);
                }
            }
            else if (Items != null)
            {
                if (Items.Contains(window))
                    Items.Remove(window);
                else
                {
                    if (Items.Contains(window.Content))
                        Items.Remove(window.Content);
                }
            }

            // clear
            window.FocusChanged -= OnWindowFocusChanged;
            window.Closed -= OnWindowClosed;
            window.DataContext = null;
            window.Content = null;
        }

        if (Items.Count > 0)
        {
            MDIWindow window_last = (MDIWindow)ItemContainerGenerator.ContainerFromIndex(Items.Count - 1);
            window_last?.Focus();
        }
    }

    private void OnWindowFocusChanged(object sender, RoutedEventArgs e)
    {
        SelectedItem = e.OriginalSource;
        Items.MoveCurrentTo(e.OriginalSource);
        //if (_sectionView.Visibility == Visibility.Visible)
        //    Hide_SectionViewPanel();
    }


    private bool _refreshAll = false;
    private void OnTaskBarStatusChanged(object sender, EventArgs e)
    {
        if (_PART_TaskBarHost.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
        {
            if (_refreshAll == false) { SyncTaskBarItem(_PART_TaskBarHost.Items.CurrentItem); }
            else
            {
                foreach (object it in _PART_TaskBarHost.Items)
                {
                    SyncTaskBarItem(it);
                    _refreshAll = false;
                }
            }
        }
    }

    private void SyncTaskBarItem(object item)
    {
        FrameworkElement LinkedRadioPresenter = (FrameworkElement)_PART_TaskBarHost.ItemContainerGenerator.ContainerFromItem(item);
        if (LinkedRadioPresenter != null)
        {
            LinkedRadioPresenter.UpdateLayout();
            RadioButton rdinstance = XAML.Utilities.VisualTreeHelpers.FindVisualChild<RadioButton>(LinkedRadioPresenter);
            if (rdinstance == null) return;
            rdinstance.GroupName = MyInstanceID.ToString();

            MDIWindow sourcecontainer = (MDIWindow)ItemContainerGenerator.ContainerFromItem(item);
            if (sourcecontainer != null)
            {
                Binding b = new(nameof(MDIWindow.IsSelected)) { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, Source = sourcecontainer };
                rdinstance.SetBinding(RadioButton.IsCheckedProperty, b);
                SetApplicationDefinition(rdinstance, sourcecontainer.AppDefinition);
            }
        }
    }

    public static async void LoadApplication(Application.ApplicationInstance item)
    {
        if (item.IsLoading == false || item.Content != null) return;
        try
        {
            await Task.Delay(1000);
            UIElement app = await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => System.Windows.Application.LoadComponent(new Uri(item.Targets["WPF"].StartupUriOrType.ToString(), UriKind.RelativeOrAbsolute)) as UIElement);
            if (app != null) item.Content = app;
            item.IsLoading = false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }

}
