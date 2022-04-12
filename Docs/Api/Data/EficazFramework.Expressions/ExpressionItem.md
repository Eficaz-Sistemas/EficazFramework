#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Expressions](EficazFrameworkData.md#EficazFramework.Expressions 'EficazFramework.Expressions')

## ExpressionItem Class

```csharp
public class ExpressionItem :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExpressionItem

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')

| Fields | |
| :--- | :--- |
| [_allowExpession](EficazFramework.Expressions/ExpressionItem/_allowExpession.md 'EficazFramework.Expressions.ExpressionItem._allowExpession') | |
| [_conversionTargetType](EficazFramework.Expressions/ExpressionItem/_conversionTargetType.md 'EficazFramework.Expressions.ExpressionItem._conversionTargetType') | |
| [_nullCheck](EficazFramework.Expressions/ExpressionItem/_nullCheck.md 'EficazFramework.Expressions.ExpressionItem._nullCheck') | |
| [_operator](EficazFramework.Expressions/ExpressionItem/_operator.md 'EficazFramework.Expressions.ExpressionItem._operator') | |
| [_selectedProperty](EficazFramework.Expressions/ExpressionItem/_selectedProperty.md 'EficazFramework.Expressions.ExpressionItem._selectedProperty') | |
| [_tmpOwnerExpressionBuilder](EficazFramework.Expressions/ExpressionItem/_tmpOwnerExpressionBuilder.md 'EficazFramework.Expressions.ExpressionItem._tmpOwnerExpressionBuilder') | |
| [_tmpOwnerExpressionUpdater](EficazFramework.Expressions/ExpressionItem/_tmpOwnerExpressionUpdater.md 'EficazFramework.Expressions.ExpressionItem._tmpOwnerExpressionUpdater') | |
| [_toLowerString](EficazFramework.Expressions/ExpressionItem/_toLowerString.md 'EficazFramework.Expressions.ExpressionItem._toLowerString') | |
| [_updateValueType](EficazFramework.Expressions/ExpressionItem/_updateValueType.md 'EficazFramework.Expressions.ExpressionItem._updateValueType') | |
| [_value1](EficazFramework.Expressions/ExpressionItem/_value1.md 'EficazFramework.Expressions.ExpressionItem._value1') | |
| [_value1StringFormat](EficazFramework.Expressions/ExpressionItem/_value1StringFormat.md 'EficazFramework.Expressions.ExpressionItem._value1StringFormat') | |
| [_value2](EficazFramework.Expressions/ExpressionItem/_value2.md 'EficazFramework.Expressions.ExpressionItem._value2') | |
| [_value2StringFormat](EficazFramework.Expressions/ExpressionItem/_value2StringFormat.md 'EficazFramework.Expressions.ExpressionItem._value2StringFormat') | |
| [_valueToUpdate](EficazFramework.Expressions/ExpressionItem/_valueToUpdate.md 'EficazFramework.Expressions.ExpressionItem._valueToUpdate') | |
| [ContainsMethod](EficazFramework.Expressions/ExpressionItem/ContainsMethod.md 'EficazFramework.Expressions.ExpressionItem.ContainsMethod') | |
| [LengthMethod](EficazFramework.Expressions/ExpressionItem/LengthMethod.md 'EficazFramework.Expressions.ExpressionItem.LengthMethod') | |
| [NullToEmptyMethod](EficazFramework.Expressions/ExpressionItem/NullToEmptyMethod.md 'EficazFramework.Expressions.ExpressionItem.NullToEmptyMethod') | |
| [StartsWithMethod](EficazFramework.Expressions/ExpressionItem/StartsWithMethod.md 'EficazFramework.Expressions.ExpressionItem.StartsWithMethod') | |
| [ToLowerMethod](EficazFramework.Expressions/ExpressionItem/ToLowerMethod.md 'EficazFramework.Expressions.ExpressionItem.ToLowerMethod') | |

| Properties | |
| :--- | :--- |
| [AllowExpression](EficazFramework.Expressions/ExpressionItem/AllowExpression.md 'EficazFramework.Expressions.ExpressionItem.AllowExpression') | |
| [AvailableOperators](EficazFramework.Expressions/ExpressionItem/AvailableOperators.md 'EficazFramework.Expressions.ExpressionItem.AvailableOperators') | |
| [ConversionTargetType](EficazFramework.Expressions/ExpressionItem/ConversionTargetType.md 'EficazFramework.Expressions.ExpressionItem.ConversionTargetType') | |
| [DateTimeValue1](EficazFramework.Expressions/ExpressionItem/DateTimeValue1.md 'EficazFramework.Expressions.ExpressionItem.DateTimeValue1') | |
| [DateTimeValue2](EficazFramework.Expressions/ExpressionItem/DateTimeValue2.md 'EficazFramework.Expressions.ExpressionItem.DateTimeValue2') | |
| [EnumValues](EficazFramework.Expressions/ExpressionItem/EnumValues.md 'EficazFramework.Expressions.ExpressionItem.EnumValues') | |
| [NullCheck](EficazFramework.Expressions/ExpressionItem/NullCheck.md 'EficazFramework.Expressions.ExpressionItem.NullCheck') | |
| [Operator](EficazFramework.Expressions/ExpressionItem/Operator.md 'EficazFramework.Expressions.ExpressionItem.Operator') | |
| [SelectedProperty](EficazFramework.Expressions/ExpressionItem/SelectedProperty.md 'EficazFramework.Expressions.ExpressionItem.SelectedProperty') | |
| [SelectedPropertyPath](EficazFramework.Expressions/ExpressionItem/SelectedPropertyPath.md 'EficazFramework.Expressions.ExpressionItem.SelectedPropertyPath') | |
| [ToLowerString](EficazFramework.Expressions/ExpressionItem/ToLowerString.md 'EficazFramework.Expressions.ExpressionItem.ToLowerString') | |
| [UpdateMode](EficazFramework.Expressions/ExpressionItem/UpdateMode.md 'EficazFramework.Expressions.ExpressionItem.UpdateMode') | |
| [UpdateValueType](EficazFramework.Expressions/ExpressionItem/UpdateValueType.md 'EficazFramework.Expressions.ExpressionItem.UpdateValueType') | |
| [Value1](EficazFramework.Expressions/ExpressionItem/Value1.md 'EficazFramework.Expressions.ExpressionItem.Value1') | |
| [Value1StringFormat](EficazFramework.Expressions/ExpressionItem/Value1StringFormat.md 'EficazFramework.Expressions.ExpressionItem.Value1StringFormat') | |
| [Value2](EficazFramework.Expressions/ExpressionItem/Value2.md 'EficazFramework.Expressions.ExpressionItem.Value2') | |
| [Value2StringFormat](EficazFramework.Expressions/ExpressionItem/Value2StringFormat.md 'EficazFramework.Expressions.ExpressionItem.Value2StringFormat') | |
| [ValueToString](EficazFramework.Expressions/ExpressionItem/ValueToString.md 'EficazFramework.Expressions.ExpressionItem.ValueToString') | |
| [ValueToUpdate](EficazFramework.Expressions/ExpressionItem/ValueToUpdate.md 'EficazFramework.Expressions.ExpressionItem.ValueToUpdate') | |

| Methods | |
| :--- | :--- |
| [Build&lt;TElement&gt;(ExpressionBuilder)](EficazFramework.Expressions/ExpressionItem/Build_TElement_(ExpressionBuilder).md 'EficazFramework.Expressions.ExpressionItem.Build<TElement>(EficazFramework.Expressions.ExpressionBuilder)') | |
| [BuildExpression&lt;TElement&gt;(object, object)](EficazFramework.Expressions/ExpressionItem/BuildExpression_TElement_(object,object).md 'EficazFramework.Expressions.ExpressionItem.BuildExpression<TElement>(object, object)') | |
| [BuildForeignExpression&lt;TElement&gt;(object)](EficazFramework.Expressions/ExpressionItem/BuildForeignExpression_TElement_(object).md 'EficazFramework.Expressions.ExpressionItem.BuildForeignExpression<TElement>(object)') | |
| [CoerceValueChanged(object, bool)](EficazFramework.Expressions/ExpressionItem/CoerceValueChanged(object,bool).md 'EficazFramework.Expressions.ExpressionItem.CoerceValueChanged(object, bool)') | |
| [IsLocked()](EficazFramework.Expressions/ExpressionItem/IsLocked().md 'EficazFramework.Expressions.ExpressionItem.IsLocked()') | |
| [OnExpressionProperty_Changed()](EficazFramework.Expressions/ExpressionItem/OnExpressionProperty_Changed().md 'EficazFramework.Expressions.ExpressionItem.OnExpressionProperty_Changed()') | |
| [OnValue_Changed(PropertyChangedEventArgs)](EficazFramework.Expressions/ExpressionItem/OnValue_Changed(PropertyChangedEventArgs).md 'EficazFramework.Expressions.ExpressionItem.OnValue_Changed(System.ComponentModel.PropertyChangedEventArgs)') | |
| [OnValueType_Changed()](EficazFramework.Expressions/ExpressionItem/OnValueType_Changed().md 'EficazFramework.Expressions.ExpressionItem.OnValueType_Changed()') | |
| [OperatorToString()](EficazFramework.Expressions/ExpressionItem/OperatorToString().md 'EficazFramework.Expressions.ExpressionItem.OperatorToString()') | |
| [ParseValueToString()](EficazFramework.Expressions/ExpressionItem/ParseValueToString().md 'EficazFramework.Expressions.ExpressionItem.ParseValueToString()') | |
| [RaisePropertyChanged(string)](EficazFramework.Expressions/ExpressionItem/RaisePropertyChanged(string).md 'EficazFramework.Expressions.ExpressionItem.RaisePropertyChanged(string)') | |
| [ToString()](EficazFramework.Expressions/ExpressionItem/ToString().md 'EficazFramework.Expressions.ExpressionItem.ToString()') | |
| [Validate(bool)](EficazFramework.Expressions/ExpressionItem/Validate(bool).md 'EficazFramework.Expressions.ExpressionItem.Validate(bool)') | |
| [ValueType_Coercion(UpdateValueMode)](EficazFramework.Expressions/ExpressionItem/ValueType_Coercion(UpdateValueMode).md 'EficazFramework.Expressions.ExpressionItem.ValueType_Coercion(EficazFramework.Expressions.UpdateValueMode)') | |

| Events | |
| :--- | :--- |
| [PropertyChanged](EficazFramework.Expressions/ExpressionItem/PropertyChanged.md 'EficazFramework.Expressions.ExpressionItem.PropertyChanged') | |
| [UpdateValueModeChanged](EficazFramework.Expressions/ExpressionItem/UpdateValueModeChanged.md 'EficazFramework.Expressions.ExpressionItem.UpdateValueModeChanged') | |
