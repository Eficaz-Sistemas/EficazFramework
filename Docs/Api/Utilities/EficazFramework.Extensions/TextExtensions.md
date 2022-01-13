#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## TextExtensions Class

```csharp
public static class TextExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextExtensions

| Methods | |
| :--- | :--- |
| [FormataIE(this string, string)](EficazFramework.Extensions/TextExtensions/FormataIE(thisstring,string).md 'EficazFramework.Extensions.TextExtensions.FormataIE(this string, string)') | |
| [FormatCEP(this string)](EficazFramework.Extensions/TextExtensions/FormatCEP(thisstring).md 'EficazFramework.Extensions.TextExtensions.FormatCEP(this string)') | Insere a máscara de formatação a um CEP. |
| [FormatCNPJ(this string)](EficazFramework.Extensions/TextExtensions/FormatCNPJ(thisstring).md 'EficazFramework.Extensions.TextExtensions.FormatCNPJ(this string)') | |
| [FormatCPF(this string)](EficazFramework.Extensions/TextExtensions/FormatCPF(thisstring).md 'EficazFramework.Extensions.TextExtensions.FormatCPF(this string)') | |
| [FormatFone(this string)](EficazFramework.Extensions/TextExtensions/FormatFone(thisstring).md 'EficazFramework.Extensions.TextExtensions.FormatFone(this string)') | |
| [FormatIE(this string, string)](EficazFramework.Extensions/TextExtensions/FormatIE(thisstring,string).md 'EficazFramework.Extensions.TextExtensions.FormatIE(this string, string)') | Insere a máscara de formatação em uma Inscrição Estadual |
| [FormatLogradouro(this string, bool)](EficazFramework.Extensions/TextExtensions/FormatLogradouro(thisstring,bool).md 'EficazFramework.Extensions.TextExtensions.FormatLogradouro(this string, bool)') | Formata um logradouro em Tipo e Nome em array de string.<br/>Ex: "Rua Sete de Setembro" em: "Rua" "Sete de Setembro". |
| [FormatPIS(this string)](EficazFramework.Extensions/TextExtensions/FormatPIS(thisstring).md 'EficazFramework.Extensions.TextExtensions.FormatPIS(this string)') | |
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
| [ToUrlSlug(this string)](EficazFramework.Extensions/TextExtensions/ToUrlSlug(thisstring).md 'EficazFramework.Extensions.TextExtensions.ToUrlSlug(this string)') | Converte a sequência de caracteres desejada em formato de URL Slug |
| [Validate_AC(this string)](EficazFramework.Extensions/TextExtensions/Validate_AC(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_AC(this string)') | |
| [Validate_AL(this string)](EficazFramework.Extensions/TextExtensions/Validate_AL(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_AL(this string)') | |
| [Validate_AM(this string)](EficazFramework.Extensions/TextExtensions/Validate_AM(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_AM(this string)') | |
| [Validate_AP(this string)](EficazFramework.Extensions/TextExtensions/Validate_AP(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_AP(this string)') | |
| [Validate_BA(this string)](EficazFramework.Extensions/TextExtensions/Validate_BA(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_BA(this string)') | |
| [Validate_CE(this string)](EficazFramework.Extensions/TextExtensions/Validate_CE(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_CE(this string)') | |
| [Validate_DF(this string)](EficazFramework.Extensions/TextExtensions/Validate_DF(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_DF(this string)') | |
| [Validate_ES(this string)](EficazFramework.Extensions/TextExtensions/Validate_ES(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_ES(this string)') | |
| [Validate_GO(this string)](EficazFramework.Extensions/TextExtensions/Validate_GO(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_GO(this string)') | |
| [Validate_MA(this string)](EficazFramework.Extensions/TextExtensions/Validate_MA(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_MA(this string)') | |
| [Validate_MG(this string)](EficazFramework.Extensions/TextExtensions/Validate_MG(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_MG(this string)') | |
| [Validate_MS(this string)](EficazFramework.Extensions/TextExtensions/Validate_MS(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_MS(this string)') | |
| [Validate_MT(this string)](EficazFramework.Extensions/TextExtensions/Validate_MT(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_MT(this string)') | |
| [Validate_PA(this string)](EficazFramework.Extensions/TextExtensions/Validate_PA(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_PA(this string)') | |
| [Validate_PB(this string)](EficazFramework.Extensions/TextExtensions/Validate_PB(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_PB(this string)') | |
| [Validate_PE(this string)](EficazFramework.Extensions/TextExtensions/Validate_PE(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_PE(this string)') | |
| [Validate_PI(this string)](EficazFramework.Extensions/TextExtensions/Validate_PI(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_PI(this string)') | |
| [Validate_PR(this string)](EficazFramework.Extensions/TextExtensions/Validate_PR(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_PR(this string)') | |
| [Validate_RJ(this string)](EficazFramework.Extensions/TextExtensions/Validate_RJ(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_RJ(this string)') | |
| [Validate_RN(this string)](EficazFramework.Extensions/TextExtensions/Validate_RN(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_RN(this string)') | |
| [Validate_RO(this string)](EficazFramework.Extensions/TextExtensions/Validate_RO(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_RO(this string)') | |
| [Validate_RR(this string)](EficazFramework.Extensions/TextExtensions/Validate_RR(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_RR(this string)') | |
| [Validate_RS(this string)](EficazFramework.Extensions/TextExtensions/Validate_RS(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_RS(this string)') | |
| [Validate_SC(this string)](EficazFramework.Extensions/TextExtensions/Validate_SC(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_SC(this string)') | |
| [Validate_SE(this string)](EficazFramework.Extensions/TextExtensions/Validate_SE(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_SE(this string)') | |
| [Validate_SP(this string)](EficazFramework.Extensions/TextExtensions/Validate_SP(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_SP(this string)') | |
| [Validate_TO(this string)](EficazFramework.Extensions/TextExtensions/Validate_TO(thisstring).md 'EficazFramework.Extensions.TextExtensions.Validate_TO(this string)') | |
