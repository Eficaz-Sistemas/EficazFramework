#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Enums.CRUD](EficazFrameworkData.md#EficazFramework.Enums.CRUD 'EficazFramework.Enums.CRUD')

## RequestAction Enum

Utilizado em [ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>') para determiner qual ação o método [Repositories.ApiRepository&lt;TEntity&gt;.RequestMethod&lt;TBody, TResult&gt;(string, TBody, System.Threading.CancellationToken)](https://docs.microsoft.com/en-us/dotnet/api/Repositories.ApiRepository<TEntity>.RequestMethod<TBody, TResult>#Repositories_ApiRepository<TEntity>_RequestMethod<TBody, TResult>_string, TBody, System_Threading_CancellationToken_ 'Repositories.ApiRepository<TEntity>.RequestMethod<TBody, TResult>(string, TBody, System.Threading.CancellationToken)') deve executar.

```csharp
public enum RequestAction
```
### Fields

<a name='EficazFramework.Enums.CRUD.RequestAction.Get'></a>

`Get` 0

<a name='EficazFramework.Enums.CRUD.RequestAction.Post'></a>

`Post` 1

<a name='EficazFramework.Enums.CRUD.RequestAction.Put'></a>

`Put` 2