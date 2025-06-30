using EficazFramework.Providers.Mock;
using AwesomeAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.Providers;

public class MySqlTests : ProviderBase
{
    [SetUp]
    public async Task SetUpAsync()
    {
        TestDbContext.ModelCreatingAction = (modelBuilder) => 
        {
            var personBuiler = modelBuilder.Entity<Person>();
            personBuiler.ToTable("Persons");
            personBuiler.HasKey(pk => pk.Id);
            personBuiler.Property(e => e.Id).ValueGeneratedNever().IsRequired();
            personBuiler.Property(e => e.Name).HasMaxLength(60).IsRequired();
        };

        DbContextOptionsBuilder<TestDbContext> builder = new();
        builder.UseMySql(_configuration.GetConnectionString("MySql") ?? "", new MySqlServerVersion(new Version(8, 0, 34)), o =>
        {
            o.CommandTimeout(600000);
            o.EnableRetryOnFailure();
            o.MigrationsHistoryTable("HistoryV3", "Migrations");
        });

        _context = new(builder.Options);
        try
        {
            (await _context.Database.EnsureCreatedAsync()).Should().BeTrue();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString().Should().ContainEquivalentOf("database exists");
            throw;
        }
    }


    [TearDown]
    public async Task TearDownAsync()
    {
        try
        {
            (await _context.Database.EnsureDeletedAsync()).Should().BeTrue();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString().Should().ContainEquivalentOf("Unknown database 'eficazframeworkprovidertests'");
            throw;
        }
        await _context.DisposeAsync();
    }


    [Test]
    public async Task Test() =>
        await TestInternalAsync();


}
