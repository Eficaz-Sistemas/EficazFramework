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
### Constructors

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.RangePeriod(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## RangePeriod(Expression<Func<T,object>>, Expression<Func<T,object>>, bool) Constructor

Regra de validação que confronta dois valores de um intervalo.

```csharp
public RangePeriod(System.Linq.Expressions.Expression<System.Func<T,object>> endValueExpression, System.Linq.Expressions.Expression<System.Func<T,object>> startValueExpression, bool allowEquals=true);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.RangePeriod(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).endValueExpression'></a>

`endValueExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md#EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.RangePeriod(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).startValueExpression'></a>

`startValueExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md#EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.RangePeriod(System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).allowEquals'></a>

`allowEquals` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Properties

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.AllowEquals'></a>

## RangePeriod<T>.AllowEquals Property

Define se o valor final pode ser igual ao valor inicial.

```csharp
public bool AllowEquals { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.EndProperty'></a>

## RangePeriod<T>.EndProperty Property

Expressão lambda para acesso à propriedade contendo o valor final que deve ser validado

```csharp
public System.Linq.Expressions.Expression<System.Func<T,object>> EndProperty { get; }
```

#### Property Value
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md#EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.StartProperty'></a>

## RangePeriod<T>.StartProperty Property

Expressão lambda para acesso à propriedade contendo o valor inicial que deve ser validado

```csharp
public System.Linq.Expressions.Expression<System.Func<T,object>> StartProperty { get; set; }
```

#### Property Value
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md#EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.T 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.ValuesStringFormatForMessage'></a>

## RangePeriod<T>.ValuesStringFormatForMessage Property

Formato de data ou número para exibição na mensagem

```csharp
public string ValuesStringFormatForMessage { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='EficazFramework.Validation.Fluent.Rules.RangePeriod_T_.GetStartPropertyName()'></a>

## RangePeriod<T>.GetStartPropertyName() Method

Obtém o nome da propriedade a ser validada pela regra

```csharp
internal string GetStartPropertyName();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')