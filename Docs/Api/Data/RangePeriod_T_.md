#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules')
## RangePeriod&lt;T&gt; Class
```csharp
internal class RangePeriod<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_RangePeriod_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;')[T](RangePeriod_T_.md#EficazFramework_Validation_Fluent_Rules_RangePeriod_T__T 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;.T')[&gt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;') &#129106; RangePeriod&lt;T&gt;  

| Constructors | |
| :--- | :--- |
| [RangePeriod(Expression&lt;Func&lt;T,object&gt;&gt;, Expression&lt;Func&lt;T,object&gt;&gt;, bool)](RangePeriod_T__RangePeriod(Expression_Func_T_object___Expression_Func_T_object___bool).md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;.RangePeriod(System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, bool)') | Regra de validação que confronta dois valores de um intervalo.<br/> |

| Properties | |
| :--- | :--- |
| [AllowEquals](RangePeriod_T__AllowEquals.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;.AllowEquals') | Define se o valor final pode ser igual ao valor inicial.<br/> |
| [EndProperty](RangePeriod_T__EndProperty.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;.EndProperty') | Expressão lambda para acesso à propriedade contendo o valor final que deve ser validado<br/> |
| [StartProperty](RangePeriod_T__StartProperty.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;.StartProperty') | Expressão lambda para acesso à propriedade contendo o valor inicial que deve ser validado<br/> |
| [ValuesStringFormatForMessage](RangePeriod_T__ValuesStringFormatForMessage.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;.ValuesStringFormatForMessage') | Formato de data ou número para exibição na mensagem<br/> |

| Methods | |
| :--- | :--- |
| [GetStartPropertyName()](RangePeriod_T__GetStartPropertyName().md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;.GetStartPropertyName()') | Obtém o nome da propriedade a ser validada pela regra<br/> |
