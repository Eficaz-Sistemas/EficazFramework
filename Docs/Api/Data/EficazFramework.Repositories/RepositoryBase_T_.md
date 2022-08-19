#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories')

## RepositoryBase<T> Class

```csharp
public abstract class RepositoryBase<T> :
System.ComponentModel.INotifyPropertyChanged,
System.IDisposable
    where T : class
```
#### Type parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RepositoryBase<T>

Derived  
&#8627; [ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>')  
&#8627; [EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Fields | |
| :--- | :--- |
| [OnAfterGet](EficazFramework.Repositories/RepositoryBase_T_/OnAfterGet.md 'EficazFramework.Repositories.RepositoryBase<T>.OnAfterGet') | |

| Properties | |
| :--- | :--- |
| [CurrentEntry](EficazFramework.Repositories/RepositoryBase_T_/CurrentEntry.md 'EficazFramework.Repositories.RepositoryBase<T>.CurrentEntry') | Entidade atualmente em edição (ou inclusão).<br/>Deve ser definido pelo ViewModel (ou regras de negócio) |
| [CurrentPage](EficazFramework.Repositories/RepositoryBase_T_/CurrentPage.md 'EficazFramework.Repositories.RepositoryBase<T>.CurrentPage') | Página atual dos métodos FetchItems e FetchItemsAsync. Será sempre 0 ou 1 quando a paginação estiver desabilitada. |
| [DataContext](EficazFramework.Repositories/RepositoryBase_T_/DataContext.md 'EficazFramework.Repositories.RepositoryBase<T>.DataContext') | Contém a enumeração dos resultados obtidos nos métodos Get e GetAsync. |
| [Filter](EficazFramework.Repositories/RepositoryBase_T_/Filter.md 'EficazFramework.Repositories.RepositoryBase<T>.Filter') | Expressão lambda para filtragem de dados dos métodos Get e GetAsync. |
| [OrderByDefinitions](EficazFramework.Repositories/RepositoryBase_T_/OrderByDefinitions.md 'EficazFramework.Repositories.RepositoryBase<T>.OrderByDefinitions') | Definições de ordenação da enumeração dos resultados da propriedade DataContext. |
| [PageSize](EficazFramework.Repositories/RepositoryBase_T_/PageSize.md 'EficazFramework.Repositories.RepositoryBase<T>.PageSize') | Utilizado para habilitar a paginação da busca, definindo o tamanho da página de resultados. Utilize 0 para não utilizar paginação. |
| [Validator](EficazFramework.Repositories/RepositoryBase_T_/Validator.md 'EficazFramework.Repositories.RepositoryBase<T>.Validator') | Instância de classe de validação Fluente para objetos T. |

| Methods | |
| :--- | :--- |
| [Add(object, bool)](EficazFramework.Repositories/RepositoryBase_T_/Add(object,bool).md 'EficazFramework.Repositories.RepositoryBase<T>.Add(object, bool)') | s<br/>            Adiciona um item recém-criado à lista de items. |
| [AddAsync(object, bool, CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/AddAsync(object,bool,CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.AddAsync(object, bool, System.Threading.CancellationToken)') | Adiciona um item recém-criado à lista de items. |
| [Cancel(object)](EficazFramework.Repositories/RepositoryBase_T_/Cancel(object).md 'EficazFramework.Repositories.RepositoryBase<T>.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [CancelAsync(object)](EficazFramework.Repositories/RepositoryBase_T_/CancelAsync(object).md 'EficazFramework.Repositories.RepositoryBase<T>.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [Commit()](EficazFramework.Repositories/RepositoryBase_T_/Commit().md 'EficazFramework.Repositories.RepositoryBase<T>.Commit()') | Efetua a persistência dos dados junto ao ambiente de armazenamento. |
| [CommitAsync(CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/CommitAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.CommitAsync(System.Threading.CancellationToken)') | Efetua a persistência dos dados junto ao ambiente de armazenamento. |
| [Create()](EficazFramework.Repositories/RepositoryBase_T_/Create().md 'EficazFramework.Repositories.RepositoryBase<T>.Create()') | Solicita a criação de uma nova instância de T |
| [Create&lt;T2&gt;()](EficazFramework.Repositories/RepositoryBase_T_/Create_T2_().md 'EficazFramework.Repositories.RepositoryBase<T>.Create<T2>()') | Solicita a criação de uma nova instância de T2 |
| [Delete(object, bool)](EficazFramework.Repositories/RepositoryBase_T_/Delete(object,bool).md 'EficazFramework.Repositories.RepositoryBase<T>.Delete(object, bool)') | Solicita a exclusão de um item da lista de items |
| [DeleteAsync(object, bool, CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/DeleteAsync(object,bool,CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.DeleteAsync(object, bool, System.Threading.CancellationToken)') | Solicita a exclusão de um item da lista de items |
| [Detach(object)](EficazFramework.Repositories/RepositoryBase_T_/Detach(object).md 'EficazFramework.Repositories.RepositoryBase<T>.Detach(object)') | Solicita que o item seja desanexado do contexto de persistÊncia. |
| [Dispose()](EficazFramework.Repositories/RepositoryBase_T_/Dispose().md 'EficazFramework.Repositories.RepositoryBase<T>.Dispose()') | |
| [FetchItems()](EficazFramework.Repositories/RepositoryBase_T_/FetchItems().md 'EficazFramework.Repositories.RepositoryBase<T>.FetchItems()') | Aciona a busca de dados contra a base. |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.FetchItemsAsync(System.Threading.CancellationToken)') | Aciona a busca de dados contra a base. |
| [FirstPage()](EficazFramework.Repositories/RepositoryBase_T_/FirstPage().md 'EficazFramework.Repositories.RepositoryBase<T>.FirstPage()') | Move os método(s) Get e GetAsync para a primeira página (apenas quando a paginação estiver habilitada). |
| [Get()](EficazFramework.Repositories/RepositoryBase_T_/Get().md 'EficazFramework.Repositories.RepositoryBase<T>.Get()') | Executa a solicitação da listagem de resultados |
| [GetAsync(CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/GetAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.GetAsync(System.Threading.CancellationToken)') | Executa a solicitação da listagem de resultados |
| [NextPage()](EficazFramework.Repositories/RepositoryBase_T_/NextPage().md 'EficazFramework.Repositories.RepositoryBase<T>.NextPage()') | Move os método(s) Get e GetAsync para a próxima página (apenas quando a paginação estiver habilitada). |
| [OnValidate(T)](EficazFramework.Repositories/RepositoryBase_T_/OnValidate(T).md 'EficazFramework.Repositories.RepositoryBase<T>.OnValidate(T)') | |
| [OnValidateAsync(T)](EficazFramework.Repositories/RepositoryBase_T_/OnValidateAsync(T).md 'EficazFramework.Repositories.RepositoryBase<T>.OnValidateAsync(T)') | |
| [PreviousPage()](EficazFramework.Repositories/RepositoryBase_T_/PreviousPage().md 'EficazFramework.Repositories.RepositoryBase<T>.PreviousPage()') | Move os método(s) Get e GetAsync para a página anterior (apenas quando a paginação estiver habilitada). |
| [Validate(T)](EficazFramework.Repositories/RepositoryBase_T_/Validate(T).md 'EficazFramework.Repositories.RepositoryBase<T>.Validate(T)') | Efetua Validação da instância especsificada ou de todo o DataContext |
| [ValidateAsync(T)](EficazFramework.Repositories/RepositoryBase_T_/ValidateAsync(T).md 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync(T)') | Efetua Validação da instância especificada ou de todo o DataContext |
| [ValidateAsync&lt;T2&gt;(T2, Validator&lt;T2&gt;)](EficazFramework.Repositories/RepositoryBase_T_/ValidateAsync_T2_(T2,Validator_T2_).md 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync<T2>(T2, EficazFramework.Validation.Fluent.Validator<T2>)') | Efetua Validação da instância especificada ou de todo o DataContext |

| Events | |
| :--- | :--- |
| [PropertyChanged](EficazFramework.Repositories/RepositoryBase_T_/PropertyChanged.md 'EficazFramework.Repositories.RepositoryBase<T>.PropertyChanged') | |
