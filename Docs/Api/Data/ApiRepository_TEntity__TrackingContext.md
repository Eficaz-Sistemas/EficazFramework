#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[ApiRepository&lt;TEntity&gt;](ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;')
## ApiRepository&lt;TEntity&gt;.TrackingContext Property
(Opcional) Instância de DbContext para Tracking de modificações.  
NOTA: Não exponha a connection string real nesta instância.  
```csharp
public Microsoft.EntityFrameworkCore.DbContext TrackingContext { get; set; }
```
#### Property Value
[Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')
