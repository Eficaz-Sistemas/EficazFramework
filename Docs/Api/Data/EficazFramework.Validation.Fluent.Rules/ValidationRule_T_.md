#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## ValidationRule<T> Class

Classa padrão de regra de validação. Deve ser herdada.

```csharp
public abstract class ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidationRule_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ValidationRule<T>

Derived  
&#8627; [Contatos&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Contatos_T_.md 'EficazFramework.Validation.Fluent.Rules.Contatos<T>')  
&#8627; [Documentos&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Documentos_T_.md 'EficazFramework.Validation.Fluent.Rules.Documentos<T>')

| Constructors | |
| :--- | :--- |
| [ValidationRule(Expression&lt;Func&lt;T,object&gt;&gt;)](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_/ValidationRule(Expression_Func_T,object__).md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>.ValidationRule(System.Linq.Expressions.Expression<System.Func<T,object>>)') | |

| Properties | |
| :--- | :--- |
| [Property](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_/Property.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>.Property') | Expressão lambda para acesso à propriedade que deve ser validada |

| Methods | |
| :--- | :--- |
| [GetPropertyName()](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_/GetPropertyName().md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>.GetPropertyName()') | Obtém o nome da propriedade a ser validada pela regra |
| [Validate(T)](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_/Validate(T).md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>.Validate(T)') | Executa a validação da propriedade na instância especificada |
