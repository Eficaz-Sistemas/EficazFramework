#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## RangePeriod<T> Class

```csharp
internal class RangePeriod<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md#EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; RangePeriod<T>

| Constructors | |
| :--- | :--- |
| [RangePeriod(Expression&lt;Func&lt;T,object&gt;&gt;, Expression&lt;Func&lt;T,object&gt;&gt;, bool)](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/RangePeriod(Expression_Func_T,object__,Expression_Func_T,object__,bool).md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.RangePeriod(System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool)') | Regra de validação que confronta dois valores de um intervalo. |

| Properties | |
| :--- | :--- |
| [AllowEquals](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/AllowEquals.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.AllowEquals') | Define se o valor final pode ser igual ao valor inicial. |
| [DateTimMessagePattern](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/DateTimMessagePattern.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.DateTimMessagePattern') | |
| [EndProperty](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/EndProperty.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.EndProperty') | Expressão lambda para acesso à propriedade contendo o valor final que deve ser validado |
| [StartProperty](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/StartProperty.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.StartProperty') | Expressão lambda para acesso à propriedade contendo o valor inicial que deve ser validado |
| [ValuesStringFormatForMessage](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/ValuesStringFormatForMessage.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.ValuesStringFormatForMessage') | Formato de data ou número para exibição na mensagem |

| Methods | |
| :--- | :--- |
| [GetStartPropertyName()](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/GetStartPropertyName().md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.GetStartPropertyName()') | Obtém o nome da propriedade a ser validada pela regra |
| [Validate(T)](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_/Validate(T).md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.Validate(T)') | |
