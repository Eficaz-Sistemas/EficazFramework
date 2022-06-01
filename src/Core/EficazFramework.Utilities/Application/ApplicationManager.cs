﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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

public sealed class ApplicationInstance : ApplicationDefinition, INotifyPropertyChanged, IDisposable
{
    internal ApplicationInstance(ApplicationDefinition fromDefinition, ISectionManager sectionManager)
    {
        var sID = sectionManager.CurrentSection?.ID ?? 0;

        Metadata = fromDefinition;
        Icon = fromDefinition.Icon;
        Title = fromDefinition.Title;
        LongTitle = fromDefinition.LongTitle;
        IsPublic = fromDefinition.IsPublic;
        GroupMenuPriority = fromDefinition.GroupMenuPriority;
        MenuPriority = fromDefinition.MenuPriority;
        IsEnabled = true;
        IsChecked = false;
        AddTargets(fromDefinition.Targets);
        Arguments = fromDefinition.Arguments;
        IsLoading = true;
        if (!fromDefinition.IsPublic)
            SessionID = sID != 0 ? sID : throw new InvalidDataException(Resources.Strings.Application.NoSessionForPrivateApp);
        else
            SessionID = 0;
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
    public override string ToString() =>
        $"[{SessionID}] - {TooltipTilte}";

    //Methods
    private void AddTargets(IEnumerable<ApplicationTarget> source) =>
        ((List<ApplicationTarget>) Targets).AddRange(source);

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

    // INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    public void RaisePropertyChanged(string propertyname) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

    // Events
    public event EventHandler AppClosed;

}