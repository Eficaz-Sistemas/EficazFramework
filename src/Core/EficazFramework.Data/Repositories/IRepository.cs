using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace EficazFramework.Repositories;

public abstract class RepositoryBase<T> : INotifyPropertyChanged, IDisposable where T : class
{

    #region Get

    /// <summary>
    /// Página atual dos métodos FetchItems e FetchItemsAsync. Será sempre 0 ou 1 quando a paginação estiver desabilitada.
    /// </summary>
    /// <returns></returns>
    public int CurrentPage { get; private set; } = 0;


    private int _pagesize = 0;
    /// <summary>
    /// Utilizado para habilitar a paginação da busca, definindo o tamanho da página de resultados. Utilize 0 para não utilizar paginação.
    /// </summary>
    /// <returns></returns>
    public int PageSize
    {
        get => _pagesize;

        set
        {
            _pagesize = value;
            RaisePropertyChanged(nameof(PageSize));
        }
    }


    /// <summary>
    /// Expressão lambda para filtragem de dados dos métodos Get e GetAsync.
    /// </summary>
    /// <returns></returns>
    public System.Linq.Expressions.Expression<Func<T, bool>> Filter { get; set; } = null;


    /// <summary>
    /// Definições de ordenação da enumeração dos resultados da propriedade DataContext.
    /// </summary>
    /// <returns></returns>
    public List<Collections.SortDescription> OrderByDefinitions { get; } = new List<Collections.SortDescription>();



    /// <summary>
    /// Aciona a busca de dados contra a base.
    /// </summary>
    /// <returns></returns>
    public abstract ObservableCollection<T> FetchItems();

    /// <summary>
    /// Aciona a busca de dados contra a base.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Task<ObservableCollection<T>> FetchItemsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Executa a solicitação da listagem de resultados
    /// </summary>
    public void Get()
    {
        if (CurrentPage == 0)
            CurrentPage = 1;
        RaisePropertyChanged(nameof(CurrentPage));
        DataContext = (EficazFramework.Collections.AsyncObservableCollection<T>)FetchItems();
        RaisePropertyChanged(nameof(DataContext));
        OnAfterGet?.Invoke();
    }

    /// <summary>
    /// Executa a solicitação da listagem de resultados
    /// </summary>
    public async Task GetAsync(CancellationToken cancellationToken)
    {
        if (CurrentPage == 0)
            CurrentPage = 1;
        RaisePropertyChanged(nameof(CurrentPage));
        DataContext = (EficazFramework.Collections.AsyncObservableCollection<T>)await FetchItemsAsync(cancellationToken);
        RaisePropertyChanged(nameof(DataContext));
        OnAfterGet?.Invoke();

    }

    public Action OnAfterGet = null;

    #endregion



    #region T

    /// <summary>
    /// Entidade atualmente em edição (ou inclusão).
    /// Deve ser definido pelo ViewModel (ou regras de negócio)
    /// </summary>
    public T CurrentEntry { get; set; } = null;

    /// <summary>
    /// Solicita a criação de uma nova instância de T
    /// </summary>
    public abstract T Create();


    /// <summary>
    /// Contém a enumeração dos resultados obtidos nos métodos Get e GetAsync.
    /// </summary>
    /// <returns></returns>
    public Collections.AsyncObservableCollection<T> DataContext { get; private set; } = new Collections.AsyncObservableCollection<T>();


    private EficazFramework.Validation.Fluent.Validator<T> _validator;
    /// <summary>
    /// Instância de classe de validação Fluente para objetos T.
    /// </summary>
    /// <returns></returns>
    public EficazFramework.Validation.Fluent.Validator<T> Validator
    {
        get => _validator;

        set
        {
            _validator = value;
            RaisePropertyChanged(nameof(Validator));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Efetua Validação da instância especsificada ou de todo o DataContext
    /// </summary>
    public EficazFramework.Validation.Fluent.ValidationResult Validate(T instance)
    {
        if (instance != null && _validator != null)
            return _validator.Validate(instance);

        var result = new EficazFramework.Validation.Fluent.ValidationResult();
        if (_validator is null)
            return result;

        if (instance == null)
        {
            foreach (var item in DataContext)
                result.AddRange(_validator.Validate(item));
        }
        result.AddRange(OnValidate(instance));

        return result;
    }

    /// <summary>
    /// Efetua Validação da instância especificada ou de todo o DataContext
    /// </summary>
    public async Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(T instance)
    {
        if (instance != null && _validator != null)
            return await _validator.ValidateAsync(instance);

        var result = new EficazFramework.Validation.Fluent.ValidationResult();
        if (_validator is null)
            return result;


        if (instance == null)
        {
            foreach (var item in DataContext)
                result.AddRange(await _validator.ValidateAsync(item));
        }
        result.AddRange(await OnValidateAsync(instance));

        return result;
    }

    public virtual EficazFramework.Validation.Fluent.ValidationResult OnValidate(T instance) => Validation.Fluent.ValidationResult.Empty;
    public virtual async Task<EficazFramework.Validation.Fluent.ValidationResult> OnValidateAsync(T instance) => await Task.Run(() => Validation.Fluent.ValidationResult.Empty);
    #endregion



    #region Generic

    /// <summary>s
    /// Adiciona um item recém-criado à lista de items.
    /// </summary>
    public Exception Add(object item, bool commit)
    {
        AddInternal(item);
        if (commit)
            return Commit();
        return null;
    }

    /// <summary>
    /// Adiciona um item recém-criado à lista de items.
    /// </summary>
    public async Task<Exception> AddAsync(object item, bool commit, CancellationToken cancellationToken)
    {
        AddInternal(item);
        if (commit)
            return await CommitAsync(cancellationToken);
        return null;
    }

    private void AddInternal(object item)
    {
        if (item is T t && (!DataContext.Contains(t)))
            DataContext.Add(t);
        ItemAdded(item);
    }

    /// <summary>
    /// Informa à fonte de dados que o item T deve ser adicionado a unidade de persistência do repositório
    /// </summary>
    internal virtual void ItemAdded(object item) { }


    /// <summary>
    /// Solicita a exclusão de um item da lista de items
    /// </summary>
    public Exception Delete(object item, bool commit)
    {
        DeleteInternal(item);
        Exception delEx = null;
        if (commit) delEx = Commit();
        if (delEx != null && item is T t) DataContext.Add(t);
        return delEx;
    }

    /// <summary>
    /// Solicita a exclusão de um item da lista de items
    /// </summary>
    public async Task<Exception> DeleteAsync(object item, bool commit, CancellationToken cancellationToken)
    {
        DeleteInternal(item);
        Exception delEx = null;
        if (commit) delEx = await CommitAsync(cancellationToken);
        if (delEx != null && item is T t) DataContext.Add(t);
        return delEx;
    }

    private void DeleteInternal(object item)
    {
        if (item is T t && DataContext.Contains(t))
            DataContext.Remove(t);
        ItemDeleted(item);
    }

    /// <summary>
    /// Informa à fonte de dados que o item T deve ser excluído a unidade de persistência do repositório
    /// </summary>
    /// <param name="item"></param>
    internal virtual void ItemDeleted(object item) { }


    /// <summary>
    /// Efetua a persistência dos dados junto ao ambiente de armazenamento.
    /// </summary>
    public abstract Exception Commit();

    /// <summary>
    /// Efetua a persistência dos dados junto ao ambiente de armazenamento.
    /// </summary>
    public abstract Task<Exception> CommitAsync(CancellationToken cancellationToken);



    /// <summary>
    /// Solicita o cancelamento das alterações efetuadas no argumento item.
    /// Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext
    /// </summary>
    public abstract Exception Cancel(object item);

    /// <summary>
    /// Solicita o cancelamento das alterações efetuadas no argumento item.
    /// Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext
    /// </summary>
    public abstract Task<Exception> CancelAsync(object item);


    /// <summary>
    /// Solicita que o item seja desanexado do contexto de persistÊncia.
    /// </summary>
    public abstract void Detach(object item);

    #endregion



    #region T2

    /// <summary>
    /// Solicita a criação de uma nova instância de T2
    /// </summary>
    public abstract T2 Create<T2>() where T2 : class;


    /// <summary>
    /// Efetua Validação da instância especificada ou de todo o DataContext
    /// </summary>
    public virtual async Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync<T2>(T2 instance, Validation.Fluent.Validator<T2> customValidator) where T2 : class
    {
        if (instance != null && customValidator != null)
            return await customValidator.ValidateAsync(instance);
        var result = new EficazFramework.Validation.Fluent.ValidationResult();
        if (customValidator is null)
            return result;
        foreach (var item in DataContext)
            result.AddRange(await customValidator.ValidateAsync(item));
        return result;
    }

    #endregion



    #region Navigation

    /// <summary>
    /// Move os método(s) Get e GetAsync para a primeira página (apenas quando a paginação estiver habilitada).
    /// </summary>
    /// <returns></returns>
    public bool FirstPage()
    {
        if (CurrentPage == 1 || CurrentPage == 0)
            return false;
        CurrentPage = 1;
        RaisePropertyChanged(nameof(CurrentPage));
        return true;
    }

    /// <summary>
    /// Move os método(s) Get e GetAsync para a página anterior (apenas quando a paginação estiver habilitada).
    /// </summary>
    /// <returns></returns>
    public bool PreviousPage()
    {
        if (CurrentPage <= 1)
            return false;
        CurrentPage -= 1;
        RaisePropertyChanged(nameof(CurrentPage));
        return true;
    }

    /// <summary>
    /// Move os método(s) Get e GetAsync para a próxima página (apenas quando a paginação estiver habilitada).
    /// </summary>
    /// <returns></returns>
    public bool NextPage()
    {
        if ((DataContext?.Count <= 0 || DataContext?.Count < PageSize) && CurrentPage > 1)
            return false;
        CurrentPage += 1;
        RaisePropertyChanged(nameof(CurrentPage));
        return true;
    }

    #endregion



    #region HandlersEvents

    internal void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion



    #region Dispose

    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                Filter = null;
                if (OrderByDefinitions != null)
                    OrderByDefinitions.Clear();
                DisposeManagedCallerObjects();
            }

            // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
            // Tarefa pendente: definir campos grandes como nulos
            if (DataContext != null)
                DataContext.Clear();
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
    internal virtual void DisposeManagedCallerObjects()
    {
    }

    /// <summary>
    /// Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
    /// Tarefa pendente: definir campos grandes como nulos
    /// </summary>
    internal virtual void DisposeUnManagedCallerObjects()
    {
    }

    #endregion
}

public interface IAuditableRepository
{
    event EventHandler OnCommit;
    event EventHandler OnDelete;
}
