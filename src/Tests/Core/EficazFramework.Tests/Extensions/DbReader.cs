using EficazFramework.Configuration;
using EficazFramework.Providers;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        _serviceCollection.AddDbConfig();
        _serviceCollection.AddScoped<DataProviderBase, TProvider>();
        _provider = _serviceCollection.BuildServiceProvider();
        Resources.Mocks.MockDbContext dbContext = new(_provider.GetService<DataProviderBase>());
        dbContext.Database.EnsureCreated();

        // seed
        for (int i = 0; i < 99; i++)
        {
            dbContext.Add(new Resources.Mocks.Classes.Blog()
            {
                Id = System.Guid.NewGuid(),
                Name = $"Blog {i}"
            });
        }
        dbContext.Add(new Resources.Mocks.Classes.Blog()
        {
            Id = System.Guid.NewGuid(),
            Name = null
        });
        dbContext.SaveChanges();
        dbContext.Dispose();
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
        Resources.Mocks.MockDbContext dbContext = new(_provider.GetService<DataProviderBase>());
        List<Resources.Mocks.Classes.Blog> list = new();
        System.Data.Common.DbCommand cmd = null;
        DataProviderBase provider = _provider.GetService<DataProviderBase>();

        // assert
        if (provider.Name == "InMemory")
        {
            query.CommandText(provider).Should().Be("SELECT * FROM InMemory.Blogs");
            return;
        }

        cmd =  query.CreateCommand(dbContext, provider);
        cmd.CommandText.Should().Be($"SELECT * FROM Blogs WHERE Name = @name");


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
        await cmd.Connection.CloseAsync();
        list.Should().HaveCount(1);
    }

    [Test]
    public async Task ReadTest2()
    {
        // query spces
        TestQuery query = new();
        query.Name = "Blog 1";

        // some aditional setup
        Resources.Mocks.MockDbContext dbContext = new(_provider.GetService<DataProviderBase>());
        List<Resources.Mocks.Classes.Blog> list = new();
        System.Data.Common.DbCommand cmd = null;
        DataProviderBase provider = _provider.GetService<DataProviderBase>();

        // assert
        if (provider.Name == "InMemory")
        {
            query.CommandText(provider).Should().Be("SELECT * FROM InMemory.Blogs");
            return;
        }

        cmd = await query.CreateCommandAsync(dbContext, provider);
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
        await cmd.Connection.CloseAsync();
        list.Should().HaveCount(1);
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
            "InMemory" => "SELECT * FROM InMemory.Blogs",
            "SqlLite" => "SELECT * FROM Blogs WHERE Name = @name",
            "MsSqlServer" => "SELECT * FROM Blogs WHERE Name = @name",
            _ => null
        };
    }
}
