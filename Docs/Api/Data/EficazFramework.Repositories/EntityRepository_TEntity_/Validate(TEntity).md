#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

## EntityRepository<TEntity>.Validate(TEntity) Method

Efetua Validação da instância especificada ou das entidades marcadas como alteradas no ChangeTracker do DbContext

```csharp
public override EficazFramework.Validation.Fluent.ValidationResult Validate(TEntity instance);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Validate(TEntity).instance'></a>

`instance` [TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')

#### Returns
[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')