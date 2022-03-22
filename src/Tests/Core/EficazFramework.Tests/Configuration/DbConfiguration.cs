using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using EficazFramework.Providers;
using System.Linq;

namespace EficazFramework.Configuration;

[TestFixture(typeof(Providers.InMemory))]
[TestFixture(typeof(Providers.SqlLite))]
[TestFixture(typeof(Providers.MsSqlServer))]
[TestFixture(typeof(Providers.MySql))]
public class DbConfigurationTests<TProvider> where TProvider : DataProviderBase
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
    }

    [TearDown]
    public void TearDown()
    {
        System.IO.File.Delete($"{DbConfiguration.SettingsPath}data_provider.json");
    }

    [Test, Order(1)]
    public void ReadAndWriteSettings()
    {
        var config = (DbConfiguration)_provider.GetService<IDbConfig>();

        config.UseConnectionStringEncryption.Should().BeTrue();

        config.Should().NotBeNull();
        config.ServerName.Should().Be(".");
        config.InstanceName.Should().Be("EfSQLEXPRESS");
        config.ServerData.Should().Be(@".\EfSQLEXPRESS");
        config.SingleTennant.Should().BeFalse();
        config.ShouldSerializePort().Should().BeFalse();

        config.ServerName = "myserver";
        config.InstanceName = "myinstance";
        config.Port = 1436;
        config.SingleTennant = true;
        config.ServerData.Should().Be(@"myserver\myinstance,1436");
        config.ShouldSerializePort().Should().BeTrue();
        config.Save();
        
        config.ServerName = ".";
        config.InstanceName = "myinstance2";
        config.Port = 1437;
        config.ServerData.Should().Be(@".\myinstance2,1437");

        config.Load();
        config.ServerName = "myserver";
        config.InstanceName = "myinstance";
        config.Port = 1436;
        config.SingleTennant = true;
        config.ServerData.Should().Be(@"myserver\myinstance,1436");
        config.ShouldSerializePort().Should().BeTrue();

        //custom path
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\custom\";
        config.Load();

        //tear down custom path
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
    }

    [Test, Order(2)]
    public void ConnectionStringBuilder()
    {
        var dataBaseProvider = (TProvider)_provider.GetService<DataProviderBase>();
        var config = (DbConfiguration)_provider.GetService<IDbConfig>();
        dataBaseProvider.Should().NotBeNull();
        _serviceCollection.Should().HaveCount(2);

        config.UseConnectionStringEncryption = false;
        config.ServerName = "myserver";
        config.InstanceName = "myDbOrInstance";
        config.Port = 1436;

        string providerName = _provider.GetService<DataProviderBase>().Name;
        Exception ex = null;
        switch (providerName)
        {
            case "InMemory":
                {
                    dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().Be("myserver");
                    config.UseConnectionStringEncryption = true;
                    dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().NotContain("myserver");
                    config.UseConnectionStringEncryption = false;
                    break;
                }

            case "MySql":
                {
                    dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().Be(@"Server=myserver;Port=1436;Database=mydb;Uid=myuser;Pwd=mypass;Connect Timeout=30;");
                    config.UseConnectionStringEncryption = true;
                    dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().NotContain("myDb");
                    config.UseConnectionStringEncryption = false;
                    break;
                }

            case "MsSqlServer":
                {
                    dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().Be(@"Data Source=myserver\myDbOrInstance,1436;Database=mydb;User ID=myuser;Password=mypass;Connect Timeout=30;Integrated Security=False;MultipleActiveResultSets=True;");
                    config.UseConnectionStringEncryption = true;
                    dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().NotContain("myDb");
                    config.UseConnectionStringEncryption = false;
                    break;
                }

            case "SqlLite":
                {
                    dataBaseProvider.GetConnectionString(@"C:\mydb.db", "myuser", "mypass").Should().Be(@"Data Source=C:\mydb.db;Password=mypass;");
                    config.UseConnectionStringEncryption = true;
                    dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().NotContain("mypass");
                    config.UseConnectionStringEncryption = false;
                    break;
                }

            default:
                {
                    ex = new NotImplementedException("Provider not supported");
                    break;
                }
        }
        ex.Should().BeNull();

    }
}