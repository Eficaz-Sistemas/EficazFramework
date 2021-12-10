#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[FinancialExtensions](EficazFramework.Extensions/FinancialExtensions.md 'EficazFramework.Extensions.FinancialExtensions')

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