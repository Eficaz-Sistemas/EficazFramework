#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework_Extensions 'EficazFramework.Extensions')
## ExpressionExpander Class
Custom expresssion visitor for ExpandableQuery. This expands calls to Expression.Compile() and  
collapses captured lambda references in subqueries which LINQ to SQL can't otherwise handle.  
```csharp
internal class ExpressionExpander : EficazFramework.Extensions.ExpressionVisitor
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ExpressionVisitor](ExpressionVisitor.md 'EficazFramework.Extensions.ExpressionVisitor') &#129106; ExpressionExpander  

| Methods | |
| :--- | :--- |
| [VisitInvocation(InvocationExpression)](ExpressionExpander_VisitInvocation(InvocationExpression).md 'EficazFramework.Extensions.ExpressionExpander.VisitInvocation(System.Linq.Expressions.InvocationExpression)') | Flatten calls to Invoke so that Entity Framework can understand it. Calls to Invoke are generated<br/>by PredicateBuilder.<br/> |
