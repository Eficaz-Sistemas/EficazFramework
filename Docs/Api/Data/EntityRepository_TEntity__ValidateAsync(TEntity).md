#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[EntityRepository&lt;TEntity&gt;](EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;')
## EntityRepository&lt;TEntity&gt;.ValidateAsync(TEntity) Method
Efetua Validação da instância especificada ou das entidades marcadas como alteradas no ChangeTracker do DbContext  
```csharp
public override System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(TEntity instance);
```
#### Parameters
<a name='EficazFramework_Repositories_EntityRepository_TEntity__ValidateAsync(TEntity)_instance'></a>
`instance` [TEntity](EntityRepository_TEntity_.md#EficazFramework_Repositories_EntityRepository_TEntity__TEntity 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.TEntity')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
