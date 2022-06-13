#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[NumberExtensions](EficazFramework.Extensions/NumberExtensions.md 'EficazFramework.Extensions.NumberExtensions')

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

`currency` [Currency](EficazFramework.Extensions/NumberExtensions/Currency.md 'EficazFramework.Extensions.NumberExtensions.Currency')

A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks