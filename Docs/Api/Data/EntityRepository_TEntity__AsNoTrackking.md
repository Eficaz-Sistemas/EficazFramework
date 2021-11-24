#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;')
## EntityRepository&lt;TEntity&gt;.AsNoTrackking Property
Obtém ou define se as queries de FetchItems() e FetchItemsAsync() devem usar o sufixo .AsNoTracking()   
para obter ganho de performance pelo não-monitoramento de alterações de valores nas entidades.  
O valor inicial padrão é TRUE.  
```csharp
public bool AsNoTrackking { get; set; }
```
#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
