#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## Range<T> Class

```csharp
internal class Range<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/Range_T_.md#EficazFramework.Validation.Fluent.Rules.Range_T_.T 'EficazFramework.Validation.Fluent.Rules.Range<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; Range<T>

| Constructors | |
| :--- | :--- |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, decimal, decimal)](EficazFramework.Validation.Fluent.Rules/Range_T_/Range(Expression_Func_T,object__,decimal,decimal).md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Range(System.Linq.Expressions.Expression<System.Func<T,object>>, decimal, decimal)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: decimal |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, double, double)](EficazFramework.Validation.Fluent.Rules/Range_T_/Range(Expression_Func_T,object__,double,double).md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Range(System.Linq.Expressions.Expression<System.Func<T,object>>, double, double)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: double |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, int, int)](EficazFramework.Validation.Fluent.Rules/Range_T_/Range(Expression_Func_T,object__,int,int).md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Range(System.Linq.Expressions.Expression<System.Func<T,object>>, int, int)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: int32 |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, long, long)](EficazFramework.Validation.Fluent.Rules/Range_T_/Range(Expression_Func_T,object__,long,long).md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Range(System.Linq.Expressions.Expression<System.Func<T,object>>, long, long)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: int64 |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, short, short)](EficazFramework.Validation.Fluent.Rules/Range_T_/Range(Expression_Func_T,object__,short,short).md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Range(System.Linq.Expressions.Expression<System.Func<T,object>>, short, short)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: int16 |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, DateTime, DateTime)](EficazFramework.Validation.Fluent.Rules/Range_T_/Range(Expression_Func_T,object__,DateTime,DateTime).md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Range(System.Linq.Expressions.Expression<System.Func<T,object>>, System.DateTime, System.DateTime)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: DATETIME |

| Properties | |
| :--- | :--- |
| [DateTimMessagePattern](EficazFramework.Validation.Fluent.Rules/Range_T_/DateTimMessagePattern.md 'EficazFramework.Validation.Fluent.Rules.Range<T>.DateTimMessagePattern') | |
| [Maximum](EficazFramework.Validation.Fluent.Rules/Range_T_/Maximum.md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Maximum') | Valor numérico máximo aceito na validação |
| [MaximumDate](EficazFramework.Validation.Fluent.Rules/Range_T_/MaximumDate.md 'EficazFramework.Validation.Fluent.Rules.Range<T>.MaximumDate') | Data máxima aceita na validação |
| [Minimum](EficazFramework.Validation.Fluent.Rules/Range_T_/Minimum.md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Minimum') | Valor numérico mínimo aceito na validação |
| [MinimumDate](EficazFramework.Validation.Fluent.Rules/Range_T_/MinimumDate.md 'EficazFramework.Validation.Fluent.Rules.Range<T>.MinimumDate') | Data mínima aceita na validação |
| [Mode](EficazFramework.Validation.Fluent.Rules/Range_T_/Mode.md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Mode') | |
| [ValuesStringFormatForMessage](EficazFramework.Validation.Fluent.Rules/Range_T_/ValuesStringFormatForMessage.md 'EficazFramework.Validation.Fluent.Rules.Range<T>.ValuesStringFormatForMessage') | Formato de data ou número para exibição na mensagem |

| Methods | |
| :--- | :--- |
| [Validate(T)](EficazFramework.Validation.Fluent.Rules/Range_T_/Validate(T).md 'EficazFramework.Validation.Fluent.Rules.Range<T>.Validate(T)') | |
