using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace EficazFramework.Application;
public class ApplicationManager
    {

        public static ObservableCollection<ApplicationDefinition> AllAplications { get; } = new ObservableCollection<ApplicationDefinition>();
        public static ObservableCollection<ApplicationInstance> RunningAplications { get; } = new ObservableCollection<ApplicationInstance>();


        public static bool IsRunning(ApplicationDefinition application)
        {
            return (RunningAplications.Where(app => app.Metadata == application && (app.SessionID == 0 | app.SessionID == SessionManager.Instance.CurrentSession.ID)).Any());
        }
        public static void Activate(ApplicationDefinition application)
        {
            bool running = IsRunning(application);
            ApplicationInstance instance = null;
            if (!running)
            {
                instance = new ApplicationInstance(application);
                RunningAplications.Add(instance);
            }
            else 
            {
                instance = RunningAplications.Where(app => app.Metadata == application && (app.SessionID == 0 | app.SessionID == SessionManager.Instance.CurrentSession.ID)).FirstOrDefault(); 
            }
            ActiveAppChanged?.Invoke(instance, EventArgs.Empty);
        }

        public static event EventHandler ActiveAppChanged;

    }

public class ScopedApplicationManager
{

    public ObservableCollection<ApplicationDefinition> AllAplications { get; } = new ObservableCollection<ApplicationDefinition>();
    public ObservableCollection<ApplicationInstance> RunningAplications { get; } = new ObservableCollection<ApplicationInstance>();

    public bool IsRunning(ApplicationDefinition application)
    {
        return (RunningAplications.Where(app => app.Metadata == application && (app.SessionID == 0 | app.SessionID == SessionManager.Instance.CurrentSession.ID)).Any());
    }
    public void Activate(ApplicationDefinition application)
    {
        bool running = IsRunning(application);
        ApplicationInstance instance = null;
        if (!running)
        {
            instance = new ApplicationInstance(application);
            RunningAplications.Add(instance);
        }
        else
        {
            instance = RunningAplications.Where(app => app.Metadata == application && (app.SessionID == 0 | app.SessionID == SessionManager.Instance.CurrentSession.ID)).FirstOrDefault();
        }
        ActiveAppChanged?.Invoke(instance, EventArgs.Empty);
    }

    public event EventHandler ActiveAppChanged;

}

public class ApplicationDefinition : INotifyPropertyChanged
{
        
    // Metadata
    public object Icon { get; set; }
    public string Title { get; set; }
    public string LongTitle { get; set; }
    public string Group { get; set; }
    public bool IsPublic { get; set; } = true;
    public string TooltipTilte => LongTitle ?? Title;
    public char FirstChar => (TooltipTilte ?? "#").First();

    // Menu metadata
    public int GroupMenuPriority { get; set; }
    public int MenuPriority { get; set; }
    public string Condition { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsChecked { get; set; }

    // Per-Platform Attributes (Ex: WPF Desktop Window Size, etc)
    public ApplicationAttributeCollection Attributes { get; set; } = new ApplicationAttributeCollection();

    // Initialization
    public string StartupURI { get; set; }
    public object SplashScreen { get; set; }

    public object[] Arguments { get; set; }

    // INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    public void RaisePropertyChanged(string propertyname)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname)) ;
    }


    //public override bool Equals(object obj)
    //{
    //    if (!(obj is ApplicationInstance)) { return base.Equals(obj); }
    //    return ((ApplicationInstance)obj)._metadata == this;
    //}

    //public override int GetHashCode()
    //{
    //    return base.GetHashCode();
    //}
}

public sealed class ApplicationInstance : ApplicationDefinition, INotifyPropertyChanged, IDisposable
{
    public ApplicationInstance(ApplicationDefinition fromDefinition)
    {
        Metadata = fromDefinition;
        SplashScreen = fromDefinition.SplashScreen;
        Icon = fromDefinition.Icon;
        Title = fromDefinition.Title;
        LongTitle = fromDefinition.LongTitle;
        IsPublic = fromDefinition.IsPublic;
        GroupMenuPriority = fromDefinition.GroupMenuPriority;
        MenuPriority = fromDefinition.MenuPriority;
        IsEnabled = true;
        IsChecked = false;
        Arguments = fromDefinition.Arguments;
        StartupURI = fromDefinition.StartupURI;
        Attributes = fromDefinition.Attributes;
        IsLoading = true;
        if (!fromDefinition.IsPublic)
        {
            if  (SessionManager.Instance.CurrentSession?.ID == 0) throw new InvalidDataException(Resources.Strings.Application.NoSessionForPrivateApp);
            SessionID = SessionManager.Instance.CurrentSession?.ID ?? throw new InvalidDataException(Resources.Strings.Application.NoSessionForPrivateApp);
        }
        else { SessionID = 0; }

    }
        
    public long SessionID { get; set; }

    private object _content = null;
    public object Content
    {
        get { return _content; }
        set
        { 
            _content = value;
            if (IsLoading == true) IsLoading = false;
            RaisePropertyChanged(nameof(Content));
        }
    }

    private object _notifyContent = null;
    public object NotifyContent
    {
        get { return _notifyContent; }
        set { _notifyContent = value; RaisePropertyChanged(nameof(NotifyContent)); }
    }

    private bool _isloading = true;
    public bool IsLoading
    {
        get { return _isloading; }
        set
        { _isloading = value; RaisePropertyChanged(nameof(IsLoading)); }
    }

    public ApplicationDefinition Metadata { get; } = null;

    // Overrides
    public override string ToString()
    {
        return string.Format("[{0}] - {1}", SessionID, TooltipTilte);
    }

    //Methods
    public void RaiseAppClosed()
    {
        AppClosed?.Invoke(this, EventArgs.Empty);
        Dispose();
    }

    public void Dispose()
    {
        if (Content != null && typeof(IDisposable).IsAssignableFrom(Content.GetType()))
        {
            IDisposable i = (IDisposable)Content;
            i.Dispose();
        }

    }

    // Events
    public event EventHandler AppClosed;


    //public override bool Equals(object obj)
    //{
    //    if (!(obj is ApplicationDefinition)) { return base.Equals(obj); }
    //    return _metadata == obj;
    //}

    //public override int GetHashCode()
    //{
    //    return base.GetHashCode();
    //}

}

public sealed class ApplicationAttribute
{
    public string Key { get; set; }
    public object Value { get; set; }
}

public sealed class ApplicationAttributeCollection : List<ApplicationAttribute>
{
    public object Item(string key)
    {
        return this.Where(it => it.Key == key).Select(it => it.Value).FirstOrDefault();
    }
}
