using EficazFramework.Configuration;
using EficazFramework.Providers;
using EficazFramework.ViewModels.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.ViewModels;

[TestFixture(typeof(Providers.InMemory))]
[TestFixture(typeof(Providers.SqlLite))]
public class EfCore<TProvider> where TProvider : DataProviderBase
{
    IServiceCollection _serviceCollection = null;
    IServiceProvider _provider = null;
    private ViewModels.ViewModel<Resources.Mocks.Classes.Blog> Vm;

    [SetUp]
    public async Task Setup()
    {
        // DI Setup
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        _serviceCollection = new ServiceCollection();
        _serviceCollection.AddScoped<IDbConfig, DbConfiguration>();
        _serviceCollection.AddScoped<DataProviderBase, TProvider>();
        _provider = _serviceCollection.BuildServiceProvider();

        // VM Setup
        Vm = new ViewModel<Resources.Mocks.Classes.Blog>();
        Vm.AddEntityFramework();
        var dbContextRepo = (EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository;
        ((EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).DbContextInstanceRequest += (s, e) => e.Instance = new Resources.Mocks.MockDbContext(_provider.GetService<IDbConfig>());

        // seed
        dbContextRepo.PrepareDbContext();
        (await dbContextRepo.DbContext.Database.EnsureCreatedAsync()).Should().BeTrue();
        for (int i = 0; i < 100; i++)
        {
            dbContextRepo.DbContext.Add(new Resources.Mocks.Classes.Blog()
            {
                Id = System.Guid.NewGuid(),
                Name = $"Blog {i}"
            });
        }
        await dbContextRepo.DbContext.SaveChangesAsync();
        await dbContextRepo.DbContext.DisposeAsync();
        dbContextRepo.DbContext = null;
    }

    [TearDown]
    public async Task ReleaseTempData()
    {
        ((EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).DbContextInstanceRequest -= (s, e) => e.Instance = new Resources.Mocks.MockDbContext(_provider.GetService<IDbConfig>());
        Vm.Dispose();

        var ctb = new Resources.Mocks.MockDbContext(_provider.GetService<IDbConfig>());
        (await ctb.Database.EnsureDeletedAsync()).Should().BeTrue();
    }

    [Test, Order(1)]
    public void ConstructorTest()
    {
        Vm.Services.Should().HaveCount(1);
    }

    [Test, Order(2)]
    public void SelectTest()
    {
        Vm.Commands.Should().HaveCount(1); // any Command is added. It's just set the repository by this service.
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(100);
        Vm.RemoveEntityFramework();

    }

}