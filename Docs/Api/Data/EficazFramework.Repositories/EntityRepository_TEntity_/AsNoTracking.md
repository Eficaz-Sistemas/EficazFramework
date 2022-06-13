#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

## EntityRepository<TEntity>.AsNoTracking Property

Obtém ou define se as queries de FetchItems() e FetchItemsAsync() devem usar o sufixo .AsNoTracking()   
para obter ganho de performance pelo não-monitoramento de alterações de valores nas entidades.  
O valor inicial padrão é TRUE.

```csharp
public bool AsNoTracking { get; set; }
```

Implements [AsNoTracking](EficazFramework.Repositories/IEntityRepository/AsNoTracking.md 'EficazFramework.Repositories.IEntityRepository.AsNoTracking')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')