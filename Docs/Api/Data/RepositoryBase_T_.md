#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories')
## RepositoryBase&lt;T&gt; Class
```csharp
public abstract class RepositoryBase<T> :
System.ComponentModel.INotifyPropertyChanged,
System.IDisposable
    where T : class
```
#### Type parameters
<a name='EficazFramework_Repositories_RepositoryBase_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RepositoryBase&lt;T&gt;  

Derived  
&#8627; [ApiRepository&lt;TEntity&gt;](ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;')  
&#8627; [DataImportRepository&lt;TSource,TCache&gt;](DataImportRepository_TSource_TCache_.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;')  
&#8627; [EntityRepository&lt;TEntity&gt;](EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;')  

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Properties | |
| :--- | :--- |
| [CurrentPage](RepositoryBase_T__CurrentPage.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.CurrentPage') | Página atual dos métodos FetchItems e FetchItemsAsync. Será sempre 0 ou 1 quando a paginação estiver desabilitada.<br/> |
| [DataContext](RepositoryBase_T__DataContext.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.DataContext') | Contém a enumeração dos resultados obtidos nos métodos Get e GetAsync.<br/> |
| [Filter](RepositoryBase_T__Filter.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Filter') | Expressão lambda para filtragem de dados dos métodos Get e GetAsync.<br/> |
| [OrderByDefinitions](RepositoryBase_T__OrderByDefinitions.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.OrderByDefinitions') | Definições de ordenação da enumeração dos resultados da propriedade DataContext.<br/> |
| [PageSize](RepositoryBase_T__PageSize.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.PageSize') | Utilizado para habilitar a paginação da busca, definindo o tamanho da página de resultados. Utilize 0 para não utilizar paginação.<br/> |
| [Validator](RepositoryBase_T__Validator.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Validator') | Instância de classe de validação Fluente para objetos T.<br/> |

| Methods | |
| :--- | :--- |
| [Add(object, bool)](RepositoryBase_T__Add(object_bool).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Add(object, bool)') | Adiciona um item recém-criado à lista de items.<br/> |
| [AddAsync(object, bool, CancellationToken)](RepositoryBase_T__AddAsync(object_bool_CancellationToken).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.AddAsync(object, bool, System.Threading.CancellationToken)') | Adiciona um item recém-criado à lista de items.<br/> |
| [Cancel(object)](RepositoryBase_T__Cancel(object).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext<br/> |
| [CancelAsync(object)](RepositoryBase_T__CancelAsync(object).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext<br/> |
| [Commit()](RepositoryBase_T__Commit().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Commit()') | Efetua a persistência dos dados junto ao ambiente de armazenamento.<br/> |
| [CommitAsync(CancellationToken)](RepositoryBase_T__CommitAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.CommitAsync(System.Threading.CancellationToken)') | Efetua a persistência dos dados junto ao ambiente de armazenamento.<br/> |
| [Create&lt;T2&gt;()](RepositoryBase_T__Create_T2_().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Create&lt;T2&gt;()') | Solicita a criação de uma nova instância de T2<br/> |
| [Create()](RepositoryBase_T__Create().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Create()') | Solicita a criação de uma nova instância de T<br/> |
| [Delete(object, bool)](RepositoryBase_T__Delete(object_bool).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Delete(object, bool)') | Solicita a exclusão de um item da lista de items<br/> |
| [DeleteAsync(object, bool, CancellationToken)](RepositoryBase_T__DeleteAsync(object_bool_CancellationToken).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.DeleteAsync(object, bool, System.Threading.CancellationToken)') | Solicita a exclusão de um item da lista de items<br/> |
| [Detach(object)](RepositoryBase_T__Detach(object).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Detach(object)') | Solicita que o item seja desanexado do contexto de persistÊncia.<br/> |
| [DisposeManagedCallerObjects()](RepositoryBase_T__DisposeManagedCallerObjects().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.DisposeManagedCallerObjects()') | Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)<br/> |
| [DisposeUnManagedCallerObjects()](RepositoryBase_T__DisposeUnManagedCallerObjects().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.DisposeUnManagedCallerObjects()') | Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador<br/>Tarefa pendente: definir campos grandes como nulos<br/> |
| [FetchItems()](RepositoryBase_T__FetchItems().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.FetchItems()') | Aciona a busca de dados contra a base.<br/> |
| [FetchItemsAsync(CancellationToken)](RepositoryBase_T__FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.FetchItemsAsync(System.Threading.CancellationToken)') | Aciona a busca de dados contra a base.<br/> |
| [FirstPage()](RepositoryBase_T__FirstPage().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.FirstPage()') | Move os método(s) Get e GetAsync para a primeira página (apenas quando a paginação estiver habilitada).<br/> |
| [Get()](RepositoryBase_T__Get().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Get()') | Executa a solicitação da listagem de resultados<br/> |
| [GetAsync(CancellationToken)](RepositoryBase_T__GetAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.GetAsync(System.Threading.CancellationToken)') | Executa a solicitação da listagem de resultados<br/> |
| [ItemAdded(object)](RepositoryBase_T__ItemAdded(object).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.ItemAdded(object)') | Informa à fonte de dados que o item T deve ser adicionado a unidade de persistência do repositório<br/> |
| [ItemDeleted(object)](RepositoryBase_T__ItemDeleted(object).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.ItemDeleted(object)') | Informa à fonte de dados que o item T deve ser excluído a unidade de persistência do repositório<br/> |
| [NextPage()](RepositoryBase_T__NextPage().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.NextPage()') | Move os método(s) Get e GetAsync para a próxima página (apenas quando a paginação estiver habilitada).<br/> |
| [PreviousPage()](RepositoryBase_T__PreviousPage().md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.PreviousPage()') | Move os método(s) Get e GetAsync para a página anterior (apenas quando a paginação estiver habilitada).<br/> |
| [Validate(T)](RepositoryBase_T__Validate(T).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.Validate(T)') | Efetua Validação da instância especsificada ou de todo o DataContext<br/> |
| [ValidateAsync&lt;T2&gt;(T2, Validator&lt;T2&gt;)](RepositoryBase_T__ValidateAsync_T2_(T2_Validator_T2_).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.ValidateAsync&lt;T2&gt;(T2, EficazFramework.Validation.Fluent.Validator&lt;T2&gt;)') | Efetua Validação da instância especificada ou de todo o DataContext<br/> |
| [ValidateAsync(T)](RepositoryBase_T__ValidateAsync(T).md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.ValidateAsync(T)') | Efetua Validação da instância especificada ou de todo o DataContext<br/> |
