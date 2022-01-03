using EficazFramework.ViewModels.Services;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using EficazFramework.Validation.Fluent.Rules;
using System.Threading;
using System.Linq;

namespace EficazFramework.ViewModels;

public class CrudOperations
{
    private ViewModels.ViewModel<Resources.Mocks.Classes.Blog> Vm;
    string resultContext = null;

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

    [Test, Order(3)]
    public async Task TabularValidationTest()
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

        //by saving
        resultContext = null;
        var service = Vm.GetTabularEdit();
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(1000);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        // by cancelling
        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(1000);
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(1000);
        resultContext.Should().BeNull();
        Vm.ViewModelAction -= VmActions_Validation;

        // just call cancel Save
        service.CancelSave();

        System.Console.WriteLine("Finished async void operations with TabularEdit<>");
    }

    [Test, Order(4)]
    public void SingleEditTest_Navigation()
    {
        Vm.AddSingledEdit();
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        var service = Vm.GetSingleEdit();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(0);
        service.MoveNext();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(1);
        service.MoveToLast();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(99);
        service.MovePrevious();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(98);
        service.MoveToFirst();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(0);
        service.MoveTo(Vm.Repository.DataContext.First(b => b.Name == "Blog 50"));
        service.CurrentEntry.Name.Should().Be("Blog 50");
    }

    private bool _saveNotified = false;
    [Test, Order(5)]
    public async Task SingleEditTest_Update()
    {
        Vm.AddSingledEdit();
        Vm.Repository.Validator = new();
        Vm.Repository.Validator.Required(n => n.Name);
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);

        resultContext = null;
        var service = Vm.GetSingleEdit();
        service.NotifyOnSave = true;
        System.Console.WriteLine("Starting async void operations with SingleEdit<>");

        var bkpName = service.CurrentEntry.Name;
        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Name = null;

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Name.Should().Be(bkpName);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Name = "Updated Item";

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        _saveNotified.Should().BeTrue();

        Vm.Repository.Filter = (e) => e.Name == "Updated Item";
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(1);
        Vm.Repository.DataContext[0].Name.Should().Be("Updated Item");


        Vm.ViewModelAction -= VmActions_Validation;
        Vm.ShowMessage -= Vm_Dialog;
        System.Console.WriteLine("Finished async void operations with TabularEdit<>");
    }

    [Test, Order(6)]
    public async Task SingleEditTest_Insert()
    {
        Vm.AddSingledEdit();
        Vm.Repository.Validator = new();
        Vm.Repository.Validator.Required(n => n.Name);
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);

        resultContext = null;
        var service = Vm.GetSingleEdit();
        System.Console.WriteLine("Starting async void operations with SingleEdit<>");

        var bkpName = service.CurrentEntry.Name;
        Vm.Commands["New"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Id = System.Guid.NewGuid();
        service.CurrentEntry.Name = null;

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Name.Should().Be(bkpName);

        resultContext = null;
        Vm.Commands["New"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Id = System.Guid.NewGuid();
        service.CurrentEntry.Name = "Added Item";

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(101);


        Vm.ViewModelAction -= VmActions_Validation;

        System.Console.WriteLine("Finished async void operations with TabularEdit<>");
    }

    private bool _refuseDelete = true;
    [Test, Order(7)]
    public async Task SingleEditTest_Delete()
    {
        Vm.AddSingledEdit();
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);

        resultContext = null;
        var service = Vm.GetSingleEdit();
        System.Console.WriteLine("Starting async void operations with SingleEdit<>");

        Vm.Commands["Delete"].Execute(Vm.Repository.DataContext.Last());
        await Task.Delay(100);
        resultContext.Should().BeNull();
        Vm.Repository.DataContext.Should().HaveCount(100);

        _refuseDelete = false;
        Vm.Commands["Delete"].Execute(Vm.Repository.DataContext.Last());
        await Task.Delay(100);
        resultContext.Should().Be("ok");
        Vm.Repository.DataContext.Should().HaveCount(99);

        Vm.ViewModelAction -= VmActions_Validation;
        Vm.ShowMessage -= Vm_Dialog;
        System.Console.WriteLine("Finished async void operations with TabularEdit<>");
    }




    void VmActions_Validation(object sender, EficazFramework.Events.CRUDEventArgs<Resources.Mocks.Classes.Blog> e)
    {
        switch (e.Action)
        {
            case Enums.CRUD.Action.EntryValidationFailed:
                {
                    resultContext = Resources.Strings.Validation.Dialog_Title;
                    break;
                }
            case Enums.CRUD.Action.Saved:
            case Enums.CRUD.Action.Canceled:
                {
                    resultContext = null;
                    break;
                }
            case Enums.CRUD.Action.EntryDeleted:
                {
                    resultContext = "ok";
                    break;
                }
        }
    }

    void Vm_Dialog(object sender, Events.MessageEventArgs e)
    {

        if (e.Title == Resources.Strings.ViewModel.StoreService_DeleteConfirmation_Title)
        {
            e.ModalAssist.Release(!_refuseDelete ? Events.MessageResult.Yes : Events.MessageResult.No);
        }
        else if (e.Title == Resources.Strings.ViewModel.StoreService_SavedSucessfull_Title && e.Type == Events.MessageType.SnackBar)
        {
            _saveNotified = true;
        }
    }

}