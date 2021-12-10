#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[TextExtensions](EficazFramework.Extensions/TextExtensions.md 'EficazFramework.Extensions.TextExtensions')

## TextExtensions.ToTitleCase(this string, string[]) Method

Formata a string para o padrão de títulos.  
Ex: 'eficaz contabilidade' para 'Eficaz Contabilidade'.  
Nota: Permite uso de array de caracteres a serem identificados como separador de nomes. Ideal para ausência de espaços.  
Ex: splitChars = New String() {";", ":", "/"}

```csharp
public static string ToTitleCase(this string name, string[] splitChars=null);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.ToTitleCase(thisstring,string[]).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.TextExtensions.ToTitleCase(thisstring,string[]).splitChars'></a>

`splitChars` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks