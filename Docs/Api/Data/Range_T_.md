#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules')
## Range&lt;T&gt; Class
```csharp
internal class Range<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_Range_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;')[T](Range_T_.md#EficazFramework_Validation_Fluent_Rules_Range_T__T 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.T')[&gt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;') &#129106; Range&lt;T&gt;  

| Constructors | |
| :--- | :--- |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, decimal, decimal)](Range_T__Range(Expression_Func_T_object___decimal_decimal).md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Range(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, decimal, decimal)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: decimal<br/> |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, double, double)](Range_T__Range(Expression_Func_T_object___double_double).md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Range(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, double, double)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: double<br/> |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, int, int)](Range_T__Range(Expression_Func_T_object___int_int).md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Range(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, int, int)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: int32<br/> |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, long, long)](Range_T__Range(Expression_Func_T_object___long_long).md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Range(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, long, long)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: int64<br/> |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, short, short)](Range_T__Range(Expression_Func_T_object___short_short).md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Range(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, short, short)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: int16<br/> |
| [Range(Expression&lt;Func&lt;T,object&gt;&gt;, DateTime, DateTime)](Range_T__Range(Expression_Func_T_object___DateTime_DateTime).md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Range(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, System.DateTime, System.DateTime)') | Regra de validação contra valores fora do intervalo desejado.<br/>Tipo: DATETIME<br/> |

| Properties | |
| :--- | :--- |
| [Maximum](Range_T__Maximum.md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Maximum') | Valor numérico máximo aceito na validação<br/> |
| [MaximumDate](Range_T__MaximumDate.md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.MaximumDate') | Data máxima aceita na validação<br/> |
| [Minimum](Range_T__Minimum.md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.Minimum') | Valor numérico mínimo aceito na validação<br/> |
| [MinimumDate](Range_T__MinimumDate.md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.MinimumDate') | Data mínima aceita na validação<br/> |
| [ValuesStringFormatForMessage](Range_T__ValuesStringFormatForMessage.md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;.ValuesStringFormatForMessage') | Formato de data ou número para exibição na mensagem<br/> |
