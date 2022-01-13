#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent](EficazFrameworkData.md#EficazFramework.Validation.Fluent 'EficazFramework.Validation.Fluent')

## Validator<T> Class

Classe definitiva da validação fluente, com estrutura genérica ao tipo a ser validado.

```csharp
public class Validator<T> :
EficazFramework.Validation.Fluent.IValidator
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Validator_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Validator<T>

Implements [IValidator](EficazFramework.Validation.Fluent/IValidator.md 'EficazFramework.Validation.Fluent.IValidator')

| Fields | |
| :--- | :--- |
| [ValidationRules](EficazFramework.Validation.Fluent/Validator_T_/ValidationRules.md 'EficazFramework.Validation.Fluent.Validator<T>.ValidationRules') | |

| Methods | |
| :--- | :--- |
| [Validate(object)](EficazFramework.Validation.Fluent/Validator_T_/Validate(object).md 'EficazFramework.Validation.Fluent.Validator<T>.Validate(object)') | Executa a validação completa da instância |
| [Validate(object, string)](EficazFramework.Validation.Fluent/Validator_T_/Validate(object,string).md 'EficazFramework.Validation.Fluent.Validator<T>.Validate(object, string)') | Executa a validação da propriedade argumentada da instância |
| [ValidateAsync(object)](EficazFramework.Validation.Fluent/Validator_T_/ValidateAsync(object).md 'EficazFramework.Validation.Fluent.Validator<T>.ValidateAsync(object)') | Executa a validação completa da instância |
| [ValidateAsync(object, string)](EficazFramework.Validation.Fluent/Validator_T_/ValidateAsync(object,string).md 'EficazFramework.Validation.Fluent.Validator<T>.ValidateAsync(object, string)') | Executa a validação da propriedade argumentada da instância |
| [ValidateInternal(T, string)](EficazFramework.Validation.Fluent/Validator_T_/ValidateInternal(T,string).md 'EficazFramework.Validation.Fluent.Validator<T>.ValidateInternal(T, string)') | |
