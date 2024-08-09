
namespace EficazFramework.Enums.CRUD;

/// <summary>
/// Efetua a comunicação de estado entre ViewModel e View, posicionando a última na tela condizente ao estado da ViewModel.
/// </summary>
public enum State
{
    /// <summary>
    /// A rotina CRUD está em modo de Adição de nova Entidade.
    /// </summary>
    /// <remarks></remarks>
    Novo = 0,
    /// <summary>
    /// A rotina CRUD está editando uma Entidade já existente.
    /// </summary>
    /// <remarks></remarks>
    Edicao = 1,
    /// <summary>
    /// A rotina CRUD está em modo Somente Leitura.
    /// </summary>
    /// <remarks></remarks>
    Leitura = 2,
    /// <summary>
    /// A rotina CRUD não permite edição nem navegação.
    /// </summary>
    /// <remarks></remarks>
    Bloqueado = 3,
    /// <summary>
    /// A rotina CRUD está ocupada processando alguma operação.
    /// </summary>
    /// <remarks></remarks>
    Processando = 4,
    /// <summary>
    /// A rotina CRUD está em modo de Adição de nova Entidade-Detalhe relacionada à Entidade-Mestre já existente.
    /// </summary>
    /// <remarks></remarks>
    NovoDetalhe = 5,
    /// <summary>
    /// A rotina CRUD está editando uma Entidade-Detalhe relacionada à Entidade-Mestre já existente.
    /// </summary>
    /// <remarks></remarks>
    EdicaoDeDelhe = 6
}

/// <summary>
/// Informa o momento em que o evento ViewModelAction foi disparado
/// </summary>
public enum Action
{
    DataFetching = 0,
    DataFetched = 1,

    Canceled = 2,

    Saving = 4,
    Saved = 5,

    EntrySetupCompleted = 6,

    EntryAdding = 11,
    EntryAdded = 12,

    EntryEditing = 13,
    EntryEdited = 14,

    EntryDeleting = 15,
    EntryDeleted = 16,
    EntryDetached = 17,

    EntryValidating = 19,
    EntryValidated = 20,
    EntryValidationFailed = 21,

    DetailCanceled = 53,
    DetailSaving = 54,
    DetailSaved = 55,
    DetailConfirmed = 56,

    DetailEntryAdding = 61,
    DetailEntryAdded = 62,

    DetailEntryEditing = 63,
    DetailEntryEdited = 64,

    DetailEntryDeleting = 65,
    DetailEntryDeleted = 66

}

/// <summary>
/// Utilizado em <see cref="Repositories.ApiRepository{TEntity}"/> para determiner qual ação o método <see cref="Repositories.ApiRepository{TEntity}.RequestMethod{TBody, TResult}(RequestAction, string, TBody, System.Threading.CancellationToken)"/> deve executar.
/// </summary>
public enum RequestAction
{
    Get = 0,
    Post = 1,
    Put = 2,
    Delete = 3,
    Patch = 4
}
