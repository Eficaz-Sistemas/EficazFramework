using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Linq;

namespace EficazFramework.Extensions;

public static class NumberExtensions
{
    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this double d, int SignificantDigits, int MinDecimals = 0)
    {
        if (d.ToString("F0").Length >= SignificantDigits)
            return d.ToString($"F{MinDecimals}");

        var decimalDigit = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        var parts = d.ToString().Split(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        if (parts.Length > 1 && (parts[0].Length + parts[1].Length) > SignificantDigits && int.Parse(parts[0]) > 0)
        {
            if (MinDecimals > 0)
                return d.ToString($"F{MinDecimals}");
            else
                return d.ToString();
        }

        // Use G format to get significant digits.
        // Then convert to double and use F format.
        var gFormatted = String.Format(string.Join("", "{0:", $"G{SignificantDigits}", "}"), Math.Abs(d));
        string result = Convert.ToDecimal(gFormatted).ToString("F99");

        // Remove trailing 0s.
        result = result.TrimEnd('0');

        // Rmove the decimal point and leading 0s,
        // leaving just the digits.
        string test = result.Replace(decimalDigit, "").TrimStart('0');

        // See if we have enough significant digits.
        if (SignificantDigits > test.Length)
        {
            // Add trailing 0s.
            result += new string('0', SignificantDigits - test.Length);
        }
        else
        {
            // See if we should remove the trailing decimal point.
            if ((SignificantDigits < test.Length) &&
                result.EndsWith("."))
                result = result[0..^1];
        }
        if (result.EndsWith(decimalDigit) && MinDecimals == 0)
            result = result.Replace(decimalDigit, "");

        if (d < 0)
            result = $"-{result}";

        if (MinDecimals > 0)
        {
            parts = result.Split(decimalDigit);
            if (parts.Length == 1 || parts[1].Length < MinDecimals)
                return double.Parse(result).ToString($"F{MinDecimals}");
        }

        return result;
    }

    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this double? d, int SignificantDigits, int MinDecimals = 0)
    {
        return ToSignificantDigits(d ?? 0.0D, SignificantDigits, MinDecimals);
    }

    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this decimal d, int SignificantDigits, int MinDecimals = 0)
    {
        return ToSignificantDigits((double)d, SignificantDigits, MinDecimals);
    }

    /// <summary>
    /// Retorna o número formatado na quantidade de algarismos significativos desejada.
    /// </summary>
    public static string ToSignificantDigits(this decimal? d, int SignificantDigits, int MinDecimals = 0)
    {
        return ToSignificantDigits((double)(d ?? 0.0M), SignificantDigits, MinDecimals);
    }


    /// <summary>
    /// Retorna o número por extenso.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="gender">Define se será escrito no mesculino (dois) ou feminino (duas).</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this short number, Gender gender = Gender.Masculino)
    {
        return ToWordsInternal(number, gender);
    }

    /// <summary>
    /// Retorna o número por extenso, em moeda.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="currency">A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this short number, Currency currency)
    {
        return ToWordsInternal(number, currency);
    }

    /// <summary>
    /// Retorna o número por extenso.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="gender">Define se será escrito no mesculino (dois) ou feminino (duas).</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this int number, Gender gender = Gender.Masculino)
    {
        return ToWordsInternal(number, gender);
    }

    /// <summary>
    /// Retorna o número por extenso, em moeda.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="currency">A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this int number, Currency currency)
    {
        return ToWordsInternal(number, currency);
    }

    /// <summary>
    /// Retorna o número por extenso.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="gender">Define se será escrito no mesculino (dois) ou feminino (duas).</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this long number, Gender gender = Gender.Masculino)
    {
        return ToWordsInternal(number, gender);
    }

    /// <summary>
    /// Retorna o número por extenso, em moeda.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="currency">A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this long number, Currency currency)
    {
        return ToWordsInternal(number, currency);
    }

    /// <summary>
    /// Retorna o número por extenso.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="gender">Define se será escrito no mesculino (dois) ou feminino (duas).</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this double number, Gender gender = Gender.Masculino)
    {
        return ToWordsInternal(Conversions.ToDecimal(number), gender);
    }

    /// <summary>
    /// Retorna o número por extenso, em moeda.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="currency">A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this double number, Currency currency)
    {
        return ToWordsInternal(Conversions.ToDecimal(number), currency);
    }

    /// <summary>
    /// Retorna o número por extenso.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="gender">Define se será escrito no mesculino (dois) ou feminino (duas).</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this decimal number, Gender gender = Gender.Masculino)
    {
        return ToWordsInternal(number, gender);
    }

    /// <summary>
    /// Retorna o número por extenso, em moeda.
    /// </summary>
    /// <param name="number">O número a ser escrito.</param>
    /// <param name="currency">A moeda a ser utilizada. Tipos suportados: Real Brasileiro, Dólar Americano e Euro.</param>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public static string ToWords(this decimal number, Currency currency)
    {
        return ToWordsInternal(number, currency);
    }


    private static string ToWordsInternal(decimal number, Gender gender = Gender.Masculino)
    {
        return GeraExtensoInternal(number, false, gender);
    }

    private static string ToWordsInternal(decimal number, Currency Currency)
    {
        return GeraExtensoInternal(number, true, Gender.Masculino, Currency);
    }

    private static readonly string[] unidades = new string[] { "Zero", "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove" };
    private static readonly string[] unidadesFem = new string[] { "Zero", "Uma", "Duas", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove" };
    private static readonly string[] dezenas1 = new string[] { "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove" };
    private static readonly string[] dezenas2 = new string[] { "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa" };
    private static readonly string[] centenas = new string[] { "Cem", "Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos" };
    private static readonly string[] centenasFem = new string[] { "Cem", "Cento", "Duzentas", "Trezentas", "Quatrocentas", "Quinhentas", "Seiscentas", "Setecentas", "Oitocentas", "Novecentas" };
    private static readonly string[] real_br = new string[] { "Real", "Reais", "Centavo", "Centavos" };
    private static readonly string[] dolar_us = new string[] { "Dólar", "Dólares", "Centavo", "Centavos" };
    private static readonly string[] euro_eu = new string[] { "Euro", "Euros", "Cêntimo", "Cêntimos" };
    private static readonly string[] naturais = new string[] { "Inteiro", "Inteiros", "Décimo", "Décimos", "Centésimo", "Centésimos" };
    private static readonly string[] naturaisFem = new string[] { "Inteira", "Inteiras", "Décima", "Décimas", "Centésima", "Centésimas" };

    private static string GeraExtensoInternal(decimal number, bool moeda, Gender genero, Currency tipoMoeda = Currency.Real_BRL)
    {
        var currency = tipoMoeda switch
        {
            Currency.Real_BRL => real_br,
            Currency.Dolar_USD => dolar_us,
            Currency.Euro_EUR => euro_eu,
            _ => throw new NotImplementedException()
        };
        var generoNaturais = genero switch
        {
            Gender.Masculino => naturais,
            Gender.Feminino => naturaisFem,
            _ => throw new NotImplementedException()
        };

        // variaveis
        number = Math.Abs(number);
        string numstr = "";
        int inteiros;
        int fracao;

        // separa a parte inteira da parte fracionaria
        inteiros = (int)Math.Truncate(number);
        fracao = Conversions.ToInteger((number - inteiros) * 100);

        // parte inteira
        var pluralIndex = 0;
        switch (inteiros.ToString().Trim().Length)
        {
            case var @case when @case <= 3: // centenas
                {
                    if (inteiros != 1)
                    {
                        numstr = GetNumberStringArray(inteiros, genero);
                        pluralIndex = 1;
                    }
                    else
                        numstr = GetNumberStringArray(inteiros, genero);

                    if (moeda == true)
                        numstr += $" {currency[pluralIndex]}"; // " Real[0] - Reais[1]"
                    else
                        numstr += $" {generoNaturais[pluralIndex]}"; // " Inteiro/a[0] - Inteiros/as[1]"
                    break;
                }

            case var case1 when case1 <= 6: // milhares
                {
                    int centenas, milhares;
                    decimal tmp = (decimal)(inteiros / (double)1000);
                    milhares = Conversions.ToInteger(tmp);
                    centenas = inteiros - milhares * 1000;
                    numstr = GetNumberStringArray(milhares, genero) + " Mil";
                    if (centenas < 101)
                    {
                        if (centenas > 0)
                            numstr = numstr + " e " + GetNumberStringArray(centenas, genero);
                    }
                    else if (centenas == 100 | centenas == 200 | centenas == 300 | centenas == 400 | centenas == 500 | centenas == 600 | centenas == 700 | centenas == 800 | centenas == 900)
                        numstr = numstr + " e " + GetNumberStringArray(centenas, genero);
                    else
                        numstr = numstr + ", " + GetNumberStringArray(centenas, genero);

                    if (moeda == true)
                        numstr += $" {currency[1]}"; // " Reais"
                    else
                        numstr += $" {generoNaturais[1]}"; // " Inteiros"
                    break;
                }

            case var case2 when case2 <= 9: // milhões
                {
                    int centenas, milhares, milhoes;
                    decimal tmp = (decimal)(inteiros / (double)1000000);
                    milhoes = Conversions.ToInteger(tmp);
                    tmp = (decimal)((inteiros - milhoes * 1000000) / (double)1000);
                    milhares = Conversions.ToInteger(tmp);
                    centenas = Conversions.ToInteger((tmp - milhares) * 1000);
                    if (milhoes == 1)
                    {
                        if (milhares == 0 & centenas == 0)
                        {
                            numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão";
                            if (moeda == true)
                                numstr += " de";
                        }
                        else if (milhares > 0 & centenas == 0)
                        {
                            if (milhares < 100)
                                numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão e ";
                            else if (milhares == 100 | milhares == 200 | milhares == 300 | milhares == 400 | milhares == 500 | milhares == 600 | milhares == 700 | milhares == 800 | milhares == 900)
                                numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão e ";
                            else
                                numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão, ";
                        }
                        else if (milhares == 0 & centenas > 0)
                        {
                            if (centenas < 100)
                                numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão";
                            else if (centenas == 100 | centenas == 200 | centenas == 300 | centenas == 400 | centenas == 500 | centenas == 600 | centenas == 700 | centenas == 800 | centenas == 900)
                                numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão e ";
                            else
                                numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão";
                        }
                        else if (milhares > 0 & centenas > 0)
                            numstr = GetNumberStringArray(milhoes, Gender.Masculino) + " Milhão, ";
                    }
                    else if (milhoes > 1)
                    {
                        if (milhares == 0 & centenas == 0)
                        {
                            numstr = GetNumberStringArray(milhoes, genero) + " Milhões";
                            if (moeda == true)
                            {
                                numstr += " de";
                            }
                        }
                        else if (milhares > 0 & centenas == 0)
                        {
                            if (milhares < 100)
                                numstr = GetNumberStringArray(milhoes, genero) + " Milhões e ";
                            else if (milhares == 100 | milhares == 200 | milhares == 300 | milhares == 400 | milhares == 500 | milhares == 600 | milhares == 700 | milhares == 800 | milhares == 900)
                                numstr = GetNumberStringArray(milhoes, genero) + " Milhões e ";
                            else
                                numstr = GetNumberStringArray(milhoes, genero) + " Milhões, ";
                        }
                        else if (milhares == 0 & centenas > 0)
                        {
                            if (centenas < 100)
                                numstr = GetNumberStringArray(milhoes, genero) + " Milhões";
                            else if (centenas == 100 | centenas == 200 | centenas == 300 | centenas == 400 | centenas == 500 | centenas == 600 | centenas == 700 | centenas == 800 | centenas == 900)
                                numstr = GetNumberStringArray(milhoes, genero) + " Milhões e ";
                            else
                                numstr = GetNumberStringArray(milhoes, genero) + " Milhões";
                        }
                        else if (milhares > 0 & centenas > 0)
                            numstr = GetNumberStringArray(milhoes, genero) + " Milhões, ";
                    }

                    if (milhares > 0)
                        numstr = numstr + GetNumberStringArray(milhares, genero) + " Mil";

                    if (centenas < 101)
                    {
                        if (centenas > 0)
                            numstr = numstr + " e " + GetNumberStringArray(centenas, genero);
                    }
                    else
                    {
                        if (!(centenas % 100 == 0))
                        {
                            numstr += ", ";
                        }
                        numstr += GetNumberStringArray(centenas, genero);
                    }

                    if (moeda == true)
                        numstr += $" {currency[1]}"; // " Reais"
                    else
                        numstr += $" {generoNaturais[1]}"; // " Inteiros"
                    break;
                }

            case var case3 when case3 <= 12: // bilhões
                {
                    numstr = "zzz...";
                    break;
                }

            case var case4 when case4 <= 15: // trilhões
                {
                    numstr = "chega né?...";
                    break;
                }
        }
        if (fracao == 0)
            numstr = numstr.Replace(generoNaturais[1], "").Replace(generoNaturais[0], "").Trim();

        // parte fracionaria
        if (fracao == 1)
        {
            if (moeda == true)
                numstr = numstr + " e " + GetNumberStringArray(fracao, Gender.Masculino) + $" {currency[2]}"; // " Centavo"
            else
                numstr = numstr + " e " + GetNumberStringArray(fracao, genero) + $" {generoNaturais[4]}"; // " Centésimo/a"
        }
        else if (fracao != 0)
        {
            if (moeda == true)
                numstr = numstr + " e " + GetNumberStringArray(fracao, Gender.Masculino) + $" {currency[3]}"; // " Centavos"
            else
            {
                if (fracao % 10 == 0)
                {
                    if (fracao == 10)
                        numstr = numstr + " e " + GetNumberStringArray(fracao / 10, genero) + $" {generoNaturais[2]}"; // " Décimo/a"
                    else
                        numstr = numstr + " e " + GetNumberStringArray(fracao / 10, genero) + $" {generoNaturais[3]}"; // " Décimos/as"
                }
                else
                {
                    numstr = numstr + " e " + GetNumberStringArray(fracao, genero) + $" {generoNaturais[5]}"; // " Centésimos/as"
                }
            }
        }
        // fim
        return numstr;
    }

    private static string GetNumberStringArray(int number, Gender gender)
    {
        int centena, dezena, unidade;
        string numstr = "";
        switch (number.ToString().Length)
        {
            case 1:
                {
                    switch (gender)
                    {
                        case Gender.Masculino:
                            {
                                numstr = unidades[number];
                                break;
                            }

                        case Gender.Feminino:
                            {
                                numstr = unidadesFem[number];
                                break;
                            }
                    }

                    break;
                }

            case 2:
                {
                    switch (number)
                    {
                        case var @case when @case < 20:
                            {
                                numstr = dezenas1[number - 10];
                                break;
                            }

                        case var case1 when case1 >= 20:
                            {
                                dezena = Conversions.ToInteger(number.ToString()[..1]);
                                unidade = Conversions.ToInteger(number.ToString().Substring(1, 1));
                                numstr = dezenas2[dezena - 2];
                                if (unidade > 0)
                                {
                                    numstr = numstr + " e " + unidades[unidade];
                                }

                                break;
                            }
                    }

                    break;
                }

            case 3:
                {
                    switch (number)
                    {
                        case 100:
                            {
                                switch (gender)
                                {
                                    case Gender.Masculino:
                                        {
                                            numstr = centenas[0];
                                            break;
                                        }

                                    case Gender.Feminino:
                                        {
                                            numstr = centenasFem[0];
                                            break;
                                        }
                                }

                                break;
                            }

                        case var case2 when case2 > 100:
                            {
                                centena = Conversions.ToInteger(number.ToString()[..1]);
                                dezena = Conversions.ToInteger(number.ToString().Substring(1, 1));
                                unidade = Conversions.ToInteger(number.ToString().Substring(2, 1));
                                switch (gender)
                                {
                                    case Gender.Masculino:
                                        {
                                            numstr = centenas[centena];
                                            break;
                                        }

                                    case Gender.Feminino:
                                        {
                                            numstr = centenasFem[centena];
                                            break;
                                        }
                                }

                                if (dezena > 0)
                                {
                                    switch (int.Parse(dezena.ToString() + unidade ?? ""))
                                    {
                                        case var case3 when case3 < 20:
                                            {
                                                numstr = numstr + " e " + dezenas1[Conversions.ToInteger(dezena.ToString() + unidade) - 10];
                                                break;
                                            }

                                        case var case4 when case4 >= 20:
                                            {
                                                numstr = numstr + " e " + dezenas2[dezena - 2];
                                                if (unidade > 0)
                                                {
                                                    numstr = numstr + " e " + unidades[unidade];
                                                }

                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    if (unidade > 0)
                                    {
                                        switch (gender)
                                        {
                                            case Gender.Masculino:
                                                {
                                                    numstr = numstr + " e " + unidades[unidade];
                                                    break;
                                                }

                                            case Gender.Feminino:
                                                {
                                                    numstr = numstr + " e " + unidadesFem[unidade];
                                                    break;
                                                }
                                        }
                                    }

                                }

                                break;
                            }
                    }

                    break;
                }
        }

        return numstr;
    }

    public enum Gender
    {
        Masculino = 0,
        Feminino = 1
    }

    public enum Currency
    {
        Real_BRL = 0,
        Dolar_USD = 1,
        Euro_EUR = 2
    }




}
