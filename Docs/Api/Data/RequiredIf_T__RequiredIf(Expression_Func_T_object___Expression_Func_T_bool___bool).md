#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules').[RequiredIf&lt;T&gt;](RequiredIf_T_.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;')
## RequiredIf&lt;T&gt;.RequiredIf(Expression&lt;Func&lt;T,object&gt;&gt;, Expression&lt;Func&lt;T,bool&gt;&gt;, bool) Constructor
Regra de validação contra valores e/ou referências nulas ou vazias  
```csharp
public RequiredIf(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.Linq.Expressions.Expression<System.Func<T,bool>> conditionExpression, bool allowempty=false);
```
#### Parameters
<a name='EficazFramework_Validation_Fluent_Rules_RequiredIf_T__RequiredIf(System_Linq_Expressions_Expression_System_Func_T_object___System_Linq_Expressions_Expression_System_Func_T_bool___bool)_propertyexpression'></a>
`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](RequiredIf_T_.md#EficazFramework_Validation_Fluent_Rules_RequiredIf_T__T 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')  
  
<a name='EficazFramework_Validation_Fluent_Rules_RequiredIf_T__RequiredIf(System_Linq_Expressions_Expression_System_Func_T_object___System_Linq_Expressions_Expression_System_Func_T_bool___bool)_conditionExpression'></a>
`conditionExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](RequiredIf_T_.md#EficazFramework_Validation_Fluent_Rules_RequiredIf_T__T 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')  
  
<a name='EficazFramework_Validation_Fluent_Rules_RequiredIf_T__RequiredIf(System_Linq_Expressions_Expression_System_Func_T_object___System_Linq_Expressions_Expression_System_Func_T_bool___bool)_allowempty'></a>
`allowempty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
