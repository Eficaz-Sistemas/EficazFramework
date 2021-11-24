#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules')
## ValidationRule&lt;T&gt; Class
Classa padrão de regra de validação. Deve ser herdada.  
```csharp
public abstract class ValidationRule<T>
    where T : class
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_ValidationRule_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ValidationRule&lt;T&gt;  

Derived  
&#8627; [Documentos&lt;T&gt;](Documentos_T_.md 'EficazFramework.Validation.Fluent.Rules.Documentos&lt;T&gt;')  
&#8627; [Equals&lt;T&gt;](Equals_T_.md 'EficazFramework.Validation.Fluent.Rules.Equals&lt;T&gt;')  
&#8627; [MaxLenght&lt;T&gt;](MaxLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MaxLenght&lt;T&gt;')  
&#8627; [MinLenght&lt;T&gt;](MinLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MinLenght&lt;T&gt;')  
&#8627; [Range&lt;T&gt;](Range_T_.md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;')  
&#8627; [RangePeriod&lt;T&gt;](RangePeriod_T_.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;')  
&#8627; [Required&lt;T&gt;](Required_T_.md 'EficazFramework.Validation.Fluent.Rules.Required&lt;T&gt;')  
&#8627; [RequiredIf&lt;T&gt;](RequiredIf_T_.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;')  
&#8627; [Test&lt;T&gt;](Test_T_.md 'EficazFramework.Validation.Fluent.Rules.Test&lt;T&gt;')  

| Properties | |
| :--- | :--- |
| [Property](ValidationRule_T__Property.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;.Property') | Expressão lambda para acesso à propriedade que deve ser validada<br/> |

| Methods | |
| :--- | :--- |
| [GetPropertyName()](ValidationRule_T__GetPropertyName().md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;.GetPropertyName()') | Obtém o nome da propriedade a ser validada pela regra<br/> |
| [Validate(T)](ValidationRule_T__Validate(T).md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;.Validate(T)') | Executa a validação da propriedade na instância especificada<br/> |
