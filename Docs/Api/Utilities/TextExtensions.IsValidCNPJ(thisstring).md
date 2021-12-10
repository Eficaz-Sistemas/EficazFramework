#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[TextExtensions](TextExtensions.md 'EficazFramework.Extensions.TextExtensions')

## TextExtensions.IsValidCNPJ(this string) Method

Verifica a veracidade do número de CNPJ informado.

```csharp
public static bool IsValidCNPJ(this string CNPJ);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.IsValidCNPJ(thisstring).CNPJ'></a>

`CNPJ` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O CNPJ a ser analisado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean

### Remarks
Antes de utilizar este método, faz-se necessário remover a máscara do número.