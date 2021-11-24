#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework_Extensions 'EficazFramework.Extensions').[ExpressionExpander](ExpressionExpander.md 'EficazFramework.Extensions.ExpressionExpander')
## ExpressionExpander.VisitInvocation(InvocationExpression) Method
Flatten calls to Invoke so that Entity Framework can understand it. Calls to Invoke are generated  
by PredicateBuilder.  
```csharp
protected override System.Linq.Expressions.Expression VisitInvocation(System.Linq.Expressions.InvocationExpression iv);
```
#### Parameters
<a name='EficazFramework_Extensions_ExpressionExpander_VisitInvocation(System_Linq_Expressions_InvocationExpression)_iv'></a>
`iv` [System.Linq.Expressions.InvocationExpression](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.InvocationExpression 'System.Linq.Expressions.InvocationExpression')  
  
#### Returns
[System.Linq.Expressions.Expression](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression')  
