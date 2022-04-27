using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace EficazFramework.Controls.AttachedProperties;

public partial class TabControl
{

    #region Navigator Template

    public static bool GetNavigationTemplate([DisallowNull] DependencyObject element) =>
        (bool)element.GetValue(NavigationTemplateProperty);

    public static void SetNavigationTemplate([DisallowNull] DependencyObject element, bool value)
    {
        element.SetValue(NavigationTemplateProperty, value);
        if (DesignerProperties.GetIsInDesignMode(element))
            return;
        try
        {
            if (ReferenceEquals(element.GetType(), typeof(System.Windows.Controls.TabControl)))
            {
                foreach (TabItem tbitem in ((System.Windows.Controls.TabControl)element).Items)
                    SetIsExpanded(tbitem, value);
            }
        }
        catch (Exception inhertanceEX)
        {
            Debug.WriteLine(inhertanceEX.ToString());
        }
    }

    public static readonly DependencyProperty NavigationTemplateProperty = DependencyProperty.RegisterAttached("NavigationTemplate", typeof(bool), typeof(TabControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, OnNavigationTemplateChanged));

    private static void OnNavigationTemplateChanged(object source, DependencyPropertyChangedEventArgs e)
    {
        // Try
        if (DesignerProperties.GetIsInDesignMode((System.Windows.DependencyObject)source))
            return;
        if (source is not System.Windows.Controls.TabControl)
        {
            if (source is System.Windows.Controls.DataGrid dg)
            {
                if ((bool)e.NewValue == true)
                {
                    if (dg.IsSynchronizedWithCurrentItem == true == true)
                        dg.IsSynchronizedWithCurrentItem = false;

                    dg.SelectedCellsChanged += DataGrid.DataGrid_NavigationTemplate_SelectionChanged;
                    dg.PreviewMouseLeftButtonDown += DataGrid.DataGrid_PreviewMouseLeftButtonDown;
                    dg.PreviewKeyDown += DataGrid.DataGrid_NavigationTemplate_PreviewKeyDown;
                    CommandManager.AddCanExecuteHandler(dg, DataGrid.DataGrid_CanExecuteBeginEdit);
                }
                // AddHandler dg.GotFocus, AddressOf DataGrid.DataGrid_GotFocus
                else
                {
                    dg.SelectedCellsChanged -= DataGrid.DataGrid_NavigationTemplate_SelectionChanged;
                    dg.PreviewKeyDown -= DataGrid.DataGrid_NavigationTemplate_PreviewKeyDown;
                    dg.PreviewMouseLeftButtonDown -= DataGrid.DataGrid_PreviewMouseLeftButtonDown;
                    CommandManager.RemoveCanExecuteHandler(dg, DataGrid.DataGrid_CanExecuteBeginEdit);
                    // RemoveHandler dg.GotFocus, AddressOf DataGrid.DataGrid_GotFocus
                }
            }

            return;
        }

        System.Windows.Controls.TabControl tab = source as System.Windows.Controls.TabControl;
        if (tab is null)
            return;
        
        var dpd = DependencyPropertyDescriptor.FromProperty(System.Windows.Controls.TabControl.SelectedContentProperty, typeof(System.Windows.Controls.TabControl));
        if (dpd is null)
            return;
        
        if ((bool)e.NewValue == true)
        {
            dpd.AddValueChanged(tab, TabControl_SelectionChanged);
            tab.PreviewKeyUp += TabControl_NavigationTemplate_PreviewKeyUp;
        }
        else
        {
            dpd.RemoveValueChanged(tab, TabControl_SelectionChanged);
            tab.PreviewKeyUp -= TabControl_NavigationTemplate_PreviewKeyUp;
        }
    }

    private static void TabControl_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (DesignerProperties.GetIsInDesignMode((System.Windows.DependencyObject)sender))
                return;

            if (!(sender is System.Windows.Controls.TabControl))
                return;

            System.Windows.Controls.TabControl tab = sender as System.Windows.Controls.TabControl;
            if (tab is null)
                return;

            if (tab.IsLoaded == false)
                return;

            if (tab.SelectedContent is null)
                return;

            tab.UpdateLayout();
            if (tab.SelectedContent is UIElement)
                ((FrameworkElement)tab.SelectedContent).MoveFocus(new TraversalRequest(FocusNavigationDirection.First));

            if (!((TabItem)tab.SelectedItem).IsKeyboardFocusWithin)
                ((TabItem)tab.SelectedItem).Focus();
        }
        catch (Exception exTabChanged)
        {
            Debug.WriteLine(exTabChanged.ToString());
        }
    }

    internal static void TabControl_NavigationTemplate_PreviewKeyUp(object sender, KeyEventArgs e)
    {
        var focused = Keyboard.FocusedElement;
        if (!e.KeyboardDevice.IsKeyDown(Key.LeftCtrl))
            return;
        System.Windows.Controls.TabControl tab = (System.Windows.Controls.TabControl)sender;
        if (e.Key == Key.Up)
        {
            if (tab.SelectedIndex > 0)
            {
                try
                {
                    var previtem = tab.Items.SourceCollection.Cast<FrameworkElement>().Where(f => f.Visibility == Visibility.Visible && tab.Items.IndexOf(f) < tab.SelectedIndex).LastOrDefault();
                    if (previtem is null)
                        return;
                    tab.SelectedItem = previtem;
                    tab.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                    e.Handled = true;
                }
                catch
                {
                } // ex As Exception
            }
        }
        else if (e.Key == Key.Down)
        {
            if (tab.SelectedIndex < tab.Items.Count - 1)
            {
                try
                {
                    var nextitem = tab.Items.SourceCollection.Cast<FrameworkElement>().Where(f => f.Visibility == Visibility.Visible && tab.Items.IndexOf(f) > tab.SelectedIndex).FirstOrDefault();
                    if (nextitem is null)
                        return;
                    tab.SelectedItem = nextitem;
                    tab.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
                    e.Handled = true;
                }
                catch
                {
                } // ex As Exception
            }
        }
    }

    #endregion

    
    #region Navigation Template - Show Title

    public static bool GetNavigationTemplateShowTitle([DisallowNull] DependencyObject element) =>
        (bool) element.GetValue(NavigationTemplateShowTitleProperty);

    public static void SetNavigationTemplateShowTitle([DisallowNull] DependencyObject element, bool value) =>
        element.SetValue(NavigationTemplateShowTitleProperty, value);

    public static readonly DependencyProperty NavigationTemplateShowTitleProperty = DependencyProperty.RegisterAttached("NavigationTemplateShowTitle", typeof(bool), typeof(TabControl), new PropertyMetadata(false));

    #endregion

    
    #region Navigator Handlers

    private static EficazFramework.Commands.CommandBase _expandCommand = new EficazFramework.Commands.CommandBase(ExpandCommand_Executed);

    public static EficazFramework.Commands.CommandBase ExpandCommand => _expandCommand;
    
    private static void ExpandCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e)
    {
        try
        {
            // If DesignerProperties.GetIsInDesignMode(sender) Then Exit Sub
            if (e.Parameter is null)
                return;
            
            if (e.Parameter is not System.Windows.Controls.TabControl)
                return;

            SetIsExpanded((DependencyObject)e.Parameter, !GetIsExpanded((DependencyObject)e.Parameter));
        }
        catch (Exception exCommDesigner)
        {
            Debug.WriteLine(exCommDesigner.ToString());
        }
    }

    #endregion

    
    #region IsExpanded

    public static bool GetIsExpanded([DisallowNull] DependencyObject element) => 
        (bool)element.GetValue(IsExpandedProperty);

    public static void SetIsExpanded([DisallowNull] DependencyObject element, bool value)
    {
        element.SetValue(IsExpandedProperty, value);
        if (ReferenceEquals(element.GetType(), typeof(System.Windows.Controls.TabControl)))
        {
            foreach (TabItem tbitem in ((System.Windows.Controls.TabControl)element).Items)
                SetIsExpanded(tbitem, value);
        }
    }

    public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.RegisterAttached("IsExpanded", typeof(bool), typeof(TabControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

    #endregion

    
    #region TabItemIcon

    public static Geometry GetIcon([DisallowNull] DependencyObject element) =>
        (Geometry) element.GetValue(IconProperty);
    
    public static void SetIcon([DisallowNull] DependencyObject element, Geometry value) =>
        element.SetValue(IconProperty, value);


    public static readonly DependencyProperty IconProperty = DependencyProperty.RegisterAttached("Icon", typeof(Geometry), typeof(TabControl), new PropertyMetadata(null));

    #endregion

    
    #region TabFocusNavigator

    public static int? GetNextTab([DisallowNull] DependencyObject element) =>
        (int?)element.GetValue(NextTabProperty);
    public static void SetNextTab([DisallowNull] DependencyObject element, int? value) =>
        element.SetValue(NextTabProperty, value);
    
    public static readonly DependencyProperty NextTabProperty = DependencyProperty.RegisterAttached("NextTab", typeof(int?), typeof(TabControl), new PropertyMetadata(null, NextOrPreviousTabPropertyChanged));

    public static int? GetPreviousTab([DisallowNull] DependencyObject element) =>
        (int?)element.GetValue(PreviousTabProperty);

    public static void SetPreviousTab([DisallowNull] DependencyObject element, int? value) =>
        element.SetValue(PreviousTabProperty, value);

    public static readonly DependencyProperty PreviousTabProperty = DependencyProperty.RegisterAttached("PreviousTab", typeof(int?), typeof(TabControl), new PropertyMetadata(null, NextOrPreviousTabPropertyChanged));

    private static void NextOrPreviousTabPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (DesignerProperties.GetIsInDesignMode((System.Windows.DependencyObject)sender))
            return;
        
        ((UIElement)sender).RemoveHandler(UIElement.LostKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(SelectTabItemFromFocusChanged));
        ((UIElement)sender).RemoveHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(TabItemChildPreviewKeyDown));
        
        if (((int?)e.NewValue).HasValue == true)
            ((UIElement)sender).AddHandler(UIElement.LostKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(SelectTabItemFromFocusChanged));
        
        if (((int?)e.NewValue).HasValue == true)
            ((UIElement)sender).AddHandler(UIElement.PreviewKeyDownEvent, new KeyEventHandler(TabItemChildPreviewKeyDown));
    }

    private static bool _supress = true;

    private static void TabItemChildPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Tab | e.Key == Key.Return | e.Key == Key.Enter)
            _supress = false;
    }

    private static void SelectTabItemFromFocusChanged(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (_supress == false)
            _supress = true;
        else
            return;
        UIElement element = (UIElement)sender;
        System.Windows.Controls.TabControl tabcontrol = null;
        
        int? index = default;
        if (e.KeyboardDevice.Modifiers == ModifierKeys.None)
            index = GetNextTab(element);
        
        else if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            index = GetPreviousTab(element);

        if (index.HasValue == false)
            return;
        
        tabcontrol = EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Controls.TabControl>(element);
        if (tabcontrol is null)
            return;
        
        if (index.Value > tabcontrol.Items.Count - 1)
            return;
        
        tabcontrol.SelectedIndex = index.Value;
    }

    #endregion

}
