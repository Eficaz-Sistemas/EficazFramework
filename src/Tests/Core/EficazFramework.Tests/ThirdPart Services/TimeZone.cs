using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.ThirdPart;

public class TimeZoneTests
{

    [Test]
    public async Task CallApi()
    {
        var result = await TimeZone.Now();
        (result as DateTime?).Should().NotBeNull();

        result = await TimeZone.Now("no place...");
        (result as DateTime?).Value.Date.Should().Be(DateTime.Now.Date);

        result = await TimeZone.Now("");
        (result as DateTime?).Value.Date.Should().Be(DateTime.Now.Date);

        result = await TimeZone.Now(null);
        (result as DateTime?).Value.Date.Should().Be(DateTime.Now.Date);
    }

}