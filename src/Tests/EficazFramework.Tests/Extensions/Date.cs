using FluentAssertions;
using NUnit.Framework;
using EficazFramework.Extensions;
using System;

namespace EficazFramework.Extensions;

class Date
{
    private readonly DateTime any17Date = new(2017, 05, 15, 0, 0, 0);
    private readonly DateTime may21Date = new(2021, 05, 15, 0, 0, 0);
    private readonly DateTime july21Date = new(2021, 07, 15, 0, 0, 0);
    private readonly DateTime august21Date = new(2021, 08, 15, 0, 0, 0);
    private readonly DateTime october21Date = new(2021, 10, 15, 0, 0, 0);
    private readonly DateTime start = new(2021, 11, 26, 0, 0, 0);
    private readonly DateTime saturday = new(2021, 11, 27, 0, 0, 0);
    private readonly DateTime end = new(2021, 11, 30, 0, 0, 0);
    private readonly DateTime any22Date = new(2022, 05, 15, 0, 0, 0);


    [Test]
    public void BusinessDay()
    {
        //BusinessDayInterval
        start.BusinessDayInterval(end).Should().Be(2);
        start.BusinessDayInterval(end, true).Should().Be(3);

        //IsBusinessDay
        start.AddDays(1).IsBusinessDay().Should().BeFalse();
        start.AddDays(1).IsBusinessDay(true).Should().BeTrue();

        //ToBusinessDay
        saturday.ToBusinessDay().Should().Be(end.AddDays(-1));
        saturday.ToBusinessDay(false).Should().Be(start);
        saturday.ToBusinessDay(true, true).Should().Be(saturday);
        saturday.ToBusinessDay(false, true).Should().Be(saturday);
        saturday.AddDays(1).ToBusinessDay(false, true).Should().Be(saturday);
    }

    [Test]
    public void Month()
    {
        //MonthStartDate
        may21Date.MonthStartDate().Should().Be(new DateTime(2021, 05, 01, 0, 0, 0));
        may21Date.MonthStartDate(true).Should().Be(new DateTime(2021, 05, 03, 0, 0, 0));
        may21Date.MonthStartDate(true, true).Should().Be(new DateTime(2021, 05, 01, 0, 0, 0));
        august21Date.MonthStartDate().Should().Be(new DateTime(2021, 08, 01, 0, 0, 0));
        august21Date.MonthStartDate(true).Should().Be(new DateTime(2021, 08, 02, 0, 0, 0));
        august21Date.MonthStartDate(true, true).Should().Be(new DateTime(2021, 08, 02, 0, 0, 0));
        start.MonthStartDate().Should().Be(new DateTime(2021, 11, 01, 0, 0, 0));
        start.MonthStartDate(true).Should().Be(new DateTime(2021, 11, 01, 0, 0, 0));
        start.MonthStartDate(true, true).Should().Be(new DateTime(2021, 11, 01, 0, 0, 0));

        //MonthEndDate
        july21Date.MonthEndDate().Should().Be(new DateTime(2021, 07, 31, 0, 0, 0));
        july21Date.MonthEndDate(true).Should().Be(new DateTime(2021, 07, 30, 0, 0, 0));
        july21Date.MonthEndDate(true, true).Should().Be(new DateTime(2021, 07, 31, 0, 0, 0));
        july21Date.MonthEndDate(false, false, true).Should().Be(new DateTime(2021, 07, 31, 23, 59, 59));
        october21Date.MonthEndDate().Should().Be(new DateTime(2021, 10, 31, 0, 0, 0));
        october21Date.MonthEndDate(true).Should().Be(new DateTime(2021, 10, 29, 0, 0, 0));
        october21Date.MonthEndDate(true, true).Should().Be(new DateTime(2021, 10, 30, 0, 0, 0));
        new DateTime(2021, 11, 01).MonthEndDate().Should().Be(new DateTime(2021, 11, 30, 0, 0, 0));
        new DateTime(2021, 11, 01).MonthEndDate(true).Should().Be(new DateTime(2021, 11, 30, 0, 0, 0));
        new DateTime(2021, 11, 01).MonthEndDate(true, true).Should().Be(new DateTime(2021, 11, 30, 0, 0, 0));
        new DateTime(2021, 11, 01).MonthEndDate(true, true, true).Should().Be(new DateTime(2021, 11, 30, 23, 59, 59));
    }

    [Test]
    public void Year()
    {
        //YearStartDate
        any22Date.YearStartDate().Should().Be(new DateTime(2022, 01, 01, 0, 0, 0));
        any22Date.YearStartDate(true).Should().Be(new DateTime(2022, 01, 03, 0, 0, 0));
        any22Date.YearStartDate(true, true).Should().Be(new DateTime(2022, 01, 01, 0, 0, 0));

        //YearEndDate
        any17Date.YearEndDate().Should().Be(new DateTime(2017, 12, 31, 0, 0, 0));
        any17Date.YearEndDate(true).Should().Be(new DateTime(2017, 12, 29, 0, 0, 0));
        any17Date.YearEndDate(true, true).Should().Be(new DateTime(2017, 12, 30, 0, 0, 0));
        any17Date.YearEndDate(false, false, true).Should().Be(new DateTime(2017, 12, 31, 23, 59, 59));
    }

}
