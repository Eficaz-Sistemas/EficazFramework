using EficazFramework.Configuration;
using AwesomeAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace EficazFramework.Providers;

public class ServiceProviderTests
{
    [SetUp]
    public void Setup()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
    }

    [TearDown]
    public void TearDown()
    {
        System.IO.File.Delete($"{DbConfiguration.SettingsPath}data_provider.json");
    }

    [Test]
    public void TestInMemory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddInMemoryService();
        IServiceProvider provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().NotBeNull();
        (svc as MsSqlServer).Should().BeNull();
        (svc as MySql).Should().BeNull();
        (svc as SqlLite).Should().BeNull();
        (svc as PostgreSql).Should().BeNull();
    }

    [Test]
    public void TestMySql()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddMySqlService();
        IServiceProvider provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().BeNull();
        (svc as MsSqlServer).Should().BeNull();
        (svc as MySql).Should().NotBeNull();
        (svc as SqlLite).Should().BeNull();
        (svc as PostgreSql).Should().BeNull();
    }

    [Test]
    public void TestMsSql()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddSqlService();
        IServiceProvider provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().BeNull();
        (svc as MsSqlServer).Should().NotBeNull();
        (svc as MySql).Should().BeNull();
        (svc as PostgreSql).Should().BeNull();
    }

    [Test]
    public void TestSqlLite()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddSqlLiteService();
        IServiceProvider provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().BeNull();
        (svc as MsSqlServer).Should().BeNull();
        (svc as MySql).Should().BeNull();
        (svc as SqlLite).Should().NotBeNull();
        (svc as PostgreSql).Should().BeNull();

        var config = provider.GetService<IDbConfig>();
        config.UseConnectionStringEncryption = true;
        svc.GetConnectionString("test", "user", null).Should().Be(Security.Cryptography.Functions.Encript($"Data Source=test;", "#hd@cl$cb#"));
    }

    public void TestPostgreSql()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddPostgreSqlService();
        IServiceProvider provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().BeNull();
        (svc as MsSqlServer).Should().BeNull();
        (svc as MySql).Should().BeNull();
        (svc as SqlLite).Should().BeNull();
        (svc as PostgreSql).Should().NotBeNull();
    }

}
