using System.Text.RegularExpressions;

namespace EficazFramework.Generators.Extensions;

public static class TextExtensions
{

    /// <summary>
    /// Remove todos os caracteres especiais de uma string.
    /// </summary>
    /// <param name="texto">A string a ser analisada.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string GetClearText(this string texto)
    {
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
        texto = Regex.Replace(texto, @"(?:[^a-z0-9]|(?<=['\'])s)", string.Empty, RegexOptions.IgnoreCase & RegexOptions.CultureInvariant);
        return texto.Replace(" ", "");
    }

    /// <summary>
    /// Divide uma string em numa lista de substrings, conforme a quantidade de caracteres desejada
    /// </summary>
    /// <param name="texto">A string a ser analisada.</param>
    /// <param name="tamanho">quantidade de caracteres desejada</param>
    /// <returns></returns>
    public static IEnumerable<string> SplitByLength(this string texto, int tamanho)
    {
        return Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(texto.Length / (double)tamanho))).Select(i => texto.Substring(i * tamanho, Math.Min(texto.Length - i * tamanho, tamanho)));
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
    public static string ToTitleCase(this string name, string[] splitChars = null)
    {
        if (name is null)
            return null;
        name = name.Trim();
        splitChars ??= new string[] { "" };

        var array = name.ToLower().ToCharArray();
        if (array.Length > 1)
        {
            if (char.IsLower(array[0]))
            {
                array[0] = char.ToUpper(array[0]);
            }

            for (int i = 1, loopTo = array.Length; i <= loopTo; i++)
            {
                if ((array[i - 1].ToString()) == " " | splitChars.Contains((array[i - 1]).ToString()))
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }

            return new string(array);
        }
        else
        {
            return name.ToUpper();
        }
    }
}

