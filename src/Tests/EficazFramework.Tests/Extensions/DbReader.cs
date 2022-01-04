﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EficazFramework.Extensions;

class DbReader
{
    [Test]
    public async Task ReadTest()
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
        query.MsSqlCommandText.Should().Be("SELECT A");
        query.OracleCommandText.Should().Be("SELECT C");
        query.MySqlCommandText.Should().Be("SELECT B");

        // assert
        List<Resources.Mocks.Classes.Blog> list = new();
        System.Data.Common.DbCommand cmd = null;

        // mock
        EficazFramework.Configuration.DbConfiguration.Instance.Provider = Providers.ConnectionProviders.MsSQL;
        cmd = await query.CreateCommandAsync(dbContext);
        cmd.CommandText.Should().Be(query.MsSqlCommandText);
        EficazFramework.Configuration.DbConfiguration.Instance.Provider = Providers.ConnectionProviders.MySQL;
        cmd = await query.CreateCommandAsync(dbContext);
        cmd.CommandText.Should().Be(query.MySqlCommandText);
        EficazFramework.Configuration.DbConfiguration.Instance.Provider = Providers.ConnectionProviders.Oracle;
        cmd = await query.CreateCommandAsync(dbContext);
        cmd.CommandText.Should().Be(query.OracleCommandText);

        // real
        EficazFramework.Configuration.DbConfiguration.Instance.Provider = Providers.ConnectionProviders.SqlLite;
        cmd = await query.CreateCommandAsync(dbContext);
        query.CreateCommand(dbContext).Connection.ConnectionString.Should().Be(cmd.Connection.ConnectionString);
        cmd.CommandText.Should().Be(query.SqlLiteCommandText);

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

        // delete
        dbContext.Dispose();
        dbContext = new Resources.Mocks.MockDbContext(Providers.ConnectionProviders.SqlLite);
        (await dbContext.Database.EnsureDeletedAsync()).Should().BeTrue();

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
    public override string MsSqlCommandText => "SELECT A";

    public override string SqlLiteCommandText => "SELECT * FROM Blogs WHERE Name = @name";

    public override string MySqlCommandText => "SELECT B";

    public override string OracleCommandText => "SELECT C";

    public TestQuery()
    {
        Parameters.Add("@name", () => Name);
    }

    public string Name { get; set; } = "Blog 1";
}
