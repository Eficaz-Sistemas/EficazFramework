using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using EficazFramework.Validation.Fluent.Rules;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EficazFramework.Extensions;
using System.Collections.Generic;
using System.Threading;
using EficazFramework.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EficazFramework.Providers;
using FluentAssertions;

namespace EficazFramework.Providers;

public class ProviderTests
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
        IServiceProvider provider = null;
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddInMemoryService();
        provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().NotBeNull();
        (svc as MsSqlServer).Should().BeNull();
        (svc as SqlLite).Should().BeNull();
    }

    [Test]
    public void TestMsSql()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        IServiceProvider provider = null;
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddSqlService();
        provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().BeNull();
        (svc as MsSqlServer).Should().NotBeNull();
        (svc as SqlLite).Should().BeNull();
    }

    [Test]
    public void TestSqlLite()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        IServiceProvider provider = null;
        serviceCollection.AddDbConfig(false);
        serviceCollection.AddSqlLiteService();
        provider = serviceCollection.BuildServiceProvider();

        var svc = provider.GetService<DataProviderBase>();
        svc.Should().NotBeNull();
        (svc as InMemory).Should().BeNull();
        (svc as MsSqlServer).Should().BeNull();
        (svc as SqlLite).Should().NotBeNull();
    }

}
