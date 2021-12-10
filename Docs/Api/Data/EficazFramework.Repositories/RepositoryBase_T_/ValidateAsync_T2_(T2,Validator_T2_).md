#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[RepositoryBase&lt;T&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>')

## RepositoryBase<T>.ValidateAsync<T2>(T2, Validator<T2>) Method

Efetua Validação da instância especificada ou de todo o DataContext

```csharp
public virtual System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync<T2>(T2 instance, EficazFramework.Validation.Fluent.Validator<T2> customValidator)
    where T2 : class;
```
#### Type parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).T2'></a>

`T2`
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).instance'></a>

`instance` [T2](EficazFramework.Repositories/RepositoryBase_T_/ValidateAsync_T2_(T2,Validator_T2_).md#EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).T2 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync<T2>(T2, EficazFramework.Validation.Fluent.Validator<T2>).T2')

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).customValidator'></a>

`customValidator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T2](EficazFramework.Repositories/RepositoryBase_T_/ValidateAsync_T2_(T2,Validator_T2_).md#EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).T2 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync<T2>(T2, EficazFramework.Validation.Fluent.Validator<T2>).T2')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')