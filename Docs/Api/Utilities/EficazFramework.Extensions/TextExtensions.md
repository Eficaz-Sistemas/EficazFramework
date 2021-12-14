#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## TextExtensions Class

```csharp
public static class TextExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextExtensions
### Methods

<a name='EficazFramework.Extensions.TextExtensions.FormatCEP(thisstring)'></a>

## TextExtensions.FormatCEP(this string) Method

Insere a máscara de formatação a um CEP.

```csharp
public static string FormatCEP(this string @base);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.FormatCEP(thisstring).base'></a>

`base` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O CEP a ser formatado.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.TextExtensions.FormatIE(thisstring,string)'></a>

## TextExtensions.FormatIE(this string, string) Method

Insere a máscara de formatação em uma Inscrição Estadual

```csharp
public static string FormatIE(this string vIE, string vUF);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.FormatIE(thisstring,string).vIE'></a>

`vIE` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O documento a ser formatado.

<a name='EficazFramework.Extensions.TextExtensions.FormatIE(thisstring,string).vUF'></a>

`vUF` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.TextExtensions.FormatLogradouro(thisstring,bool)'></a>

## TextExtensions.FormatLogradouro(this string, bool) Method

Formata um logradouro em Tipo e Nome em array de string.  
Ex: "Rua Sete de Setembro" em: "Rua" "Sete de Setembro".

```csharp
public static string[] FormatLogradouro(this string logradouro, bool ToTitleCase=true);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.FormatLogradouro(thisstring,bool).logradouro'></a>

`logradouro` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O endereço a ser formatado.

<a name='EficazFramework.Extensions.TextExtensions.FormatLogradouro(thisstring,bool).ToTitleCase'></a>

`ToTitleCase` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
String

### Remarks

<a name='EficazFramework.Extensions.TextExtensions.FormatRFBDocument(thisstring)'></a>

## TextExtensions.FormatRFBDocument(this string) Method

Insere a máscara de formatação em um CNPJ ou CPF.

```csharp
public static string FormatRFBDocument(this string documento);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.FormatRFBDocument(thisstring).documento'></a>

`documento` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O documento a ser formatado.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.TextExtensions.GetClearText(thisstring)'></a>

## TextExtensions.GetClearText(this string) Method

Remove todos os caracteres especiais de uma string.

```csharp
public static string GetClearText(this string texto);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.GetClearText(thisstring).texto'></a>

`texto` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string a ser analisada.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.TextExtensions.IsValidCNPJ(thisstring)'></a>

## TextExtensions.IsValidCNPJ(this string) Method

Verifica a veracidade do número de CNPJ informado.

```csharp
public static bool IsValidCNPJ(this string CNPJ);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.IsValidCNPJ(thisstring).CNPJ'></a>

`CNPJ` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O CNPJ a ser analisado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean

### Remarks
Antes de utilizar este método, faz-se necessário remover a máscara do número.

<a name='EficazFramework.Extensions.TextExtensions.IsValidCPF(thisstring)'></a>

## TextExtensions.IsValidCPF(this string) Method

Verifica a veracidade do número de CPF informado.

```csharp
public static bool IsValidCPF(this string CPF);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.IsValidCPF(thisstring).CPF'></a>

`CPF` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O CPF a ser analisado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean

### Remarks
Antes de utilizar este método, faz-se necessário remover a máscara do número.

<a name='EficazFramework.Extensions.TextExtensions.IsValidEmailAddress(thisstring)'></a>

## TextExtensions.IsValidEmailAddress(this string) Method

Verifica se o endereço de e-mail informado é válido.

```csharp
public static bool IsValidEmailAddress(this string email);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.IsValidEmailAddress(thisstring).email'></a>

`email` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean

### Remarks

<a name='EficazFramework.Extensions.TextExtensions.IsValidInscricaoEstadual(thisstring,string)'></a>

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

<a name='EficazFramework.Extensions.TextExtensions.IsValidPISePASEP(thisstring)'></a>

## TextExtensions.IsValidPISePASEP(this string) Method

Verifica a veracidade do número de PIS/Pasep informado.

```csharp
public static bool IsValidPISePASEP(this string PIS);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.IsValidPISePASEP(thisstring).PIS'></a>

`PIS` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O PIS/Pasep a ser analisado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean

### Remarks
Antes de utilizar este método, faz-se necessário remover a máscara do número.

<a name='EficazFramework.Extensions.TextExtensions.Left(thisstring,int)'></a>

## TextExtensions.Left(this string, int) Method

Returns the left part of this string instance.

```csharp
public static string Left(this string input, int count);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.Left(thisstring,int).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.TextExtensions.Left(thisstring,int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of characters to return.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.TextExtensions.Mid(thisstring,int)'></a>

## TextExtensions.Mid(this string, int) Method

Returns the mid part of this string instance.

```csharp
public static string Mid(this string input, int start);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.Mid(thisstring,int).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.TextExtensions.Mid(thisstring,int).start'></a>

`start` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Character index to start return the midstring from.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Substring or empty string when start is outside range.

<a name='EficazFramework.Extensions.TextExtensions.Mid(thisstring,int,int)'></a>

## TextExtensions.Mid(this string, int, int) Method

Returns the mid part of this string instance.

```csharp
public static string Mid(this string input, int start, int count);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.Mid(thisstring,int,int).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.TextExtensions.Mid(thisstring,int,int).start'></a>

`start` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Starting character index number.

<a name='EficazFramework.Extensions.TextExtensions.Mid(thisstring,int,int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of characters to return.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Substring or empty string when out of range.

<a name='EficazFramework.Extensions.TextExtensions.RemoveTextMask(thisstring)'></a>

## TextExtensions.RemoveTextMask(this string) Method

Remove todos os caracteres de máscara (literais) de uma string.

```csharp
public static string RemoveTextMask(this string texto);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.RemoveTextMask(thisstring).texto'></a>

`texto` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string a ser analisada.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
String

### Remarks

<a name='EficazFramework.Extensions.TextExtensions.Right(thisstring,int)'></a>

## TextExtensions.Right(this string, int) Method

Returns the right part of the string instance.

```csharp
public static string Right(this string input, int count);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.Right(thisstring,int).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.TextExtensions.Right(thisstring,int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of characters to return.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.TextExtensions.SplitByLength(thisstring,int)'></a>

## TextExtensions.SplitByLength(this string, int) Method

Divide uma string em numa lista de substrings, conforme a quantidade de caracteres desejada

```csharp
public static System.Collections.Generic.IEnumerable<string> SplitByLength(this string texto, int tamanho);
```
#### Parameters

<a name='EficazFramework.Extensions.TextExtensions.SplitByLength(thisstring,int).texto'></a>

`texto` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A string a ser analisada.

<a name='EficazFramework.Extensions.TextExtensions.SplitByLength(thisstring,int).tamanho'></a>

`tamanho` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

quantidade de caracteres desejada

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='EficazFramework.Extensions.TextExtensions.ToTitleCase(thisstring,string[])'></a>

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