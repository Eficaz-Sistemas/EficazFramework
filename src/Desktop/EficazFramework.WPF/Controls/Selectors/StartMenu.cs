using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Windows.Controls.Primitives;

namespace EficazFramework.Controls;

public class StartMenu : TabControl
{
    public StartMenu()
    {
        SetValue(CustomTabsProperty, new ObservableCollection<TabItem>());
        //CustomTabs.CollectionChanged += CustomTabs_CollectionChanged;

        Applications = new ListCollectionView(Application.IApplicationManager.Instance.AllApplications);
        Applications.SortDescriptions.Add(new System.ComponentModel.SortDescription("TooltipTilte", System.ComponentModel.ListSortDirection.Ascending));
        Applications.GroupDescriptions.Add(new PropertyGroupDescription("FirstChar"));

        ExcludedUris = new ObservableCollection<string>();
        PinnedApplications = new ListCollectionView(Application.IApplicationManager.Instance.AllApplications);
        PinnedApplications.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
        PinnedApplications.Filter = (app) =>
        {
            Application.ApplicationDefinition eapp = app as Application.ApplicationDefinition;
            return !ExcludedUris.Contains(eapp.StartupURI);
        };

        SetValue(OpenMenuCommandPropertyKey, new Commands.CommandBase(OpenPopupMenu_Executed));
        SetValue(OpenApplicationCommandPropertyKey, new Commands.CommandBase(OpenApplication_Executed));
        SetValue(AppsViewModeCommandPropertyKey, new Commands.CommandBase(ChangeAppsViewMode_Executed));
        SetValue(PinOffApplicationCommandPropertyKey, new Commands.CommandBase(PinOffApplication_Executed));
    }

    //TabControl PART_Tabs = null;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ListCollectionView Applications
    {
        get { return (ListCollectionView)GetValue(ApplicationsProperty); }
        private set { SetValue(ApplicationsPropertyKey, value); }
    }
    private static DependencyPropertyKey ApplicationsPropertyKey = DependencyProperty.RegisterReadOnly(nameof(Applications), typeof(ListCollectionView), typeof(StartMenu), new PropertyMetadata(null));
    public static DependencyProperty ApplicationsProperty = ApplicationsPropertyKey.DependencyProperty;



    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ListCollectionView PinnedApplications
    {
        get { return (ListCollectionView)GetValue(PinnedApplicationsProperty); }
        private set { SetValue(PinnedApplicationsPropertyKey, value); }
    }
    private static DependencyPropertyKey PinnedApplicationsPropertyKey = DependencyProperty.RegisterReadOnly(nameof(PinnedApplications), typeof(ListCollectionView), typeof(StartMenu), new PropertyMetadata(null));
    public static DependencyProperty PinnedApplicationsProperty = PinnedApplicationsPropertyKey.DependencyProperty;



    public ObservableCollection<string> ExcludedUris
    {
        get { return (ObservableCollection<string>)GetValue(ExcludedUrisProperty); }
        set { SetValue(ExcludedUrisProperty, value); }
    }
    public static readonly DependencyProperty ExcludedUrisProperty = DependencyProperty.Register("ExcludedUris", typeof(ObservableCollection<string>), typeof(StartMenu), new PropertyMetadata(null));



    public string SearchAppLiteral
    {
        get { return (string)GetValue(SearchAppLiteralProperty); }
        set { SetValue(SearchAppLiteralProperty, value); }
    }
    public static readonly DependencyProperty SearchAppLiteralProperty = DependencyProperty.Register("SearchAppLiteral", typeof(string), typeof(StartMenu), new PropertyMetadata(null, OnSearchLiteral_Changed));



    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ICommand OpenMenuCommand
    {
        get { return (ICommand)GetValue(OpenMenuCommandProperty); }
        private set { SetValue(OpenMenuCommandPropertyKey, value); }
    }
    private static DependencyPropertyKey OpenMenuCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(OpenMenuCommand), typeof(ICommand), typeof(StartMenu), new PropertyMetadata(null));
    public static DependencyProperty OpenMenuCommandProperty = OpenMenuCommandPropertyKey.DependencyProperty;


    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ICommand OpenApplicationCommand
    {
        get { return (ICommand)GetValue(OpenApplicationCommandProperty); }
        private set { SetValue(OpenApplicationCommandPropertyKey, value); }
    }
    private static DependencyPropertyKey OpenApplicationCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(OpenApplicationCommand), typeof(ICommand), typeof(StartMenu), new PropertyMetadata(null));
    public static DependencyProperty OpenApplicationCommandProperty = OpenApplicationCommandPropertyKey.DependencyProperty;



    public bool IsPopupOpened
    {
        get { return (bool)GetValue(IsPopupOpenedProperty); }
        set { SetValue(IsPopupOpenedProperty, value); }
    }
    public static readonly DependencyProperty IsPopupOpenedProperty = DependencyProperty.Register("IsPopupOpened", typeof(bool), typeof(StartMenu), new PropertyMetadata(false, OnIsOpen_Changed));



    public PlacementMode PopupPlacement
    {
        get { return (PlacementMode)GetValue(PopupPlacementProperty); }
        set { SetValue(PopupPlacementProperty, value); }
    }
    public static readonly DependencyProperty PopupPlacementProperty = DependencyProperty.Register("PopupPlacement", typeof(PlacementMode), typeof(StartMenu), new PropertyMetadata(PlacementMode.Top));



    public DataTemplate PinnedApplicationTemplate
    {
        get { return (DataTemplate)GetValue(PinnedApplicationTemplateProperty); }
        set { SetValue(PinnedApplicationTemplateProperty, value); }
    }
    public static readonly DependencyProperty PinnedApplicationTemplateProperty = DependencyProperty.Register("PinnedApplicationTemplate", typeof(DataTemplate), typeof(StartMenu), new PropertyMetadata(null));



    public ICommand AppsViewModeCommand
    {
        get { return (ICommand)GetValue(AppsViewModeCommandProperty); }
        private set { SetValue(AppsViewModeCommandPropertyKey, value); }
    }
    private static DependencyPropertyKey AppsViewModeCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(AppsViewModeCommand), typeof(ICommand), typeof(StartMenu), new PropertyMetadata(null));
    public static DependencyProperty AppsViewModeCommandProperty = AppsViewModeCommandPropertyKey.DependencyProperty;



    public bool AllAppsList
    {
        get { return (bool)GetValue(AllAppsListProperty); }
        set { SetValue(AllAppsListProperty, value); }
    }
    public static readonly DependencyProperty AllAppsListProperty = DependencyProperty.Register("AllAppsList", typeof(bool), typeof(StartMenu), new PropertyMetadata(false));



    public ObservableCollection<TabItem> CustomTabs
    {
        get { return (ObservableCollection<TabItem>)GetValue(CustomTabsProperty); }
        set { SetValue(CustomTabsProperty, value); }
    }
    public static readonly DependencyProperty CustomTabsProperty = DependencyProperty.Register("CustomTabs", typeof(ObservableCollection<TabItem>), typeof(StartMenu), new PropertyMetadata(null));



    public object MainPageTopRightContent
    {
        get { return (object)GetValue(MainPageTopRightContentProperty); }
        set { SetValue(MainPageTopRightContentProperty, value); }
    }
    public static readonly DependencyProperty MainPageTopRightContentProperty = DependencyProperty.Register("MainPageTopRightContent", typeof(object), typeof(StartMenu), new PropertyMetadata(null));



    public string WelcomeText
    {
        get { return (string)GetValue(WelcomeTextProperty); }
        set { SetValue(WelcomeTextProperty, value); }
    }
    public static readonly DependencyProperty WelcomeTextProperty = DependencyProperty.Register("WelcomeText", typeof(string), typeof(StartMenu), new PropertyMetadata(null));



    public ICommand PinOffApplicationCommand
    {
        get { return (ICommand)GetValue(PinOffApplicationCommandProperty); }
        private set { SetValue(PinOffApplicationCommandPropertyKey, value); }
    }
    private static DependencyPropertyKey PinOffApplicationCommandPropertyKey = DependencyProperty.RegisterReadOnly(nameof(PinOffApplicationCommand), typeof(ICommand), typeof(StartMenu), new PropertyMetadata(null));
    public static DependencyProperty PinOffApplicationCommandProperty = PinOffApplicationCommandPropertyKey.DependencyProperty;



    #region Overrides

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var item = ((CompositeCollection)ItemsSource)[1];
        if ((item as CollectionContainer) == null) return;
        (item as CollectionContainer).Collection = CustomTabs;
    }

    #endregion


    #region Handlers

    private static void OnSearchLiteral_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        StartMenu instance = (StartMenu)sender;

        if (string.IsNullOrEmpty((string)e.NewValue))
        {
            instance.Applications.Filter = null;
            instance.PinnedApplications.Filter = (app) =>
            {
                Application.ApplicationDefinition eapp = app as Application.ApplicationDefinition;
                return !instance.ExcludedUris.Contains(eapp.StartupURI);
            };
            return;
        }
        instance.Applications.Filter = (app) =>
        {
            Application.ApplicationDefinition eapp = app as Application.ApplicationDefinition;
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.TooltipTilte, (string)e.NewValue,
                                                                    CompareOptions.IgnoreNonSpace |
                                                                    CompareOptions.IgnoreCase) >= 0 ||
                   CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.Group, (string)e.NewValue,
                                                                    CompareOptions.IgnoreNonSpace |
                                                                    CompareOptions.IgnoreCase) >= 0;
        };
        instance.PinnedApplications.Filter = (app) =>
        {
            Application.ApplicationDefinition eapp = app as Application.ApplicationDefinition;
            return (!instance.ExcludedUris.Contains(eapp.StartupURI)) &&
                   CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.TooltipTilte, (string)e.NewValue,
                                                                    CompareOptions.IgnoreNonSpace |
                                                                    CompareOptions.IgnoreCase) >= 0 ||
                   CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.Group, (string)e.NewValue,
                                                                    CompareOptions.IgnoreNonSpace |
                                                                    CompareOptions.IgnoreCase) >= 0;
        };
    }

    private static void OnIsOpen_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if ((bool)e.NewValue == true)
        {
            StartMenu instance = (StartMenu)sender;
            instance.SelectedIndex = 0;
        }
    }


    public void RefreshPinnedApps()
    {
        if (PinnedApplications == null) return;
        PinnedApplications.Refresh();
    }

    private void OpenApplication_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (e.Parameter == null) return;
        if ((e.Parameter as EficazFramework.Application.ApplicationDefinition) == null) return;
        Application.IApplicationManager.Instance.Activate((Application.ApplicationDefinition)e.Parameter);
        SetValue(IsPopupOpenedProperty, false);
    }

    private void OpenPopupMenu_Executed(object sender, Events.ExecuteEventArgs e)
    {
        SetValue(IsPopupOpenedProperty, !(bool)GetValue(IsPopupOpenedProperty));
    }

    private void PinOffApplication_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if ((e.Parameter as Application.ApplicationDefinition) == null) return;
        Application.ApplicationDefinition app = (Application.ApplicationDefinition)e.Parameter;
        ExcludedUris.Add(app.StartupURI);
        RefreshPinnedApps();
        ApplicationPinnedOff?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, app.StartupURI));
    }

    private void ChangeAppsViewMode_Executed(object sender, Events.ExecuteEventArgs e)
    {
        SetValue(AllAppsListProperty, !(bool)GetValue(AllAppsListProperty));
    }

    #endregion


    public event NotifyCollectionChangedEventHandler ApplicationPinnedOff;
}
