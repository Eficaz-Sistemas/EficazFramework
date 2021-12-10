#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

## EntityRepository<TEntity>.DbContextInstanceRequest Event

Evento disparado quando o Repositório precisa de uma nova instância de DbContext.

```csharp
public event DbContextInstanceCreatingEventHandler DbContextInstanceRequest;
```

#### Event Type
[EficazFramework.Events.DbContextInstanceCreatingEventHandler](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.DbContextInstanceCreatingEventHandler 'EficazFramework.Events.DbContextInstanceCreatingEventHandler')