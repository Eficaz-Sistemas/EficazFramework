using FluentAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.Extensions;

class Number
{
    [Test]
    public void ToWords()
    {
        //currency - reais
        (1102385.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um milhão, cento e dois mil, trezentos e oitenta e cinco reais e noventa e cinco centavos");
        (1000000.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um milhão de reais e noventa e cinco centavos");
        (1300000.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um milhão e trezentos mil reais e noventa e cinco centavos");
        (1000500.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um milhão e quinhentos reais e noventa e cinco centavos");
        (2000000.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois milhões de reais e noventa e cinco centavos");
        (2300000.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois milhões e trezentos mil reais e noventa e cinco centavos");
        (2000500.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois milhões e quinhentos reais e noventa e cinco centavos");
        (2385.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais e noventa e cinco centavos");
        (2385.95D.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais e noventa e cinco centavos");
        (2385.95M.ToWords(NumberExtensions.Currency.Dolar_USD) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco dólares e noventa e cinco centavos");
        (2385.95M.ToWords(NumberExtensions.Currency.Euro_EUR) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco euros e noventa e cinco cêntimos");
        (2385.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais");
        (2100.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil e cem reais");
        (300.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("trezentos reais");
        (257.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("duzentos e cinquenta e sete reais");
        (33.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("trinta e três reais");
        (19.1.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dezenove reais e dez centavos");
        (19.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dezenove reais");
        (1.9.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real e noventa centavos");
        (1.9.ToWords(NumberExtensions.Currency.Dolar_USD) ?? "").ToLower().Should().Be("um dólar e noventa centavos");
        (1.9.ToWords(NumberExtensions.Currency.Euro_EUR) ?? "").ToLower().Should().Be("um euro e noventa cêntimos");
        (1.01.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real e um centavo");
        (1.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real");
        (((long)1).ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real");
        (((short)1).ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real");

        // masculino
        (1102385.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um milhão, cento e dois mil, trezentos e oitenta e cinco inteiros e noventa e cinco centésimos");
        (1000000.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um milhão inteiros e noventa e cinco centésimos");
        (1300000.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um milhão e trezentos mil inteiros e noventa e cinco centésimos");
        (1000500.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um milhão e quinhentos inteiros e noventa e cinco centésimos");
        (2000000.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois milhões inteiros e noventa e cinco centésimos");
        (2300000.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois milhões e trezentos mil inteiros e noventa e cinco centésimos");
        (2000500.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois milhões e quinhentos inteiros e noventa e cinco centésimos");
        (2385.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco inteiros e noventa e cinco centésimos");
        (2385.95D.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco inteiros e noventa e cinco centésimos");
        (2385.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco");
        (2100.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil e cem");
        (300.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("trezentos");
        (257.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("duzentos e cinquenta e sete");
        (33.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("trinta e três");
        (19.1.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dezenove inteiros e um décimo");
        (19.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dezenove");
        (1.9.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um inteiro e nove décimos");
        (1.01.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um inteiro e um centésimo");
        (1.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um");
        (((long)1).ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um");
        (((short)1).ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um");

        // feminimo
        (1102385.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("um milhão, cento e duas mil, trezentas e oitenta e cinco inteiras e noventa e cinco centésimas");
        (1000000.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("um milhão inteiras e noventa e cinco centésimas");
        (1300000.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("um milhão e trezentas mil inteiras e noventa e cinco centésimas");
        (1000500.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("um milhão e quinhentas inteiras e noventa e cinco centésimas");
        (2000000.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas milhões inteiras e noventa e cinco centésimas");
        (2300000.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas milhões e trezentas mil inteiras e noventa e cinco centésimas");
        (2000500.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas milhões e quinhentas inteiras e noventa e cinco centésimas");
        (2385.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil, trezentas e oitenta e cinco inteiras e noventa e cinco centésimas");
        (2385.95D.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil, trezentas e oitenta e cinco inteiras e noventa e cinco centésimas");
        (2385.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil, trezentas e oitenta e cinco");
        (2100.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil e cem");
        (300.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("trezentas");
        (257.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duzentas e cinquenta e sete");
        (33.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("trinta e três");
        (19.1.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("dezenove inteiras e uma décima");
        (19.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("dezenove");
        (1.9.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma inteira e nove décimas");
        (1.01.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma inteira e uma centésima");
        (1.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma");
        (((long)1).ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma");
        (((short)1).ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma");
    }

    [Test]
    public void ToSignificantDigits()
    {
        0.00453D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.0045300");
        0.0453D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.045300");
        0.453D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.45300");
        4.53D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("4.5300");
        45.3D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("45.300");
        453D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("453.00");
        4530D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("4530.0");
        45300D.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("45300");

        0.00453D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.0045300");
        0.0453D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.045300");
        0.453D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.45300");
        4.53D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("4.5300");
        45.3D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("45.300");
        453D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("453.00");
        4530D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("4530.00");
        45300D.ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("45300.00");

        (-0.00453D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-0.0045300");
        (-0.0453D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-0.045300");
        (-0.453D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-0.45300");
        (-4.53D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-4.5300");
        (-45.3D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-45.300");
        (-453D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-453.00");
        (-4530D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-4530.00");
        (-45300D).ToSignificantDigits(5, 2).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("-45300.00");

        double? number = null;
        number.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.00000");
   
        4.53M.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("4.5300");
        
        decimal? numberDec = null;
        numberDec.ToSignificantDigits(5).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".").Should().Be("0.00000");

    }

}
