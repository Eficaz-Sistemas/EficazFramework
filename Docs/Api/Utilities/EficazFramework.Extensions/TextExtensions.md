#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## TextExtensions Class

```csharp
public static class TextExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextExtensions

| Methods | |
| :--- | :--- |
| [FormatCEP(this string)](EficazFramework.Extensions/TextExtensions/FormatCEP(thisstring).md 'EficazFramework.Extensions.TextExtensions.FormatCEP(this string)') | Insere a máscara de formatação a um CEP. |
| [FormatIE(this string, string)](EficazFramework.Extensions/TextExtensions/FormatIE(thisstring,string).md 'EficazFramework.Extensions.TextExtensions.FormatIE(this string, string)') | Insere a máscara de formatação em uma Inscrição Estadual |
| [FormatLogradouro(this string, bool)](EficazFramework.Extensions/TextExtensions/FormatLogradouro(thisstring,bool).md 'EficazFramework.Extensions.TextExtensions.FormatLogradouro(this string, bool)') | Formata um logradouro em Tipo e Nome em array de string.<br/>Ex: "Rua Sete de Setembro" em: "Rua" "Sete de Setembro". |
| [FormatRFBDocument(this string)](EficazFramework.Extensions/TextExtensions/FormatRFBDocument(thisstring).md 'EficazFramework.Extensions.TextExtensions.FormatRFBDocument(this string)') | Insere a máscara de formatação em um CNPJ ou CPF. |
| [GetClearText(this string)](EficazFramework.Extensions/TextExtensions/GetClearText(thisstring).md 'EficazFramework.Extensions.TextExtensions.GetClearText(this string)') | Remove todos os caracteres especiais de uma string. |
| [IsValidCNPJ(this string)](EficazFramework.Extensions/TextExtensions/IsValidCNPJ(thisstring).md 'EficazFramework.Extensions.TextExtensions.IsValidCNPJ(this string)') | Verifica a veracidade do número de CNPJ informado. |
| [IsValidCPF(this string)](EficazFramework.Extensions/TextExtensions/IsValidCPF(thisstring).md 'EficazFramework.Extensions.TextExtensions.IsValidCPF(this string)') | Verifica a veracidade do número de CPF informado. |
| [IsValidEmailAddress(this string)](EficazFramework.Extensions/TextExtensions/IsValidEmailAddress(thisstring).md 'EficazFramework.Extensions.TextExtensions.IsValidEmailAddress(this string)') | Verifica se o endereço de e-mail informado é válido. |
| [IsValidInscricaoEstadual(this string, string)](EficazFramework.Extensions/TextExtensions/IsValidInscricaoEstadual(thisstring,string).md 'EficazFramework.Extensions.TextExtensions.IsValidInscricaoEstadual(this string, string)') | Verifica a veracidade do número de Inscrição Estadual informado. |
| [IsValidPISePASEP(this string)](EficazFramework.Extensions/TextExtensions/IsValidPISePASEP(thisstring).md 'EficazFramework.Extensions.TextExtensions.IsValidPISePASEP(this string)') | Verifica a veracidade do número de PIS/Pasep informado. |
| [Left(this string, int)](EficazFramework.Extensions/TextExtensions/Left(thisstring,int).md 'EficazFramework.Extensions.TextExtensions.Left(this string, int)') | Returns the left part of this string instance. |
| [Mid(this string, int)](EficazFramework.Extensions/TextExtensions/Mid(thisstring,int).md 'EficazFramework.Extensions.TextExtensions.Mid(this string, int)') | Returns the mid part of this string instance. |
| [Mid(this string, int, int)](EficazFramework.Extensions/TextExtensions/Mid(thisstring,int,int).md 'EficazFramework.Extensions.TextExtensions.Mid(this string, int, int)') | Returns the mid part of this string instance. |
| [RemoveTextMask(this string)](EficazFramework.Extensions/TextExtensions/RemoveTextMask(thisstring).md 'EficazFramework.Extensions.TextExtensions.RemoveTextMask(this string)') | Remove todos os caracteres de máscara (literais) de uma string. |
| [Right(this string, int)](EficazFramework.Extensions/TextExtensions/Right(thisstring,int).md 'EficazFramework.Extensions.TextExtensions.Right(this string, int)') | Returns the right part of the string instance. |
| [SplitByLength(this string, int)](EficazFramework.Extensions/TextExtensions/SplitByLength(thisstring,int).md 'EficazFramework.Extensions.TextExtensions.SplitByLength(this string, int)') | Divide uma string em numa lista de substrings, conforme a quantidade de caracteres desejada |
| [ToTitleCase(this string, string[])](EficazFramework.Extensions/TextExtensions/ToTitleCase(thisstring,string[]).md 'EficazFramework.Extensions.TextExtensions.ToTitleCase(this string, string[])') | Formata a string para o padrão de títulos.<br/>Ex: 'eficaz contabilidade' para 'Eficaz Contabilidade'.<br/>Nota: Permite uso de array de caracteres a serem identificados como separador de nomes. Ideal para ausência de espaços.<br/>Ex: splitChars = New String() {";", ":", "/"} |
