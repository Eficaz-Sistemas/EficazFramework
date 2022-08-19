#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

## EntityRepository<TEntity>.DbContextRequest Property

Evento disparado quando o Repositório precisa de uma nova instância de DbContext.

```csharp
public System.Func<DbContext> DbContextRequest { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')