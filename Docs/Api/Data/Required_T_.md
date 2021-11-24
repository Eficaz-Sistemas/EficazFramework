#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules')
## Required&lt;T&gt; Class
```csharp
internal class Required<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_Required_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;')[T](Required_T_.md#EficazFramework_Validation_Fluent_Rules_Required_T__T 'EficazFramework.Validation.Fluent.Rules.Required&lt;T&gt;.T')[&gt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;') &#129106; Required&lt;T&gt;  

| Constructors | |
| :--- | :--- |
| [Required(Expression&lt;Func&lt;T,object&gt;&gt;, bool)](Required_T__Required(Expression_Func_T_object___bool).md 'EficazFramework.Validation.Fluent.Rules.Required&lt;T&gt;.Required(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, bool)') | Regra de validação contra valores e/ou referências nulas ou vazias<br/> |

| Properties | |
| :--- | :--- |
| [AllowEmpty](Required_T__AllowEmpty.md 'EficazFramework.Validation.Fluent.Rules.Required&lt;T&gt;.AllowEmpty') | Obtém ou define se a constante String.Empty será permitida ou não<br/> |
