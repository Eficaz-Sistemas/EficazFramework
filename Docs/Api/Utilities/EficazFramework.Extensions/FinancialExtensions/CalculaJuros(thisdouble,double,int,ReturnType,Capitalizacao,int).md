#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[FinancialExtensions](EficazFramework.Extensions/FinancialExtensions.md 'EficazFramework.Extensions.FinancialExtensions')

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

`retorno` [ReturnType](EficazFramework.Extensions/FinancialExtensions/ReturnType.md 'EficazFramework.Extensions.FinancialExtensions.ReturnType')

Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).tipo'></a>

`tipo` [Capitalizacao](EficazFramework.Extensions/FinancialExtensions/Capitalizacao.md 'EficazFramework.Extensions.FinancialExtensions.Capitalizacao')

Juros Simples ou Juros Compostos.

<a name='EficazFramework.Extensions.FinancialExtensions.CalculaJuros(thisdouble,double,int,EficazFramework.Extensions.FinancialExtensions.ReturnType,EficazFramework.Extensions.FinancialExtensions.Capitalizacao,int).rounding'></a>

`rounding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.

#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Double

### Remarks