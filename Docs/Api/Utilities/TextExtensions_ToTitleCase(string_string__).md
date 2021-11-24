#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[TextExtensions](TextExtensions.md 'EficazFramework.Extensions.TextExtensions')
## TextExtensions.ToTitleCase(string, string[]) Method
Formata a string para o padrão de títulos.  
Ex: 'eficaz contabilidade' para 'Eficaz Contabilidade'.  
Nota: Permite uso de array de caracteres a serem identificados como separador de nomes. Ideal para ausência de espaços.  
Ex: splitChars = New String() {";", ":", "/"}  
```csharp
public static string ToTitleCase(this string name, string[] splitChars=null);
```
#### Parameters
<a name='EficazFramework_Extensions_TextExtensions_ToTitleCase(string_string__)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='EficazFramework_Extensions_TextExtensions_ToTitleCase(string_string__)_splitChars'></a>
`splitChars` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
  
#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String
### Remarks
