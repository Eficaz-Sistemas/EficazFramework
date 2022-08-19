#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>')

## ApiRepository<TEntity>.RequestMethod<TBody,TResult>(RequestAction, string, TBody, CancellationToken) Method

Request base para implementações

```csharp
public System.Threading.Tasks.Task<TResult> RequestMethod<TBody,TResult>(EficazFramework.Enums.CRUD.RequestAction action, string requestUri, TBody body, System.Threading.CancellationToken cancellationToken);
```
#### Type parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).TBody'></a>

`TBody`

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).TResult'></a>

`TResult`
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).action'></a>

`action` [RequestAction](EficazFramework.Enums.CRUD/RequestAction.md 'EficazFramework.Enums.CRUD.RequestAction')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).requestUri'></a>

`requestUri` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).body'></a>

`body` [TBody](EficazFramework.Repositories/ApiRepository_TEntity_/RequestMethod_TBody,TResult_(RequestAction,string,TBody,CancellationToken).md#EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).TBody 'EficazFramework.Repositories.ApiRepository<TEntity>.RequestMethod<TBody,TResult>(EficazFramework.Enums.CRUD.RequestAction, string, TBody, System.Threading.CancellationToken).TBody')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](EficazFramework.Repositories/ApiRepository_TEntity_/RequestMethod_TBody,TResult_(RequestAction,string,TBody,CancellationToken).md#EficazFramework.Repositories.ApiRepository_TEntity_.RequestMethod_TBody,TResult_(EficazFramework.Enums.CRUD.RequestAction,string,TBody,System.Threading.CancellationToken).TResult 'EficazFramework.Repositories.ApiRepository<TEntity>.RequestMethod<TBody,TResult>(EficazFramework.Enums.CRUD.RequestAction, string, TBody, System.Threading.CancellationToken).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')