#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[TextExtensions](TextExtensions.md 'EficazFramework.Extensions.TextExtensions')
## TextExtensions.IsValidInscricaoEstadual(string, string) Method
Verifica a veracidade do número de Inscrição Estadual informado.  
```csharp
public static bool IsValidInscricaoEstadual(this string IE, string UF);
```
#### Parameters
<a name='EficazFramework_Extensions_TextExtensions_IsValidInscricaoEstadual(string_string)_IE'></a>
`IE` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A Inscrição Estadual a ser analisada.
  
<a name='EficazFramework_Extensions_TextExtensions_IsValidInscricaoEstadual(string_string)_UF'></a>
`UF` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A unidade de federação da Inscrição Estadual. As seguinte UF's ainda não estão funcionando: DF, PE e RS
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean
### Remarks
