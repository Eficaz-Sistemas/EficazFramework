#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent](EficazFrameworkData.md#EficazFramework_Validation_Fluent 'EficazFramework.Validation.Fluent')
## Validator&lt;T&gt; Class
Classe definitiva da validação fluente, com estrutura genérica ao tipo a ser validado.  
```csharp
public class Validator<T> :
EficazFramework.Validation.Fluent.IValidator
    where T : class
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Validator_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Validator&lt;T&gt;  

Implements [IValidator](IValidator.md 'EficazFramework.Validation.Fluent.IValidator')  

| Methods | |
| :--- | :--- |
| [Validate(object)](Validator_T__Validate(object).md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;.Validate(object)') | Executa a validação completa da instância<br/> |
| [Validate(object, string)](Validator_T__Validate(object_string).md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;.Validate(object, string)') | Executa a validação da propriedade argumentada da instância<br/> |
| [ValidateAsync(object)](Validator_T__ValidateAsync(object).md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;.ValidateAsync(object)') | Executa a validação completa da instância<br/> |
| [ValidateAsync(object, string)](Validator_T__ValidateAsync(object_string).md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;.ValidateAsync(object, string)') | Executa a validação da propriedade argumentada da instância<br/> |
