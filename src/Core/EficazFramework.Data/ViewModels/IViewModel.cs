using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.ViewModels;

/// <summary>
/// Provê a estrutura básica de ViewModel em leitura tabular.
/// Adicione funções, como operações CRUD e Registro de Repositório utilizando as extensões disponíveis
/// </summary>
public class ViewModel<T> : INotifyPropertyChanged, IDisposable where T : class
{

    public ViewModel()
    {
        SectionID = Application.IApplicationManager.Instance?.SectionManager.CurrentSection?.ID ?? 0;
        Commands.Add("Get", new EficazFramework.Commands.CommandBase(Get_Execute));
    }

    public ViewModel(long sectionId)
    {
        SectionID = sectionId;
        Commands.Add("Get", new EficazFramework.Commands.CommandBase(Get_Execute));
    }

    private System.Threading.CancellationTokenSource _CancelationTokenSource = null;

    public object[] Arguments { get; set; }

    public bool IsLoading { get; private set; } = false;
    public string LoadingMessage { get; private set; }

    private Enums.CRUD.State _state = Enums.CRUD.State.Bloqueado;
    public Enums.CRUD.State State
    {
        get => _state;

        internal set
        {
            _state = value;
            RaisePropertyChanged(nameof(State));
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public long SectionID { get; private set; } = 0;

    // ### Persistance
    private Repositories.RepositoryBase<T> _repository;
    public Repositories.RepositoryBase<T> Repository
    {
        get => _repository;

        internal set
        {
            _repository = value;
            RaisePropertyChanged(nameof(Repository));
        }
    }


    // ### Actions
    public Collections.ObservableDictionary<string, Commands.CommandBase> Commands { get; private set; } = new Collections.ObservableDictionary<string, Commands.CommandBase>();


    // ### Service Injection
    internal Dictionary<string, Services.ViewModelService<T>> _servicesInternal = [];
    public Dictionary<string, Services.ViewModelService<T>> Services => _servicesInternal;

    internal bool FailAssertion { get; set; } = false;


    /// <summary>
    /// Notifica às views que houve alteração em alguma propriedade do ViewModel
    /// </summary>
    /// <param name="propertyName">Nome da propriedade que deve notificar a View para atualização de Binding</param>
    public void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Determina o estado de Loading e a Mensagem ao usuário
    /// </summary>
    /// <param name="loading">Estado de loading: True ou False</param>
    /// <param name="message">Mensagem de loading desejada</param>
    public void SetState(Enums.CRUD.State state, bool loading, string message = null)
    {
        _state = state;
        LoadingMessage = message;
        IsLoading = loading;
        RaisePropertyChanged(nameof(LoadingMessage));
        RaisePropertyChanged(nameof(IsLoading));
        RaisePropertyChanged(nameof(State));
        StateChanged?.Invoke(this, EventArgs.Empty);
    }



    // ### Cancelation Token

    /// <summary>
    /// Inicia um novo Token de Cancelamento para operações assíncronas, ao passo que cancela qualquer operação assíncrona em andamento
    /// </summary>
    public void StartNewAsyncOperation()
    {
        CancelCurrentOperation();
        CreatActionToken();
    }

    /// <summary>
    /// Cria um novo token de cancelamento de operação assíncrona
    /// </summary>
    public System.Threading.CancellationTokenSource CreatActionToken()
    {
        _CancelationTokenSource = new System.Threading.CancellationTokenSource();
        return _CancelationTokenSource;
    }

    /// <summary>
    /// Executa o cancelamento da operação assíncrona em andamento
    /// </summary>
    public void CancelCurrentOperation()
    {
        if (_CancelationTokenSource is null)
            return;
        if (_CancelationTokenSource.IsCancellationRequested == false)
            _CancelationTokenSource.Cancel();
        // Me._CancelationTokenSource.Token.ThrowIfCancellationRequested()
        _CancelationTokenSource.Dispose();
    }

    /// <summary>
    /// Finaliza o Token de Cancelamento da operação assíncrona Finalizada
    /// </summary>
    public void FinishCurrentOperation()
    {
        if (_CancelationTokenSource != null && _CancelationTokenSource.IsCancellationRequested == false)
        {
            _CancelationTokenSource.Dispose();
            _CancelationTokenSource = null;
        }
    }


    // ### Commands
    private async void Get_Execute(object sender, Events.ExecuteEventArgs e)
    {
        if (e.Parameter as System.Linq.Expressions.Expression<Func<T, bool>> != null)
        {
            Repository.Filter = (System.Linq.Expressions.Expression<Func<T, bool>>)e.Parameter;
        }
        await GetAsync();
    }


    // ### Persistance

    /// <summary>
    /// Solicita o Get no repositório de dados.
    /// </summary>
    public void Get()
    {
        if (BeginGet().Cancel == true)
            return;
        SetState(EficazFramework.Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultLoadingMessage);
        Repository.Get();
        OnEntrySetup(null);
        EndGet();
    }

    /// <summary>
    /// Solicita o Get no repositório de dados.
    /// </summary>
    /// <returns></returns>
    public async Task GetAsync()
    {
        if (BeginGet().Cancel == true)
            return;
        SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.CancelingCurrentAsyncMethod);
        CancelCurrentOperation();
        SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultLoadingMessage);
        CreatActionToken();
        await Repository.GetAsync(_CancelationTokenSource.Token);
        await OnEntrySetup(null);
        EndGet();
    }

    /// <summary>
    /// Executado antes dos métodos Get ou GetAsync do Repositório, permitindo interceptar algum parâmetro ou toda a operação
    /// </summary>
    /// <returns></returns>
    private Events.CRUDEventArgs<T> BeginGet()
    {
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DataFetching, Enums.CRUD.State.Processando, null);
        ViewModelAction?.Invoke(this, args);
        if (args.Cancel == true)
            return args;
        ItemsFetching?.Invoke(this, args);
        return args;
    }

    /// <summary>
    /// Executado ao final dos métodos Get ou GetAsync do Repositório
    /// </summary>
    private void EndGet()
    {
        FinishCurrentOperation();
        if (Repository.DataContext.Count > 0)
            SetState(EficazFramework.Enums.CRUD.State.Leitura, false, null);
        else
            SetState(EficazFramework.Enums.CRUD.State.Bloqueado, false, null);
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DataFetched, State, null);
        ItemsFetched?.Invoke(this, args);
    }



    // ### Dialog messages

    public void RaiseDialogMessage(Events.MessageEventArgs args)
    {
        ShowMessage?.Invoke(this, args);
    }



    // ### View Model Actions by Services

    /// <summary>
    /// Permite aos serviços a execução de Eventos de Comandos de ViewModel
    /// </summary>
    public void RaiseViewModelEvent(Events.CRUDEventArgs<T> args)
    {
        ViewModelAction?.Invoke(this, args);
    }

    /// <summary>
    /// Disparado quando alguma propriedade de entidade monitorada sofre alteração de valor.
    /// </summary>
    public virtual void OnEntryPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        EntryPropertyChanged?.Invoke(sender, e);
    }

    /// <summary>
    /// Possibilita efetuar modificações nas entidades em ações específicas dos Serviços injetados.
    /// Considere configurar todas as entidades de Repository.DataContext quando o argumento entry for null.
    /// NOTA: Corresponde aos métodos PostProcessItem() e PostProcessCollection() da EficazFrameworkV3.
    /// </summary>
    public virtual Task OnEntrySetup(T entry)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Evento disparado quando uma propriedade do ViewModel é alterada.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Evento disparado quando uma propriedade da Entidade do DataContext é alterada.
    /// </summary>
    public event PropertyChangedEventHandler EntryPropertyChanged;

    /// <summary>
    /// Evento disparado quando o estado do ViewModel é alterado por alguma ação ou comando, indicando que pode haver notificações à view.
    /// </summary>
    public event EventHandler StateChanged;

    /// <summary>
    /// Evento disparado antes dos métodos Get e GetAsync.
    /// </summary>
    public event Events.CRUDEventHandler<T> ItemsFetching;

    /// <summary>
    /// Evento disparado após ao final dos métodos Get e GetAsync.
    /// </summary>
    public event Events.CRUDEventHandler<T> ItemsFetched;

    /// <summary>
    /// Dispara uma requisição de Caixa de Diálogo para a View.
    /// </summary>
    public event Events.MessageEventHandler ShowMessage;

    /// <summary>
    /// Permite que os serviços executem o disparo de seus sub-eventos na classe principal.
    /// </summary>
    public event Events.CRUDEventHandler<T> ViewModelAction;

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                if (_CancelationTokenSource != null)
                    CancelCurrentOperation();
                Repository?.Dispose();
                var services = Services.ToList();
                services.ForEach(s => s.Value.Dispose());
                services = null;
                _servicesInternal.Clear();
                Commands.Clear();
                DisposeManagedCallerObjects();
            }

            // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
            // Tarefa pendente: definir campos grandes como nulos
            DisposeUnManagedCallerObjects();
            disposedValue = true;
        }
    }

    // ' Tarefa pendente: substituir o finalizador somente se 'Dispose(disposing As Boolean)' tiver o código para liberar recursos não gerenciados
    // Protected Overrides Sub Finalize()
    // ' Não altere este código. Coloque o código de limpeza no método 'Dispose(disposing As Boolean)'
    // Dispose(disposing:=False)
    // MyBase.Finalize()
    // End Sub

    public void Dispose()
    {
        // Não altere este código. Coloque o código de limpeza no método 'Dispose(disposing As Boolean)'
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
    /// </summary>
    public virtual void DisposeManagedCallerObjects()
    {
    }

    /// <summary>
    /// Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
    /// Tarefa pendente: definir campos grandes como nulos
    /// </summary>
    public virtual void DisposeUnManagedCallerObjects()
    {
    }

}
