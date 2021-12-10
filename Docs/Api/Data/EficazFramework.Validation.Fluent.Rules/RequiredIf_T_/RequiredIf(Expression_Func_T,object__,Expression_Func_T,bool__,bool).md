#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules').[RequiredIf&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>')

## RequiredIf(Expression<Func<T,object>>, Expression<Func<T,bool>>, bool) Constructor

Regra de validação contra valores e/ou referências nulas ou vazias

```csharp
public RequiredIf(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.Linq.Expressions.Expression<System.Func<T,bool>> conditionExpression, bool allowempty=false);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.RequiredIf_T_.RequiredIf(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_.md#EficazFramework.Validation.Fluent.Rules.RequiredIf_T_.T 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RequiredIf_T_.RequiredIf(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).conditionExpression'></a>

`conditionExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_.md#EficazFramework.Validation.Fluent.Rules.RequiredIf_T_.T 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RequiredIf_T_.RequiredIf(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).allowempty'></a>

`allowempty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')