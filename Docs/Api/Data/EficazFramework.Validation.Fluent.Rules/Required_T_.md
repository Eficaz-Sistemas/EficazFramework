#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## Required<T> Class

```csharp
internal class Required<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.Required_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/Required_T_.md#EficazFramework.Validation.Fluent.Rules.Required_T_.T 'EficazFramework.Validation.Fluent.Rules.Required<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; Required<T>

| Constructors | |
| :--- | :--- |
| [Required(Expression&lt;Func&lt;T,object&gt;&gt;, bool)](EficazFramework.Validation.Fluent.Rules/Required_T_/Required(Expression_Func_T,object__,bool).md 'EficazFramework.Validation.Fluent.Rules.Required<T>.Required(System.Linq.Expressions.Expression<System.Func<T,object>>, bool)') | Regra de validação contra valores e/ou referências nulas ou vazias |

| Properties | |
| :--- | :--- |
| [AllowEmpty](EficazFramework.Validation.Fluent.Rules/Required_T_/AllowEmpty.md 'EficazFramework.Validation.Fluent.Rules.Required<T>.AllowEmpty') | Obtém ou define se a constante String.Empty será permitida ou não |
