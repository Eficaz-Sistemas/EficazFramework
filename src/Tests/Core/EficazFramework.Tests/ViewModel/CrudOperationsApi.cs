using EficazFramework.Validation.Fluent.Rules;
using EficazFramework.ViewModels.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EficazFramework.ViewModels;

public class CrudOperationsApi
{
    internal EficazFramework.Tests.Resources.Mock.API.ApiApplicationFactory Aplication { get; private set; }
    public IServiceScope Scope { get; private set; }
    public IServiceProvider Provider { get; private set; }
    public HttpClient Client { get; private set; }


    private ViewModels.ViewModel<Resources.Mocks.Classes.Blog> Vm;
    string resultContext = null;
    bool shouldCancel = false;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Aplication = new();
        Scope = Aplication.Services.CreateScope();
        Provider = Scope.ServiceProvider;
        Client = Aplication.CreateClient();
    }

    [SetUp]
    public void Setup()
    {
        resultContext = null;
        shouldCancel = false;
        var provider = new EficazFramework.Providers.InMemory(new EficazFramework.Configuration.DbConfiguration()
        {
            ServerName = "myserver"
        }); ;
        
        Vm = new ViewModel<Resources.Mocks.Classes.Blog>().AddRestApi(Client, options =>
        {
            options.UrlGet = "/blog/get";
            options.UrlPost = "/blog/post";
            options.UrlPut = "/blog/put";
            options.UrlDelete = "/blog/delete";

        });

        var dbContextRepo = (EficazFramework.Repositories.ApiRepository<Resources.Mocks.Classes.Blog>)Vm.Repository;
        ((EficazFramework.Repositories.ApiRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).DbContextRequest = () => new Resources.Mocks.MockDbContext(provider);
    }

    [TearDown]
    public void TearDown()
    {
        Vm.Dispose();
    }

    [Test]
    public async Task SelectTestAsync()
    {
        Vm.Repository.DataContext.Should().HaveCount(0);

        Vm.Commands["Get"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);
            
        Vm.Repository.DataContext.Should().HaveCount(5);
    }

    [Test]
    public async Task SingleEditTest_Navigation()
    {
        Vm.ViewModelAction += VmActions_Validation;

        Vm.AddSingledEdit();
        var service = Vm.GetSingleEdit();

        service.CurrentEntry.Should().BeNull();
        service.MoveToFirst();
        service.CurrentEntry.Should().BeNull();
        service.MoveNext();
        service.CurrentEntry.Should().BeNull();
        service.MovePrevious();
        service.CurrentEntry.Should().BeNull();
        service.MoveToLast();
        service.CurrentEntry.Should().BeNull();

        Vm.Commands["Get"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);

        Vm.Repository.DataContext.Should().HaveCount(5);
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(0);
        service.MoveNext();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(1);
        service.MoveToLast();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(4);
        service.MovePrevious();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(3);
        service.MoveToFirst();
        Vm.Repository.DataContext.IndexOf(service.CurrentEntry).Should().Be(0);

        Vm.Commands["Cancel"].Execute(null); // but VM will lock
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        Vm.Commands["New"].Execute(null); // but VM will lock
        await Task.Delay(100);
        Vm.State.Should().NotBe(Enums.CRUD.State.Novo);
        service.CurrentEntry?.IsNew.Should().BeFalse();

        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        shouldCancel = true;
        Vm.Commands["New"].Execute(null); // but VM will lock
        await Task.Delay(100);
        Vm.State.Should().NotBe(Enums.CRUD.State.Novo);

        Vm.Commands["Save"].Execute(null); // but VM will lock
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        Vm.Commands["Edit"].Execute(null); // but VM will lock
        await Task.Delay(100);
        Vm.State.Should().NotBe(Enums.CRUD.State.Edicao);

        shouldCancel = false;
        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);
        shouldCancel = true;

        Vm.Commands["Save"].Execute(null); // but VM will lock (again)
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        Vm.Commands["Delete"].Execute(null); // but VM will lock (again)
        await Task.Delay(100);
        Vm.Repository.DataContext.Should().HaveCount(5);

        shouldCancel = false;
        Vm.ViewModelAction -= VmActions_Validation;
    }

    //private bool _saveNotified = false;
    [Test]
    public async Task SingleEditTest_Update()
    {
        Vm.AddSingledEdit();
        Vm.Repository.Validator = new();
        Vm.Repository.Validator.Required(n => n.Name);
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);

        resultContext = null;
        var service = Vm.GetSingleEdit();
        service.NotifyOnSave = true;

        var bkpName = service.CurrentEntry.Name;
        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(150);
        service.CurrentEntry.Name = null;

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(150);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(150);
        service.CurrentEntry.Name.Should().Be(bkpName);

        Vm.Commands["Edit"].Execute(service.CurrentEntry);
        await Task.Delay(150);
        service.CurrentEntry.Name = "Updated Item";

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(500);
        resultContext.Should().BeNull();

        var dbContextRepo = (EficazFramework.Repositories.ApiRepository<Resources.Mocks.Classes.Blog>)Vm.Repository;
        dbContextRepo.Filter = new()
        {
            new Expressions.ExpressionObjectQuery()
            {
                FieldName = "Name",
                Operator = Enums.CompareMethod.Equals,
                Value  = "Updated Item"
            }
        };
        Vm.Commands["Get"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);

        Vm.Repository.DataContext.Should().HaveCount(1);
        Vm.Repository.DataContext[0].Name.Should().Be("Updated Item");

        Vm.ViewModelAction -= VmActions_Validation;
        Vm.ShowMessage -= Vm_Dialog;
    }

    [Test]
    public async Task SingleEditTest_Insert()
    {
        Vm.AddSingledEdit();
        Vm.Repository.Validator = new();
        Vm.Repository.Validator.Required(n => n.Name);
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);

        resultContext = null;
        var service = Vm.GetSingleEdit();

        var bkpName = service.CurrentEntry.Name;
        Vm.Commands["New"].Execute(null);
        await Task.Delay(5);
        service.CurrentEntry.Id = System.Guid.NewGuid();
        service.CurrentEntry.Name = null;

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(5);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(5);
        service.CurrentEntry.Name.Should().Be(bkpName);

        resultContext = null;
        Vm.Commands["New"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Id = System.Guid.NewGuid();
        service.CurrentEntry.Name = "Added Item";

        Vm.Commands["Save"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);
        resultContext.Should().BeNull();

        Vm.Commands["Get"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);

        Vm.Repository.DataContext.Should().HaveCount(6);

        Vm.ViewModelAction -= VmActions_Validation;
    }

    private bool _refuseDelete = true;
    [Test]
    public async Task SingleEditTest_Delete()
    {
        Vm.AddSingledEdit();
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);
        while (Vm.IsLoading)
            await Task.Delay(50);

        resultContext = null;
        var service = Vm.GetSingleEdit();

        _refuseDelete = true;
        Vm.Commands["Delete"].Execute(Vm.Repository.DataContext.Last());
        while (Vm.IsLoading)
            await Task.Delay(50);

        resultContext.Should().BeNull();
        Vm.Repository.DataContext.Should().HaveCount(5);

        _refuseDelete = false;
        Vm.Commands["Delete"].Execute(Vm.Repository.DataContext.Last());
        while (Vm.IsLoading)
            await Task.Delay(50);

        resultContext.Should().Be("ok");
        Vm.Repository.DataContext.Should().HaveCount(4);

        Vm.ViewModelAction -= VmActions_Validation;
        Vm.ShowMessage -= Vm_Dialog;
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
            case Enums.CRUD.Action.DetailEntryDeleted:
                {
                    resultContext = "ok";
                    break;
                }
            case Enums.CRUD.Action.EntryAdding:
            case Enums.CRUD.Action.Saving:
            case Enums.CRUD.Action.EntryEditing:
                if (shouldCancel == true)
                    e.Cancel = true;

                break;

            //default:
            //    resultContext = null;
            //    break;
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
            //_saveNotified = true;
        }

        //if (e.StackTrace != null)
        //    _exceptionRaised = true;
    }

}