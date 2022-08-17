#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Enums.CRUD](EficazFrameworkData.md#EficazFramework.Enums.CRUD 'EficazFramework.Enums.CRUD')

## RequestAction Enum

Utilizado em [ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>') para determiner qual ação o método [RequestMethod&lt;TBody,TResult&gt;(RequestAction, string, TBody, CancellationToken)](EficazFramework.Repositories/ApiRepository_TEntity_/RequestMethod_TBody,TResult_(RequestAction,string,TBody,CancellationToken).md 'EficazFramework.Repositories.ApiRepository<TEntity>.RequestMethod<TBody,TResult>(EficazFramework.Enums.CRUD.RequestAction, string, TBody, System.Threading.CancellationToken)') deve executar.

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