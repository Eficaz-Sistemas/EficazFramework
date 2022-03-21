using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace EficazFramework.Application;

public interface IApplicationManager
{
    /// <summary>
    /// Inicia e retorna uma nova instância de ApplicationManager.
    /// </summary>
    public static IApplicationManager Create()
    {
        return new ApplicationManager();
    }

    /// <summary>
    /// Retorna em padrão singleton a Última Instância de ApplicationManager instanciada.
    /// </summary>
    public static IApplicationManager Instance { get; private set; }

    /// <summary>
    /// Instância de SectionManager para gestão de múltiplas área de trabalho.
    /// </summary>
    public ISectionManager SectionManager { get; }

    /// <summary>
    /// Cache de aplicativos em execução
    /// </summary>
    public ObservableCollection<ApplicationDefinition> AllApplications { get; }

    /// <summary>
    /// Cache de aplicativos em execução
    /// </summary>
    public ObservableCollection<ApplicationInstance> RunningApplications { get; }

    /// <summary>
    /// Retorna se um aplicativo está em execução atualmente.
    /// </summary>
    /// <param name="application">Instância de aplicativo a ser verificado.</param>
    /// <returns></returns>
    public bool IsRunning(ApplicationDefinition application);

    /// <summary>
    /// Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.
    /// </summary>
    /// <param name="application">Manifesto de aplicativo a ser iniciado ou ativado.</param>
    public void Activate(ApplicationDefinition application);

    public event EventHandler ActiveAppChanged;
}

internal class ApplicationManager : IApplicationManager
{
    internal ApplicationManager()
    {
        _sectionManager = new SectionManager(this);
        Instance = this;
    }

    private static IApplicationManager _instance = null;
    /// <summary>
    /// Retorna em padrão singleton a Última Instância de ApplicationManager instanciada.
    /// </summary>
    public static IApplicationManager Instance 
    { 
        get
        {
            if (_instance == null) 
                _instance = new ApplicationManager();

            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    private ISectionManager _sectionManager;

    /// <summary>
    /// Instância de SectionManager para gestão de múltiplas área de trabalho.
    /// </summary>
    public ISectionManager SectionManager => _sectionManager;

    /// <summary>
    /// Listagem de aplicações disponíveis para trabalho (pode ser utilizada como menu principal)
    /// </summary>
    public ObservableCollection<ApplicationDefinition> AllApplications { get; } = new ObservableCollection<ApplicationDefinition>();

    /// <summary>
    /// Cache de aplicativos em execução
    /// </summary>
    public ObservableCollection<ApplicationInstance> RunningApplications { get; } = new ObservableCollection<ApplicationInstance>();

    /// <summary>
    /// Retorna se um aplicativo está em execução atualmente.
    /// </summary>
    /// <param name="application">Instância de aplicativo a ser verificado.</param>
    /// <returns></returns>
    public bool IsRunning(ApplicationDefinition application)
    {
        return (RunningApplications.Where(app => app.Metadata == application && (app.SessionID == 0 | app.SessionID == _sectionManager.CurrentSection.ID)).Any());
    }

    /// <summary>
    /// Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.
    /// </summary>
    /// <param name="application">Manifesto de aplicativo a ser iniciado ou ativado.</param>
    public void Activate(ApplicationDefinition application)
    {
        bool running = IsRunning(application);
        ApplicationInstance instance = null;
        if (!running)
        {
            instance = new ApplicationInstance(application, _sectionManager);
            RunningApplications.Add(instance);
            instance.AppClosed += AppClosed;
        }
        else
        {
            instance = RunningApplications.Where(app => app.Metadata == application && (app.SessionID == 0 | app.SessionID == _sectionManager.CurrentSection.ID)).FirstOrDefault();
        }
        ActiveAppChanged?.Invoke(instance, EventArgs.Empty);
    }

    private void AppClosed(object sender, System.EventArgs e)
    {
        var instance = sender as ApplicationInstance;
        if (instance != null)
        {
            instance.AppClosed -= AppClosed;
            RunningApplications.Remove(instance);
        }
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
}

public sealed class ApplicationInstance : ApplicationDefinition, INotifyPropertyChanged, IDisposable
{
    internal ApplicationInstance(ApplicationDefinition fromDefinition, ISectionManager sectionManager)
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
            if  (sectionManager.CurrentSection?.ID == 0) throw new InvalidDataException(Resources.Strings.Application.NoSessionForPrivateApp);
            //SessionID = sectionManager.CurrentSection?.ID ?? throw new InvalidDataException(Resources.Strings.Application.NoSessionForPrivateApp);
        }
        else { SessionID = 0; }

    }

    internal ApplicationInstance()
    {
        //throw new UnauthorizedAccessException();
    }
        
    public long SessionID { get; set; }

    private object _content = null;
    public object Content
    {
        get => _content;
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
        get => _notifyContent;
        set { _notifyContent = value; RaisePropertyChanged(nameof(NotifyContent)); }
    }

    private bool _isloading = true;
    public bool IsLoading
    {
        get => _isloading;
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
    public void Close()
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

}

[ExcludeFromCodeCoverage]
public sealed class ApplicationAttribute
{
    public string Key { get; set; }
    public object Value { get; set; }
}

[ExcludeFromCodeCoverage]
public sealed class ApplicationAttributeCollection : List<ApplicationAttribute>
{
    public object Item(string key)
    {
        return this.Where(it => it.Key == key).Select(it => it.Value).FirstOrDefault();
    }
}

public static class ApplicationExtensions
{
    /// <summary>
    /// Retorna se um aplicativo está em execução atualmente.
    /// </summary>
    /// <param name="application">Instância de aplicativo a ser verificado.</param>
    /// <returns></returns>
    public static bool IsRunning(this ApplicationDefinition application)
    {
        return ApplicationManager.Instance.IsRunning(application);
    }

    /// <summary>
    /// Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.
    /// </summary>
    /// <param name="application">Manifesto de aplicativo a ser iniciado ou ativado.</param>
    public static void Activate(this ApplicationDefinition application)
    {
        ApplicationManager.Instance.Activate(application);
    }

}
