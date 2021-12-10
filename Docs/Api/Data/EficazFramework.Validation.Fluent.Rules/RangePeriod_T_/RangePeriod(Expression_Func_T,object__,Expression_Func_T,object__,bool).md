#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules').[RangePeriod&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>')

## RangePeriod(Expression<Func<T,object>>, Expression<Func<T,object>>, bool) Constructor

Regra de validação que confronta dois valores de um intervalo.

```csharp
public RangePeriod(System.Linq.Expressions.Expression<System.Func<T,object>> endValueExpression, System.Linq.Expressions.Expression<System.Func<T,object>> startValueExpression, bool allowEquals=true);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.RangePeriod(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).endValueExpression'></a>

`endValueExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md#EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.RangePeriod(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).startValueExpression'></a>

`startValueExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md#EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.RangePeriod(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).allowEquals'></a>

`allowEquals` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')