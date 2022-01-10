using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EficazFramework.Configuration;
using EficazFramework.Providers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace EficazFramework.Extensions;

[TestFixture(typeof(Providers.InMemory))]
[TestFixture(typeof(Providers.SqlLite))]
class DbReader<TProvider> where TProvider : DataProviderBase
{
    IServiceCollection _serviceCollection = null;
    IServiceProvider _provider = null;

    [SetUp]
    public void Setup()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        _serviceCollection = new ServiceCollection();
        _serviceCollection.AddScoped<IDbConfig, DbConfiguration>();
        _serviceCollection.AddScoped<DataProviderBase, TProvider>();
        _provider = _serviceCollection.BuildServiceProvider();

        Resources.Mocks.MockDbContext dbContext = new(_provider.GetService<IDbConfig>());
        dbContext.Database.EnsureCreated().Should().BeTrue();

        // seed
        for (int i = 0; i < 100; i++)
        {
            dbContext.Add(new Resources.Mocks.Classes.Blog()
            {
                Id = System.Guid.NewGuid(),
                Name = $"Blog {i}"
            });
        }
        dbContext.SaveChanges();
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
    public async Task ReadTest()
    {

        // query spces
        TestQuery query = new();

        // some aditional setup
        Resources.Mocks.MockDbContext dbContext = new(_provider.GetService<IDbConfig>());
        List<Resources.Mocks.Classes.Blog> list = new();
        System.Data.Common.DbCommand cmd = null;
        DataProviderBase provider = _provider.GetService<DataProviderBase>();

        // assert
        cmd =  query.CreateCommand(dbContext, provider);
        cmd.CommandText.Should().Be($"SELECT * FROM {provider.Name}");

        if (provider.Name == "InMemory")
            return;

        await cmd.Connection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();
        list.AddRange(reader.SelectFromReader((r) =>
        {
            return new Resources.Mocks.Classes.Blog()
            {
                Id = r.GetValue<System.Guid>("Id"),
                Name = r.GetValue<string>("Name"),
            };
        }));
        list.Should().HaveCount(1);
    }

    [Test]
    public async Task ReadTest2()
    {
        Resources.Mocks.MockDbContext dbContext = new(Providers.ConnectionProviders.SqlLite);
        dbContext.Database.EnsureCreated().Should().BeTrue();

        // seed
        for (int i = 0; i < 100; i++)
        {
            dbContext.Add(new Resources.Mocks.Classes.Blog()
            {
                Id = System.Guid.NewGuid(),
                Name = $"Blog {i}"
            });
        }
        await dbContext.SaveChangesAsync();

        // query spces
        TestQuery query = new();


        // assert
        List<Resources.Mocks.Classes.Blog> list = new();
        var cmd = await query.CreateCommandAsync(dbContext);
        query.CreateCommand(dbContext).Connection.ConnectionString.Should().Be(cmd.Connection.ConnectionString);
        cmd.CommandText = query.SqlLiteCommandText;
        await cmd.Connection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();
        list.AddRange(reader.SelectFromReader((r) =>
        {
            return new Resources.Mocks.Classes.Blog()
            {
                Id = r.GetValue<System.Guid>(0),
                Name = r.GetValue<string>(1),
            };
        }));
        list.Should().HaveCount(1);

        // delete
        dbContext.Dispose();
        dbContext = new Resources.Mocks.MockDbContext(Providers.ConnectionProviders.SqlLite);
        (await dbContext.Database.EnsureDeletedAsync()).Should().BeTrue();

    }


}

internal class TestQuery : EficazFramework.Repositories.Services.QueryBase
{
    public TestQuery()
    {
        Parameters.Add("@name", () => Name);
    }

    public string Name { get; set; } = "Blog 1";

    public override string CommandText(DataProviderBase provider)
    {
        return provider.Name switch
        {
            "InMemory" => "SELECT * FROM InMemory",
            "SqlLite" => "SELECT * FROM SqlLite",
            "MsSqlServer" => "SELECT * FROM MsSqlServer",
            _ => null
        };
    }
}
