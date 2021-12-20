using System;

namespace EficazFramework.Extensions;

public static class FinancialExtensions
{
    public enum ReturnType
    {
        Juros = 0,
        Montante = 1
    }

    public enum Capitalizacao
    {
        JurosSimples = 0,
        JurosCompostos = 1
    }

    public enum PeriodoCapitalizacao
    {
        Diario = 0,
        Semanal = 1,
        Mensal = 2,
        Anual = 3
    }

    /// <summary>
    /// Calcula os juros sobre um capital, a uma taxa e período desejado.
    /// NOTA: periodo e taxa devem estar na mesma unidade de tempo (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="taxa">A taxa de juros a ser aplicada.</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="retorno">Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaJuros(this double capital, double taxa, int periodo, ReturnType retorno = ReturnType.Montante, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double resultado = tipo switch
        {
            Capitalizacao.JurosCompostos => retorno switch
            {
                ReturnType.Juros => (capital * Math.Pow(1 + (taxa / 100), periodo)) - capital,
                _ => capital * Math.Pow(1 + (taxa / 100), periodo)
            },
            _ => retorno switch
            {
                ReturnType.Juros => capital * (taxa / 100) * periodo,
                _ => capital * (1 + (taxa / 100 * periodo))
            }
        };

        if (rounding <= -1)
            return resultado;
        else
            return Math.Round(resultado, rounding);
    }

    /// <summary>
    /// Calcula os juros sobre um capital, a uma taxa e período desejado.
    /// NOTA: periodo e taxa devem estar na mesma unidade de tempo (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="taxa">A taxa de juros a ser aplicada.</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="retorno">Montante: Retorna o valor do capital corrigido. Juros: Retorna apenas o valor dos juros calculados.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaJuros(this double? capital, double taxa, int periodo, ReturnType retorno = ReturnType.Montante, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double cap = capital ?? 0D;
        return cap.CalculaJuros(taxa, periodo, retorno, tipo, rounding);
    }

    /// <summary>
    /// Calcula a taxa de juros de uma operação com base no capital aplicado em um período desejado.
    /// NOTA: A taxa retornada será referente à unidade de tempo do período (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="montante">O montante final (valor agregado) (capital + juros).</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaTaxa(this double capital, double montante, int periodo, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double resultado = tipo switch
        {
            Capitalizacao.JurosCompostos => (Math.Pow(montante / capital, 1D / periodo) - 1D) * 100D,
            _ => capital * periodo / (montante - capital) / 100D
        };

        if (rounding <= -1)
            return resultado;
        else
            return Math.Round(resultado, rounding);
    }

    /// <summary>
    /// Calcula a taxa de juros de uma operação com base no capital aplicado em um período desejado.
    /// NOTA: A taxa retornada será referente à unidade de tempo do período (ao dia, ao mês, etc).
    /// </summary>
    /// <param name="capital">O capital base para cálculo.</param>
    /// <param name="montante">O montante final (valor agregado) (capital + juros).</param>
    /// <param name="periodo">O período a ser aplicado.</param>
    /// <param name="tipo">Juros Simples ou Juros Compostos.</param>
    /// <param name="rounding">Número de casas decimais para arredondamento. Use -1 para não usar arredondamento.</param>
    /// <returns>Double</returns>
    /// <remarks></remarks>
    public static double CalculaTaxa(this double? capital, double montante, int periodo, Capitalizacao tipo = Capitalizacao.JurosSimples, int rounding = -1)
    {
        double cap = capital ?? 0D;
        return cap.CalculaTaxa(montante, periodo, tipo, rounding);
    }


}
