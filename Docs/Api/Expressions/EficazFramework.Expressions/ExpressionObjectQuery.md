#### [EficazFramework.Expressions](EficazFrameworkExpressions.md 'EficazFramework Expressions')
### [EficazFramework.Expressions](EficazFrameworkExpressions.md#EficazFramework.Expressions 'EficazFramework.Expressions')

## ExpressionObjectQuery Class

Representa a tradução da query originada de uma instância de [ExpressionItem](EficazFramework.Expressions/ExpressionItem.md 'EficazFramework.Expressions.ExpressionItem'). <br/>  
Esta classe pode ser utilizada para traduzir a query montada por um [ExpressionBuilder](EficazFramework.Expressions/ExpressionBuilder.md 'EficazFramework.Expressions.ExpressionBuilder')  
no intuito de ser passada como argumento (Body) para alguma API Rest, por exemplo, uma vez que  
não é possível utilizar [System.Linq.Expressions.Expression](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') diretamente como parametro.

```csharp
public class ExpressionObjectQuery
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExpressionObjectQuery

| Properties | |
| :--- | :--- |
| [CollectionName](EficazFramework.Expressions/ExpressionObjectQuery/CollectionName.md 'EficazFramework.Expressions.ExpressionObjectQuery.CollectionName') | Quando preenchido, define que a expressão deve ser adicionar a instrução .Any() para<br/>pesquisar em uma coleção interna (Inner Join) |
| [ConversionTargetType](EficazFramework.Expressions/ExpressionObjectQuery/ConversionTargetType.md 'EficazFramework.Expressions.ExpressionObjectQuery.ConversionTargetType') | Utilize esta propriedade caso seja preciso efetuar algum Cast do tipo digitado para viabilizar a consulta. |
| [FieldName](EficazFramework.Expressions/ExpressionObjectQuery/FieldName.md 'EficazFramework.Expressions.ExpressionObjectQuery.FieldName') | Nome do Campo a ser filtrado |
| [Operator](EficazFramework.Expressions/ExpressionObjectQuery/Operator.md 'EficazFramework.Expressions.ExpressionObjectQuery.Operator') | Operador ou critério de consulta |
| [Value](EficazFramework.Expressions/ExpressionObjectQuery/Value.md 'EficazFramework.Expressions.ExpressionObjectQuery.Value') | Valor a ser utilizado no filtro |
| [Value2](EficazFramework.Expressions/ExpressionObjectQuery/Value2.md 'EficazFramework.Expressions.ExpressionObjectQuery.Value2') | Segundo valor a ser utilizado no filtro. <br/><br/>Só será considerado quando [Operator](EficazFramework.Expressions/ExpressionObjectQuery/Operator.md 'EficazFramework.Expressions.ExpressionObjectQuery.Operator') for igual a<br/>[Between](EficazFramework.Enums/CompareMethod.md#EficazFramework.Enums.CompareMethod.Between 'EficazFramework.Enums.CompareMethod.Between') |

| Methods | |
| :--- | :--- |
| [GetExpression&lt;TElement&gt;(IEnumerable&lt;ExpressionObjectQuery&gt;)](EficazFramework.Expressions/ExpressionObjectQuery/GetExpression_TElement_(IEnumerable_ExpressionObjectQuery_).md 'EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<TElement>(System.Collections.Generic.IEnumerable<EficazFramework.Expressions.ExpressionObjectQuery>)') | Obtém o filtro compilado em Expressão das condições especificadas na lista de [ExpressionObjectQuery](EficazFramework.Expressions/ExpressionObjectQuery.md 'EficazFramework.Expressions.ExpressionObjectQuery')<br/>passada como parâmetro, para o tipo TElement especificado. |
