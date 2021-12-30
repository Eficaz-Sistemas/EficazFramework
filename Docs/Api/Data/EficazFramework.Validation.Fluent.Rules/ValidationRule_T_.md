#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## ValidationRule<T> Class

Classa padrão de regra de validação. Deve ser herdada.

```csharp
public abstract class ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidationRule_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ValidationRule<T>

Derived  
&#8627; [Documentos&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Documentos_T_.md 'EficazFramework.Validation.Fluent.Rules.Documentos<T>')  
&#8627; [Equals&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Equals_T_.md 'EficazFramework.Validation.Fluent.Rules.Equals<T>')  
&#8627; [MaxLenght&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/MaxLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MaxLenght<T>')  
&#8627; [MinLenght&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/MinLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MinLenght<T>')  
&#8627; [Range&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Range_T_.md 'EficazFramework.Validation.Fluent.Rules.Range<T>')  
&#8627; [RangePeriod&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>')  
&#8627; [Required&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Required_T_.md 'EficazFramework.Validation.Fluent.Rules.Required<T>')  
&#8627; [RequiredIf&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>')
### Properties

<a name='EficazFramework.Validation.Fluent.Rules.ValidationRule_T_.Property'></a>

## ValidationRule<T>.Property Property

Expressão lambda para acesso à propriedade que deve ser validada

```csharp
public System.Linq.Expressions.Expression<System.Func<T,object>> Property { get; set; }
```

#### Property Value
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md#EficazFramework.Validation.Fluent.Rules.ValidationRule_T_.T 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

| Methods | |
| :--- | :--- |
| [GetPropertyName()](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_/GetPropertyName().md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>.GetPropertyName()') | Obtém o nome da propriedade a ser validada pela regra |
| [Validate(T)](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_/Validate(T).md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>.Validate(T)') | Executa a validação da propriedade na instância especificada |
