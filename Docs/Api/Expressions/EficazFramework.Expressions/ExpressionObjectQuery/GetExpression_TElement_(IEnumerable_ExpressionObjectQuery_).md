#### [EficazFramework.Expressions](EficazFrameworkExpressions.md 'EficazFramework Expressions')
### [EficazFramework.Expressions](EficazFrameworkExpressions.md#EficazFramework.Expressions 'EficazFramework.Expressions').[ExpressionObjectQuery](EficazFramework.Expressions/ExpressionObjectQuery.md 'EficazFramework.Expressions.ExpressionObjectQuery')

## ExpressionObjectQuery.GetExpression<TElement>(IEnumerable<ExpressionObjectQuery>) Method

Obtém o filtro compilado em Expressão das condições especificadas na lista de [ExpressionObjectQuery](EficazFramework.Expressions/ExpressionObjectQuery.md 'EficazFramework.Expressions.ExpressionObjectQuery')  
passada como parâmetro, para o tipo TElement especificado.

```csharp
public static System.Linq.Expressions.Expression<System.Func<TElement,bool>> GetExpression<TElement>(System.Collections.Generic.IEnumerable<EficazFramework.Expressions.ExpressionObjectQuery> source);
```
#### Type parameters

<a name='EficazFramework.Expressions.ExpressionObjectQuery.GetExpression_TElement_(System.Collections.Generic.IEnumerable_EficazFramework.Expressions.ExpressionObjectQuery_).TElement'></a>

`TElement`
#### Parameters

<a name='EficazFramework.Expressions.ExpressionObjectQuery.GetExpression_TElement_(System.Collections.Generic.IEnumerable_EficazFramework.Expressions.ExpressionObjectQuery_).source'></a>

`source` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ExpressionObjectQuery](EficazFramework.Expressions/ExpressionObjectQuery.md 'EficazFramework.Expressions.ExpressionObjectQuery')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

#### Returns
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TElement](EficazFramework.Expressions/ExpressionObjectQuery/GetExpression_TElement_(IEnumerable_ExpressionObjectQuery_).md#EficazFramework.Expressions.ExpressionObjectQuery.GetExpression_TElement_(System.Collections.Generic.IEnumerable_EficazFramework.Expressions.ExpressionObjectQuery_).TElement 'EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<TElement>(System.Collections.Generic.IEnumerable<EficazFramework.Expressions.ExpressionObjectQuery>).TElement')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')