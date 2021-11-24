using EficazFramework.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace EficazFramework.Application;

public class SessionManager : INotifyPropertyChanged
{
    static SessionManager()
    {
        Sessions.Add(new Session() { ID = 0, Name = "Public" });
        Instance.CurrentSession = Sessions[0];
        Sessions.CollectionChanged += Sessions_CollectionChanged;
    }

    public static SessionManager Instance { get; } = new SessionManager();

    private Session _current;
    public Session CurrentSession
    {
        get
        {
            return _current;
        }
        set
        {
            _current = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSession)));
            CurrentSectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public static ObservableCollection<Session> Sessions { get; } = new ObservableCollection<Session>();
    private static void Sessions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null && e.OldItems.Count > 0)
        {
            if (e.OldItems.Contains(Instance.CurrentSession))
                Instance.CurrentSession = Sessions.LastOrDefault();

            foreach (Session old in e.OldItems)
            {
                var apps = Application.ApplicationManager.RunningAplications.Where((e) => e.SessionID == old.ID);
                foreach (ApplicationInstance app in apps)
                {
                    app.Dispose();
                    Application.ApplicationManager.RunningAplications.Remove(app);
                }
            }
        }
    }

    public static void ActivateSession(long ID)
    {
        Session exists = Sessions.Where(s => s.ID == ID).FirstOrDefault();
        Instance.CurrentSession = exists ?? throw new NullReferenceException(string.Format(Resources.Strings.Application.SessionNotFoundByID, ID));
    }

    public static void ActivateSession(Session session)
    {
        Session exists = Sessions.Where(s => s.ID == session.ID).FirstOrDefault();
        if (exists == null)
        {
            Sessions.Add(session);
            Instance.CurrentSession = session;
            return;
        }
        Instance.CurrentSession = exists;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler CurrentSectionChanged;

}

public class ScopedSessionManager : INotifyPropertyChanged
{
    public ScopedSessionManager()
    {
        Sessions.Add(new Session() { ID = 0, Name = "Public" });
        CurrentSession = Sessions[0];
        Sessions.CollectionChanged += Sessions_CollectionChanged;
    }

    private Session _current;
    public Session CurrentSession
    {
        get
        {
            return _current;
        }
        set
        {
            _current = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSession)));
            CurrentSectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public ScopedApplicationManager ApplicationManager { get; } = new ScopedApplicationManager();

    public ObservableCollection<Session> Sessions { get; } = new ObservableCollection<Session>();
    private void Sessions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null && e.OldItems.Count > 0)
        {
            if (e.OldItems.Contains(CurrentSession))
                CurrentSession = Sessions.LastOrDefault();

            foreach (Session old in e.OldItems)
            {
                var apps = ApplicationManager.RunningAplications.Where((e) => e.SessionID == old.ID);
                foreach (ApplicationInstance app in apps)
                {
                    app.Dispose();
                    ApplicationManager.RunningAplications.Remove(app);
                }
            }
        }
    }

    public void ActivateSession(long ID)
    {
        Session exists = Sessions.Where(s => s.ID == ID).FirstOrDefault();
        CurrentSession = exists ?? throw new NullReferenceException(string.Format(Resources.Strings.Application.SessionNotFoundByID, ID));
    }

    public void ActivateSession(Session session)
    {
        Session exists = Sessions.Where(s => s.ID == session.ID).FirstOrDefault();
        if (exists == null)
        {
            Sessions.Add(session);
            CurrentSession = session;
            return;
        }
        CurrentSession = exists;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler CurrentSectionChanged;

}

public class Session : INotifyPropertyChanged
{

    #region SectionInformation

    public Session()
        {
            RemoveSectionCommand = new Commands.CommandBase(RemoveSection_Executed);
        }

        private long _id;
        public long ID
        {
            get
            {
                return _id;
            }

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
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Icon)));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private bool _showIdAsIcon;
        public bool ShowIdAsIcon
        {
            get
            {
                return _showIdAsIcon;
            }

            set
            {
                _showIdAsIcon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowIdAsIcon)));
            }
        }

        private object _tag;
        public object Tag
        {
            get
            {
                return _tag;
            }

            set
            {
                _tag = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tag)));
            }
        }

        public Commands.CommandBase RemoveSectionCommand { get; }
        private void RemoveSection_Executed(object sender, Events.ExecuteEventArgs e)
        {
            SessionManager.Sessions.Remove(this);
        }

    #endregion

    public override string ToString()
    {
        return string.Format("{0} - {1}", ID, Name);
    }

    public event PropertyChangedEventHandler PropertyChanged;

}
