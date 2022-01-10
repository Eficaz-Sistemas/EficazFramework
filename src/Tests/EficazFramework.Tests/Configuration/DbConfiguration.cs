using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using EficazFramework.Providers;

namespace EficazFramework.Configuration;

[TestFixture(typeof(Providers.InMemory))]
[TestFixture(typeof(Providers.MsSqlServer))]
public class DbConfigurationTests<TProvider> where TProvider : DataProviderBase
{
    DbConfiguration _config = null;
    IServiceCollection _serviceCollection = null;
    IServiceProvider _provider = null;
    TProvider _dataBaseProvider = null;

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
        _config.UseConnectionStringEncryption.Should().BeTrue();

        _config.Should().NotBeNull();
        _config.ServerName.Should().Be(".");
        _config.InstanceName.Should().Be("EfSQLEXPRESS");
        _config.ServerData.Should().Be(@".\EfSQLEXPRESS");
        _config.SingleTennant.Should().BeFalse();
        _config.ShouldSerializePort().Should().BeFalse();

        _config.ServerName = "myserver";
        _config.InstanceName = "myinstance";
        _config.Port = 1436;
        _config.SingleTennant = true;
        _config.ServerData.Should().Be(@"myserver\myinstance,1436");
        _config.ShouldSerializePort().Should().BeTrue();
        _config.Save();
        
        _config.ServerName = ".";
        _config.InstanceName = "myinstance2";
        _config.Port = 1437;
        _config.ServerData.Should().Be(@".\myinstance2,1437");

        _config.Load();
        _config.ServerName = "myserver";
        _config.InstanceName = "myinstance";
        _config.Port = 1436;
        _config.SingleTennant = true;
        _config.ServerData.Should().Be(@"myserver\myinstance,1436");
        _config.ShouldSerializePort().Should().BeTrue();
    }

    [Test, Order(2)]
    public void ConnectionStringBuilder()
    {
        _dataBaseProvider = (TProvider)_provider.GetService<DataProviderBase>();
        _config = (DbConfiguration)_provider.GetService<IDbConfig>();
        _dataBaseProvider.Should().NotBeNull();
        _serviceCollection.Should().HaveCount(2);

        _config.UseConnectionStringEncryption = false;
        _config.ServerName = "myserver";
        _config.InstanceName = "myDbOrInstance";
        _config.Port = 1436;

        _dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().Be(@"Data Source=myserver\myinstance,1436;Database=mydb;User ID=myuser;Password=mypass;Connect Timeout=30;Integrated Security=False;MultipleActiveResultSets=True;");
        _config.UseConnectionStringEncryption = true;
        _dataBaseProvider.GetConnectionString("mydb", "myuser", "mypass").Should().NotContain("myDb");
        _config.UseConnectionStringEncryption = false;
    }


    //[Test, Order(2)]
    //public void ConnectionStringBuilderForMsSql()
    //{
    //    config.UseConnectionStringEncryption = false;
    //    config.ServerName = "myserver";
    //    config.InstanceName = "myinstance";
    //    config.Port = 1436;
    //    config.GetConnection("mydb", "myuser", "mypass").Should().Be(@"Data Source=myserver\myinstance,1436;Database=mydb;User ID=myuser;Password=mypass;Connect Timeout=30;Integrated Security=False;MultipleActiveResultSets=True;");
    //    config.UseConnectionStringEncryption = true;
    //    config.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
    //    config.UseConnectionStringEncryption = false;
    //}

    //[Test, Order(3)]
    //public void ConnectionStringBuilderForSqlLite()
    //{
    //    config.UseConnectionStringEncryption = false;
    //    config.Provider = Providers.ConnectionProviders.SqlLite;
    //    config.GetConnection(@"C:\mydb.db", "myuser", "mypass").Should().Be(@"Data Source=C:\mydb.db;Password=mypass;");
    //    config.UseConnectionStringEncryption = true;
    //    config.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
    //    config.UseConnectionStringEncryption = false;
    //}

    //[Test, Order(3)]
    //public void ConnectionStringBuilderForMySql()
    //{
    //    config.UseConnectionStringEncryption = false;
    //    config.ServerName = "myserver";
    //    config.Port = 1436;
    //    config.Provider = Providers.ConnectionProviders.MySQL;
    //    config.GetConnection("mydb", "myuser", "mypass").Should().Be(@"Server=myserver;Port=1436;Database=mydb;Uid=myuser;Pwd=mypass;Connect Timeout=30;");
    //    config.UseConnectionStringEncryption = true;
    //    config.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
    //    config.UseConnectionStringEncryption = false;
    //}

    //[Test, Order(4)]
    //public void ConnectionStringBuilderForOracle()
    //{
    //    config.UseConnectionStringEncryption = false;
    //    config.ServerName = "myserver";
    //    config.InstanceName = "myinstance";
    //    config.Port = 1436;
    //    config.Provider = Providers.ConnectionProviders.Oracle;
    //    config.GetConnection("mydb", "myuser", "mypass").Should().Be(@"Data Source=myserver\myinstance,1436;Database=mydb;User ID=myuser;Password=mypass;Connect Timeout=30;Integrated Security=no;");
    //    config.UseConnectionStringEncryption = true;
    //    config.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
    //    config.UseConnectionStringEncryption = false;
    //}
}