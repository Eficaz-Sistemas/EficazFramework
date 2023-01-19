    using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EficazFramework.Extensions;

public static partial class TextExtensions
{
#if NET7_0_OR_GREATER
    [GeneratedRegex("[á|à|ä|â|ã]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexA();

    [GeneratedRegex("[é|è|ë|ê]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexE();

    [GeneratedRegex("[í|ì|ï|î]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexI();

    [GeneratedRegex("[ó|ò|ö|ô|õ]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexO();

    [GeneratedRegex("[ú|ù|ü|û]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexU();

    [GeneratedRegex("[Á|À|Ä|Â|Ã]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexAUpperCase();

    [GeneratedRegex("[É|È|Ë|Ê]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexEUpperCase();

    [GeneratedRegex("[Í|Ì|Ï|Î]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexIUpperCase();

    [GeneratedRegex("[Ó|Ò|Ö|Ô|Õ]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexOUpperCase();

    [GeneratedRegex("[Ú|Ù|Ü|Û]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexUUpperCase();

    [GeneratedRegex("[ç]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexC();

    [GeneratedRegex("[Ç]", RegexOptions.CultureInvariant)]
    private static partial Regex RegexCUpperCase();

    [GeneratedRegex(@"(?:[^a-za-zA-Z0-9]|(?<=['\'])s)", RegexOptions.CultureInvariant)]
    private static partial Regex RegexMask();

#endif

    /// <summary>
    /// Returns the left part of this string instance.
    /// </summary>
    /// <param name="count">Number of characters to return.</param>
    public static string Left(this string input, int count)
    {
        return input[..Math.Min(input.Length, count)];
    }

    /// <summary>
    /// Returns the right part of the string instance.
    /// </summary>
    /// <param name="count">Number of characters to return.</param>
    public static string Right(this string input, int count)
    {
        return input.Substring(Math.Max(input.Length - count, 0), Math.Min(count, input.Length));
    }

    /// <summary>
    /// Returns the mid part of this string instance.
    /// </summary>
    /// <param name="start">Character index to start return the midstring from.</param>
    /// <returns>Substring or empty string when start is outside range.</returns>
    public static string Mid(this string input, int start)
    {
        return input[Math.Min(start, input.Length)..];
    }

    /// <summary>
    /// Returns the mid part of this string instance.
    /// </summary>
    /// <param name="start">Starting character index number.</param>
    /// <param name="count">Number of characters to return.</param>
    /// <returns>Substring or empty string when out of range.</returns>
    public static string Mid(this string input, int start, int count)
    {
        return input.Substring(Math.Min(start, input.Length), Math.Min(count, Math.Max(input.Length - start, 0)));
    }

    /// <summary>
    /// Insere a máscara de formatação a um CEP.
    /// </summary>
    /// <param name="base">O CEP a ser formatado.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string FormatCEP(this string @base)
    {
        @base = @base.Replace("-", string.Empty).Replace(".", string.Empty).Replace(",", string.Empty).Replace("_", string.Empty);
        return @base.Length switch
        {
            4 => $"{@base[..1]}-{@base.Substring(1, 3)}",
            5 => $"{@base[..2]}-{@base.Substring(2, 3)}",
            6 => $"{@base[..3]}-{@base.Substring(3, 3)}",
            7 => $"{@base[..1]}.{@base.Substring(1, 3)}-{@base.Substring(4, 3)}",
            8 => $"{@base[..2]}.{@base.Substring(2, 3)}-{@base.Substring(5, 3)}",
            9 => $"{@base[..3]}.{@base.Substring(3, 3)}-{@base.Substring(6, 3)}",
            10 => $"{@base[..1]}.{@base.Substring(1, 3)}.{@base.Substring(4, 3)}-{@base.Substring(7, 3)}",
            11 => $"{@base[..2]}.{@base.Substring(2, 3)}.{@base.Substring(5, 3)}-{@base.Substring(8, 3)}",
            12 => $"{@base[..3]}.{@base.Substring(3, 3)}.{@base.Substring(6, 3)}-{@base.Substring(9, 3)}",
            _ => @base
        };
    }

    public static string FormatFone(this string @base)
    {
        @base = @base.RemoveTextMask();
        if (long.TryParse(@base, out long number) == false)
            return @base;

        switch (@base.Length)
        {
            case 7: // 544-1511
                {
                    return string.Format(@"{0:000\-0000}", number);
                }

            case 8: // 3544-1511
                {
                    return string.Format(@"{0:0000\-0000}", number);
                }

            case 9: // 99971-2741
                {
                    return string.Format(@"{0:00000\-0000}", number);
                }

            case 10: // (35) 3544-1511
                {
                    return string.Format(@"{0:\(00\) 0000\-0000}", number);
                }

            case 11: // 0800 123 4567 ou (16) 99971-2741
                {
                    string four_chars = @base[..4];
                    if (four_chars == "0800" | four_chars == "0300" | four_chars == "3030")
                        return string.Format("{0:0000 000 0000}", number);
                    else
                        return string.Format(@"{0:\(00\) 00000\-0000}", number);
                }

            case 12: // +55 12 3456-7890
                {
                    return string.Format(@"{0:\+00 \(00\) 0000\-0000}", number);
                }

            case 13: // +55 12 34567-8900
                {
                    return string.Format(@"{0:\+00\ \(00\) 00000\-0000}", number);
                }

            default:
                {
                    return @base;
                }
        }

    }

    /// <summary>
    /// Formata um logradouro em Tipo e Nome em array de string.
    /// Ex: "Rua Sete de Setembro" em: "Rua" "Sete de Setembro".
    /// </summary>
    /// <param name="logradouro">O endereço a ser formatado.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string[] FormatLogradouro(this string logradouro, bool ToTitleCase = true)
    {
        var result = new string[2];
        string _palavra = "";
        foreach (char letra in logradouro)
        {
            _palavra += letra;
            if (LogradouroExtensions.ReplacementDictionary.ContainsKey(_palavra.ToLower()))
            {
                result[0] = LogradouroExtensions.ReplacementDictionary[_palavra.ToLower()];
                if (logradouro[_palavra.Length..].Length > 45)
                {
                    result[1] = logradouro[(_palavra.Length + 1)..45].Trim();
                }
                else
                {
                    result[1] = logradouro[(_palavra.Length + 1)..].Trim();
                }
            }
        }

        if (result[0] is null)
        {
            result[0] = "Rua";
            if (logradouro.Length > 45)
                result[1] = logradouro[..Math.Min(45, logradouro.Length)].Trim();
            else
                result[1] = logradouro.Trim();
        }

        if (result[0] != null)
        {
            if (result[0].Length > 15)
                result[0] = result[0][..Math.Min(14, result[1].Length)];

            if (ToTitleCase == true)
                result[0] = result[0].ToTitleCase();
        }

        if (result[1] != null)
        {
            if (ToTitleCase == true)
                result[1] = result[1].ToTitleCase();
        }

        return result;
    }


    /// <summary>
    /// Insere a máscara de formatação em um CNPJ ou CPF.
    /// </summary>
    /// <param name="documento">O documento a ser formatado.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string? FormatRFBDocument(this string documento)
    {
        if (documento is null)
        {
            return documento;
        }

        if (documento.Contains('.') | documento.Contains('-'))
            return documento;

        switch (documento.Trim().Length)
        {
            case 14:
                {
                    return documento.FormatCNPJ();
                }

            case 11:
                {
                    return documento.FormatCPF();
                }

            default:
                {
                    return documento;
                }
        }
    }

    private static string FormatCNPJ(this string documento) =>
        $"{documento[..2]}.{documento.Substring(2, 3)}.{documento.Substring(5, 3)}/{documento.Substring(8, 4)}-{documento.Substring(12, 2)}";

    public static string FormatPIS(this string documento) =>
        Convert.ToDecimal(documento).ToString(@"#000\.00000\.00\-0");

    private static string FormatCPF(this string documento) =>
        documento[..3] + "." + documento.Substring(3, 3) + "." + documento.Substring(6, 3) + "-" + documento.Substring(9, 2);

    /// <summary>
    /// Insere a máscara de formatação em uma Inscrição Estadual
    /// </summary>
    /// <param name="vIE">O documento a ser formatado.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string FormatIE(this string vIE, string vUF)
    {
        if (vIE.ToLower() == "isento" | vIE.ToLower() == "isenta")
            return vIE;
        if (string.IsNullOrEmpty(vIE) | string.IsNullOrWhiteSpace(vIE) | string.IsNullOrEmpty(vUF) | string.IsNullOrWhiteSpace(vUF))
            return vIE;
        if (long.TryParse(vIE, out _) == false)
            return vIE;
        return vIE.FormataIE(vUF);
    }

    private static string FormataIE(this string IE, string UF)
    {
        switch (UF ?? "")
        {
            case "AC":
                {
                    return string.Format(@"{0:00\.000\.000\/000\-00}", Conversions.ToLong(IE)); // (IE, "@@.@@@.@@@/@@@-@@")
                }

            case "AL":
                {
                    return string.Format("{0:000000000}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

            case "AP":
                {
                    return string.Format("{0:000000000}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

            case "AM":
                {
                    return string.Format(@"{0:00\.000\.000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@@-@")

            case "BA":
                {
                    return string.Format(@"{0:000000\-00}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@-@@")

            case "CE":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@")

            case "DF":
                {
                    return string.Format(@"{0:00000000000\-00}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@@@-@@")

            case "ES":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

            case "GO":
                {
                    return string.Format(@"{0:00\.000\.000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@@-@")

            case "MA":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

            case "MT":
                {
                    return string.Format(@"{0:0000000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@@-@")

            case "MS":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

            case "MG":
                {
                    return string.Format(@"{0:000\.000000\.00\-00}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@.@@@@@@.@@-@@")

            case "PA":
                {
                    return string.Format(@"{0:00\.000000\.0\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@.@@@@@@.@-@")

            case "PB":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@")

            case "PR":
                {
                    return string.Format(@"{0:000\.00000\-00}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@@")

            case "PE":
                {
                    return string.Format(@"{0:00\.0\.000\.0000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@.@.@@@.@@@@@@@-@")

            case "PI":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@")

            case "RJ":
                {
                    return string.Format(@"{0:00\.000\.00\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@-@")

            case "RN":
                {
                    return string.Format(@"{0:00\.000\.000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@.@@@.@@@-@")

            case "RS":
                {
                    return string.Format(@"{0:000\/0000000}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@/@@@@@@@")

            case "RO":
                {
                    return string.Format(@"{0:000\.00000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@.@@@@@-@")

            case "RR":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@-@")

            case "SC":
                {
                    return string.Format(@"{0:000\.000\.000}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@.@@@.@@@")

            case "SP":
                {
                    return string.Format(@"{0:000\.000\.000\.000}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@.@@@.@@@.@@@")

            case "SE":
                {
                    return string.Format(@"{0:00000000\-0}", Conversions.ToLong(IE));
                }
            // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@-@")

            case "TO":
                {
                    // txtIE.Text = Format(txtIE.Text, "@@@@@@@@@@@")

                    return string.Format(@"{0:0000000000\-0}", Conversions.ToLong(IE));
                }

            default:
                {
                    return IE; // "ISENTO"
                }
        }
    }

    /// <summary>
    /// Remove todos os caracteres especiais de uma string.
    /// </summary>
    /// <param name="texto">A string a ser analisada.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string GetClearText(this string texto)
    {
#if NET7_0_OR_GREATER
        texto = RegexA().Replace(texto, "a");
        texto = RegexE().Replace(texto, "e");
        texto = RegexI().Replace(texto, "i");
        texto = RegexO().Replace(texto, "o");
        texto = RegexU().Replace(texto, "u");
        texto = RegexC().Replace(texto, "c");
        texto = RegexAUpperCase().Replace(texto, "A");
        texto = RegexEUpperCase().Replace(texto, "E");
        texto = RegexIUpperCase().Replace(texto, "I");
        texto = RegexOUpperCase().Replace(texto, "O");
        texto = RegexUUpperCase().Replace(texto, "U");
        texto = RegexCUpperCase().Replace(texto, "C");
#else
        texto = Regex.Replace(texto, "[á|à|ä|â|ã]", "a", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[é|è|ë|ê]", "e", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[í|ì|ï|î]", "i", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[ó|ò|ö|ô|õ]", "o", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[ú|ù|ü|û]", "u", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[Á|À|Ä|Â|Ã]", "A", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[É|È|Ë|Ê]", "E", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[Í|Ì|Ï|Î]", "I", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[Ó|Ò|Ö|Ô|Õ]", "O", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[Ú|Ù|Ü|Û]", "U", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[ç]", "c", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        texto = Regex.Replace(texto, "[Ç]", "C", RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
#endif
        return texto;
    }

    /// <summary>
    /// Remove todos os caracteres de máscara (literais) de uma string.
    /// </summary>
    /// <param name="texto">A string a ser analisada.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string RemoveTextMask(this string texto)
    {
#if NET7_0_OR_GREATER
        texto = RegexMask().Replace(texto, string.Empty);
#else
        texto = Regex.Replace(texto, @"(?:[^a-za-zA-Z0-9]|(?<=['\'])s)", string.Empty, RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
#endif
        return texto.Replace(" ", "");
    }

    /// <summary>
    /// Divide uma string em numa lista de substrings, conforme a quantidade de caracteres desejada
    /// </summary>
    /// <param name="texto">A string a ser analisada.</param>
    /// <param name="tamanho">quantidade de caracteres desejada</param>
    /// <returns></returns>
    public static IEnumerable<string> SplitByLength(this string texto, int tamanho) =>
        Enumerable.Range(0, Conversions.ToInteger(Math.Ceiling(texto.Length / (double)tamanho))).Select(i => texto.Substring(i * tamanho, Math.Min(texto.Length - i * tamanho, tamanho)));

    /// <summary>
    /// Converte a sequência de caracteres desejada em formato de URL Slug
    /// </summary>
    /// <returns></returns>
    public static string ToUrlSlug(this string value)
    {
        value = (value ?? "").GetClearText().ToLowerInvariant();
        value = Regex.Replace(value, @"[^A-Za-z0-9\s-]", "");
        value = Regex.Replace(value, @"\s+", " ").Trim();
        value = Regex.Replace(value, @"\s", "-");
        return value;
    }

    /// <summary>
    /// Verifica se o endereço de e-mail informado é válido.
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Boolean</returns>
    /// <remarks></remarks>
    public static bool IsValidEmailAddress(this string email)
    {
        var r = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        return r.IsMatch(email);
    }

    /// <summary>
    /// Formata a string para o padrão de títulos.
    /// Ex: 'eficaz contabilidade' para 'Eficaz Contabilidade'.
    /// Nota: Permite uso de array de caracteres a serem identificados como separador de nomes. Ideal para ausência de espaços.
    /// Ex: splitChars = New String() {";", ":", "/"}
    /// </summary>
    /// <param name="name"></param>
    /// <param name="splitChars"></param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string? ToTitleCase(this string? name, string[]? splitChars = null)
    {
        if (name is null)
            return name;

        name = name.Trim();
        splitChars ??= new string[] { "" };

        var array = name.ToLower().ToCharArray();
        if (array.Length > 1)
        {
            if (char.IsLower(array[0]))
                array[0] = char.ToUpper(array[0]);

            for (int i = 1, loopTo = array.Length; i <= loopTo; i++)
            {
                if (Conversions.ToString(array[i - 1]) == " " | splitChars.Contains(Conversions.ToString(array[i - 1])))
                    array[i] = char.ToUpper(array[i]);
            }

            return new string(array);
        }
        else
        {
            return name.ToUpper();
        }
    }


    public static string NullToEmpty(this string text) =>
        text ?? string.Empty;

    /// <summary>
    /// Verifica a veracidade do número de CNPJ informado.
    /// </summary>
    /// <param name="CNPJ">O CNPJ a ser analisado.</param>
    /// <returns>Boolean</returns>
    /// <remarks>Antes de utilizar este método, faz-se necessário remover a máscara do número.</remarks>
    public static bool IsValidCNPJ(this string CNPJ)
    {
        try
        {
            // Declara as variáveis
            var digit = new int[13];
            var verify = new int[13];
            int st_value, nd_value;
            int[] calc = new int[13];
            int calc_t, resto;

            // CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR:
            // define os valores fixos para cálculo do 1º dígito verificador
            verify[0] = 5;
            verify[1] = 4;
            verify[2] = 3;
            verify[3] = 2;
            verify[4] = 9;
            verify[5] = 8;
            verify[6] = 7;
            verify[7] = 6;
            verify[8] = 5;
            verify[9] = 4;
            verify[10] = 3;
            verify[11] = 2;

            // obtém os valores de cada dígito do cnpj informado pelo usuário
            for (int ic = 0; ic <= 11; ic++)
                digit[ic] = Conversions.ToInteger(CNPJ.Substring(ic, 1));

            // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
            int i;
            calc_t = 0;
            for (i = 0; i <= 11; i++)
            {
                calc[i] = verify[i] * digit[i];
                calc_t += calc[i];
            }

            if (calc_t == 0)
                return false;

            // realiza a divisão do somatório por 11 e captura o resto da divisão
            resto = calc_t % 11;

            // analisa o resto da divisão e apura o valor do primeiro dígito verificador
            if (resto < 2)
                st_value = 0;
            else
                st_value = 11 - resto;

            // CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR:
            // nessa etapa os numeros da tabela "verify" foram modificados, além da 
            // adição de mais um algarismo, para ser multiplicado com o valor do primeiro
            // dígito verificador encontrado
            // define os valores fixos para cálculo do 2º dígito verificador
            verify[0] = 6;
            verify[1] = 5;
            verify[2] = 4;
            verify[3] = 3;
            verify[4] = 2;
            verify[5] = 9;
            verify[6] = 8;
            verify[7] = 7;
            verify[8] = 6;
            verify[9] = 5;
            verify[10] = 4;
            verify[11] = 3;
            verify[12] = 2;
            digit[12] = st_value;

            // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
            int j;
            calc_t = 0;
            for (j = 0; j <= 12; j++)
            {
                calc[j] = verify[j] * digit[j];
                calc_t += calc[j];
            }

            // realiza a divisão do somatório por 11 e captura o resto da divisão
            resto = calc_t % 11;

            // analisa o resto da divisão e apura o valor do segundo dígito verificador
            if (resto < 2)
                nd_value = 0;
            else
                nd_value = 11 - resto;

            // compara os dígitos apurados com os informados pelo usuário
            if (st_value == Conversions.ToInteger(CNPJ.Substring(12, 1)) & nd_value == Conversions.ToInteger(CNPJ.Substring(13, 1)))
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica a veracidade do número de CPF informado.
    /// </summary>
    /// <param name="CPF">O CPF a ser analisado.</param>
    /// <returns>Boolean</returns>
    /// <remarks>Antes de utilizar este método, faz-se necessário remover a máscara do número.</remarks>
    public static bool IsValidCPF(this string CPF)
    {
        try
        {
            // Declara as variáveis
            var digit = new int[10];
            var verify = new int[10];
            int st_value, nd_value;
            int[] calc = new int[10];
            int calc_t, resto;

            // CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR:
            // define os valores fixos para cálculo do 1º dígito verificador
            verify[0] = 10;
            verify[1] = 9;
            verify[2] = 8;
            verify[3] = 7;
            verify[4] = 6;
            verify[5] = 5;
            verify[6] = 4;
            verify[7] = 3;
            verify[8] = 2;

            // obtém os valores de cada dígito do cnpj informado pelo usuário
            for (int ic = 0; ic <= 8; ic++)
                digit[ic] = Conversions.ToInteger(CPF.Substring(ic, 1));

            // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
            int i;
            calc_t = 0;
            for (i = 0; i <= 8; i++)
            {
                calc[i] = verify[i] * digit[i];
                calc_t += calc[i];
            }

            if (calc_t == 0)
                return false;

            // realiza a divisão do somatório por 11 e captura o resto da divisão
            resto = calc_t % 11;

            // analisa o resto da divisão e apura o valor do primeiro dígito verificador
            if (resto < 2)
                st_value = 0;
            else
                st_value = 11 - resto;

            // CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR:
            // nessa etapa os numeros da tabela "verify" foram modificados, além da 
            // adição de mais um algarismo, para ser multiplicado com o valor do primeiro
            // dígito verificador encontrado
            // define os valores fixos para cálculo do 2º dígito verificador
            verify[0] = 11;
            verify[1] = 10;
            verify[2] = 9;
            verify[3] = 8;
            verify[4] = 7;
            verify[5] = 6;
            verify[6] = 5;
            verify[7] = 4;
            verify[8] = 3;
            verify[9] = 2;
            digit[9] = st_value;

            // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
            int j;
            calc_t = 0;
            for (j = 0; j <= 9; j++)
            {
                calc[j] = verify[j] * digit[j];
                calc_t += calc[j];
            }

            // realiza a divisão do somatório por 11 e captura o resto da divisão
            resto = calc_t % 11;

            // analisa o resto da divisão e apura o valor do segundo dígito verificador
            if (resto < 2)
                nd_value = 0;
            else
                nd_value = 11 - resto;

            // compara os dígitos apurados com os informados pelo usuário
            if (st_value == Conversions.ToInteger(CPF.Substring(9, 1)) & nd_value == Conversions.ToInteger(CPF.Substring(10, 1)))
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica a veracidade do número de PIS/Pasep informado.
    /// </summary>
    /// <param name="PIS">O PIS/Pasep a ser analisado.</param>
    /// <returns>Boolean</returns>
    /// <remarks>Antes de utilizar este método, faz-se necessário remover a máscara do número.</remarks>
    public static bool IsValidPISePASEP(this string PIS)
    {
        try
        {
            // Declara as variáveis
            var digit = new int[10];
            var verify = new int[10];
            int value;
            int[] calc = new int[10];
            int calc_t, resto;

            // define os valores fixos para cálculo do dígito verificador
            verify[0] = 3;
            verify[1] = 2;
            verify[2] = 9;
            verify[3] = 8;
            verify[4] = 7;
            verify[5] = 6;
            verify[6] = 5;
            verify[7] = 4;
            verify[8] = 3;
            verify[9] = 2;

            // obtém os valores de cada dígito do pis informado pelo usuário
            for (int ic = 0; ic <= 9; ic++)
                digit[ic] = Conversions.ToInteger(PIS.Substring(ic, 1));

            // calcula a multiplicação das colunas da matriz e faz o somatório dos resultados
            int i;
            calc_t = 0;
            for (i = 0; i <= 9; i++)
            {
                calc[i] = verify[i] * digit[i];
                calc_t += calc[i];
            }

            // realiza a divisão do somatório por 11 e captura o resto da divisão
            resto = calc_t % 11;

            // analisa o resto da divisão e apura o valor do dígito verificador
            if (resto != 0)
                value = 11 - resto;
            else
                value = 0;

            // compara os dígitos apurados com os informados pelo usuário
            if (value == Conversions.ToInteger(PIS.Substring(10, 1)))
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Verifica a veracidade do número de Inscrição Estadual informado.
    /// </summary>
    /// <param name="IE">A Inscrição Estadual a ser analisada.</param>
    /// <param name="UF">A unidade de federação da Inscrição Estadual. As seguinte UF's ainda não estão funcionando: DF, PE e RS</param>
    /// <returns>Boolean</returns>
    /// <remarks></remarks>
    public static bool IsValidInscricaoEstadual(this string IE, string UF)
    {
        if (string.IsNullOrEmpty(IE) || (IE ?? "").ToUpper().Contains("ISENTO"))
            return true;

        if (string.IsNullOrEmpty(UF))
            return false;

        if (UF == "EX")
            return true;

        UF = UF.ToUpper();
        IE = (IE ?? "").ToUpper();
        // Formata os dígitos da inscrição, deixando apenas números
        IE = IE.Replace(".", string.Empty);
        IE = IE.Replace(",", string.Empty);
        IE = IE.Replace("-", string.Empty);
        IE = IE.Replace("_", string.Empty);
        IE = IE.Replace("/", string.Empty);
        IE = IE.Replace(@"\", string.Empty);
        IE = IE.Replace("+", string.Empty);
        IE = IE.Replace("=", string.Empty);
        IE = IE.Replace("@", string.Empty);
        IE = IE.Replace("#", string.Empty);
        IE = IE.Replace("$", string.Empty);
        IE = IE.Replace("%", string.Empty);
        IE = IE.Replace("&", string.Empty);
        IE = IE.Replace("*", string.Empty);
        IE = IE.Replace("(", string.Empty);
        IE = IE.Replace(")", string.Empty);

        // Verifica a UF
        return (UF ?? "") switch
        {
            "AC" => IE.Validate_AC(),
            "AL" => IE.Validate_AL(),
            "AM" => IE.Validate_AM(),
            "AP" => IE.Validate_AP(),
            "BA" => IE.Validate_BA(),
            "CE" => IE.Validate_CE(),
            "DF" => IE.Validate_DF(),
            "ES" => IE.Validate_ES(),
            "GO" => IE.Validate_GO(),
            "MA" => IE.Validate_MA(),
            "MG" => IE.Validate_MG(),
            "MS" => IE.Validate_MS(),
            "MT" => IE.Validate_MT(),
            "PA" => IE.Validate_PA(),
            "PB" => IE.Validate_PB(),
            "PE" => IE.Validate_PE(),
            "PI" => IE.Validate_PI(),
            "PR" => IE.Validate_PR(),
            "RJ" => IE.Validate_RJ(),
            "RN" => IE.Validate_RN(),
            "RS" => IE.Validate_RS(),
            "RO" => IE.Validate_RO(),
            "RR" => IE.Validate_RR(),
            "SC" => IE.Validate_SC(),
            "SE" => IE.Validate_SE(),
            "SP" => IE.Validate_SP(),
            "TO" => IE.Validate_TO(),
            _ => false
        };
    }


    private static bool Validate_AC(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 13)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 13)
            {
                // ## Verifica se os dois primeiros dígitos valem 01 ##
                if (IE[..2] != "01")
                {
                    return false;
                }
                else
                {
                    var xdigito = new int[13];
                    int digito1;
                    int digito2;

                    // ## CÁLCULO DO PRIMEIRO DÍGITO ##
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 4;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 3;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 2;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 9;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 8;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 7;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 6;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 5;
                    xdigito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 4;
                    xdigito[9] = Conversions.ToInteger(IE.Substring(9, 1)) * 3;
                    xdigito[10] = Conversions.ToInteger(IE.Substring(10, 1)) * 2;
                    int totalD1 = 0;
                    for (int i = 0; i <= 10; i++)
                        totalD1 += xdigito[i];
                    int resto1 = totalD1 % 11;
                    digito1 = 11 - resto1;
                    if (digito1 == 10 | digito1 == 11)
                    {
                        digito1 = 0;
                    }


                    // ## CÁLCULO DO SEGUNDO DÍGITO ##
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 5;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 4;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 3;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 2;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 9;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 8;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 7;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 6;
                    xdigito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 5;
                    xdigito[9] = Conversions.ToInteger(IE.Substring(9, 1)) * 4;
                    xdigito[10] = Conversions.ToInteger(IE.Substring(10, 1)) * 3;
                    xdigito[11] = digito1 * 2;
                    int totalD2 = 0;
                    for (int i = 0; i <= 11; i++)
                        totalD2 += xdigito[i];
                    int resto2 = totalD2 % 11;
                    digito2 = 11 - resto2;
                    if (digito2 == 10 | digito2 == 11)
                    {
                        digito2 = 0;
                    }

                    // ## VALIDAÇÃO DOS DÍGITOS ##
                    int dinf1 = Conversions.ToInteger(IE.Substring(11, 1));
                    int dinf2 = Conversions.ToInteger(IE.Substring(12, 1));
                    if (dinf1 == digito1 & dinf2 == digito2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_AL(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Trim().Length == 9)
            {
                // ## Verifica se os dois primeiros dígitos valem 24 (VAPoOO..) ##
                if (IE[..2] != "24")
                {
                    return false;
                }
                else
                {
                    var xdigito = new int[8];
                    int digito;

                    // ## CÁLCULO DO ÚNICO DÍGITO ##
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                    int totalD = 0;
                    for (int i = 0; i <= 7; i++)
                        totalD += xdigito[i];
                    int resto = totalD * 10 % 11;

                    // ## Avaliação do resto da divisão ##
                    if (resto < 10)
                    {
                        digito = resto; // 11 - resto 'fixed on 07/04/2014
                    }
                    else
                    {
                        digito = 0;
                    }


                    // ## VALIDAÇÃO DO DÍGITO ##
                    int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                    if (dinf1 == digito)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working.. bug fixes in 07/07/2014

    private static bool Validate_AM(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_AP(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 8)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9 | IE.Trim().Length == 8)
            {
                // ## Elimina o dígito inicial 0, caso informado ##
                if (Conversions.ToInteger(IE[..1]) == 0)
                {
                    IE = IE[1..];
                }

                // ## Verifica se o primeiro dígito é igual a 3 ##
                if (Conversions.ToInteger(IE[..1]) != 3)
                {
                    return false;
                }
                else
                {
                    var xdigito = new int[7];
                    var digito = default(int);
                    int p = default, d = default;

                    // Define as variáveis P e D
                    if (Conversions.ToInteger(IE[..7]) >= 3000001 & Conversions.ToInteger(IE[..7]) <= 3017000)
                    {
                        p = 5;
                        d = 0;
                    }
                    else if (Conversions.ToInteger(IE[..7]) >= 3017001 & Conversions.ToInteger(IE[..7]) <= 3019022)
                    {
                        p = 9;
                        d = 1;
                    }
                    else if (Conversions.ToInteger(IE[..7]) >= 3019023)
                    {
                        p = 0;
                        d = 0;
                    }


                    // ## CÁLCULO DO ÚNICO DÍGITO ##
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 8;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 7;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 6;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 5;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 4;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 3;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 2;
                    int totalD = 0;
                    for (int i = 0; i <= 6; i++)
                        totalD += xdigito[i];
                    int resto = (totalD + p) % 11;

                    // ## Avaliação do resto da divisão ##
                    int op = 11 - resto;
                    switch (op)
                    {
                        case var @case when @case < 10:
                            {
                                digito = op;
                                break;
                            }

                        case 10:
                            {
                                digito = 0;
                                break;
                            }

                        case 11:
                            {
                                digito = d;
                                break;
                            }
                    }


                    // ## VALIDAÇÃO DO DÍGITO ##
                    int dinf1 = Conversions.ToInteger(IE.Substring(7, 1));
                    if (dinf1 == digito)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_BA(this string IE)
    {
        if (IE.Length != 9 && IE.Length != 8)
        {
            return false;
        }

        string strBase = "";
        switch (IE.Length)
        {
            case 8:
                {
                    strBase = (IE.Trim() + "00000000")[..8];
                    break;
                }

            case 9:
                {
                    strBase = (IE.Trim() + "00000000")[..9];
                    break;
                }
        }

        int intSoma = 0;
        int intValor;
        int intPeso = 0;
        int intResto;
        string strDigito1 = "";
        string strDigito2 = "";
        string strBase2 = "";


        // #Region "Validação 8 dígitos"
        if (strBase.Length == 8)
        {
            if ("0123458".IndexOf(strBase[..1], 0, StringComparison.OrdinalIgnoreCase) + 1 > 0)
            {
                int intPos = 1;
                while (intPos <= 6)
                {
                    intValor = int.Parse(strBase.Substring(intPos - 1, 1));
                    if (intPos == 1)
                    {
                        intPeso = 7;
                    }

                    intSoma += intValor * intPeso;
                    intPeso -= 1;
                    intPos += 1;
                }

                intResto = intSoma % 10;
                strDigito2 = (intResto == 0 ? "0" : Convert.ToString(10 - intResto))[^1..];
                strBase2 = strBase[..7] + strDigito2;
                if ((strBase2 ?? "") == (IE ?? ""))
                {
                    intSoma = 0;
                    intPeso = 0;
                    int intPos2 = 1;
                    while (intPos2 <= 7)
                    {
                        intValor = int.Parse(strBase.Substring(intPos2 - 1, 1));
                        if (intPos2 == 7)
                        {
                            intValor = int.Parse(strBase.Substring(intPos2, 1));
                        }

                        if (intPos2 == 1)
                        {
                            intPeso = 8;
                        }

                        intSoma += intValor * intPeso;
                        intPeso -= 1;
                        intPos2 += 1;
                    }

                    intResto = intSoma % 10;
                    strDigito1 = (intResto == 0 ? "0" : Convert.ToString(10 - intResto))[^1..];
                    strBase2 = strBase[..6] + strDigito1 + strDigito2;
                    return (strBase2 ?? "") == (IE ?? "");
                }

                return false;
            }

            if ("679".IndexOf(strBase[..1], 0, StringComparison.OrdinalIgnoreCase) + 1 > 0)
            {
                intSoma = 0;
                int intPos = 1;
                while (intPos <= 6)
                {
                    intValor = int.Parse(strBase.Substring(intPos - 1, 1));
                    if (intPos == 1)
                    {
                        intPeso = 7;
                    }

                    intSoma += intValor * intPeso;
                    intPeso -= 1;
                    intPos += 1;
                }

                intResto = intSoma % 11;
                strDigito2 = (intResto == 0 ? "0" : Convert.ToString(11 - intResto))[^1..];
                strBase2 = strBase[..7] + strDigito2;
                if ((strBase2 ?? "") == (IE ?? ""))
                {
                    intSoma = 0;
                    intPeso = 0;
                    int intPos2 = 1;
                    while (intPos2 <= 7)
                    {
                        intValor = int.Parse(strBase.Substring(intPos2 - 1, 1));
                        if (intPos2 == 7)
                        {
                            intValor = int.Parse(strBase.Substring(intPos2, 1));
                        }

                        if (intPos2 == 1)
                        {
                            intPeso = 8;
                        }

                        intSoma += intValor * intPeso;
                        intPeso -= 1;
                        intPos2 += 1;
                    }

                    intResto = intSoma % 11;
                    strDigito1 = (intResto == 0 ? "0" : Convert.ToString(11 - intResto))[^1..];
                    strBase2 = strBase[..6] + strDigito1 + strDigito2;
                    return (strBase2 ?? "") == (IE ?? "");
                }

                return false;
            }
        }
        // #End Region


        // #Region "Validação 9 dígitos"
        if (IE.Length == 9)
        {
            int modulo = "0123458".IndexOf(strBase.Substring(1, 1), 0, StringComparison.OrdinalIgnoreCase) + 1 > 0 ? 10 : 11;
            intSoma = 0;
            int intPos = 1;
            while (intPos <= 7)
            {
                intValor = int.Parse(strBase.Substring(intPos - 1, 1));
                if (intPos == 1)
                {
                    intPeso = 8;
                }

                intSoma += intValor * intPeso;
                intPeso -= 1;
                intPos += 1;
            }

            intResto = intSoma % modulo;
            if (modulo == 11)
            {
                strDigito2 = (intResto == 0 || intResto == 1 ? "0" : Convert.ToString(modulo - intResto))[^1..];
            }
            else
            {
                strDigito2 = (intResto == 0 ? "0" : Convert.ToString(modulo - intResto))[^1..];
            }

            strBase2 = strBase[..8] + strDigito2;
            if ((strBase2 ?? "") == (IE ?? ""))
            {
                intSoma = 0;
                intPeso = 0;
                int intPos2 = 1;
                while (intPos2 <= 8)
                {
                    intValor = int.Parse(strBase.Substring(intPos2 - 1, 1));
                    if (intPos2 == 8)
                    {
                        intValor = int.Parse(strBase.Substring(intPos2, 1));
                    }

                    if (intPos2 == 1)
                    {
                        intPeso = 9;
                    }

                    intSoma += intValor * intPeso;
                    intPeso -= 1;
                    intPos2 += 1;
                }

                intResto = intSoma % modulo;
                if (modulo == 11)
                {
                    strDigito1 = (intResto == 0 || intResto == 1 ? "0" : Convert.ToString(modulo - intResto))[^1..];
                }
                else
                {
                    strDigito1 = (intResto == 0 ? "0" : Convert.ToString(modulo - intResto))[^1..];
                }

                strBase2 = strBase[..7] + strDigito1 + strDigito2;
                return (strBase2 ?? "") == (IE ?? "");
            }

            return false;
        }

        return true;
    } // UPdated 02/02/2017

    private static bool Validate_CE(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_DF(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 1)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 13)
            {
                var xdigito = new int[12];
                int digito1;
                int digito2;

                // ## CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 4;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 3;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 2;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 9;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 8;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 7;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 6;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 5;
                xdigito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 4;
                xdigito[9] = Conversions.ToInteger(IE.Substring(9, 1)) * 3;
                xdigito[10] = Conversions.ToInteger(IE.Substring(10, 1)) * 2;
                int totalD1 = 0;
                for (int i = 0; i <= 10; i++)
                    totalD1 += xdigito[i];
                int resto = totalD1 % 11;

                // ## Avaliação do resto da divisão ##
                resto = 11 - resto;
                if (resto > 9)
                {
                    digito1 = 0;
                }
                else
                {
                    digito1 = resto;
                }
                // If resto <= 1 Then
                // digito1 = 0
                // Else
                // digito1 = 11 - resto
                // End If


                // ## CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 5;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 4;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 3;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 2;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 9;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 8;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 7;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 6;
                xdigito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 5;
                xdigito[9] = Conversions.ToInteger(IE.Substring(9, 1)) * 4;
                xdigito[10] = Conversions.ToInteger(IE.Substring(10, 1)) * 3;
                xdigito[11] = digito1 * 2;
                int totalD2 = 0;
                for (int i = 0; i <= 11; i++)
                    totalD2 += xdigito[i];
                resto = totalD2 % 11;

                // ## Avaliação do resto da divisão ##
                // If resto <= 1 Then
                // digito2 = 0
                // Else
                // digito2 = 11 - resto
                // End If
                resto = 11 - resto;
                if (resto > 9)
                {
                    digito2 = 0;
                }
                else
                {
                    digito2 = resto;
                }


                // ## VALIDAÇÃO DOS DÍGITOS ##
                int dinf1 = Conversions.ToInteger(IE.Substring(11, 1));
                int dinf2 = Conversions.ToInteger(IE.Substring(12, 1));
                if (dinf1 == digito1 & dinf2 == digito2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working.. bug fixed in 19/09/2013

    private static bool Validate_ES(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_GO(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();

            // ## Verifica se os dois primeiros dígitos valem 10, 11 ou 15 ##
            if (IE[..2] != "10" & IE[..2] != "11" & IE[..2] != "15")
            {
                return false;
            }
            else if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                var digito = default(int);

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto > 1)
                {
                    digito = 11 - resto;
                }
                else if (Conversions.ToInteger(IE[..7]) == 11094402)
                {
                    return true;
                }
                else if (resto == 0)
                {
                    digito = resto;
                }
                else if (resto == 1)
                {
                    if (Conversions.ToInteger(IE[..7]) >= 10103105 & Conversions.ToInteger(IE[..7]) <= 10119997)
                    {
                        digito = 1;
                    }
                    else
                    {
                        digito = 0;
                    }
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_MA(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                // ## Verifica se os dois primeiros dígitos valem 12 ##
                if (IE[..2] != "12")
                {
                    return false;
                }
                else
                {
                    var xdigito = new int[8];
                    int digito;

                    // ## CÁLCULO DO ÚNICO DÍGITO ##
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                    int totalD = 0;
                    for (int i = 0; i <= 7; i++)
                        totalD += xdigito[i];
                    int resto = totalD % 11;

                    // ## Avaliação do resto da divisão ##
                    if (resto <= 1)
                    {
                        digito = 0;
                    }
                    else
                    {
                        digito = 11 - resto;
                    }


                    // ## VALIDAÇÃO DO DÍGITO ##
                    int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                    if (dinf1 == digito)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_MG(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 13)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 13)
            {
                var digito = new int[12];
                int digito1;
                int digito2;

                // ## CÁLCULO DO PRIMEIRO DÍGITO ##
                // Multiplicando os dígitos por 1 e 2
                digito[0] = Conversions.ToInteger(IE[..1]) * 1;
                digito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 2;
                digito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 1;
                digito[3] = 0;
                digito[4] = Conversions.ToInteger(IE.Substring(3, 1)) * 1;
                digito[5] = Conversions.ToInteger(IE.Substring(4, 1)) * 2;
                digito[6] = Conversions.ToInteger(IE.Substring(5, 1)) * 1;
                digito[7] = Conversions.ToInteger(IE.Substring(6, 1)) * 2;
                digito[8] = Conversions.ToInteger(IE.Substring(7, 1)) * 1;
                digito[9] = Conversions.ToInteger(IE.Substring(8, 1)) * 2;
                digito[10] = Conversions.ToInteger(IE.Substring(9, 1)) * 1;
                digito[11] = Conversions.ToInteger(IE.Substring(10, 1)) * 2;

                // Somando os dígitos dos produtos
                int totalD1 = 0;
                for (int i = 0; i <= 11; i++)
                {
                    if (digito[i] >= 10)
                    {
                        totalD1 += Conversions.ToInteger(digito[i].ToString()[..1]) + Conversions.ToInteger(digito[i].ToString().Substring(1, 1));
                    }
                    else
                    {
                        totalD1 += digito[i];
                    }
                }

                // Subtraindo a primeira dezena exata imediatamente superior (PUTA QUE PARIU..)
                if (totalD1 % 10 == 0)
                {
                    digito1 = 0;
                }
                else
                {
                    int dezena = 0;
                    if (totalD1 > 10)
                    {
                        dezena = Conversions.ToInteger((int)(Conversions.ToDouble(totalD1.ToString()[..1]) + 1) + "0");
                    }
                    else
                    {
                        dezena = 10;
                    }

                    digito1 = dezena - totalD1;
                }


                // ## CÁLCULO DO SEGUNDO DÍGITO ##
                // Dígitos Originais
                digito[0] = Conversions.ToInteger(IE[..1]) * 3;
                digito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 2;
                digito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 11;
                digito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 10;
                digito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 9;
                digito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 8;
                digito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 7;
                digito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 6;
                digito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 5;
                digito[9] = Conversions.ToInteger(IE.Substring(9, 1)) * 4;
                digito[10] = Conversions.ToInteger(IE.Substring(10, 1)) * 3;
                digito[11] = digito1 * 2;

                // Somando os produtos das multiplicações
                int totalD2 = 0;
                for (int i = 0; i <= 11; i++)
                    totalD2 += digito[i];

                // Apurando o resto da divisão da soma dos produtos por 11
                int resto = totalD2 % 11;
                if (resto == 0 | resto == 1)
                {
                    digito2 = 0; // disgraçaaa
                }
                else
                {
                    digito2 = 11 - resto;
                }

                // ## VALIDAÇÃO DOS DÍGITOS ##
                int dinf1 = Conversions.ToInteger(IE.Substring(11, 1));
                int dinf2 = Conversions.ToInteger(IE.Substring(12, 1));
                if (dinf1 == digito1 & dinf2 == digito2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working.. bug fixed in 02/08/2013. added left zeros support in 19/09/2013.. bug fixed in 07/04/2014

    private static bool Validate_MT(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE[..2] == "00")
            {
                IE = IE.Remove(0, 2);
            }

            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[10];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_MS(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_PA(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                // ## Verifica se os dois primeiros dígitos valem 15 ##
                if (IE[..2] != "15")
                {
                    return false;
                }
                else
                {
                    var xdigito = new int[8];
                    int digito;

                    // ## CÁLCULO DO ÚNICO DÍGITO ##
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                    int totalD = 0;
                    for (int i = 0; i <= 7; i++)
                        totalD += xdigito[i];
                    int resto = totalD % 11;

                    // ## Avaliação do resto da divisão ##
                    if (resto <= 1)
                    {
                        digito = 0;
                    }
                    else
                    {
                        digito = 11 - resto;
                    }


                    // ## VALIDAÇÃO DO DÍGITO ##
                    int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                    if (dinf1 == digito)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_PB(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_PE(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[9];
                int digito1;
                int digito2;

                // ## CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 8;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 7;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 6;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 5;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 4;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 3;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 2;
                int totalD1 = 0;
                for (int i = 0; i <= 6; i++)
                    totalD1 += xdigito[i];
                int resto = totalD1 % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito1 = 0;
                }
                else
                {
                    digito1 = 11 - resto;
                }


                // ## CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = digito1 * 2;
                int totalD2 = 0;
                for (int i = 0; i <= 7; i++)
                    totalD2 += xdigito[i];
                resto = totalD2 % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito2 = 0;
                }
                else
                {
                    digito2 = 11 - resto;
                }


                // ## VALIDAÇÃO DOS DÍGITOS ##
                int dinf1 = Conversions.ToInteger(IE.Substring(7, 1));
                int dinf2 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito1 & dinf2 == digito2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Not Tested Yet..

    private static bool Validate_PI(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_PR(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 10)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 10)
            {
                var xdigito = new int[10];
                int digito1;
                int digito2;

                // ## CÁLCULO DO PRIMEIRO DÍGITO VERIFICADOR ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 3;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 2;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD1 = 0;
                for (int i = 0; i <= 7; i++)
                    totalD1 += xdigito[i];
                int resto = totalD1 % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito1 = 0;
                }
                else
                {
                    digito1 = 11 - resto;
                }


                // ## CÁLCULO DO SEGUNDO DÍGITO VERIFICADOR ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 4;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 3;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 2;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 7;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 6;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 5;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 4;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 3;
                xdigito[8] = digito1 * 2;
                int totalD2 = 0;
                for (int i = 0; i <= 8; i++)
                    totalD2 += xdigito[i];
                resto = totalD2 % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito2 = 0;
                }
                else
                {
                    digito2 = 11 - resto;
                }


                // ## VALIDAÇÃO DOS DÍGITOS ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                int dinf2 = Conversions.ToInteger(IE.Substring(9, 1));
                if (dinf1 == digito1 & dinf2 == digito2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_RJ(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 8)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 8)
            {
                var xdigito = new int[7];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 2;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 7;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 6;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 5;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 4;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 3;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 6; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(7, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_RN(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE[..2] != "20")
            {
                return false;
            }

            if (IE.Trim().Length == 9 | IE.Trim().Length == 10)
            {
                var xdigito = new int[9];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                if (IE.Trim().Length == 9)
                {
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                }
                else if (IE.Trim().Length == 10)
                {
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 10;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 9;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 8;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 7;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 6;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 5;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 4;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 3;
                    xdigito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 2;
                }

                int totalD = 0;
                if (IE.Trim().Length == 9)
                {
                    for (int i = 0; i <= 7; i++)
                        totalD += xdigito[i];
                }
                else if (IE.Trim().Length == 10)
                {
                    for (int i = 0; i <= 8; i++)
                        totalD += xdigito[i];
                }

                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }

                // ## VALIDAÇÃO DO DÍGITO ##
                var dinf1 = default(int);
                switch (IE.Trim().Length)
                {
                    case 9:
                        {
                            dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                            break;
                        }

                    case 10:
                        {
                            dinf1 = Conversions.ToInteger(IE.Substring(9, 1));
                            break;
                        }
                }

                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_RS(this string IE)
    {
        try
        {
            // Dim intNumero As Long = Convert.ToInt32(IE.Substring(0, 3))
            // If intNumero > 0 And intNumero <= 468 Then
            // Dim intSoma As Integer = 0
            // Dim intPeso As Integer = 2
            // For intPos = 8 To 0 Step -1
            // Dim intValorI As Integer = Convert.ToInt32(IE.Substring(intPos, 1))
            // intValorI = intValorI * intPeso
            // intSoma = intSoma + intValorI
            // intPeso = intPeso + 1
            // If intPeso > 9 Then
            // intPeso = 2
            // End If
            // Next
            // Dim intResto As Integer = intSoma Mod 11
            // Dim intValor As Integer = 11 - intResto
            // If intValor > 9 Then
            // intValor = 0
            // End If
            // 'Dim strDigito1 As String = IE.Substring(9, 1) 'old right..
            // Dim strBase2 As String = IE.Substring(0, 9) & intValor.ToString
            // If strBase2 = IE Then
            // Return True
            // Else
            // Return False
            // End If
            // Else
            // Return False
            // End If

            if (IE.Length != 10)
            {
                return false;
            }

            string strBase = (IE.Trim() + "0000000000")[..10];
            int intSoma = 0;
            int intPeso = 2;
            int intValor = 0;
            int intPos = 9;
            while (intPos >= 1)
            {
                intValor = int.Parse(strBase.Substring(intPos - 1, 1));
                intValor *= intPeso;
                intSoma += intValor;
                intPeso++;
                if (intPeso > 9)
                {
                    intPeso = 2;
                }

                intPos--;
            }

            int intResto = intSoma % 11;
            intValor = 11 - intResto;
            if (intValor > 9)
            {
                intValor = 0;
            }

            string strDigito1 = Convert.ToString(intValor)[^1..];
            string strBase2 = strBase[..9] + strDigito1;
            return (strBase2 ?? "") == (IE ?? "");
        }
        catch (Exception)
        {
            return false;
        }
    } // updates 02/02/2017

    private static bool Validate_RO(this string IE)
    {
        try
        {
            // ## Ajusta o tamanho da String ##
            string complemento = string.Empty;
            switch (IE.Trim().Length)
            {
                case 13:
                    {
                        complemento = "0";
                        break;
                    }

                case 12:
                    {
                        complemento = "00";
                        break;
                    }

                case 11:
                    {
                        complemento = "000";
                        break;
                    }

                case 10:
                    {
                        complemento = "0000";
                        break;
                    }

                case 9:
                    {
                        complemento = "00000";
                        break;
                    }

                case 8:
                    {
                        complemento = "000000";
                        break;
                    }

                case 7:
                    {
                        complemento = "0000000";
                        break;
                    }

                case 6:
                    {
                        complemento = "00000000";
                        break;
                    }
            }

            IE = complemento + IE;
            var xdigito = new int[13];
            int digito;

            // ## CÁLCULO DO ÚNICO DÍGITO ##
            xdigito[0] = Conversions.ToInteger(IE[..1]) * 6;
            xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 5;
            xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 4;
            xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 3;
            xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 2;
            xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 9;
            xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 8;
            xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 7;
            xdigito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 6;
            xdigito[9] = Conversions.ToInteger(IE.Substring(9, 1)) * 5;
            xdigito[10] = Conversions.ToInteger(IE.Substring(10, 1)) * 4;
            xdigito[11] = Conversions.ToInteger(IE.Substring(11, 1)) * 3;
            xdigito[12] = Conversions.ToInteger(IE.Substring(12, 1)) * 2;
            int totalD = 0;
            for (int i = 0; i <= 12; i++)
                totalD += xdigito[i];
            int resto = totalD % 11;
            digito = 11 - resto;
            if (digito > 9)
            {
                digito -= 10;
            }

            // ## VALIDAÇÃO DO DÍGITO ##
            int dinf1 = Conversions.ToInteger(IE.Substring(13, 1));
            if (dinf1 == digito)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_RR(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Trim().Length == 9)
            {
                // ## Verifica se os dois primeiros dígitos valem 24 (VAPoOO..) ##
                if (IE[..2] != "24")
                {
                    return false;
                }
                else
                {
                    var xdigito = new int[8];
                    int digito;

                    // ## CÁLCULO DO ÚNICO DÍGITO ##
                    xdigito[0] = Conversions.ToInteger(IE[..1]) * 1;
                    xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 2;
                    xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 3;
                    xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 4;
                    xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                    xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 6;
                    xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 7;
                    xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 8;
                    int totalD = 0;
                    for (int i = 0; i <= 7; i++)
                        totalD += xdigito[i];
                    digito = totalD % 9;

                    // ## VALIDAÇÃO DO DÍGITO ##
                    int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                    if (dinf1 == digito)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_SC(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_SE(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;
                if (IE[..2] != "27")
                {
                    return false;
                }

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_SP(this string IE)
    {
        try
        {
            var xdigito = new int[12];
            int digito1;
            int digito2;
            if (!IE.Contains('P')) // Inscrição Normal
            {
                // ## CÁLCULO DO PRIMEIRO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 1;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 3;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 4;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 5;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 6;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 7;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 8;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 10;
                var totalD1 = default(int);
                for (int i = 0; i <= 7; i++)
                    totalD1 += xdigito[i];
                int restoD1 = totalD1 % 11;
                if (restoD1 >= 10)
                {
                    digito1 = 0;
                }
                else
                {
                    digito1 = restoD1;
                }


                // ## CÁLCULO DO SEGUNDO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 3;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 2;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 10;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 9;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 8;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 7;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 6;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 5;
                xdigito[8] = digito1 * 4;
                xdigito[9] = Conversions.ToInteger(IE.Substring(9, 1)) * 3;
                xdigito[10] = Conversions.ToInteger(IE.Substring(10, 1)) * 2;
                var totalD2 = default(int);
                for (int i = 0; i <= 10; i++)
                    totalD2 += xdigito[i];
                int restoD2 = totalD2 % 11;
                if (restoD2 >= 10)
                {
                    digito2 = 0;
                }
                else
                {
                    digito2 = restoD2;
                }


                // ## VALIDAÇÃO DOS DÍGITOS ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                int dinf2 = Conversions.ToInteger(IE.Substring(11, 1));
                if (dinf1 == digito1 & dinf2 == digito2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else // Inscrição de Produtor Rural
            {
                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = 0;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 1;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 3;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 4;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 6;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 7;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 8;
                xdigito[8] = Conversions.ToInteger(IE.Substring(8, 1)) * 10;
                var totalD1 = default(int);
                for (int i = 0; i <= 8; i++)
                    totalD1 += xdigito[i];
                int restoD1 = totalD1 % 11;
                if (restoD1 >= 10)
                {
                    digito1 = 0;
                }
                else
                {
                    digito1 = restoD1;
                }

                // ## VALIDAÇÃO DOS DÍGITOS ##
                int dinf1 = Conversions.ToInteger(IE.Substring(9, 1));
                if (dinf1 == digito1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

    private static bool Validate_TO(this string IE)
    {
        try
        {
            while (IE.Trim().Length < 9)
                IE = "0" + IE.Trim();
            if (IE.Trim().Length == 9)
            {
                var xdigito = new int[8];
                int digito;

                // ## Verifica se os dois primeiros dígitos valem 01 ##
                if (IE[..2] != "29")
                {
                    return false;
                }

                // ## CÁLCULO DO ÚNICO DÍGITO ##
                xdigito[0] = Conversions.ToInteger(IE[..1]) * 9;
                xdigito[1] = Conversions.ToInteger(IE.Substring(1, 1)) * 8;
                xdigito[2] = Conversions.ToInteger(IE.Substring(2, 1)) * 7;
                xdigito[3] = Conversions.ToInteger(IE.Substring(3, 1)) * 6;
                xdigito[4] = Conversions.ToInteger(IE.Substring(4, 1)) * 5;
                xdigito[5] = Conversions.ToInteger(IE.Substring(5, 1)) * 4;
                xdigito[6] = Conversions.ToInteger(IE.Substring(6, 1)) * 3;
                xdigito[7] = Conversions.ToInteger(IE.Substring(7, 1)) * 2;
                int totalD = 0;
                for (int i = 0; i <= 7; i++)
                    totalD += xdigito[i];
                int resto = totalD % 11;

                // ## Avaliação do resto da divisão ##
                if (resto <= 1)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }


                // ## VALIDAÇÃO DO DÍGITO ##
                int dinf1 = Conversions.ToInteger(IE.Substring(8, 1));
                if (dinf1 == digito)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }
    } // Tested & Working..

}

public class LogradouroExtensions
{
    private static Dictionary<string, string>? _replacementDict;

    public static Dictionary<string, string> ReplacementDictionary
    {
        get
        {
            if (_replacementDict is null)
                CreateKnownReplacementDictionary();

            return _replacementDict!;
        }
    }

    private static void CreateKnownReplacementDictionary()
    {
        _replacementDict = new Dictionary<string, string>
        {
            { "10ª rua", "10ª Rua" },
            { "10ª travessa", "10ª Travessa" },
            { "11ª rua", "11ª Rua" },
            { "11ª travessa", "11ª Travessa" },
            { "12ª rua", "12ª Rua" },
            { "12ª travessa", "12ª Travessa" },
            { "13ª travessa", "13ª Travessa" },
            { "14ª travessa", "14ª Travessa" },
            { "15ª travessa", "15ª Travessa" },
            { "16ª travessa", "16ª Travessa" },
            { "1ª avenida", "1ª Avenida" },
            { "1ª paralela", "1ª Paralela" },
            { "1ª rua", "1ª Rua" },
            { "1ª subida", "1ª Subida" },
            { "1ª travessa", "1ª Travessa" },
            { "1ª vila", "1ª Vila" },
            { "1º alto", "1º Alto" },
            { "1º beco", "1º Beco" },
            { "2ª avenida", "2ª Avenida" },
            { "2ª paralela", "2ª Paralela" },
            { "2ª rua", "2ª Rua" },
            { "2ª subida", "2ª Subida" },
            { "2ª travessa", "2ª Travessa" },
            { "2ª vila", "2ª Vila" },
            { "2º alto", "2º Alto" },
            { "2º beco", "2º Beco" },
            { "3ª avenida", "3ª Avenida" },
            { "3ª paralela", "3ª Paralela" },
            { "3ª rua", "3ª Rua" },
            { "3ª subida", "3ª Subida" },
            { "3ª travessa", "3ª Travessa" },
            { "3ª vila", "3ª Vila" },
            { "3º alto", "3º Alto" },
            { "3º beco", "3º Beco" },
            { "4ª avenida", "4ª Avenida" },
            { "4ª rua", "4ª Rua" },
            { "4ª subida", "4ª Subida" },
            { "4ª travessa", "4ª Travessa" },
            { "4ª vila", "4ª Vila" },
            { "5ª avenida", "5ª Avenida" },
            { "5ª rua", "5ª Rua" },
            { "5ª subida", "5ª Subida" },
            { "5ª travessa", "5ª Travessa" },
            { "5ª vila", "5ª Vila" },
            { "6ª avenida", "6ª Avenida" },
            { "6ª rua", "6ª Rua" },
            { "6ª subida", "6ª Subida" },
            { "6ª travessa", "6ª Travessa" },
            { "7ª rua", "7ª Rua" },
            { "7ª travessa", "7ª Travessa" },
            { "8ª rua", "8ª Rua" },
            { "8ª travessa", "8ª Travessa" },
            { "9ª rua", "9ª Rua" },
            { "9ª travessa", "9ª Travessa" },
            { "acampamento", "Acampamento" },
            { "acamp ", "Acampamento" },
            { "acamp.", "Acampamento" },
            { "acesso", "Acesso" },
            { "adro", "Adro" },
            { "aeroporto", "Aeroporto" },
            { "alameda", "Alameda" },
            { "alam ", "Alameda" },
            { "alam.", "Alameda" },
            { "alto", "Alto" },
            { "antiga estrada", "Antiga Estrada" },
            { "área", "Área" },
            { "área especial", "Área Especial" },
            { "artéria", "Artéria" },
            { "atalho", "Atalho" },
            { "avenida", "Avenida" },
            { "a ", "Avenida" },
            { "av.", "Avenida" },
            { "av ", "Avenida" },
            { "av;", "Avenida" },
            { "av:", "Avenida" },
            { "av/", "Avenida" },
            { "av-", "Avenida" },
            { "aven ", "Avenida" },
            { "aven.", "Avenida" },
            { "aven:", "Avenida" },
            { "aven-", "Avenida" },
            { "avenida contorno", "Avenida Contorno" },
            { "avenida marginal", "Avenida Marginal" },
            { "avenida velha", "Avenida Velha" },
            { "baixa", "Baixa" },
            { "balão", "Balão" },
            { "beco", "Beco" },
            { "belvedere", "Belvedere" },
            { "bloco", "Bloco" },
            { "bosque", "Bosque" },
            { "boulevard", "Boulevard" },
            { "bulevar", "Bulevar" },
            { "buraco", "Buraco" },
            { "cais", "Cais" },
            { "calçada", "Calçada" },
            { "caminho", "Caminho" },
            { "campo", "Campo" },
            { "canal", "Canal" },
            { "chácara", "Chácara" },
            { "ciclovia", "Ciclovia" },
            { "circular", "Circular" },
            { "colônia", "Colônia" },
            { "complexo viário", "Complexo Viário" },
            { "condomínio", "Condomínio" },
            { "conjunto", "Conjunto" },
            { "conj ", "Conjunto" },
            { "conj.", "Conjunto" },
            { "conj:", "Conjunto" },
            { "cj ", "Conjunto" },
            { "cj.", "Conjunto" },
            { "cj:", "Conjunto" },
            { "conjunto mutirão", "Conjunto Mutirão" },
            { "contorno", "Contorno" },
            { "corredor", "Corredor" },
            { "córrego", "Córrego" },
            { "descida", "Descida" },
            { "desvio", "Desvio" },
            { "distrito", "Distrito" },
            { "elevada", "Elevada" },
            { "entrada particular", "Entrada Particular" },
            { "entre quadra", "Entre Quadra" },
            { "escada", "Escada" },
            { "escadaria", "Escadaria" },
            { "esplanada", "Esplanada" },
            { "estação", "Estação" },
            { "estacionamento", "Estacionamento" },
            { "estádio", "Estádio" },
            { "estrada", "Estrada" },
            { "estrada de ligação", "Estrada de Ligação" },
            { "estrada estadual", "Estrada Estadual" },
            { "estrada municipal", "Estrada Municipal" },
            { "estrada particular", "Estrada Particular" },
            { "estrada velha", "Estrada Velha" },
            { "estrada vicinal", "Estrada Vicinal" },
            { "favela", "Favela" },
            { "fazenda", "Fazenda" },
            { "faz ", "Fazenda" },
            { "faz.", "Fazenda" },
            { "faz;", "Fazenda" },
            { "faz:", "Fazenda" },
            { "faz-", "Fazenda" },
            { @"faz\", "Fazenda" },
            { "fz ", "Fazenda" },
            { "fz.", "Fazenda" },
            { "feira", "Feira" },
            { "ferrovia", "Ferrovia" },
            { "fonte", "Fonte" },
            { "forte", "Forte" },
            { "galeria", "Galeria" },
            { "granja", "Granja" },
            { "ilha", "Ilha" },
            { "jardim", "Jardim" },
            { "jardinete", "Jardinete" },
            { "ladeira", "Ladeira" },
            { "lad ", "Ladeira" },
            { "lad.", "Ladeira" },
            { "lago", "Lago" },
            { "lagoa", "Lagoa" },
            { "largo", "Largo" },
            { "loteamento", "Loteamento" },
            { "lot ", "Loteamento" },
            { "lot.", "Loteamento" },
            { "lot:", "Loteamento" },
            { "lot-", "Loteamento" },
            { "marina", "Marina" },
            { "módulo", "Módulo" },
            { "monte", "Monte" },
            { "morro", "Morro" },
            { "núcleo", "Núcleo" },
            { "parada", "Parada" },
            { "paralela", "Paralela" },
            { "parque", "Parque" },
            { "parq ", "Parque" },
            { "parq.", "Parque" },
            { "pq ", "Parque" },
            { "pq.", "Parque" },
            { "parque municipal", "Parque Municipal" },
            { "parque residencial", "Parque Residencial" },
            { "passagem", "Passagem" },
            { "pass.", "Passagem" },
            { "pass:", "Passagem" },
            { "passagem de pedestres", "Passagem de Pedestres" },
            { "passagem subterrânea", "Passagem Subterrânea" },
            { "passarela", "Passarela" },
            { "passeio", "Passeio" },
            { "pátio", "Pátio" },
            { "ponta", "Ponta" },
            { "ponte", "Ponte" },
            { "porto", "Porto" },
            { "praça", "Praça" },
            { "pça", "Praça" },
            { "pca", "Praça" },
            { "praça de esportes", "Praça de Esportes" },
            { "praia", "Praia" },
            { "prolongamento", "Prolongamento" },
            { "quadra", "Quadra" },
            { "quinta", "Quinta" },
            { "ramal", "Ramal" },
            { "rampa", "Rampa" },
            { "recanto", "Recanto" },
            { "rec.", "Recanto" },
            { "rec ", "Recanto" },
            { "residencial", "Residencial" },
            { "reta", "Reta" },
            { "retiro", "Retiro" },
            { "retorno", "Retorno" },
            { "rodo anel", "Rodo Anel" },
            { "rodovia", "Rodovia" },
            { "rod ", "Rodovia" },
            { "rod.", "Rodovia" },
            { "rod:", "Rodovia" },
            { "rod;", "Rodovia" },
            { "rotatória", "Rotatória" },
            { "rótula", "Rótula" },
            { "rua", "Rua" },
            { "r ", "Rua" },
            { "r.", "Rua" },
            { "r:", "Rua" },
            { "r;", "Rua" },
            { "r-", "Rua" },
            { "rua;", "Rua" },
            { @"rua\", "Rua" },
            { "rua-", "Rua" },
            { "rua de ligação", "Rua de Ligação" },
            { "rua de pedestre", "Rua de Pedestre" },
            { "rua particular", "Rua Particular" },
            { "rua velha", "Rua Velha" },
            { "servidão", "Servidão" },
            { "setor", "Setor" },
            { "sítio", "Sítio" },
            { "sitio", "Sítio" },
            { "s.", "Sítio" },
            { "s ", "Sítio" },
            { "sít.", "Sítio" },
            { "sít ", "Sítio" },
            { "sít:", "Sítio" },
            { "sit.", "Sítio" },
            { "sit ", "Sítio" },
            { "sit:", "Sítio" },
            { "subida", "Subida" },
            { "terminal", "Terminal" },
            { "travessa", "Travessa" },
            { "tv ", "Travessa" },
            { "tv.", "Travessa" },
            { "tv:", "Travessa" },
            { "trav ", "Travessa" },
            { "trav.", "Travessa" },
            { "trav:", "Travessa" },
            { "trav-", "Travessa" },
            { "travessa particular", "Travessa Particular" },
            { "travessa velha", "Travessa Velha" },
            { "trecho", "Trecho" },
            { "trevo", "Trevo" },
            { "túnel", "Túnel" },
            { "unidade", "Unidade" },
            { "vala", "Vala" },
            { "vale", "Vale" },
            { "vereda", "Vereda" },
            { "via", "Via" },
            { "v ", "Via" },
            { "v.", "Via" },
            { "v:", "Via" },
            { "via coletora", "Via Coletora" },
            { "via de acesso", "Via de Acesso" },
            { "via de pedestre", "Via de Pedestre" },
            { "via elevado", "Via Elevado" },
            { "via expressa", "Via Expressa" },
            { "via litoranea", "Via Litoranea" },
            { "via local", "Via Local" },
            { "viaduto", "Viaduto" },
            { "viela", "Viela" },
            { "vila", "Vila" },
            { "vl ", "Vila" },
            { "vl.", "Vila" },
            { "zigue-zague", "Zigue-Zague" }
        };
    }
}

public static class LocalizationExtensions
{
    private static readonly Dictionary<Type, System.Resources.ResourceManager> _resourcesCache = new();

    /// <summary>
    /// Retorna o texto no idioma (System.Globalization.Culture.CultureInfo) atual.
    /// Utiliza o dicionário EficazFramework.Resources.Strings.Descriptions.
    /// </summary>
    /// <param name="text">ID do texto a ser localizado.</param>
    /// <returns></returns>
    public static string? Localize(this string text) =>
        text.Localize(typeof(EficazFramework.Resources.Strings.Descriptions), null);

    /// <summary>
    /// Retorna o texto no idioma (System.Globalization.Culture.CultureInfo) atual
    /// </summary>
    /// <param name="text">ID do texto a ser localizado.</param>
    /// <param name="resourceManager">Tipo do dicionário ResourceManager a ser consultado.</param>
    /// <param name="stringformat">(Opcional) Máscara para formatação do texto resultante.</param>
    /// <returns></returns>
    public static string Localize(this string text, Type resourceManager, string stringformat)
    {
        try
        {
            System.Resources.ResourceManager resourceManagerInstance;
            string tmpstring = text;

            if (_resourcesCache.ContainsKey(resourceManager))
            {
                resourceManagerInstance = _resourcesCache[resourceManager];
            }
            else
            {
                resourceManagerInstance = new(resourceManager);
                _resourcesCache.Add(resourceManager, resourceManagerInstance);
            }

            tmpstring = (resourceManagerInstance.GetString(text) ?? text);
            if (tmpstring != null)
            {
                if (stringformat == null)
                    return tmpstring;
                else
                    return string.Format(stringformat, tmpstring);
            }

            if (stringformat == null)
                return text;
            else
                return string.Format(stringformat, text);
        }
        catch //(Exception ex)
        {

            if (stringformat == null)
                return text;
            else
                return string.Format(stringformat, text);

        }
    }
}
