#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[NumberExtensions](EficazFramework.Extensions/NumberExtensions.md 'EficazFramework.Extensions.NumberExtensions')

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

`currency` [Currency](EficazFramework.Extensions/NumberExtensions/Currency.md 'EficazFramework.Extensions.NumberExtensions.Currency')

A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks