#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## MaxLenght<T> Class

```csharp
internal class MaxLenght<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.MaxLenght_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/MaxLenght_T_.md#EficazFramework.Validation.Fluent.Rules.MaxLenght_T_.T 'EficazFramework.Validation.Fluent.Rules.MaxLenght<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; MaxLenght<T>
### Constructors

<a name='EficazFramework.Validation.Fluent.Rules.MaxLenght_T_.MaxLenght(System.Linq.Expressions.Expression_System.Func_T,object__,int)'></a>

## MaxLenght(Expression<Func<T,object>>, int) Constructor

Regra de validação contra valores e/ou referências nulas ou vazias

```csharp
public MaxLenght(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, int lenght);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.MaxLenght_T_.MaxLenght(System.Linq.Expressions.Expression_System.Func_T,object__,int).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/MaxLenght_T_.md#EficazFramework.Validation.Fluent.Rules.MaxLenght_T_.T 'EficazFramework.Validation.Fluent.Rules.MaxLenght<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.MaxLenght_T_.MaxLenght(System.Linq.Expressions.Expression_System.Func_T,object__,int).lenght'></a>

`lenght` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Properties

<a name='EficazFramework.Validation.Fluent.Rules.MaxLenght_T_.Lenght'></a>

## MaxLenght<T>.Lenght Property

Limite de caracteres aceito.

```csharp
public int Lenght { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')