#### [EficazFramework.Expressions](EficazFrameworkExpressions.md 'EficazFramework Expressions')
### [EficazFramework.Expressions](EficazFrameworkExpressions.md#EficazFramework.Expressions 'EficazFramework.Expressions')

## ExpressionBuilder Class

```csharp
public class ExpressionBuilder :
System.ComponentModel.INotifyPropertyChanged,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExpressionBuilder

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [AddNewItemCommand](EficazFramework.Expressions/ExpressionBuilder/AddNewItemCommand.md 'EficazFramework.Expressions.ExpressionBuilder.AddNewItemCommand') | |
| [AllowNulls](EficazFramework.Expressions/ExpressionBuilder/AllowNulls.md 'EficazFramework.Expressions.ExpressionBuilder.AllowNulls') | Obtém ou define se o construtor de expressões deve permitir que algum item possa ter valor nulo. |
| [CanAddExpressions](EficazFramework.Expressions/ExpressionBuilder/CanAddExpressions.md 'EficazFramework.Expressions.ExpressionBuilder.CanAddExpressions') | |
| [CanBuildCustomExpressions](EficazFramework.Expressions/ExpressionBuilder/CanBuildCustomExpressions.md 'EficazFramework.Expressions.ExpressionBuilder.CanBuildCustomExpressions') | |
| [CurrentItem](EficazFramework.Expressions/ExpressionBuilder/CurrentItem.md 'EficazFramework.Expressions.ExpressionBuilder.CurrentItem') | |
| [DeleteItemCommand](EficazFramework.Expressions/ExpressionBuilder/DeleteItemCommand.md 'EficazFramework.Expressions.ExpressionBuilder.DeleteItemCommand') | |
| [FixedItems](EficazFramework.Expressions/ExpressionBuilder/FixedItems.md 'EficazFramework.Expressions.ExpressionBuilder.FixedItems') | Listagem de condições para pesquisa que deve ser fixas para toda e qualquer consulta. |
| [HasErrors](EficazFramework.Expressions/ExpressionBuilder/HasErrors.md 'EficazFramework.Expressions.ExpressionBuilder.HasErrors') | Indica se o construtor de filtros está em estado de Erro após a última compilação de [System.Linq.Expressions.Expression](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') |
| [Items](EficazFramework.Expressions/ExpressionBuilder/Items.md 'EficazFramework.Expressions.ExpressionBuilder.Items') | Itens que formam o filtro desejado. |
| [LastValidationErrors](EficazFramework.Expressions/ExpressionBuilder/LastValidationErrors.md 'EficazFramework.Expressions.ExpressionBuilder.LastValidationErrors') | |
| [Properties](EficazFramework.Expressions/ExpressionBuilder/Properties.md 'EficazFramework.Expressions.ExpressionBuilder.Properties') | Campos disponíveis para escolha no editor. |

| Methods | |
| :--- | :--- |
| [Dispose()](EficazFramework.Expressions/ExpressionBuilder/Dispose().md 'EficazFramework.Expressions.ExpressionBuilder.Dispose()') | |
| [GetExpression&lt;TElement&gt;()](EficazFramework.Expressions/ExpressionBuilder/GetExpression_TElement_().md 'EficazFramework.Expressions.ExpressionBuilder.GetExpression<TElement>()') | Constrói a [System.Linq.Expressions.Expression](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') para a query que será executada. |
| [ToExpressionObjectQuery()](EficazFramework.Expressions/ExpressionBuilder/ToExpressionObjectQuery().md 'EficazFramework.Expressions.ExpressionBuilder.ToExpressionObjectQuery()') | |
| [Validate()](EficazFramework.Expressions/ExpressionBuilder/Validate().md 'EficazFramework.Expressions.ExpressionBuilder.Validate()') | |

| Events | |
| :--- | :--- |
| [ExpressionBuilding](EficazFramework.Expressions/ExpressionBuilder/ExpressionBuilding.md 'EficazFramework.Expressions.ExpressionBuilder.ExpressionBuilding') | |
| [ExpressionBuilt](EficazFramework.Expressions/ExpressionBuilder/ExpressionBuilt.md 'EficazFramework.Expressions.ExpressionBuilder.ExpressionBuilt') | |
| [ItemAdded](EficazFramework.Expressions/ExpressionBuilder/ItemAdded.md 'EficazFramework.Expressions.ExpressionBuilder.ItemAdded') | |
| [PropertyChanged](EficazFramework.Expressions/ExpressionBuilder/PropertyChanged.md 'EficazFramework.Expressions.ExpressionBuilder.PropertyChanged') | |
| [RaisMessageBox](EficazFramework.Expressions/ExpressionBuilder/RaisMessageBox.md 'EficazFramework.Expressions.ExpressionBuilder.RaisMessageBox') | |
| [RemovedAdded](EficazFramework.Expressions/ExpressionBuilder/RemovedAdded.md 'EficazFramework.Expressions.ExpressionBuilder.RemovedAdded') | |
