using EficazFramework.ViewModels.Services;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using EficazFramework.Validation.Fluent.Rules;
using System.Threading;

namespace EficazFramework.ViewModels;

public class CrudOperations
{
    private ViewModels.ViewModel<Resources.Mocks.Classes.Blog> Vm;
    string resultContext = null;
    bool canContinue = false;

    [SetUp]
    public async Task Setup()
    {
        Vm = new ViewModel<Resources.Mocks.Classes.Blog>().AddEntityFramework();
        Vm.Repository.OrderByDefinitions.Add(new()
        {
            PropertyName = "Id",
            Direction = Enums.Collection.SortOrientation.Asceding
        });

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
    public void TabularConstructorTest()
    {
        Vm.AddTabular();
        Vm.Services.Should().HaveCount(2);
        Vm.Commands.Should().HaveCount(3); // + Save && Cancel
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).AsNoTracking.Should().BeFalse();
    }

    [Test, Order(2)]
    public void SelectTest()
    {
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(100);

    }

    [Test, Order(2)]
    public void TabularValidationTest()
    {
        Vm.AddTabular();
        Vm.Repository.Validator = new();
        Vm.Repository.Validator.Required(n => n.Name);
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext[0].Name = null;
        Vm.Repository.DataContext[1].Name = null;

        // manual valudation
        Vm.Repository.Validate(null).Should().HaveCount(2);

        System.Console.WriteLine("Starting async void operations with TabularEdit<>");
        // by saving
        //resultContext = null;
        //var service = Vm.GetTabularEdit();
        //canContinue = false;
        //Vm.Commands["Save"].Execute(null);
        //while (!canContinue) { }
        //resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        //// by cancelling
        //resultContext = null;
        //canContinue = false;
        //Vm.Commands["Cancel"].Execute(null);
        //while (!canContinue) { }
        //canContinue = false;
        //Vm.Commands["Save"].Execute(null);
        //while (!canContinue) { }
        //resultContext.Should().BeNull();
        //Vm.ViewModelAction -= VmActions_Validation;
        System.Console.WriteLine("Finished async void operations with TabularEdit<>");
    }

    void VmActions_Validation(object sender, EficazFramework.Events.CRUDEventArgs<Resources.Mocks.Classes.Blog> e)
    {
        switch (e.Action)
        {
            case Enums.CRUD.Action.EntryValidationFailed:
                {
                    resultContext = Resources.Strings.Validation.Dialog_Title;
                    canContinue = true;
                    break;
                }
            case Enums.CRUD.Action.Saved:
            case Enums.CRUD.Action.Canceled:
                {
                    resultContext = null;
                    canContinue = true;
                    break;
                }
        }
    }
}