#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent](EficazFrameworkData.md#EficazFramework.Validation.Fluent 'EficazFramework.Validation.Fluent')

## ValidationResult Class

Lista resultante dos métodos de Validação

```csharp
public class ValidationResult : EficazFramework.Collections.StringCollection
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') &#129106; [EficazFramework.Collections.StringCollection](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.StringCollection 'EficazFramework.Collections.StringCollection') &#129106; ValidationResult
### Properties

<a name='EficazFramework.Validation.Fluent.ValidationResult.NullInstance'></a>

## ValidationResult.NullInstance Property

Obtém a mensagem de validação padrão para instâncias nulas.

```csharp
public static EficazFramework.Validation.Fluent.ValidationResult NullInstance { get; }
```

#### Property Value
[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')
### Methods

<a name='EficazFramework.Validation.Fluent.ValidationResult.GetValidationException(string,System.Exception)'></a>

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