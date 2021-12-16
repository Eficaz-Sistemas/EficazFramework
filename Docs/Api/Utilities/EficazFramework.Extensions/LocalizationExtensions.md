#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## LocalizationExtensions Class

```csharp
public static class LocalizationExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LocalizationExtensions
### Methods

<a name='EficazFramework.Extensions.LocalizationExtensions.Localize(thisstring)'></a>

## LocalizationExtensions.Localize(this string) Method

Retorna o texto no idioma (System.Globalization.Culture.CultureInfo) atual.  
Utiliza o dicionário EficazFramework.Resources.Strings.Descriptions.

```csharp
public static string Localize(this string text);
```
#### Parameters

<a name='EficazFramework.Extensions.LocalizationExtensions.Localize(thisstring).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

ID do texto a ser localizado.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.LocalizationExtensions.Localize(thisstring,System.Type,string)'></a>

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