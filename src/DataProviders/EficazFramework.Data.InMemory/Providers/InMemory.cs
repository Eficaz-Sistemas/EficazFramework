﻿using EficazFramework.Configuration;
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

    public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password) => optionsBuilder.UseInMemoryDatabase(!DbConfig.UseConnectionStringEncryption ? DbConfig.ServerName : Security.Cryptography.Functions.Encript(DbConfig.ServerName, "h##CCd*&LBf!M¨321"));

}

public static class Extension
{
    public static IServiceCollection AddInMemoryService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<DataProviderBase, InMemory>();
        return serviceCollection;
    }
}