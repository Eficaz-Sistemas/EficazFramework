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
    }

}