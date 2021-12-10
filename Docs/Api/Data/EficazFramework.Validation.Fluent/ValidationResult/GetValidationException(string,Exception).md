#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent](EficazFrameworkData.md#EficazFramework.Validation.Fluent 'EficazFramework.Validation.Fluent').[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')

## ValidationResult.GetValidationException(string, Exception) Method

Obtém a mensagem de validação padrão ao ocorrer alguma exceção durante a validação.

```csharp
public static EficazFramework.Validation.Fluent.ValidationResult GetValidationException(string propertyname, System.Exception exception);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.ValidationResult.GetValidationException(string,System.Exception).propertyname'></a>

`propertyname` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome da propriedade valdada, que causou exceção

<a name='EficazFramework.Validation.Fluent.ValidationResult.GetValidationException(string,System.Exception).exception'></a>

`exception` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

Exceção gerada

#### Returns
[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')