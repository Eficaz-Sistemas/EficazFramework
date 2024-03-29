﻿using EficazFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EficazFramework.Providers;

/// <summary>
/// Implementa definições para trabalho com base de dados Microsoft SQL Server, utilizando
/// o provedor EntityFrameworkCore.SqlServer
/// </summary>
public class MsSqlServer : DataProviderBase
{
    public MsSqlServer(IDbConfig dbConfig) : base(dbConfig) { }

    public override string Name => "MsSqlServer";

    public override string GetConnectionString(string database, string username, string password)
    {
        if (DbConfig.UseConnectionStringEncryption == true)
            return Security.Cryptography.Functions.Encript($"Data Source={((DbConfiguration)DbConfig).ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=False;MultipleActiveResultSets=True;", "#hd@cl$cb#");

        return $"Data Source={((DbConfiguration)DbConfig).ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=False;MultipleActiveResultSets=True;";
    }

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) => optionsBuilder.UseSqlServer(GetConnectionString(database, username, password));
}
public static class Extension
{
    /// <summary>
    /// Adiciona o provedor MsSqlServer ao contexto de Injeção de Dependência
    /// </summary>
    public static IServiceCollection AddSqlService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<DataProviderBase, MsSqlServer>();
        return serviceCollection;
    }
}