using EficazFramework.Configuration;
using EficazFramework.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Providers;

public class InMemory : DataProviderBase
{
    public InMemory(string databaseName) : base()
    {
        DatabaseName = databaseName;
    }

    public string DatabaseName { get; }

    public override string GetCommandText([NotNull] QueryBase queryBase) => throw new NotImplementedException("Provider not compatible with sql queries");

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) => optionsBuilder.UseInMemoryDatabase(DatabaseName);

}