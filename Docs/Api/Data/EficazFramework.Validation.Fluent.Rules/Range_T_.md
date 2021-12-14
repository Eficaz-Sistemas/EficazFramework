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
### Constructors

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal)'></a>

## Range(Expression<Func<T,object>>, decimal, decimal) Constructor

Regra de validação contra valores fora do intervalo desejado.  
Tipo: decimal

```csharp
public Range(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, decimal minimum, decimal maximum);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Range_T_.md#EficazFramework.Validation.Fluent.Rules.Range_T_.T 'EficazFramework.Validation.Fluent.Rules.Range<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal).minimum'></a>

`minimum` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal).maximum'></a>

`maximum` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,double,double)'></a>

## Range(Expression<Func<T,object>>, double, double) Constructor

Regra de validação contra valores fora do intervalo desejado.  
Tipo: double

```csharp
public Range(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, double minimum, double maximum);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,double,double).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Range_T_.md#EficazFramework.Validation.Fluent.Rules.Range_T_.T 'EficazFramework.Validation.Fluent.Rules.Range<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,double,double).minimum'></a>

`minimum` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,double,double).maximum'></a>

`maximum` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,int,int)'></a>

## Range(Expression<Func<T,object>>, int, int) Constructor

Regra de validação contra valores fora do intervalo desejado.  
Tipo: int32

```csharp
public Range(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, int minimum, int maximum);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,int,int).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Range_T_.md#EficazFramework.Validation.Fluent.Rules.Range_T_.T 'EficazFramework.Validation.Fluent.Rules.Range<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,int,int).minimum'></a>

`minimum` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,int,int).maximum'></a>

`maximum` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,long,long)'></a>

## Range(Expression<Func<T,object>>, long, long) Constructor

Regra de validação contra valores fora do intervalo desejado.  
Tipo: int64

```csharp
public Range(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, long minimum, long maximum);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,long,long).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Range_T_.md#EficazFramework.Validation.Fluent.Rules.Range_T_.T 'EficazFramework.Validation.Fluent.Rules.Range<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,long,long).minimum'></a>

`minimum` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,long,long).maximum'></a>

`maximum` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,short,short)'></a>

## Range(Expression<Func<T,object>>, short, short) Constructor

Regra de validação contra valores fora do intervalo desejado.  
Tipo: int16

```csharp
public Range(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, short minimum, short maximum);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,short,short).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Range_T_.md#EficazFramework.Validation.Fluent.Rules.Range_T_.T 'EficazFramework.Validation.Fluent.Rules.Range<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,short,short).minimum'></a>

`minimum` [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/System.Int16 'System.Int16')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,short,short).maximum'></a>

`maximum` [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/System.Int16 'System.Int16')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime)'></a>

## Range(Expression<Func<T,object>>, DateTime, DateTime) Constructor

Regra de validação contra valores fora do intervalo desejado.  
Tipo: DATETIME

```csharp
public Range(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.DateTime minimum, System.DateTime maximum);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Range_T_.md#EficazFramework.Validation.Fluent.Rules.Range_T_.T 'EficazFramework.Validation.Fluent.Rules.Range<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).minimum'></a>

`minimum` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Range(System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).maximum'></a>

`maximum` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')
### Properties

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Maximum'></a>

## Range<T>.Maximum Property

Valor numérico máximo aceito na validação

```csharp
public decimal Maximum { get; set; }
```

#### Property Value
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.MaximumDate'></a>

## Range<T>.MaximumDate Property

Data máxima aceita na validação

```csharp
public System.DateTime MaximumDate { get; set; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.Minimum'></a>

## Range<T>.Minimum Property

Valor numérico mínimo aceito na validação

```csharp
public decimal Minimum { get; set; }
```

#### Property Value
[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.MinimumDate'></a>

## Range<T>.MinimumDate Property

Data mínima aceita na validação

```csharp
public System.DateTime MinimumDate { get; set; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='EficazFramework.Validation.Fluent.Rules.Range_T_.ValuesStringFormatForMessage'></a>

## Range<T>.ValuesStringFormatForMessage Property

Formato de data ou número para exibição na mensagem

```csharp
public string ValuesStringFormatForMessage { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')