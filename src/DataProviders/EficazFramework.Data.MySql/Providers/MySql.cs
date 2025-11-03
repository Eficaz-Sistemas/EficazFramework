using EficazFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EficazFramework.Providers;

/// <summary>
/// Implementa definições para trabalho com base de dados MySQL, utilizando
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

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) =>
        optionsBuilder.UseMySql(GetConnectionString(database, username, password), new MySqlServerVersion(new Version(8, 0, 34)));

}
public static class Extension
{
    /// <summary>
    /// Adiciona o provedor MySql ao contexto de Injeção de Dependência
    /// </summary>
    public static IServiceCollection AddMySqlService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<DataProviderBase, MySql>();
        return serviceCollection;
    }
}