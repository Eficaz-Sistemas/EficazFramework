#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## FinancialExtensions Class

```csharp
public static class FinancialExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; FinancialExtensions
### Methods

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int)'></a>

## FinancialExtensions.CalculaJuros(this double, double, int, ReturnType, Capitalizacao, int) Method

Calcula os juros sobre um capital, a uma taxa e período desejado.  
NOTA: periodo e taxa devem estar na mesma unidade de tempo (ao dia, ao mês, etc).

```csharp
public static double CalculaJuros(this double capital, double taxa, int periodo, EficazFramework.Extensions.FinancialExtensions.ReturnType retorno=EficazFramework.Extensions.FinancialExtensions.ReturnType.Montante, EficazFramework.Extensions.FinancialExtensions.Capitalizacao tipo=EficazFramework.Extensions.FinancialExtensions.Capitalizacao.JurosSimples, int rounding=-1);
```
#### Parameters

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).capital'></a>

`capital` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O capital base para cálculo.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).taxa'></a>

`taxa` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

A taxa de juros a ser aplicada.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).periodo'></a>

`periodo` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

O período a ser aplicado.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).retorno'></a>

`retorno` [EficazFramework.Extensions.FinancialExtensions.ReturnType](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.ReturnType 'EficazFramework.Extensions.FinancialExtensions.ReturnType')

Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).tipo'></a>

`tipo` [EficazFramework.Extensions.FinancialExtensions.Capitalizacao](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.Capitalizacao 'EficazFramework.Extensions.FinancialExtensions.Capitalizacao')

Juros Simples ou Juros Compostos.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).rounding'></a>

`rounding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Double

### Remarks

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int)'></a>

## FinancialExtensions.CalculaJuros(this Nullable<double>, double, int, ReturnType, Capitalizacao, int) Method

Calcula os juros sobre um capital, a uma taxa e período desejado.  
NOTA: periodo e taxa devem estar na mesma unidade de tempo (ao dia, ao mês, etc).

```csharp
public static double CalculaJuros(this System.Nullable<double> capital, double taxa, int periodo, EficazFramework.Extensions.FinancialExtensions.ReturnType retorno=EficazFramework.Extensions.FinancialExtensions.ReturnType.Montante, EficazFramework.Extensions.FinancialExtensions.Capitalizacao tipo=EficazFramework.Extensions.FinancialExtensions.Capitalizacao.JurosSimples, int rounding=-1);
```
#### Parameters

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).capital'></a>

`capital` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

O capital base para cálculo.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).taxa'></a>

`taxa` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

A taxa de juros a ser aplicada.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).periodo'></a>

`periodo` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

O período a ser aplicado.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).retorno'></a>

`retorno` [EficazFramework.Extensions.FinancialExtensions.ReturnType](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.ReturnType 'EficazFramework.Extensions.FinancialExtensions.ReturnType')

Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).tipo'></a>

`tipo` [EficazFramework.Extensions.FinancialExtensions.Capitalizacao](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.Capitalizacao 'EficazFramework.Extensions.FinancialExtensions.Capitalizacao')

Juros Simples ou Juros Compostos.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).rounding'></a>

`rounding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Double

### Remarks

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int)'></a>

## FinancialExtensions.CalculaTaxa(this double, double, int, Capitalizacao, int) Method

Calcula a taxa de juros de uma operação com base no capital aplicado em um período desejado.  
NOTA: A taxa retornada será referente à unidade de tempo do período (ao dia, ao mês, etc).

```csharp
public static double CalculaTaxa(this double capital, double montante, int periodo, EficazFramework.Extensions.FinancialExtensions.Capitalizacao tipo=EficazFramework.Extensions.FinancialExtensions.Capitalizacao.JurosSimples, int rounding=-1);
```
#### Parameters

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).capital'></a>

`capital` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O capital base para cálculo.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).montante'></a>

`montante` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O montante final (valor agregado) (capital + juros).

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).periodo'></a>

`periodo` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

O período a ser aplicado.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).tipo'></a>

`tipo` [EficazFramework.Extensions.FinancialExtensions.Capitalizacao](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.Capitalizacao 'EficazFramework.Extensions.FinancialExtensions.Capitalizacao')

Juros Simples ou Juros Compostos.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).rounding'></a>

`rounding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Double

### Remarks

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int)'></a>

## FinancialExtensions.CalculaTaxa(this Nullable<double>, double, int, Capitalizacao, int) Method

Calcula a taxa de juros de uma operação com base no capital aplicado em um período desejado.  
NOTA: A taxa retornada será referente à unidade de tempo do período (ao dia, ao mês, etc).

```csharp
public static double CalculaTaxa(this System.Nullable<double> capital, double montante, int periodo, EficazFramework.Extensions.FinancialExtensions.Capitalizacao tipo=EficazFramework.Extensions.FinancialExtensions.Capitalizacao.JurosSimples, int rounding=-1);
```
#### Parameters

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).capital'></a>

`capital` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

O capital base para cálculo.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).montante'></a>

`montante` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

O montante final (valor agregado) (capital + juros).

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).periodo'></a>

`periodo` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

O período a ser aplicado.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).tipo'></a>

`tipo` [EficazFramework.Extensions.FinancialExtensions.Capitalizacao](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.Capitalizacao 'EficazFramework.Extensions.FinancialExtensions.Capitalizacao')

Juros Simples ou Juros Compostos.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaTaxa(thisSystem.Nullable_double_,double,int,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).rounding'></a>

`rounding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Double

### Remarks