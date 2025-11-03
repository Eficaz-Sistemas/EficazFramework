using EficazFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EficazFramework.Providers;

/// <summary>
/// Implementa definições para trabalho com base de dados MySQL, utilizando
/// o provedor EntityFrameworkCore.SqlServer
/// </summary>
public class PostgreSql : DataProviderBase
{
    public PostgreSql(IDbConfig dbConfig) : base(dbConfig) { }

    public override string Name => "PostgreSql";

    public override string GetConnectionString(string database, string username, string password)
    {
        if (DbConfig.UseConnectionStringEncryption == true)
            return Security.Cryptography.Functions.Encript($"Host={((DbConfiguration)DbConfig).ServerName};Port={((DbConfiguration)DbConfig).Port};Database={database};Username={username};Password={password};Timeout={30};", "#hd@cl$cb#");

        return $"Host={((DbConfiguration)DbConfig).ServerName};Port={((DbConfiguration)DbConfig).Port};Database={database};Username={username};Password={password};Timeout={30};";
    }

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) =>
        optionsBuilder.UseNpgsql(GetConnectionString(database, username, password));

}
public static class Extension
{
    /// <summary>
    /// Adiciona o provedor PostgreSql ao contexto de Injeção de Dependência
    /// </summary>
    public static IServiceCollection AddPostgreSqlService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<DataProviderBase, PostgreSql>();
        return serviceCollection;
    }
}