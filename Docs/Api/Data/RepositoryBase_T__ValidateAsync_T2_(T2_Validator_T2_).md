#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[RepositoryBase&lt;T&gt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;')
## RepositoryBase&lt;T&gt;.ValidateAsync&lt;T2&gt;(T2, Validator&lt;T2&gt;) Method
Efetua Validação da instância especificada ou de todo o DataContext  
```csharp
public virtual System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync<T2>(T2 instance, EficazFramework.Validation.Fluent.Validator<T2> customValidator)
    where T2 : class;
```
#### Type parameters
<a name='EficazFramework_Repositories_RepositoryBase_T__ValidateAsync_T2_(T2_EficazFramework_Validation_Fluent_Validator_T2_)_T2'></a>
`T2`  
  
#### Parameters
<a name='EficazFramework_Repositories_RepositoryBase_T__ValidateAsync_T2_(T2_EficazFramework_Validation_Fluent_Validator_T2_)_instance'></a>
`instance` [T2](RepositoryBase_T__ValidateAsync_T2_(T2_Validator_T2_).md#EficazFramework_Repositories_RepositoryBase_T__ValidateAsync_T2_(T2_EficazFramework_Validation_Fluent_Validator_T2_)_T2 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.ValidateAsync&lt;T2&gt;(T2, EficazFramework.Validation.Fluent.Validator&lt;T2&gt;).T2')  
  
<a name='EficazFramework_Repositories_RepositoryBase_T__ValidateAsync_T2_(T2_EficazFramework_Validation_Fluent_Validator_T2_)_customValidator'></a>
`customValidator` [EficazFramework.Validation.Fluent.Validator&lt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')[T2](RepositoryBase_T__ValidateAsync_T2_(T2_Validator_T2_).md#EficazFramework_Repositories_RepositoryBase_T__ValidateAsync_T2_(T2_EficazFramework_Validation_Fluent_Validator_T2_)_T2 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;.ValidateAsync&lt;T2&gt;(T2, EficazFramework.Validation.Fluent.Validator&lt;T2&gt;).T2')[&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
