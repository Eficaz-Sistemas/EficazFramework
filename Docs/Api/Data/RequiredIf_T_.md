#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules')
## RequiredIf&lt;T&gt; Class
```csharp
internal class RequiredIf<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_RequiredIf_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;')[T](RequiredIf_T_.md#EficazFramework_Validation_Fluent_Rules_RequiredIf_T__T 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;.T')[&gt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;') &#129106; RequiredIf&lt;T&gt;  

| Constructors | |
| :--- | :--- |
| [RequiredIf(Expression&lt;Func&lt;T,object&gt;&gt;, Expression&lt;Func&lt;T,bool&gt;&gt;, bool)](RequiredIf_T__RequiredIf(Expression_Func_T_object___Expression_Func_T_bool___bool).md 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;.RequiredIf(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,bool&gt;&gt;, bool)') | Regra de validação contra valores e/ou referências nulas ou vazias<br/> |

| Properties | |
| :--- | :--- |
| [AllowEmpty](RequiredIf_T__AllowEmpty.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;.AllowEmpty') | Obtém ou define se a constante String.Empty será permitida ou não<br/> |
| [ConditionExpression](RequiredIf_T__ConditionExpression.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;.ConditionExpression') | Expressão que condiciona a obrigatoriedade do campo ser requerido ou não<br/> |
