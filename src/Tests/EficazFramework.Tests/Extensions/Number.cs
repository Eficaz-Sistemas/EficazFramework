using FluentAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.Extensions;

class Number
{
    [Test]
    public void ToWords()
    {
        //currency
        (2385.95M.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais e noventa e cinco centavos");
        (2385.95D.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais e noventa e cinco centavos");
        (2385.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais");
        (2100.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil e cem reais");
        (1.9.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real e noventa centavos");
        (1.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real");
        (((long)1).ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real");

        // masculino
        (2385.95M.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco inteiros e noventa e cinco centésimos");
        (2385.95D.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco inteiros e noventa e cinco centésimos");
        (2385.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco");
        (2100.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("dois mil e cem");
        (1.9.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um inteiro e nove décimos");
        (1.ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um");
        (((long)1).ToWords(NumberExtensions.Gender.Masculino) ?? "").ToLower().Should().Be("um");

        // feminimo
        (2385.95M.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil, trezentas e oitenta e cinco inteiras e noventa e cinco centésimas");
        (2385.95D.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil, trezentas e oitenta e cinco inteiras e noventa e cinco centésimas");
        (2385.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil, trezentas e oitenta e cinco");
        (2100.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("duas mil e cem");
        (1.9.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma inteira e nove décimas");
        (1.ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma");
        (((long)1).ToWords(NumberExtensions.Gender.Feminino) ?? "").ToLower().Should().Be("uma");
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
