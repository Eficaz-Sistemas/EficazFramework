#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories')

## ApiRepository<TEntity> Class

```csharp
public sealed class ApiRepository<TEntity> : EficazFramework.Repositories.RepositoryBase<TEntity>
    where TEntity : class
```
#### Type parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.TEntity'></a>

`TEntity`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>')[TEntity](EficazFramework.Repositories/ApiRepository_TEntity_.md#EficazFramework.Repositories.ApiRepository_TEntity_.TEntity 'EficazFramework.Repositories.ApiRepository<TEntity>.TEntity')[&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>') &#129106; ApiRepository<TEntity>

| Constructors | |
| :--- | :--- |
| [ApiRepository(HttpClient)](EficazFramework.Repositories/ApiRepository_TEntity_/ApiRepository(HttpClient).md 'EficazFramework.Repositories.ApiRepository<TEntity>.ApiRepository(System.Net.Http.HttpClient)') | |

| Properties | |
| :--- | :--- |
| [TrackingContext](EficazFramework.Repositories/ApiRepository_TEntity_/TrackingContext.md 'EficazFramework.Repositories.ApiRepository<TEntity>.TrackingContext') | (Opcional) Instância de DbContext para Tracking de modificações.<br/>NOTA: Não exponha a connection string real nesta instância. |
| [UriCancel](EficazFramework.Repositories/ApiRepository_TEntity_/UriCancel.md 'EficazFramework.Repositories.ApiRepository<TEntity>.UriCancel') | URI de requisição para métodos FetchItems() e FetchItemsAsync() |
| [UriDelete](EficazFramework.Repositories/ApiRepository_TEntity_/UriDelete.md 'EficazFramework.Repositories.ApiRepository<TEntity>.UriDelete') | URI de requisição para métodos FetchItems() e FetchItemsAsync() |
| [UriGet](EficazFramework.Repositories/ApiRepository_TEntity_/UriGet.md 'EficazFramework.Repositories.ApiRepository<TEntity>.UriGet') | URI de requisição para métodos FetchItems() e FetchItemsAsync() |
| [UriInsert](EficazFramework.Repositories/ApiRepository_TEntity_/UriInsert.md 'EficazFramework.Repositories.ApiRepository<TEntity>.UriInsert') | URI de requisição para métodos FetchItems() e FetchItemsAsync() |
| [UriUpdate](EficazFramework.Repositories/ApiRepository_TEntity_/UriUpdate.md 'EficazFramework.Repositories.ApiRepository<TEntity>.UriUpdate') | s<br/>            URI de requisição para métodos FetchItems() e FetchItemsAsync() |

| Methods | |
| :--- | :--- |
| [Cancel(object)](EficazFramework.Repositories/ApiRepository_TEntity_/Cancel(object).md 'EficazFramework.Repositories.ApiRepository<TEntity>.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [CancelAsync(object)](EficazFramework.Repositories/ApiRepository_TEntity_/CancelAsync(object).md 'EficazFramework.Repositories.ApiRepository<TEntity>.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [Commit()](EficazFramework.Repositories/ApiRepository_TEntity_/Commit().md 'EficazFramework.Repositories.ApiRepository<TEntity>.Commit()') | |
| [CommitAsync(CancellationToken)](EficazFramework.Repositories/ApiRepository_TEntity_/CommitAsync(CancellationToken).md 'EficazFramework.Repositories.ApiRepository<TEntity>.CommitAsync(System.Threading.CancellationToken)') | |
| [Create()](EficazFramework.Repositories/ApiRepository_TEntity_/Create().md 'EficazFramework.Repositories.ApiRepository<TEntity>.Create()') | |
| [Create&lt;T2&gt;()](EficazFramework.Repositories/ApiRepository_TEntity_/Create_T2_().md 'EficazFramework.Repositories.ApiRepository<TEntity>.Create<T2>()') | |
| [Detach(object)](EficazFramework.Repositories/ApiRepository_TEntity_/Detach(object).md 'EficazFramework.Repositories.ApiRepository<TEntity>.Detach(object)') | |
| [FetchItems()](EficazFramework.Repositories/ApiRepository_TEntity_/FetchItems().md 'EficazFramework.Repositories.ApiRepository<TEntity>.FetchItems()') | s<br/>            Efetua a instrução GET contra o datasource |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/ApiRepository_TEntity_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.ApiRepository<TEntity>.FetchItemsAsync(System.Threading.CancellationToken)') | s<br/>            Efetua a instrução GET contra o datasource |
