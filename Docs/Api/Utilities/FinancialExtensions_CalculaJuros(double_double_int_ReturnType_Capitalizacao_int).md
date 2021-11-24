#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[FinancialExtensions](FinancialExtensions.md 'EficazFramework.Extensions.FinancialExtensions')
## FinancialExtensions.CalculaJuros(double, double, int, ReturnType, Capitalizacao, int) Method
Calcula os juros sobre um capital, a uma taxa e período desejado.  
NOTA: periodo e taxa devem estar na mesma unidade de tempo (ao dia, ao mês, etc).  
```csharp
public static double CalculaJuros(this double capital, double taxa, int periodo, EficazFramework.Extensions.FinancialExtensions.ReturnType retorno=EficazFramework.Extensions.FinancialExtensions.ReturnType.Montante, EficazFramework.Extensions.FinancialExtensions.Capitalizacao tipo=EficazFramework.Extensions.FinancialExtensions.Capitalizacao.JurosSimples, int rounding=-1);
```
#### Parameters
<a name='EficazFramework_Extensions_FinancialExtensions_CalculaJuros(double_double_int_EficazFramework_Extensions_FinancialExtensions_ReturnType_EficazFramework_Extensions_FinancialExtensions_Capitalizacao_int)_capital'></a>
`capital` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
O capital base para cálculo.
  
<a name='EficazFramework_Extensions_FinancialExtensions_CalculaJuros(double_double_int_EficazFramework_Extensions_FinancialExtensions_ReturnType_EficazFramework_Extensions_FinancialExtensions_Capitalizacao_int)_taxa'></a>
`taxa` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
A taxa de juros a ser aplicada.
  
<a name='EficazFramework_Extensions_FinancialExtensions_CalculaJuros(double_double_int_EficazFramework_Extensions_FinancialExtensions_ReturnType_EficazFramework_Extensions_FinancialExtensions_Capitalizacao_int)_periodo'></a>
`periodo` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
O período a ser aplicado.
  
<a name='EficazFramework_Extensions_FinancialExtensions_CalculaJuros(double_double_int_EficazFramework_Extensions_FinancialExtensions_ReturnType_EficazFramework_Extensions_FinancialExtensions_Capitalizacao_int)_retorno'></a>
`retorno` [EficazFramework.Extensions.FinancialExtensions.ReturnType](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.ReturnType 'EficazFramework.Extensions.FinancialExtensions.ReturnType')  
Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.
  
<a name='EficazFramework_Extensions_FinancialExtensions_CalculaJuros(double_double_int_EficazFramework_Extensions_FinancialExtensions_ReturnType_EficazFramework_Extensions_FinancialExtensions_Capitalizacao_int)_tipo'></a>
`tipo` [EficazFramework.Extensions.FinancialExtensions.Capitalizacao](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.FinancialExtensions.Capitalizacao 'EficazFramework.Extensions.FinancialExtensions.Capitalizacao')  
Juros Simples ou Juros Compostos.
  
<a name='EficazFramework_Extensions_FinancialExtensions_CalculaJuros(double_double_int_EficazFramework_Extensions_FinancialExtensions_ReturnType_EficazFramework_Extensions_FinancialExtensions_Capitalizacao_int)_rounding'></a>
`rounding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.
  
#### Returns
[System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')  
Double
### Remarks
