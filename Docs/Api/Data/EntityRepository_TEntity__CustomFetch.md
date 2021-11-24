#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;')
## EntityRepository&lt;TEntity&gt;.CustomFetch Property
Obtém ou define se o Repositório deve executar uma função customizada em FetchItems e FetchItemsAsync.  
```csharp
public System.Func<System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<TEntity>>> CustomFetch { get; set; }
```
#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TEntity](EntityRepository_TEntity_.md#EficazFramework_Repositories_EntityRepository_TEntity__TEntity 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')
