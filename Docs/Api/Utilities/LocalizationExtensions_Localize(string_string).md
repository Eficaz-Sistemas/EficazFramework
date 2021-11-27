#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[LocalizationExtensions](LocalizationExtensions.md 'EficazFramework.Extensions.LocalizationExtensions')
## LocalizationExtensions.Localize(string, string) Method
Retorna o texto no idioma (System.Globalization.Culture.CultureInfo) atual.  
Utiliza o dicionário EficazFramework.Resources.Strings.Descriptions.  
```csharp
public static string Localize(this string text, string stringformat);
```
#### Parameters
<a name='EficazFramework_Extensions_LocalizationExtensions_Localize(string_string)_text'></a>
`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
ID do texto a ser localizado.
  
<a name='EficazFramework_Extensions_LocalizationExtensions_Localize(string_string)_stringformat'></a>
`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
(Opcional) Máscara para formatação do texto resultante.
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
