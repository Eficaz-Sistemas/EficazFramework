using FluentAssertions;
using NUnit.Framework;
using EficazFramework.Extensions;
using System;

namespace EficazFramework.Extensions;

class Financial
{

    [Test]
    public void CalculaJuros()
    {
        // Simples
        1000D.CalculaJuros(1D, 2, FinancialExtensions.ReturnType.Juros).Should().Be(20D);
        1000D.CalculaJuros(1D, 2, FinancialExtensions.ReturnType.Montante).Should().Be(1020D);

        // Compostos
        1000D.CalculaJuros(1D, 2, FinancialExtensions.ReturnType.Juros, FinancialExtensions.Capitalizacao.JurosCompostos).Should().Be(20.100000000000023D);
        1000D.CalculaJuros(1D, 2, FinancialExtensions.ReturnType.Montante, FinancialExtensions.Capitalizacao.JurosCompostos).Should().Be(1020.100000000000023D);
        1000D.CalculaJuros(1D, 2, FinancialExtensions.ReturnType.Juros, FinancialExtensions.Capitalizacao.JurosCompostos, 2).Should().Be(20.1D);
        1000D.CalculaJuros(1D, 2, FinancialExtensions.ReturnType.Montante, FinancialExtensions.Capitalizacao.JurosCompostos, 2).Should().Be(1020.1D);
    }

    [Test]
    public void CalculaTaxa()
    {
        // Simples
        1000D.CalculaTaxa(1020D, 2, FinancialExtensions.Capitalizacao.JurosSimples).Should().Be(1D);

    }

}
