using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace EficazFramework.Application;

public class SessionManager : INotifyPropertyChanged
{
    static SessionManager()
    {
        SessionsInternal.Add(new Session() { ID = 0, Name = "Public" });
        Instance.CurrentSession = SessionsInternal[0];
        SessionsInternal.CollectionChanged += Sessions_CollectionChanged;
    }

    /// <summary>
    /// Instância singleton para uso com Binding e INotifyPropertyChanged.
    /// </summary>
    public static SessionManager Instance { get; } = new SessionManager();

    private Session _current;
    /// <summary>
    /// Contém informações acerca da Seção Ativa.
    /// </summary>
    public Session CurrentSession
    {
        get => _current;
        set
        {
            _current = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSession)));
            CurrentSectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Dicionário das seções ativas, útil para evitar ativação em duplicidade.
    /// </summary>
    private static readonly Dictionary<long, Session> SessionsIDs = new();

    private static ObservableCollection<Session> SessionsInternal { get; } = new ObservableCollection<Session>();

    /// <summary>
    /// Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")
    /// </summary>
    public static ReadOnlyCollection<Session> Sessions 
    {
        get => SessionsInternal.ToReadOnlyCollection<Session>();
    }

    private static void Sessions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null && e.NewItems.Count > 0)
        {
            foreach (Session news in e.NewItems)
            {
                SessionsIDs.Add(news.ID, news);
            }
        }
        if (e.OldItems != null && e.OldItems.Count > 0)
        {
            if (e.OldItems.Contains(Instance.CurrentSession))
                Instance.CurrentSession = SessionsInternal.LastOrDefault();

            foreach (Session old in e.OldItems)
            {
                var apps = Application.ApplicationManager.RunningAplications.Where((e) => e.SessionID == old.ID);
                foreach (ApplicationInstance app in apps)
                {
                    app.Dispose();
                    Application.ApplicationManager.RunningAplications.Remove(app);
                }
                SessionsIDs.Remove(old.ID);
            }
        }
    }

    public static void ActivateSession(long ID)
    {
        Session exists = SessionsInternal.Where(s => s.ID == ID).FirstOrDefault();
        Instance.CurrentSession = exists ?? throw new NullReferenceException(string.Format(Resources.Strings.Application.SessionNotFoundByID, ID));
    }

    public static void ActivateSession(Session session, bool update = false)
    {
        Session exists = SessionsInternal.Where(s => s.ID == session.ID).FirstOrDefault();
        if (exists == null)
        {
            SessionsInternal.Add(session);
            Instance.CurrentSession = session;
            return;
        }
        if (update)
        {
            exists.Icon = session.Icon;
            exists.Name = session.Name;
            exists.ShowIdAsIcon = session.ShowIdAsIcon;
            exists.Tag = session.Tag;
        }
        Instance.CurrentSession = exists;
    }

    public static void DisposeSession(long ID)
    {
        SessionsInternal.Remove(SessionsInternal.FirstOrDefault(s => s.ID == ID));
    }

    public static void DisposeSession(Session session)
    {
        SessionsInternal.Remove(session);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler CurrentSectionChanged;

}

public class ScopedSessionManager : INotifyPropertyChanged
{
    public ScopedSessionManager()
    {
        SessionsInternal.Add(new Session() { ID = 0, Name = "Public" });
        CurrentSession = Sessions[0];
        SessionsInternal.CollectionChanged += Sessions_CollectionChanged;
    }

    private Session _current;
    /// <summary>
    /// Contém informações acerca da Seção Ativa.
    /// </summary>
    public Session CurrentSession
    {
        get => _current;
        private set
        {
            _current = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSession)));
            CurrentSectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Armazena e gerencia informações sobre aplicativos neste scopo de seções.
    /// </summary>
    public ScopedApplicationManager ApplicationManager { get; } = new ScopedApplicationManager();

    /// <summary>
    /// Dicionário das seções ativas, útil para evitar ativação em duplicidade.
    /// </summary>
    private readonly Dictionary<long, Session> SessionsIDs = new();

    private ObservableCollection<Session> SessionsInternal { get; } = new ObservableCollection<Session>();

    /// <summary>
    /// Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")
    /// </summary>
    public ReadOnlyCollection<Session> Sessions
    {
        get => SessionsInternal.ToReadOnlyCollection<Session>();
    }

    private void Sessions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null && e.NewItems.Count > 0)
        {
            foreach (Session news in e.NewItems)
            {
                SessionsIDs.Add(news.ID, news);
            }
        }
        if (e.OldItems != null && e.OldItems.Count > 0)
        {
            if (e.OldItems.Contains(CurrentSession))
                CurrentSession = SessionsInternal.LastOrDefault();

            foreach (Session old in e.OldItems)
            {
                var apps = Application.ApplicationManager.RunningAplications.Where((e) => e.SessionID == old.ID);
                foreach (ApplicationInstance app in apps)
                {
                    app.Dispose();
                    Application.ApplicationManager.RunningAplications.Remove(app);
                }
                SessionsIDs.Remove(old.ID);
            }
        }
    }

    public void ActivateSession(long ID)
    {
        Session exists = SessionsInternal.Where(s => s.ID == ID).FirstOrDefault();
        CurrentSession = exists ?? throw new NullReferenceException(string.Format(Resources.Strings.Application.SessionNotFoundByID, ID));
    }

    public void ActivateSession(Session session, bool update = false)
    {
        Session exists = SessionsInternal.Where(s => s.ID == session.ID).FirstOrDefault();
        if (exists == null)
        {
            SessionsInternal.Add(session);
            CurrentSession = session;
            return;
        }
        if (update)
        {
            exists.Icon = session.Icon;
            exists.Name = session.Name;
            exists.ShowIdAsIcon = session.ShowIdAsIcon;
            exists.Tag = session.Tag;
        }
        CurrentSession = exists;
    }

    public void DisposeSession(long ID)
    {
        SessionsInternal.Remove(SessionsInternal.FirstOrDefault(s => s.ID == ID));
    }

    public void DisposeSession(Session session)
    {
        SessionsInternal.Remove(session);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler CurrentSectionChanged;

}

public class Session : INotifyPropertyChanged
{
    public Session()
        {
            RemoveSectionCommand = new Commands.CommandBase(RemoveSection_Executed);
        }

    private long _id;
    public long ID
    {
        get => _id;
        set
        {
            _id = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
        }
    }

    public bool SectionIdLargerText
    {
        get
        {
            if (ID.ToString().Length >= 3)
                return true;
            else
                return false;
        }
    }

    private object _icon;
    public object Icon
    {
        get => _icon;
        set
        {
            _icon = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Icon)));
        }
    }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }

    private bool _showIdAsIcon;
    public bool ShowIdAsIcon
    {
        get => _showIdAsIcon;
        set
        {
            _showIdAsIcon = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowIdAsIcon)));
        }
    }

    private object _tag;
    public object Tag
    {
        get => _tag;
        set
        {
            _tag = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tag)));
        }
    }

    public Commands.CommandBase RemoveSectionCommand { get; }
    private void RemoveSection_Executed(object sender, Events.ExecuteEventArgs e)
    {
        SessionManager.DisposeSession(this);
    }

    public override string ToString()
    {
        return string.Format("{0} - {1}", ID, Name);
    }

    public event PropertyChangedEventHandler PropertyChanged;

}
