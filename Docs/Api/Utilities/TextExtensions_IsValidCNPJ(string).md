#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[TextExtensions](TextExtensions.md 'EficazFramework.Extensions.TextExtensions')
## TextExtensions.IsValidCNPJ(string) Method
Verifica a veracidade do número de CNPJ informado.  
```csharp
public static bool IsValidCNPJ(this string CNPJ);
```
#### Parameters
<a name='EficazFramework_Extensions_TextExtensions_IsValidCNPJ(string)_CNPJ'></a>
`CNPJ` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
O CNPJ a ser analisado.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean
### Remarks
Antes de utilizar este método, faz-se necessário remover a máscara do número.
