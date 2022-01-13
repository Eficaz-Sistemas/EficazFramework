#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Expressions](EficazFrameworkData.md#EficazFramework.Expressions 'EficazFramework.Expressions')

## ExpressionBuilder Class

```csharp
public class ExpressionBuilder :
System.ComponentModel.INotifyPropertyChanged,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExpressionBuilder

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Fields | |
| :--- | :--- |
| [_addcommand](EficazFramework.Expressions/ExpressionBuilder/_addcommand.md 'EficazFramework.Expressions.ExpressionBuilder._addcommand') | |
| [_allownulls](EficazFramework.Expressions/ExpressionBuilder/_allownulls.md 'EficazFramework.Expressions.ExpressionBuilder._allownulls') | |
| [_canAdd](EficazFramework.Expressions/ExpressionBuilder/_canAdd.md 'EficazFramework.Expressions.ExpressionBuilder._canAdd') | |
| [_currentItem](EficazFramework.Expressions/ExpressionBuilder/_currentItem.md 'EficazFramework.Expressions.ExpressionBuilder._currentItem') | |
| [_customexpressions](EficazFramework.Expressions/ExpressionBuilder/_customexpressions.md 'EficazFramework.Expressions.ExpressionBuilder._customexpressions') | |
| [_deletecommand](EficazFramework.Expressions/ExpressionBuilder/_deletecommand.md 'EficazFramework.Expressions.ExpressionBuilder._deletecommand') | |
| [_errors](EficazFramework.Expressions/ExpressionBuilder/_errors.md 'EficazFramework.Expressions.ExpressionBuilder._errors') | |
| [_fixeditems](EficazFramework.Expressions/ExpressionBuilder/_fixeditems.md 'EficazFramework.Expressions.ExpressionBuilder._fixeditems') | |
| [_items](EficazFramework.Expressions/ExpressionBuilder/_items.md 'EficazFramework.Expressions.ExpressionBuilder._items') | |
| [_MP](EficazFramework.Expressions/ExpressionBuilder/_MP.md 'EficazFramework.Expressions.ExpressionBuilder._MP') | |
| [_MP_new](EficazFramework.Expressions/ExpressionBuilder/_MP_new.md 'EficazFramework.Expressions.ExpressionBuilder._MP_new') | |
| [_props](EficazFramework.Expressions/ExpressionBuilder/_props.md 'EficazFramework.Expressions.ExpressionBuilder._props') | |

| Properties | |
| :--- | :--- |
| [AddNewItemCommand](EficazFramework.Expressions/ExpressionBuilder/AddNewItemCommand.md 'EficazFramework.Expressions.ExpressionBuilder.AddNewItemCommand') | |
| [AllowNulls](EficazFramework.Expressions/ExpressionBuilder/AllowNulls.md 'EficazFramework.Expressions.ExpressionBuilder.AllowNulls') | |
| [CanAddExpressions](EficazFramework.Expressions/ExpressionBuilder/CanAddExpressions.md 'EficazFramework.Expressions.ExpressionBuilder.CanAddExpressions') | |
| [CanBuildCustomExpressions](EficazFramework.Expressions/ExpressionBuilder/CanBuildCustomExpressions.md 'EficazFramework.Expressions.ExpressionBuilder.CanBuildCustomExpressions') | |
| [CurrentItem](EficazFramework.Expressions/ExpressionBuilder/CurrentItem.md 'EficazFramework.Expressions.ExpressionBuilder.CurrentItem') | |
| [DeleteItemCommand](EficazFramework.Expressions/ExpressionBuilder/DeleteItemCommand.md 'EficazFramework.Expressions.ExpressionBuilder.DeleteItemCommand') | |
| [FixedItems](EficazFramework.Expressions/ExpressionBuilder/FixedItems.md 'EficazFramework.Expressions.ExpressionBuilder.FixedItems') | |
| [HasErrors](EficazFramework.Expressions/ExpressionBuilder/HasErrors.md 'EficazFramework.Expressions.ExpressionBuilder.HasErrors') | |
| [Items](EficazFramework.Expressions/ExpressionBuilder/Items.md 'EficazFramework.Expressions.ExpressionBuilder.Items') | |
| [LastValidationErrors](EficazFramework.Expressions/ExpressionBuilder/LastValidationErrors.md 'EficazFramework.Expressions.ExpressionBuilder.LastValidationErrors') | |
| [Properties](EficazFramework.Expressions/ExpressionBuilder/Properties.md 'EficazFramework.Expressions.ExpressionBuilder.Properties') | |

| Methods | |
| :--- | :--- |
| [AddItemCommand_Execute(object, ExecuteEventArgs)](EficazFramework.Expressions/ExpressionBuilder/AddItemCommand_Execute(object,ExecuteEventArgs).md 'EficazFramework.Expressions.ExpressionBuilder.AddItemCommand_Execute(object, EficazFramework.Events.ExecuteEventArgs)') | |
| [CallExpressionBuilding(object, ExpressionEventArgs)](EficazFramework.Expressions/ExpressionBuilder/CallExpressionBuilding(object,ExpressionEventArgs).md 'EficazFramework.Expressions.ExpressionBuilder.CallExpressionBuilding(object, EficazFramework.Events.ExpressionEventArgs)') | |
| [ClearErrors()](EficazFramework.Expressions/ExpressionBuilder/ClearErrors().md 'EficazFramework.Expressions.ExpressionBuilder.ClearErrors()') | |
| [DeleteItemCommand_Execute(object, ExecuteEventArgs)](EficazFramework.Expressions/ExpressionBuilder/DeleteItemCommand_Execute(object,ExecuteEventArgs).md 'EficazFramework.Expressions.ExpressionBuilder.DeleteItemCommand_Execute(object, EficazFramework.Events.ExecuteEventArgs)') | |
| [Dispose()](EficazFramework.Expressions/ExpressionBuilder/Dispose().md 'EficazFramework.Expressions.ExpressionBuilder.Dispose()') | |
| [GetExpression&lt;TElement&gt;()](EficazFramework.Expressions/ExpressionBuilder/GetExpression_TElement_().md 'EficazFramework.Expressions.ExpressionBuilder.GetExpression<TElement>()') | |
| [ItemsCollectionsChanged(object, NotifyCollectionChangedEventArgs)](EficazFramework.Expressions/ExpressionBuilder/ItemsCollectionsChanged(object,NotifyCollectionChangedEventArgs).md 'EficazFramework.Expressions.ExpressionBuilder.ItemsCollectionsChanged(object, System.Collections.Specialized.NotifyCollectionChangedEventArgs)') | |
| [RaisePropertyChanged(string)](EficazFramework.Expressions/ExpressionBuilder/RaisePropertyChanged(string).md 'EficazFramework.Expressions.ExpressionBuilder.RaisePropertyChanged(string)') | |
| [SetCurrentItem(ExpressionItem)](EficazFramework.Expressions/ExpressionBuilder/SetCurrentItem(ExpressionItem).md 'EficazFramework.Expressions.ExpressionBuilder.SetCurrentItem(EficazFramework.Expressions.ExpressionItem)') | |
| [Validate()](EficazFramework.Expressions/ExpressionBuilder/Validate().md 'EficazFramework.Expressions.ExpressionBuilder.Validate()') | |

| Events | |
| :--- | :--- |
| [ExpressionBuilding](EficazFramework.Expressions/ExpressionBuilder/ExpressionBuilding.md 'EficazFramework.Expressions.ExpressionBuilder.ExpressionBuilding') | |
| [ExpressionBuilt](EficazFramework.Expressions/ExpressionBuilder/ExpressionBuilt.md 'EficazFramework.Expressions.ExpressionBuilder.ExpressionBuilt') | |
| [ItemAdded](EficazFramework.Expressions/ExpressionBuilder/ItemAdded.md 'EficazFramework.Expressions.ExpressionBuilder.ItemAdded') | |
| [PropertyChanged](EficazFramework.Expressions/ExpressionBuilder/PropertyChanged.md 'EficazFramework.Expressions.ExpressionBuilder.PropertyChanged') | |
| [RaisMessageBox](EficazFramework.Expressions/ExpressionBuilder/RaisMessageBox.md 'EficazFramework.Expressions.ExpressionBuilder.RaisMessageBox') | |
| [RemovedAdded](EficazFramework.Expressions/ExpressionBuilder/RemovedAdded.md 'EficazFramework.Expressions.ExpressionBuilder.RemovedAdded') | |
