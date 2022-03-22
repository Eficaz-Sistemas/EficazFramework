using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace EficazFramework.Controls;

public class SessionView : Control, IDisposable
{

    public SessionView()
    {
        Applications = new ListCollectionView(Application.IApplicationManager.Instance.RunningApplications)
        {
            Filter = (e) =>
            {
                Application.ApplicationInstance app = e as Application.ApplicationInstance;
                return (app.SessionID == 0 || app.SessionID == Application.IApplicationManager.Instance.SectionManager.CurrentSection.ID);
            }
        };
        Sessions = new ListCollectionView(Application.IApplicationManager.Instance.SectionManager.Sections)
        {
            Filter = (e) =>
            {
                Application.Section s = e as Application.Section;
                return s.ID != 0;
            }
        };
        SetValue(OpenSessionsCommandPropertyKey, new Commands.CommandBase(SessionsView_Executed));
        SetValue(NewSessionRequestCommandPropertyKey, new Commands.CommandBase(SessionRequest_Executed));
        Application.IApplicationManager.Instance.SectionManager.CurrentSectionChanged += OnSessionChanged;

    }

    #region Fields

    #endregion

    #region Properties

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ListCollectionView Applications
    {
        get { return (ListCollectionView)GetValue(ApplicationsProperty); }
        private set { SetValue(ApplicationsPropertyKey, value); }
    }
    private static DependencyPropertyKey ApplicationsPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(Applications), typeof(ListCollectionView), typeof(SessionView), new PropertyMetadata(null));
    public static DependencyProperty ApplicationsProperty = ApplicationsPropertyKey.DependencyProperty;



    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ListCollectionView Sessions
    {
        get { return (ListCollectionView)GetValue(SessionsProperty); }
        private set { SetValue(SessionsPropertyKey, value); }
    }
    private static DependencyPropertyKey SessionsPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(Sessions), typeof(ListCollectionView), typeof(SessionView), new PropertyMetadata(null));
    public static DependencyProperty SessionsProperty = SessionsPropertyKey.DependencyProperty;



    public DataTemplate SessionListItemTemplate
    {
        get { return (DataTemplate)GetValue(SessionListItemTemplateProperty); }
        set { SetValue(SessionListItemTemplateProperty, value); }
    }
    public static readonly DependencyProperty SessionListItemTemplateProperty =
        DependencyProperty.Register("SessionListItemTemplate", typeof(DataTemplate), typeof(SessionView), new PropertyMetadata(null));



    public DataTemplate SelectedSessionTemplate
    {
        get { return (DataTemplate)GetValue(SelectedSessionTemplateProperty); }
        set { SetValue(SelectedSessionTemplateProperty, value); }
    }
    public static readonly DependencyProperty SelectedSessionTemplateProperty =
        DependencyProperty.Register("SelectedSessionTemplate", typeof(DataTemplate), typeof(SessionView), new PropertyMetadata(null));



    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ICommand OpenSessionsCommand
    {
        get { return (ICommand)GetValue(OpenSessionsCommandProperty); }
        private set { SetValue(OpenSessionsCommandPropertyKey, value); }
    }
    private static DependencyPropertyKey OpenSessionsCommandPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(OpenSessionsCommand), typeof(ICommand), typeof(SessionView), new PropertyMetadata(null));
    public static DependencyProperty OpenSessionsCommandProperty = OpenSessionsCommandPropertyKey.DependencyProperty;



    public ICommand NewSessionRequestCommand
    {
        get { return (ICommand)GetValue(NewSessionRequestCommandProperty); }
        private set { SetValue(NewSessionRequestCommandPropertyKey, value); }
    }
    private static DependencyPropertyKey NewSessionRequestCommandPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(NewSessionRequestCommand), typeof(ICommand), typeof(SessionView), new PropertyMetadata(null));
    public static DependencyProperty NewSessionRequestCommandProperty = NewSessionRequestCommandPropertyKey.DependencyProperty;



    public bool IsPopupOpened
    {
        get { return (bool)GetValue(IsPopupOpenedProperty); }
        set { SetValue(IsPopupOpenedProperty, value); }
    }
    public static readonly DependencyProperty IsPopupOpenedProperty =
        DependencyProperty.Register("IsPopupOpened", typeof(bool), typeof(SessionView), new PropertyMetadata(false));



    public PlacementMode PopupPlacement
    {
        get { return (PlacementMode)GetValue(PopupPlacementProperty); }
        set { SetValue(PopupPlacementProperty, value); }
    }
    public static readonly DependencyProperty PopupPlacementProperty =
        DependencyProperty.Register("PopupPlacement", typeof(PlacementMode), typeof(SessionView), new PropertyMetadata(PlacementMode.Top));

    #endregion

    #region Handlers

    private void OnSessionChanged(object sender, System.EventArgs e)
    {
        Applications.Refresh();
        SetValue(IsPopupOpenedProperty, false);
    }

    private void SessionsView_Executed(object sender, Events.ExecuteEventArgs e)
    {
        SetValue(IsPopupOpenedProperty, !(bool)GetValue(IsPopupOpenedProperty));
    }

    private void SessionRequest_Executed(object sender, Events.ExecuteEventArgs e)
    {
        NewSessionRequested?.Invoke(this, EventArgs.Empty);
        SetValue(IsPopupOpenedProperty, !(bool)GetValue(IsPopupOpenedProperty));
    }

    #endregion

    #region Events

    public event EventHandler NewSessionRequested;

    #endregion

    public void Dispose()
    {
        Application.IApplicationManager.Instance.SectionManager.CurrentSectionChanged -= OnSessionChanged;
        GC.SuppressFinalize(this);
    }

}
