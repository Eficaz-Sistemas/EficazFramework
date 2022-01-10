using EficazFramework.Configuration;
using EficazFramework.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EficazFramework.Providers;

public class InMemory : DataProviderBase
{
    public InMemory(IDbConfig dbConfig) : base(dbConfig) { }

    public override string Name => "InMemory";

    public override string GetConnectionString(string database, string username, string password) => !DbConfig.UseConnectionStringEncryption ? DbConfig.ServerName : Security.Cryptography.Functions.Encript(DbConfig.ServerName, "#hd@cl$cb#");

    public override string GetCommandText([NotNull] QueryBase queryBase) => throw new NotImplementedException("Provider not compatible with sql queries");

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) => optionsBuilder.UseInMemoryDatabase(!DbConfig.UseConnectionStringEncryption ? DbConfig.ServerName : Security.Cryptography.Functions.Encript(DbConfig.ServerName, "h##CCd*&LBf!M¨321"));

}