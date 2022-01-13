using EficazFramework.Configuration;
using EficazFramework.Providers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.Extensions;

[TestFixture(typeof(Providers.SqlLite))]
class DbContext<TProvider> where TProvider : DataProviderBase
{

    [SetUp]
    public void Setup()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
    }

    [TearDown]
    public void TearDown()
    {
        Resources.Mocks.MockDbContext ctx = new();
        ctx.Database.EnsureDeleted();
        ctx.Dispose();
        System.IO.File.Delete($"{DbConfiguration.SettingsPath}data_provider.json");
    }

    [Test]
    public async Task MigrationsTest()
    {
        Resources.Mocks.MockDbContext ctx = new();
        ctx.AllMigrationsApplied().Should().BeFalse();
        await ctx.Database.MigrateAsync();
        ctx.AllMigrationsApplied().Should().BeTrue();
    }
}
