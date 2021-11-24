#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent](EficazFrameworkData.md#EficazFramework_Validation_Fluent 'EficazFramework.Validation.Fluent').[Validator&lt;T&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')
## Validator&lt;T&gt;.ValidateAsync(object, string) Method
Executa a validação da propriedade argumentada da instância  
```csharp
public System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(object instance, string propertyName);
```
#### Parameters
<a name='EficazFramework_Validation_Fluent_Validator_T__ValidateAsync(object_string)_instance'></a>
`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Instância a ser validade
  
<a name='EficazFramework_Validation_Fluent_Validator_T__ValidateAsync(object_string)_propertyName'></a>
`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Nome da propriedade a ser validada
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  

Implements [ValidateAsync(object, string)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.Fluent.IValidator.ValidateAsync#EficazFramework_Validation_Fluent_IValidator_ValidateAsync_System_Object,System_String_ 'EficazFramework.Validation.Fluent.IValidator.ValidateAsync(System.Object,System.String)')  
