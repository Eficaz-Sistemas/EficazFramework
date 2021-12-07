using EficazFramework.Configuration;
using System;

namespace EficazFramework.Providers;

public enum ConnectionProviders
{

    /// <summary>
    /// Microsoft SQL Server
    /// </summary>
    MsSQL = 0,

    /// <summary>
    /// SQL Lite
    /// </summary>
    SqlLite = 1,

    /// <summary>
    /// MySQL
    /// </summary>
    MySQL = 2,

    /// <summary>
    /// Oracle SQL
    /// </summary>
    Oracle = 3
}

internal interface IDataProvider
{
    public string CreateConnectionString(string database, string username, string password);
}

internal class MsSqlServer : IDataProvider
{
    public string CreateConnectionString(string database, string username, string password)
    {
        if (Configuration.DbConfiguration.Instance is null)
            throw new NullReferenceException(Resources.Strings.Validation.DbConfigurationNull);

        if (DbConfiguration.UseConnectionStringEncryption == true)
            return Security.Cryptography.Functions.Encript($"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=False;MultipleActiveResultSets=True;", "#hd@cl$cb#");

        return $"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=False;MultipleActiveResultSets=True;";
    }
}

internal class SqlLite : IDataProvider
{
    public string CreateConnectionString(string database, string username, string password)
    {
        if (EficazFramework.Configuration.DbConfiguration.Instance is null)
            throw new NullReferenceException(Resources.Strings.Validation.DbConfigurationNull);

        if (DbConfiguration.UseConnectionStringEncryption == true)
        {
            if (!string.IsNullOrEmpty(password))
                return Security.Cryptography.Functions.Encript($"Data Source={database};Password={password};", "#hd@cl$cb#");
            else
                return Security.Cryptography.Functions.Encript($"Data Source={database};", "#hd@cl$cb#");
        }

        if (!string.IsNullOrEmpty(password))
            return $"Data Source={database};Password={password};";
        else
            return $"Data Source={database};";
    }
}

internal class MySQL : IDataProvider
{
    public string CreateConnectionString(string database, string username, string password)
    {
        if (EficazFramework.Configuration.DbConfiguration.Instance is null)
            throw new NullReferenceException(Resources.Strings.Validation.DbConfigurationNull);

        if (DbConfiguration.UseConnectionStringEncryption == true)
            return Security.Cryptography.Functions.Encript($"Server={EficazFramework.Configuration.DbConfiguration.Instance.ServerName};Port={EficazFramework.Configuration.DbConfiguration.Instance.Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};", "#hd@cl$cb#");

        return $"Server={EficazFramework.Configuration.DbConfiguration.Instance.ServerName};Port={EficazFramework.Configuration.DbConfiguration.Instance.Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};";
    }
}

internal class Oracle : IDataProvider
{
    public string CreateConnectionString(string database, string username, string password)
    {
        if (EficazFramework.Configuration.DbConfiguration.Instance is null)
            throw new NullReferenceException(Resources.Strings.Validation.DbConfigurationNull);

        if (DbConfiguration.UseConnectionStringEncryption == true)
            return Security.Cryptography.Functions.Encript($"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=no;", "#hd@cl$cb#");

        return $"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=no;";
    }
}
