#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[DataImportRepository&lt;TSource,TCache&gt;](EficazFramework.Repositories/DataImportRepository_TSource,TCache_.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>')

## DataImportRepository<TSource,TCache>.FetchItemsAsync(CancellationToken) Method

Carrega o(s) arquivo(s) no caminho da propriedade DNS (arquivo ou diretório)   
e efetua a análise das informações.

```csharp
public override System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<TSource>> FetchItemsAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.FetchItemsAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[TSource](EficazFramework.Repositories/DataImportRepository_TSource,TCache_.md#EficazFramework.Repositories.DataImportRepository_TSource,TCache_.TSource 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')