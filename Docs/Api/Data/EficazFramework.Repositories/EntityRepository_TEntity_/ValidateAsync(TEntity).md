#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

## EntityRepository<TEntity>.ValidateAsync(TEntity) Method

Efetua Validação da instância especificada ou das entidades marcadas como alteradas no ChangeTracker do DbContext

```csharp
public override System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(TEntity instance);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.ValidateAsync(TEntity).instance'></a>

`instance` [TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')