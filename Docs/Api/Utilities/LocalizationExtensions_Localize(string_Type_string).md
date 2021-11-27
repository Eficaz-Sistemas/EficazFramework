#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[LocalizationExtensions](LocalizationExtensions.md 'EficazFramework.Extensions.LocalizationExtensions')
## LocalizationExtensions.Localize(string, Type, string) Method
Retorna o texto no idioma (System.Globalization.Culture.CultureInfo) atual  
```csharp
public static string Localize(this string text, System.Type resourceManager, string stringformat);
```
#### Parameters
<a name='EficazFramework_Extensions_LocalizationExtensions_Localize(string_System_Type_string)_text'></a>
`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
ID do texto a ser localizado.
  
<a name='EficazFramework_Extensions_LocalizationExtensions_Localize(string_System_Type_string)_resourceManager'></a>
`resourceManager` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
Tipo do dicionário ResourceManager a ser consultado.
  
<a name='EficazFramework_Extensions_LocalizationExtensions_Localize(string_System_Type_string)_stringformat'></a>
`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(Opcional) Máscara para formatação do texto resultante.
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
