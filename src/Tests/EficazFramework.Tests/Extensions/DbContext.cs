using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EficazFramework.Extensions;

class DbContext
{
    [Test]
    public void ExistsTest()
    {
        // InMemory
        var dbContext = new Resources.Mocks.MockDbContext();
        dbContext.Exists().Should().BeTrue();

        // SqlLite
        dbContext = new Resources.Mocks.MockDbContext(Providers.ConnectionProviders.SqlLite);
        dbContext.Exists().Should().BeFalse();
        dbContext.Database.EnsureCreated().Should().BeTrue();
        dbContext.Exists().Should().BeTrue();
        dbContext.AllMigrationsApplied().Should().BeTrue();
        dbContext.Blogs.Count().Should().Be(0);
        dbContext.Database.EnsureDeleted().Should().BeTrue();
    }

    [Test]
    public async Task ExistsAsyncTest()
    {
        // InMemory
        var dbContext = new Resources.Mocks.MockDbContext();
        (await dbContext.ExistsAsync()).Should().BeTrue();

        // SqlLite
        dbContext = new Resources.Mocks.MockDbContext(Providers.ConnectionProviders.SqlLite);
        (await dbContext.ExistsAsync()).Should().BeFalse();
        (await dbContext.Database.EnsureCreatedAsync()).Should().BeTrue();
        (await dbContext.ExistsAsync()).Should().BeTrue();
        (await dbContext.AllMigrationsAppliedAsync()).Should().BeTrue();
        (await dbContext.Blogs.CountAsync()).Should().Be(0);
        (await dbContext.Database.EnsureDeletedAsync()).Should().BeTrue();
    }


}
