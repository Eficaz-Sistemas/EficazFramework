﻿using EficazFramework.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EficazFramework.Providers;


public class DataProviderService : Microsoft.EntityFrameworkCore.Infrastructure.IDbContextOptionsExtension
{
    public DbContextOptionsExtensionInfo Info => null;

    public void ApplyServices(IServiceCollection services)
    {
        services.AddScoped<Configuration.IDbConfig, Configuration.DbConfiguration>();
    }

    public void Validate(IDbContextOptions options)
    {
    }
}

public abstract class DataProviderBase
{
    public abstract string GetCommandText(Repositories.Services.QueryBase queryBase);

    public abstract void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password);
}

//internal class SqlLite : DataProviderBase
//{
//    public string CreateConnectionString(string database, string username, string password)
//    {
//        if (DbConfiguration.UseConnectionStringEncryption == true)
//        {
//            if (!string.IsNullOrEmpty(password))
//                return Security.Cryptography.Functions.Encript($"Data Source={database};Password={password};", "#hd@cl$cb#");
//            else
//                return Security.Cryptography.Functions.Encript($"Data Source={database};", "#hd@cl$cb#");
//        }

//        if (!string.IsNullOrEmpty(password))
//            return $"Data Source={database};Password={password};";
//        else
//            return $"Data Source={database};";
//    }
//}

//internal class MySQL : DataProviderBase
//{
//    public string CreateConnectionString(string database, string username, string password)
//    {
//        if (DbConfiguration.UseConnectionStringEncryption == true)
//            return Security.Cryptography.Functions.Encript($"Server={EficazFramework.Configuration.DbConfiguration.Instance.ServerName};Port={EficazFramework.Configuration.DbConfiguration.Instance.Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};", "#hd@cl$cb#");

//        return $"Server={EficazFramework.Configuration.DbConfiguration.Instance.ServerName};Port={EficazFramework.Configuration.DbConfiguration.Instance.Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};";
//    }
//}

//internal class Oracle : DataProviderBase
//{
//    public string CreateConnectionString(string database, string username, string password)
//    {
//        if (DbConfiguration.UseConnectionStringEncryption == true)
//            return Security.Cryptography.Functions.Encript($"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=no;", "#hd@cl$cb#");

//        return $"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=no;";
//    }
//}
