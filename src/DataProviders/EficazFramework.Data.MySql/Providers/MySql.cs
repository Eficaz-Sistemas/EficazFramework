using EficazFramework.Configuration;
using EficazFramework.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Providers;

/// <summary>
/// Implementa definições para trabalho com cache, utilizando
/// o provedor EntityFrameworkCore.SqlServer
/// </summary>
public class MySql : DataProviderBase
{
    public MySql(IDbConfig dbConfig) : base(dbConfig) { }

    public override string Name => "MySql";

    public override string GetConnectionString(string database, string username, string password)
    {
        if (DbConfig.UseConnectionStringEncryption == true)
            return Security.Cryptography.Functions.Encript($"Server={((DbConfiguration)DbConfig).ServerName};Port={((DbConfiguration)DbConfig).Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};", "#hd@cl$cb#");

        return $"Server={((DbConfiguration)DbConfig).ServerName};Port={((DbConfiguration)DbConfig).Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};";
    }

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) => optionsBuilder.UseMySQL(GetConnectionString(database, username, password));
}
public static class Extension
{
    /// <summary>
    /// Adiciona o provedor MsSqlServer ao contexto de Injeção de Dependência
    /// </summary>
    public static IServiceCollection AddMySqlService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<DataProviderBase, MySql>();
        return serviceCollection;
    }
}