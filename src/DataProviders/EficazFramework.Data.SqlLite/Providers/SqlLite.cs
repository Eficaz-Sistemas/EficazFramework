using EficazFramework.Configuration;
using EficazFramework.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Providers;

/// <summary>
/// Implementa definições para trabalho com cache, utilizando
/// o provedor EntityFrameworkCore.SqlLite
/// </summary>
public class SqlLite : DataProviderBase
{
    public SqlLite(IDbConfig dbConfig) : base(dbConfig) { }

    public override string Name => "SqlLite";
    
    public override string GetConnectionString(string database, string username, string password)
    {
        if (DbConfig.UseConnectionStringEncryption == true)
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

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) => optionsBuilder.UseSqlite(GetConnectionString(database, username, password));
}
public static class Extension
{
    /// <summary>
    /// Adiciona o provedor SqlLite ao contexto de Injeção de Depenência
    /// </summary>
    public static IServiceCollection AddSqlLiteService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<DataProviderBase, SqlLite>();
        return serviceCollection;
    }
}