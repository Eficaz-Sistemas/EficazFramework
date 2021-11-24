#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions')
## TextExtensions Class
```csharp
public static class TextExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextExtensions  

| Methods | |
| :--- | :--- |
| [FormatCEP(string)](TextExtensions_FormatCEP(string).md 'EficazFramework.Extensions.TextExtensions.FormatCEP(string)') | Insere a máscara de formatação a um CEP.<br/> |
| [FormatIE(string, string)](TextExtensions_FormatIE(string_string).md 'EficazFramework.Extensions.TextExtensions.FormatIE(string, string)') | Insere a máscara de formatação em uma Inscrição Estadual<br/> |
| [FormatLogradouro(string, bool)](TextExtensions_FormatLogradouro(string_bool).md 'EficazFramework.Extensions.TextExtensions.FormatLogradouro(string, bool)') | Formata um logradouro em Tipo e Nome em array de string.<br/>Ex: "Rua Sete de Setembro" em: "Rua" "Sete de Setembro".<br/> |
| [FormatRFBDocument(string)](TextExtensions_FormatRFBDocument(string).md 'EficazFramework.Extensions.TextExtensions.FormatRFBDocument(string)') | Insere a máscara de formatação em um CNPJ ou CPF.<br/> |
| [GetClearText(string)](TextExtensions_GetClearText(string).md 'EficazFramework.Extensions.TextExtensions.GetClearText(string)') | Remove todos os caracteres especiais de uma string.<br/> |
| [IsValidCNPJ(string)](TextExtensions_IsValidCNPJ(string).md 'EficazFramework.Extensions.TextExtensions.IsValidCNPJ(string)') | Verifica a veracidade do número de CNPJ informado.<br/> |
| [IsValidCPF(string)](TextExtensions_IsValidCPF(string).md 'EficazFramework.Extensions.TextExtensions.IsValidCPF(string)') | Verifica a veracidade do número de CPF informado.<br/> |
| [IsValidEmailAddress(string)](TextExtensions_IsValidEmailAddress(string).md 'EficazFramework.Extensions.TextExtensions.IsValidEmailAddress(string)') | Verifica se o endereço de e-mail informado é válido.<br/> |
| [IsValidInscricaoEstadual(string, string)](TextExtensions_IsValidInscricaoEstadual(string_string).md 'EficazFramework.Extensions.TextExtensions.IsValidInscricaoEstadual(string, string)') | Verifica a veracidade do número de Inscrição Estadual informado.<br/> |
| [IsValidPISePASEP(string)](TextExtensions_IsValidPISePASEP(string).md 'EficazFramework.Extensions.TextExtensions.IsValidPISePASEP(string)') | Verifica a veracidade do número de PIS/Pasep informado.<br/> |
| [Left(string, int)](TextExtensions_Left(string_int).md 'EficazFramework.Extensions.TextExtensions.Left(string, int)') | Returns the left part of this string instance.<br/> |
| [Mid(string, int)](TextExtensions_Mid(string_int).md 'EficazFramework.Extensions.TextExtensions.Mid(string, int)') | Returns the mid part of this string instance.<br/> |
| [Mid(string, int, int)](TextExtensions_Mid(string_int_int).md 'EficazFramework.Extensions.TextExtensions.Mid(string, int, int)') | Returns the mid part of this string instance.<br/> |
| [RemoveTextMask(string)](TextExtensions_RemoveTextMask(string).md 'EficazFramework.Extensions.TextExtensions.RemoveTextMask(string)') | Remove todos os caracteres de máscara (literais) de uma string.<br/> |
| [Right(string, int)](TextExtensions_Right(string_int).md 'EficazFramework.Extensions.TextExtensions.Right(string, int)') | Returns the right part of the string instance.<br/> |
| [SplitByLength(string, int)](TextExtensions_SplitByLength(string_int).md 'EficazFramework.Extensions.TextExtensions.SplitByLength(string, int)') | Divide uma string em numa lista de substrings, conforme a quantidade de caracteres desejada<br/> |
| [ToTitleCase(string, string[])](TextExtensions_ToTitleCase(string_string__).md 'EficazFramework.Extensions.TextExtensions.ToTitleCase(string, string[])') | Formata a string para o padrão de títulos.<br/>Ex: 'eficaz contabilidade' para 'Eficaz Contabilidade'.<br/>Nota: Permite uso de array de caracteres a serem identificados como separador de nomes. Ideal para ausência de espaços.<br/>Ex: splitChars = New String() {";", ":", "/"}<br/> |
