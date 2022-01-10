using EficazFramework.Configuration;
using EficazFramework.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Providers;

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

    public override string GetCommandText([NotNull] QueryBase queryBase) => queryBase.MsSqlCommandText;

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) => optionsBuilder.UseSqlServer(GetConnectionString(database, username, password));
}
public static class Extension
{
    public static IServiceCollection WithSqlService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<DataProviderBase, MsSqlServer>();
        return serviceCollection;
    }
}