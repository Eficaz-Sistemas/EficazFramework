using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace EficazFramework.Application;

public interface IApplicationManager
{
    /// <summary>
    /// Inicia e retorna uma nova instância de ApplicationManager.
    /// </summary>
    private static IApplicationManager Create() =>
        new ApplicationManager();

    private static IApplicationManager? _instance = null;
    /// <summary>
    /// Retorna em padrão singleton a Última Instância de ApplicationManager instanciada.
    /// </summary>
    public static IApplicationManager Instance
    {
        get
        {
            _instance ??= Create();
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    /// <summary>
    /// Instância de SectionManager para gestão de múltiplas área de trabalho.
    /// </summary>
    public ISectionManager SectionManager { get; }

    /// <summary>
    /// Listagem de aplicações disponíveis para trabalho (pode ser utilizada como menu principal)
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
    public ApplicationInstance Activate(ApplicationDefinition application);

    public void Clear();

    public event EventHandler ActiveAppChanged;
}

internal class ApplicationManager : IApplicationManager
{
    internal ApplicationManager()
    {
        _sectionManager = new SectionManager(this);
    }

    private readonly ISectionManager _sectionManager;

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
        return (RunningApplications.Where(app => app.Metadata == application && (app.SessionID == 0 || app.SessionID == (_sectionManager.CurrentSection?.ID ?? 0))).Any());
    }

    /// <summary>
    /// Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.
    /// </summary>
    /// <param name="application">Manifesto de aplicativo a ser iniciado ou ativado.</param>
    public ApplicationInstance Activate(ApplicationDefinition application)
    {
        bool running = IsRunning(application);
        ApplicationInstance? instance = null;
        if (!running)
        {
            instance = new ApplicationInstance(application, _sectionManager.CurrentSectionId);
            RunningApplications.Add(instance);
            instance.AppClosed += AppClosed;
        }
        else
        {
            instance = RunningApplications.Where(app => app.Metadata == application && (app.SessionID == 0 || app.SessionID == (_sectionManager.CurrentSection?.ID ?? 0))).FirstOrDefault();
        }
        ActiveAppChanged?.Invoke(instance, EventArgs.Empty);
        return instance!;
    }

    private void AppClosed(object? sender, System.EventArgs e)
    {
        if (sender is ApplicationInstance instance)
        {
            instance.AppClosed -= AppClosed;
            RunningApplications.Remove(instance);
        }
    }

    public event EventHandler? ActiveAppChanged;

    public void Clear()
    {
        foreach (var all in RunningApplications)
        {
            all.Dispose();
        }
        AllApplications.Clear();
        RunningApplications.Clear();
    }

}

public sealed class ApplicationInstance : ApplicationDefinition, INotifyPropertyChanged, IDisposable
{
    internal ApplicationInstance(ApplicationDefinition fromDefinition, long forSection)
    {
        Id = System.Guid.NewGuid();
        Metadata = fromDefinition;
        Title = fromDefinition.Title;
        LongTitle = fromDefinition.LongTitle;
        IsPublic = fromDefinition.IsPublic;
        GroupMenuPriority = fromDefinition.GroupMenuPriority;
        MenuPriority = fromDefinition.MenuPriority;
        IsEnabled = true;
        IsChecked = false;
        AddTargetProperties(fromDefinition.Targets);
        Arguments = fromDefinition.Arguments;
        IsLoading = true;
        if (!fromDefinition.IsPublic)
            SessionID = forSection != 0 ? forSection : throw new InvalidDataException(Resources.Strings.Application.NoSessionForPrivateApp);
        else
            SessionID = 0;
    }
    
    public static ApplicationInstance Create(ApplicationDefinition fromDefinition, long forSection) =>
        new (fromDefinition, forSection) { SessionID = forSection };

    public System.Guid Id { get; }

    public long SessionID { get; internal set; }


    private object? _content;
    public object? Content
    {
        get => _content;
        set
        {
            _content = value;
            if (IsLoading == true) IsLoading = false;
            RaisePropertyChanged(nameof(Content));
        }
    }


    private object? _notifyContent;
    public object? NotifyContent
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

    public ApplicationDefinition Metadata { get; }

    public IDictionary<string, object> Services { get; } = new Dictionary<string, object>();

    // Overrides
    public override string ToString() =>
        $"[{SessionID}] - {TooltipTilte}";

    //Methods
    private void AddTargetProperties(IDictionary<string, ApplicationTarget> sourceTargets)
    {
        foreach (var sourceTarget in sourceTargets)
        {
            Targets.Add(sourceTarget.Key, sourceTarget.Value.Clone()); ;
        }
    }

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

        foreach(var svc in Services)
            (svc.Value as IDisposable)?.Dispose();

    }

    // INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    public void RaisePropertyChanged(string propertyname) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

    // Events
    public event EventHandler? AppClosed;

}