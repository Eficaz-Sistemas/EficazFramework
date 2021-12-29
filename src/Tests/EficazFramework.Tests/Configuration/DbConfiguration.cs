using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Configuration;

public class DbConfigurationTests
{


    [Test, Order(1)]
    public void ReadAndWriteSettings()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        DbConfiguration.UseConnectionStringEncryption.Should().BeTrue();
        System.IO.File.Delete($"{DbConfiguration.SettingsPath}data_provider.json");

        DbConfiguration.Instance.Should().NotBeNull();
        DbConfiguration.Instance.ServerName.Should().Be(".");
        DbConfiguration.Instance.InstanceName.Should().Be("EfSQLEXPRESS");
        DbConfiguration.Instance.ServerData.Should().Be(@".\EfSQLEXPRESS");
        DbConfiguration.Instance.SingleTennant.Should().BeFalse();
        DbConfiguration.Instance.ShouldSerializePort().Should().BeFalse();

        DbConfiguration.Instance.ServerName = "myserver";
        DbConfiguration.Instance.InstanceName = "myinstance";
        DbConfiguration.Instance.Port = 1436;
        DbConfiguration.Instance.SingleTennant = true;
        DbConfiguration.Instance.ServerData.Should().Be(@"myserver\myinstance,1436");
        DbConfiguration.Instance.ShouldSerializePort().Should().BeTrue();
        DbConfiguration.Save();
        
        DbConfiguration.Instance.ServerName = ".";
        DbConfiguration.Instance.InstanceName = "myinstance2";
        DbConfiguration.Instance.Port = 1437;
        DbConfiguration.Instance.ServerData.Should().Be(@".\myinstance2,1437");

        DbConfiguration.Load();
        DbConfiguration.Instance.ServerName = "myserver";
        DbConfiguration.Instance.InstanceName = "myinstance";
        DbConfiguration.Instance.Port = 1436;
        DbConfiguration.Instance.SingleTennant = true;
        DbConfiguration.Instance.ServerData.Should().Be(@"myserver\myinstance,1436");
        DbConfiguration.Instance.ShouldSerializePort().Should().BeTrue();

        System.IO.File.Delete($"{DbConfiguration.SettingsPath}data_provider.json");
    }

    [Test, Order(2)]
    public void ConnectionStringBuilderForMsSql()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        DbConfiguration.UseConnectionStringEncryption = false;
        DbConfiguration.Instance.Provider = Providers.ConnectionProviders.MsSQL;
        DbConfiguration.Instance.ServerName = "myserver";
        DbConfiguration.Instance.InstanceName = "myinstance";
        DbConfiguration.Instance.Port = 1436;
        DbConfiguration.GetConnection("mydb", "myuser", "mypass").Should().Be(@"Data Source=myserver\myinstance,1436;Database=mydb;User ID=myuser;Password=mypass;Connect Timeout=30;Integrated Security=False;MultipleActiveResultSets=True;");
        DbConfiguration.UseConnectionStringEncryption = true;
        DbConfiguration.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
        DbConfiguration.UseConnectionStringEncryption = false;
    }

    [Test, Order(3)]
    public void ConnectionStringBuilderForSqlLite()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        DbConfiguration.UseConnectionStringEncryption = false;
        DbConfiguration.Instance.Provider = Providers.ConnectionProviders.SqlLite;
        DbConfiguration.GetConnection(@"C:\mydb.db", "myuser", "mypass").Should().Be(@"Data Source=C:\mydb.db;Password=mypass;");
        DbConfiguration.UseConnectionStringEncryption = true;
        DbConfiguration.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
        DbConfiguration.UseConnectionStringEncryption = false;
    }

    [Test, Order(3)]
    public void ConnectionStringBuilderForMySql()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        DbConfiguration.UseConnectionStringEncryption = false;
        DbConfiguration.Instance.ServerName = "myserver";
        DbConfiguration.Instance.Port = 1436;
        DbConfiguration.Instance.Provider = Providers.ConnectionProviders.MySQL;
        DbConfiguration.GetConnection("mydb", "myuser", "mypass").Should().Be(@"Server=myserver;Port=1436;Database=mydb;Uid=myuser;Pwd=mypass;Connect Timeout=30;");
        DbConfiguration.UseConnectionStringEncryption = true;
        DbConfiguration.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
        DbConfiguration.UseConnectionStringEncryption = false;
    }

    public void ConnectionStringBuilderForOracle()
    {
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        DbConfiguration.UseConnectionStringEncryption = false;
        DbConfiguration.Instance.ServerName = "myserver";
        DbConfiguration.Instance.Port = 1436;
        DbConfiguration.Instance.Provider = Providers.ConnectionProviders.Oracle;
        DbConfiguration.GetConnection("mydb", "myuser", "mypass").Should().Be(@"Data Source=myserver\myinstance,1436;Database=mydb;User ID=myuser;Password=mypass;Connect Timeout=30;Integrated Security=no;");
        DbConfiguration.UseConnectionStringEncryption = true;
        DbConfiguration.GetConnection("mydb", "myuser", "mypass").Should().NotContain("mypass");
        DbConfiguration.UseConnectionStringEncryption = false;
    }
}