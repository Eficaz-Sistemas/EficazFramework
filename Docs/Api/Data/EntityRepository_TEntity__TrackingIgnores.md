#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;')
## EntityRepository&lt;TEntity&gt;.TrackingIgnores Property
Informa ao DbContext os tipo de entidades que não devem ser monitorados pelo ChangeTracker.  
Evita marcar entidades desconectadas como .Added().  
```csharp
public System.Collections.Generic.List<System.Type> TrackingIgnores { get; }
```
#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')
