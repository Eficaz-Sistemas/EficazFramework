#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

## EntityRepository<TEntity>.GetIOrderedQueryable(IQueryable<TEntity>, SortDescription, bool) Method

Obtém uma instância de query ordenável (instrução ORDER BY em T-SQL) do tipo IOrderedQueryable.

```csharp
private static System.Linq.IQueryable<TEntity> GetIOrderedQueryable(System.Linq.IQueryable<TEntity> query, EficazFramework.Collections.SortDescription orderbyDefinition, bool use_thenby=false);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.GetIOrderedQueryable(System.Linq.IQueryable_TEntity_,EficazFramework.Collections.SortDescription,bool).query'></a>

`query` [System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')

Instância IQueryable principal, contendo instruções SELECT e WHERE (esta última opcional).

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.GetIOrderedQueryable(System.Linq.IQueryable_TEntity_,EficazFramework.Collections.SortDescription,bool).orderbyDefinition'></a>

`orderbyDefinition` [SortDescription](EficazFramework.Collections/SortDescription.md 'EficazFramework.Collections.SortDescription')

Definições de ordenação (SortDescription).

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.GetIOrderedQueryable(System.Linq.IQueryable_TEntity_,EficazFramework.Collections.SortDescription,bool).use_thenby'></a>

`use_thenby` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se deve ser utilizado o método ThenBy, para multiciplidade de ocorrências de ordenação.

#### Returns
[System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')