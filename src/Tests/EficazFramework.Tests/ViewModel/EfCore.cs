using EficazFramework.ViewModels.Services;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EficazFramework.ViewModels;

public class EfCore
{
    private ViewModels.ViewModel<Resources.Mocks.Classes.Blog> Vm;

    [SetUp]
    public async Task Setup()
    {
        Vm = new ViewModel<Resources.Mocks.Classes.Blog>();
        Vm.AddEntityFramework();
        var dbContextRepo = (EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository;
        ((EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).DbContextInstanceRequest += (s, e) => e.Instance = new Resources.Mocks.MockDbContext(Providers.ConnectionProviders.SqlLite);

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
        ((EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).DbContextInstanceRequest -= (s, e) => e.Instance = new Resources.Mocks.MockDbContext(Providers.ConnectionProviders.SqlLite);
        Vm.Dispose();

        var ctb = new Resources.Mocks.MockDbContext(Providers.ConnectionProviders.SqlLite);
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

    }

}