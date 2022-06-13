#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[LocalizationExtensions](EficazFramework.Extensions/LocalizationExtensions.md 'EficazFramework.Extensions.LocalizationExtensions')

## LocalizationExtensions.Localize(this string, Type, string) Method

Retorna o texto no idioma (System.Globalization.Culture.CultureInfo) atual

```csharp
public static string Localize(this string text, System.Type resourceManager, string stringformat);
```
#### Parameters

<a name='EficazFramework.Extensions.LocalizationExtensions.Localize(thisstring,System.Type,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

ID do texto a ser localizado.

<a name='EficazFramework.Extensions.LocalizationExtensions.Localize(thisstring,System.Type,string).resourceManager'></a>

`resourceManager` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

Tipo do dicionário ResourceManager a ser consultado.

<a name='EficazFramework.Extensions.LocalizationExtensions.Localize(thisstring,System.Type,string).stringformat'></a>

`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

(Opcional) Máscara para formatação do texto resultante.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')