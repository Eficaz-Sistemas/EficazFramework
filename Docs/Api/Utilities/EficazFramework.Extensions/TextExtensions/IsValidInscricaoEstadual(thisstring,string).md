#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[TextExtensions](EficazFramework.Extensions/TextExtensions.md 'EficazFramework.Extensions.TextExtensions')

## TextExtensions.IsValidInscricaoEstadual(this string, string) Method

Verifica a veracidade do número de Inscrição Estadual informado.

```csharp
public static bool IsValidInscricaoEstadual(this string IE, string UF);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.IsValidInscricaoEstadual(thisstring,string).IE'></a>

`IE` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A Inscrição Estadual a ser analisada.

<a name='EficazFramework.Extensions.TextExtensions.IsValidInscricaoEstadual(thisstring,string).UF'></a>

`UF` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A unidade de federação da Inscrição Estadual. As seguinte UF's ainda não estão funcionando: DF, PE e RS

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean

### Remarks