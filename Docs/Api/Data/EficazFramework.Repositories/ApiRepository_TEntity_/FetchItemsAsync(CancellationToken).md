#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>')

## ApiRepository<TEntity>.FetchItemsAsync(CancellationToken) Method

s  
            Efetua a instrução GET contra o datasource

```csharp
public override System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<TEntity>> FetchItemsAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.FetchItemsAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[TEntity](EficazFramework.Repositories/ApiRepository_TEntity_.md#EficazFramework.Repositories.ApiRepository_TEntity_.TEntity 'EficazFramework.Repositories.ApiRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')