#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## Equals<T> Class

```csharp
internal class Equals<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.Equals_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/Equals_T_.md#EficazFramework.Validation.Fluent.Rules.Equals_T_.T 'EficazFramework.Validation.Fluent.Rules.Equals<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; Equals<T>
### Constructors

<a name='EficazFramework.Validation.Fluent.Rules.Equals_T_.Equals(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__)'></a>

## Equals(Expression<Func<T,object>>, Expression<Func<T,object>>) Constructor

Regra de validação contra valores e/ou referências nulas ou vazias

```csharp
public Equals(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.Linq.Expressions.Expression<System.Func<T,object>> to);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Equals_T_.Equals(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Equals_T_.md#EficazFramework.Validation.Fluent.Rules.Equals_T_.T 'EficazFramework.Validation.Fluent.Rules.Equals<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Equals_T_.Equals(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).to'></a>

`to` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Equals_T_.md#EficazFramework.Validation.Fluent.Rules.Equals_T_.T 'EficazFramework.Validation.Fluent.Rules.Equals<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')
### Properties

<a name='EficazFramework.Validation.Fluent.Rules.Equals_T_.To'></a>

## Equals<T>.To Property

Limite de caracteres aceito.

```csharp
public System.Linq.Expressions.Expression<System.Func<T,object>> To { get; set; }
```

#### Property Value
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Equals_T_.md#EficazFramework.Validation.Fluent.Rules.Equals_T_.T 'EficazFramework.Validation.Fluent.Rules.Equals<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')