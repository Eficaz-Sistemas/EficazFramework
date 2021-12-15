using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.Extensions;

class DbContext
{
    [Test]
    public void ExistsTest()
    {
        var dbContext = new Resources.Mocks.InMemoryDbContext();
        dbContext.Exists().Should().BeTrue();
    }

    [Test]
    public async Task ExistsAsyncTest()
    {
        var dbContext = new Resources.Mocks.InMemoryDbContext();
        (await dbContext.ExistsAsync()).Should().BeTrue();
    }


}
