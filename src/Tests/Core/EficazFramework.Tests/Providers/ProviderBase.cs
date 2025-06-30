using EficazFramework.Providers.Mock;
using AwesomeAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.Providers;

public class ProviderBase
{
    internal TestDbContext _context;
    internal IConfiguration _configuration;


    [OneTimeSetUp]
    public void OneTimeSetUp() =>
        SetupConfiguration();

    private void SetupConfiguration() =>
        _configuration = new ConfigurationBuilder().AddJsonFile(System.IO.Path.Combine(Environment.CurrentDirectory, "appsettings.json")).AddUserSecrets<ProviderBase>().Build();


    internal async Task TestInternalAsync()
    {
        var faker = new Bogus.Faker<Person>();
        faker.RuleFor(p => p.Id, s => s.Random.Guid());
        faker.RuleFor(p => p.Name, s => s.Person.FullName);


        _context.Should().NotBeNull();
        (await _context.Persons.ToListAsync()).Should().HaveCount(0);

        await _context.Persons.AddRangeAsync(faker.Generate(5));
        await _context.SaveChangesAsync();
        (await _context.Persons.ToListAsync()).Should().HaveCount(5);
    }


}
