#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;')
## EntityRepository&lt;TEntity&gt;.GetIOrderedQueryable(IQueryable&lt;TEntity&gt;, SortDescription, bool) Method
Obtém uma instância de query ordenável (instrução ORDER BY em T-SQL) do tipo IOrderedQueryable.  
```csharp
private System.Linq.IQueryable<TEntity> GetIOrderedQueryable(System.Linq.IQueryable<TEntity> query, EficazFramework.Collections.SortDescription orderbyDefinition, bool use_thenby=false);
```
#### Parameters
<a name='EficazFramework_Repositories_EntityRepository_TEntity__GetIOrderedQueryable(System_Linq_IQueryable_TEntity__EficazFramework_Collections_SortDescription_bool)_query'></a>
`query` [System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[TEntity](EntityRepository_TEntity_.md#EficazFramework_Repositories_EntityRepository_TEntity__TEntity 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')  
Instância IQueryable principal, contendo instruções SELECT e WHERE (esta última opcional).
  
<a name='EficazFramework_Repositories_EntityRepository_TEntity__GetIOrderedQueryable(System_Linq_IQueryable_TEntity__EficazFramework_Collections_SortDescription_bool)_orderbyDefinition'></a>
`orderbyDefinition` [EficazFramework.Collections.SortDescription](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.SortDescription 'EficazFramework.Collections.SortDescription')  
Definições de ordenação (SortDescription).
  
<a name='EficazFramework_Repositories_EntityRepository_TEntity__GetIOrderedQueryable(System_Linq_IQueryable_TEntity__EficazFramework_Collections_SortDescription_bool)_use_thenby'></a>
`use_thenby` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se deve ser utilizado o método ThenBy, para multiciplidade de ocorrências de ordenação.
  
#### Returns
[System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[TEntity](EntityRepository_TEntity_.md#EficazFramework_Repositories_EntityRepository_TEntity__TEntity 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')  
