#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[NumberExtensions](NumberExtensions.md 'EficazFramework.Extensions.NumberExtensions')
## NumberExtensions.ToWords(long, Currency) Method
Retorna o número por extenso, em moeda.  
```csharp
public static string ToWords(this long number, EficazFramework.Extensions.NumberExtensions.Currency currency);
```
#### Parameters
<a name='EficazFramework_Extensions_NumberExtensions_ToWords(long_EficazFramework_Extensions_NumberExtensions_Currency)_number'></a>
`number` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')  
O número a ser escrito.
  
<a name='EficazFramework_Extensions_NumberExtensions_ToWords(long_EficazFramework_Extensions_NumberExtensions_Currency)_currency'></a>
`currency` [EficazFramework.Extensions.NumberExtensions.Currency](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.NumberExtensions.Currency 'EficazFramework.Extensions.NumberExtensions.Currency')  
A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String
### Remarks
