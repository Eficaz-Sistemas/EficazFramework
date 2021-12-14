#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## Required<T> Class

```csharp
internal class Required<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.Required_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/Required_T_.md#EficazFramework.Validation.Fluent.Rules.Required_T_.T 'EficazFramework.Validation.Fluent.Rules.Required<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; Required<T>
### Constructors

<a name='EficazFramework.Validation.Fluent.Rules.Required_T_.Required(System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## Required(Expression<Func<T,object>>, bool) Constructor

Regra de validação contra valores e/ou referências nulas ou vazias

```csharp
public Required(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, bool allowempty=false);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Required_T_.Required(System.Linq.Expressions.Expression_System.Func_T,object__,bool).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Required_T_.md#EficazFramework.Validation.Fluent.Rules.Required_T_.T 'EficazFramework.Validation.Fluent.Rules.Required<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Required_T_.Required(System.Linq.Expressions.Expression_System.Func_T,object__,bool).allowempty'></a>

`allowempty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Properties

<a name='EficazFramework.Validation.Fluent.Rules.Required_T_.AllowEmpty'></a>

## Required<T>.AllowEmpty Property

Obtém ou define se a constante String.Empty será permitida ou não

```csharp
public bool AllowEmpty { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')