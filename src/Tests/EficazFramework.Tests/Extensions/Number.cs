using FluentAssertions;
using NUnit.Framework;

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

}
