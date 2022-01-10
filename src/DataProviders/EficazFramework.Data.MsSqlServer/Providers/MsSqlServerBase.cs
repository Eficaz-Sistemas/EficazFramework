using EficazFramework.Configuration;
using EficazFramework.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Providers;

public abstract class MsSqlServer : DataProviderBase
{
    protected MsSqlServer(IDbConfig dbConfig) : base(dbConfig) { }

    public override string GetConnectionString(string database, string username, string password) => DbConfig.ServerName;

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