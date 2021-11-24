#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories')
## ApiRepository&lt;TEntity&gt; Class
```csharp
public sealed class ApiRepository<TEntity> : EficazFramework.Repositories.RepositoryBase<TEntity>
    where TEntity : class
```
#### Type parameters
<a name='EficazFramework_Repositories_ApiRepository_TEntity__TEntity'></a>
`TEntity`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;')[TEntity](ApiRepository_TEntity_.md#EficazFramework_Repositories_ApiRepository_TEntity__TEntity 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.TEntity')[&gt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;') &#129106; ApiRepository&lt;TEntity&gt;  

| Properties | |
| :--- | :--- |
| [TrackingContext](ApiRepository_TEntity__TrackingContext.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.TrackingContext') | (Opcional) Instância de DbContext para Tracking de modificações.<br/>NOTA: Não exponha a connection string real nesta instância.<br/> |
| [UriCancel](ApiRepository_TEntity__UriCancel.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.UriCancel') | URI de requisição para métodos FetchItems() e FetchItemsAsync()<br/> |
| [UriDelete](ApiRepository_TEntity__UriDelete.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.UriDelete') | URI de requisição para métodos FetchItems() e FetchItemsAsync()<br/> |
| [UriGet](ApiRepository_TEntity__UriGet.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.UriGet') | URI de requisição para métodos FetchItems() e FetchItemsAsync()<br/> |
| [UriInsert](ApiRepository_TEntity__UriInsert.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.UriInsert') | URI de requisição para métodos FetchItems() e FetchItemsAsync()<br/> |
| [UriUpdate](ApiRepository_TEntity__UriUpdate.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.UriUpdate') | s<br/>            URI de requisição para métodos FetchItems() e FetchItemsAsync()<br/>             |

| Methods | |
| :--- | :--- |
| [Cancel(object)](ApiRepository_TEntity__Cancel(object).md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext<br/> |
| [CancelAsync(object)](ApiRepository_TEntity__CancelAsync(object).md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext<br/> |
| [CancelByApiAsync(object)](ApiRepository_TEntity__CancelByApiAsync(object).md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.CancelByApiAsync(object)') | Executa o cancelamento da edição por meio da API 'UriCancel'<br/> |
| [CancelByDbContextAsync(object)](ApiRepository_TEntity__CancelByDbContextAsync(object).md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.CancelByDbContextAsync(object)') | Executa o cancelamento da edição por meio do ChangeTracker da instância DbContext<br/> |
| [FetchItems()](ApiRepository_TEntity__FetchItems().md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.FetchItems()') | s<br/>            Efetua a instrução GET contra o datasource<br/>             |
| [FetchItemsAsync(CancellationToken)](ApiRepository_TEntity__FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.FetchItemsAsync(System.Threading.CancellationToken)') | s<br/>            Efetua a instrução GET contra o datasource<br/>             |
| [PostMethod&lt;TBody,TResult&gt;(string, TBody, CancellationToken)](ApiRepository_TEntity__PostMethod_TBody_TResult_(string_TBody_CancellationToken).md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;.PostMethod&lt;TBody,TResult&gt;(string, TBody, System.Threading.CancellationToken)') | método POST base para implementações<br/> |
