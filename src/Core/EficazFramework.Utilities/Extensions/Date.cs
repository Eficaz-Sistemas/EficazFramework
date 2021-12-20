using System;

namespace EficazFramework.Extensions;

public static class DateExtensions
{

    /// <summary>
    /// Retorna o número de dias úteis entre duas datas.
    /// </summary>
    /// <param name="StartDate">A data inicial para análise.</param>
    /// <param name="FinalDate">A data final para análise.</param>
    /// <param name="ConsiderSaturday">Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.</param>
    /// <returns>Integer</returns>
    /// <remarks></remarks>
    public static int BusinessDayInterval(this DateTime StartDate, DateTime FinalDate, bool ConsiderSaturday = false)
    {
        int result = 0;
        var current = StartDate.AddDays(1);
        while (current <= FinalDate)
        {
            if (current.IsBusinessDay(ConsiderSaturday))
            {
                result += 1;
            }

            current = current.AddDays(1);
        }

        return result;
    }

    /// <summary>
    /// Analise se uma data qualquer se trata de um dia útil ou não.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <param name="ConsiderSaturday">Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.</param>
    /// <returns>Boolean</returns>
    /// <remarks></remarks>
    public static bool IsBusinessDay(this DateTime BaseDate, bool ConsiderSaturday = false)
    {
        return BaseDate.DayOfWeek switch
        {
            DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday or DayOfWeek.Friday => true,
            DayOfWeek.Saturday => ConsiderSaturday,
            _ => false
        };
    }

    /// <summary>
    /// Retorna a primeira data disponível para um mês e ano determinado.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <param name="BussinessDay">Define se a data inicial do mês e ano desejado deve ser um dia útil. Por padrão não precisa ser.</param>
    /// <param name="ConsiderSaturday">Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DateTime MonthStartDate(this DateTime BaseDate, bool BussinessDay = false, bool ConsiderSaturday = false)
    {
        if (BussinessDay == false)
        {
            return new DateTime(BaseDate.Year, BaseDate.Month, 1, 0, 0, 0);
        }
        else
        {
            return new DateTime(BaseDate.Year, BaseDate.Month, 1, 0, 0, 0).ToBusinessDay(true, ConsiderSaturday);
        }
    }

    /// <summary>
    /// Retorna a primeira data disponível para um mês e ano determinado.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <param name="BussinessDay">Define se a data inicial do mês e ano desejado deve ser um dia útil. Por padrão não precisa ser.</param>
    /// <param name="ConsiderSaturday">Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.</param>
    /// <param name="UseTime235959">Define se a data deve ser retornada com Timespan 23:59:59.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DateTime MonthEndDate(this DateTime BaseDate, bool BussinessDay = false, bool ConsiderSaturday = false, bool UseTime235959 = false)
    {
        DateTime tmp_date = BaseDate.Month switch
        {
            1 or 3 or 5 or 7 or 8 or 10 or 12 => !UseTime235959 ? new DateTime(BaseDate.Year, BaseDate.Month, 31) : new DateTime(BaseDate.Year, BaseDate.Month, 31, 23, 59, 59),
            4 or 6 or 9 or 11 => !UseTime235959 ? new DateTime(BaseDate.Year, BaseDate.Month, 30) : new DateTime(BaseDate.Year, BaseDate.Month, 30, 23, 59, 59),
            _ => MonthEndDateFebruary(BaseDate, UseTime235959)
        };

        if (BussinessDay == false)
            return tmp_date;
        else
            return tmp_date.ToBusinessDay(false, ConsiderSaturday);
    }

    private static DateTime MonthEndDateFebruary(DateTime baseDate, bool UseTime235959 = false)
    {
        try
        {
            if (UseTime235959 == false)
                return new DateTime(baseDate.Year, baseDate.Month, 29);
            else
                return new DateTime(baseDate.Year, baseDate.Month, 29, 23, 59, 59);
        }
        catch (Exception)
        {
            if (UseTime235959 == false)
                return new DateTime(baseDate.Year, baseDate.Month, 28);
            else
                return new DateTime(baseDate.Year, baseDate.Month, 28, 23, 59, 59);
        }

    }

    /// <summary>
    /// Retorna a primeira data disponível para um ano determinado.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <param name="BussinessDay">Define se a data inicial do ano desejado deve ser um dia útil. Por padrão não precisa ser.</param>
    /// <param name="ConsiderSaturday">Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DateTime YearStartDate(this DateTime BaseDate, bool BussinessDay = false, bool ConsiderSaturday = false)
    {
        DateTime tmp_date;
        tmp_date = new DateTime(BaseDate.Year, 1, 1, 0, 0, 0);
        if (BussinessDay == false)
        {
            return tmp_date;
        }
        else
        {
            tmp_date = tmp_date.ToBusinessDay(false, ConsiderSaturday);
            if (tmp_date.Year != BaseDate.Year)
            {
                tmp_date = new DateTime(BaseDate.Year, 1, 1, 0, 0, 0).ToBusinessDay(true, ConsiderSaturday);
            }
            return tmp_date.ToBusinessDay(false, ConsiderSaturday);
        }
    }

    /// <summary>
    /// Retorna a última data disponível para um ano determinado.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <param name="BussinessDay">Define se a data final do ano desejado deve ser um dia útil. Por padrão não precisa ser.</param>
    /// <param name="ConsiderSaturday">Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DateTime YearEndDate(this DateTime BaseDate, bool BussinessDay = false, bool ConsiderSaturday = false, bool UseTime235959 = false)
    {
        DateTime tmp_date;
        if (UseTime235959 == false)
            tmp_date = new DateTime(BaseDate.Year, 12, 31);
        else
            tmp_date = new DateTime(BaseDate.Year, 12, 31, 23, 59, 59);
        if (BussinessDay == false)
        {
            return tmp_date;
        }
        else
        {
            return tmp_date.ToBusinessDay(false, ConsiderSaturday);
        }
    }

    /// <summary>
    /// Retorna uma dia útil posterior ou retroativo mais próximo da data desejada.
    /// </summary>
    /// <param name="BaseDate">A data a ser analisada.</param>
    /// <param name="NextDate">Define se a data deve ser posterior ou retroativa. Por padrão será posterior.</param>
    /// <param name="ConsiderSaturday">Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.</param>
    /// <returns>Date</returns>
    /// <remarks></remarks>
    public static DateTime ToBusinessDay(this DateTime BaseDate, bool NextDate = true, bool ConsiderSaturday = false)
    {
        if (BaseDate.IsBusinessDay(ConsiderSaturday) == true)
        {
            return BaseDate;
        }
        else
        {
            return BaseDate.DayOfWeek switch
            {
                DayOfWeek.Saturday => NextDate ? BaseDate.AddDays(2) : BaseDate.AddDays(-1),
                DayOfWeek.Sunday => NextDate ? BaseDate.AddDays(1) : (ConsiderSaturday ? BaseDate.AddDays(-1) : BaseDate.AddDays(-2)),
                _ => BaseDate
            };
        }
    }
}

public enum DateInterval
{
    Year = 0,
    Quarter = 1,
    Month = 2,
    DayOfYear = 3,
    Day = 4,
    WeekOfYear = 5,
    Weekday = 6,
    Hour = 7,
    Minute = 8,
    Second = 9
}

public enum FirstDayOfWeek
{
    System = 0,
    Sunday = 1,
    Monday = 2,
    Tuesday = 3,
    Wednesday = 4,
    Thursday = 5,
    Friday = 6,
    Saturday = 7
}

public enum FirstWeekOfYear
{
    System = 0,
    Jan1 = 1,
    FirstFourDays = 2,
    FirstFullWeek = 3
}