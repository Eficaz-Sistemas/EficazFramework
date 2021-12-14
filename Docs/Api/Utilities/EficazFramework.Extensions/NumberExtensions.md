#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## NumberExtensions Class

```csharp
public static class NumberExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; NumberExtensions
### Methods

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdecimal,int,int)'></a>

## NumberExtensions.ToSignificantDigits(this decimal, int, int) Method

Retorna o número formatado na quantidade de algarismos significativos desejada.

```csharp
public static string ToSignificantDigits(this decimal d, int SignificantDigits, int MinDecimals=0);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdecimal,int,int).d'></a>

`d` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdecimal,int,int).SignificantDigits'></a>

`SignificantDigits` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdecimal,int,int).MinDecimals'></a>

`MinDecimals` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdouble,int,int)'></a>

## NumberExtensions.ToSignificantDigits(this double, int, int) Method

Retorna o número formatado na quantidade de algarismos significativos desejada.

```csharp
public static string ToSignificantDigits(this double d, int SignificantDigits, int MinDecimals=0);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdouble,int,int).d'></a>

`d` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdouble,int,int).SignificantDigits'></a>

`SignificantDigits` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisdouble,int,int).MinDecimals'></a>

`MinDecimals` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_decimal_,int,int)'></a>

## NumberExtensions.ToSignificantDigits(this Nullable<decimal>, int, int) Method

Retorna o número formatado na quantidade de algarismos significativos desejada.

```csharp
public static string ToSignificantDigits(this System.Nullable<decimal> d, int SignificantDigits, int MinDecimals=0);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_decimal_,int,int).d'></a>

`d` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_decimal_,int,int).SignificantDigits'></a>

`SignificantDigits` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_decimal_,int,int).MinDecimals'></a>

`MinDecimals` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_double_,int,int)'></a>

## NumberExtensions.ToSignificantDigits(this Nullable<double>, int, int) Method

Retorna o número formatado na quantidade de algarismos significativos desejada.

```csharp
public static string ToSignificantDigits(this System.Nullable<double> d, int SignificantDigits, int MinDecimals=0);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_double_,int,int).d'></a>

`d` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_double_,int,int).SignificantDigits'></a>

`SignificantDigits` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Extensions.NumberExtensions.ToSignificantDigits(thisSystem.Nullable_double_,int,int).MinDecimals'></a>

`MinDecimals` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdecimal,EficazFramework.Extensions.NumberExtensions.Currency)'></a>

## NumberExtensions.ToWords(this decimal, Currency) Method

Retorna o número por extenso, em moeda.

```csharp
public static string ToWords(this decimal number, EficazFramework.Extensions.NumberExtensions.Currency currency);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdecimal,EficazFramework.Extensions.NumberExtensions.Currency).number'></a>

`number` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdecimal,EficazFramework.Extensions.NumberExtensions.Currency).currency'></a>

`currency` [EficazFramework.Extensions.NumberExtensions.Currency](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Currency 'EficazFramework.Extensions.NumberExtensions.Currency')

A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdecimal,EficazFramework.Extensions.NumberExtensions.Gender)'></a>

## NumberExtensions.ToWords(this decimal, Gender) Method

Retorna o número por extenso.

```csharp
public static string ToWords(this decimal number, EficazFramework.Extensions.NumberExtensions.Gender gender=EficazFramework.Extensions.NumberExtensions.Gender.Masculino);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdecimal,EficazFramework.Extensions.NumberExtensions.Gender).number'></a>

`number` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdecimal,EficazFramework.Extensions.NumberExtensions.Gender).gender'></a>

`gender` [EficazFramework.Extensions.NumberExtensions.Gender](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Gender 'EficazFramework.Extensions.NumberExtensions.Gender')

Define se será escrito no mesculino (dois) ou feminino (duas).

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdouble,EficazFramework.Extensions.NumberExtensions.Currency)'></a>

## NumberExtensions.ToWords(this double, Currency) Method

Retorna o número por extenso, em moeda.

```csharp
public static string ToWords(this double number, EficazFramework.Extensions.NumberExtensions.Currency currency);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdouble,EficazFramework.Extensions.NumberExtensions.Currency).number'></a>

`number` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdouble,EficazFramework.Extensions.NumberExtensions.Currency).currency'></a>

`currency` [EficazFramework.Extensions.NumberExtensions.Currency](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Currency 'EficazFramework.Extensions.NumberExtensions.Currency')

A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdouble,EficazFramework.Extensions.NumberExtensions.Gender)'></a>

## NumberExtensions.ToWords(this double, Gender) Method

Retorna o número por extenso.

```csharp
public static string ToWords(this double number, EficazFramework.Extensions.NumberExtensions.Gender gender=EficazFramework.Extensions.NumberExtensions.Gender.Masculino);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdouble,EficazFramework.Extensions.NumberExtensions.Gender).number'></a>

`number` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisdouble,EficazFramework.Extensions.NumberExtensions.Gender).gender'></a>

`gender` [EficazFramework.Extensions.NumberExtensions.Gender](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Gender 'EficazFramework.Extensions.NumberExtensions.Gender')

Define se será escrito no mesculino (dois) ou feminino (duas).

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisint,EficazFramework.Extensions.NumberExtensions.Currency)'></a>

## NumberExtensions.ToWords(this int, Currency) Method

Retorna o número por extenso, em moeda.

```csharp
public static string ToWords(this int number, EficazFramework.Extensions.NumberExtensions.Currency currency);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisint,EficazFramework.Extensions.NumberExtensions.Currency).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisint,EficazFramework.Extensions.NumberExtensions.Currency).currency'></a>

`currency` [EficazFramework.Extensions.NumberExtensions.Currency](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Currency 'EficazFramework.Extensions.NumberExtensions.Currency')

A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisint,EficazFramework.Extensions.NumberExtensions.Gender)'></a>

## NumberExtensions.ToWords(this int, Gender) Method

Retorna o número por extenso.

```csharp
public static string ToWords(this int number, EficazFramework.Extensions.NumberExtensions.Gender gender=EficazFramework.Extensions.NumberExtensions.Gender.Masculino);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisint,EficazFramework.Extensions.NumberExtensions.Gender).number'></a>

`number` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisint,EficazFramework.Extensions.NumberExtensions.Gender).gender'></a>

`gender` [EficazFramework.Extensions.NumberExtensions.Gender](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Gender 'EficazFramework.Extensions.NumberExtensions.Gender')

Define se será escrito no mesculino (dois) ou feminino (duas).

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thislong,EficazFramework.Extensions.NumberExtensions.Currency)'></a>

## NumberExtensions.ToWords(this long, Currency) Method

Retorna o número por extenso, em moeda.

```csharp
public static string ToWords(this long number, EficazFramework.Extensions.NumberExtensions.Currency currency);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thislong,EficazFramework.Extensions.NumberExtensions.Currency).number'></a>

`number` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thislong,EficazFramework.Extensions.NumberExtensions.Currency).currency'></a>

`currency` [EficazFramework.Extensions.NumberExtensions.Currency](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Currency 'EficazFramework.Extensions.NumberExtensions.Currency')

A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thislong,EficazFramework.Extensions.NumberExtensions.Gender)'></a>

## NumberExtensions.ToWords(this long, Gender) Method

Retorna o número por extenso.

```csharp
public static string ToWords(this long number, EficazFramework.Extensions.NumberExtensions.Gender gender=EficazFramework.Extensions.NumberExtensions.Gender.Masculino);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thislong,EficazFramework.Extensions.NumberExtensions.Gender).number'></a>

`number` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thislong,EficazFramework.Extensions.NumberExtensions.Gender).gender'></a>

`gender` [EficazFramework.Extensions.NumberExtensions.Gender](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Gender 'EficazFramework.Extensions.NumberExtensions.Gender')

Define se será escrito no mesculino (dois) ou feminino (duas).

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisshort,EficazFramework.Extensions.NumberExtensions.Currency)'></a>

## NumberExtensions.ToWords(this short, Currency) Method

Retorna o número por extenso, em moeda.

```csharp
public static string ToWords(this short number, EficazFramework.Extensions.NumberExtensions.Currency currency);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisshort,EficazFramework.Extensions.NumberExtensions.Currency).number'></a>

`number` [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/System.Int16 'System.Int16')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisshort,EficazFramework.Extensions.NumberExtensions.Currency).currency'></a>

`currency` [EficazFramework.Extensions.NumberExtensions.Currency](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Currency 'EficazFramework.Extensions.NumberExtensions.Currency')

A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisshort,EficazFramework.Extensions.NumberExtensions.Gender)'></a>

## NumberExtensions.ToWords(this short, Gender) Method

Retorna o número por extenso.

```csharp
public static string ToWords(this short number, EficazFramework.Extensions.NumberExtensions.Gender gender=EficazFramework.Extensions.NumberExtensions.Gender.Masculino);
```
#### Parameters

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisshort,EficazFramework.Extensions.NumberExtensions.Gender).number'></a>

`number` [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/System.Int16 'System.Int16')

O número a ser escrito.

<a name='EficazFramework.Extensions.NumberExtensions.ToWords(thisshort,EficazFramework.Extensions.NumberExtensions.Gender).gender'></a>

`gender` [EficazFramework.Extensions.NumberExtensions.Gender](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Gender 'EficazFramework.Extensions.NumberExtensions.Gender')

Define se será escrito no mesculino (dois) ou feminino (duas).

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks