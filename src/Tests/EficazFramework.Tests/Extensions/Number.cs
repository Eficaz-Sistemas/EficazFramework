using FluentAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.Extensions;

class Number
{
    [Test]
    public void ToWords()
    {
        (2385.95.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais e noventa e cinco centavos");
        (2385.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("dois mil, trezentos e oitenta e cinco reais");
        (1.9.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real e noventa centavos");
        (1.ToWords(NumberExtensions.Currency.Real_BRL) ?? "").ToLower().Should().Be("um real");
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

    }

}
