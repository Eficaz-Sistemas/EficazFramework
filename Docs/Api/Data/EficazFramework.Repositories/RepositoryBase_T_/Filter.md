#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[RepositoryBase&lt;T&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>')

## RepositoryBase<T>.Filter Property

Expressão lambda para filtragem de dados dos métodos Get e GetAsync.

```csharp
public System.Linq.Expressions.Expression<System.Func<T,bool>> Filter { get; set; }
```

#### Property Value
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')