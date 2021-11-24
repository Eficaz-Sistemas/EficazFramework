#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[RepositoryBase&lt;T&gt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;')
## RepositoryBase&lt;T&gt;.Filter Property
Expressão lambda para filtragem de dados dos métodos Get e GetAsync.  
```csharp
public System.Linq.Expressions.Expression<System.Func<T,bool>> Filter { get; set; }
```
#### Property Value
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](RepositoryBase_T_.md#EficazFramework_Repositories_RepositoryBase_T__T 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')
