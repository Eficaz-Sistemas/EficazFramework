#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## RequiredIf<T> Class

```csharp
internal class RequiredIf<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.RequiredIf_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_.md#EficazFramework.Validation.Fluent.Rules.RequiredIf_T_.T 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; RequiredIf<T>

| Constructors | |
| :--- | :--- |
| [RequiredIf(Expression&lt;Func&lt;T,object&gt;&gt;, Expression&lt;Func&lt;T,bool&gt;&gt;, bool)](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_/RequiredIf(Expression_Func_T,object__,Expression_Func_T,bool__,bool).md 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>.RequiredIf(System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool)') | Regra de validação contra valores e/ou referências nulas ou vazias |

| Properties | |
| :--- | :--- |
| [AllowEmpty](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_/AllowEmpty.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>.AllowEmpty') | Obtém ou define se a constante String.Empty será permitida ou não |
| [ConditionExpression](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_/ConditionExpression.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>.ConditionExpression') | Expressão que condiciona a obrigatoriedade do campo ser requerido ou não |
