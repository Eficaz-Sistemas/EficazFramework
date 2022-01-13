#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent](EficazFrameworkData.md#EficazFramework.Validation.Fluent 'EficazFramework.Validation.Fluent').[Validator&lt;T&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

## Validator<T>.ValidateAsync(object, string) Method

Executa a validação da propriedade argumentada da instância

```csharp
public System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(object instance, string propertyName);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Validator_T_.ValidateAsync(object,string).instance'></a>

`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Instância a ser validade

<a name='EficazFramework.Validation.Fluent.Validator_T_.ValidateAsync(object,string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome da propriedade a ser validada

Implements [ValidateAsync(object, string)](EficazFramework.Validation.Fluent/IValidator/ValidateAsync(object,string).md 'EficazFramework.Validation.Fluent.IValidator.ValidateAsync(object, string)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')