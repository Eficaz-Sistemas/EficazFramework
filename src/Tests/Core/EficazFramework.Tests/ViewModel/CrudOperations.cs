using EficazFramework.Validation.Fluent.Rules;
using EficazFramework.ViewModels.Services;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.ViewModels;

public class CrudOperations
{
    private ViewModels.ViewModel<Resources.Mocks.Classes.Blog> Vm;
    string resultContext = null;
    bool shouldCancel = false;

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
        ((EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).DbContextRequest = () => new Resources.Mocks.MockDbContext();

        // seed
        dbContextRepo.PrepareDbContext();
        (await dbContextRepo.DbContext.Database.EnsureCreatedAsync()).Should().BeTrue();
        for (int i = 0; i < 100; i++)
        {
            var tmpId = System.Guid.NewGuid();
            dbContextRepo.DbContext.Add(new Resources.Mocks.Classes.Blog()
            {
                Id = tmpId,
                Name = $"Blog {i}"
            });
            dbContextRepo.DbContext.Add(new Resources.Mocks.Classes.Post()
            {
                BlogId = tmpId,
                PostId = System.Guid.NewGuid(),
                Title = $"Post {i}"
            });
        }
        await dbContextRepo.DbContext.SaveChangesAsync();
        await dbContextRepo.DbContext.DisposeAsync();
        dbContextRepo.DbContext = null;
    }

    [TearDown]
    public async Task TearDown()
    {
        ((EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).DbContextRequest = () => new Resources.Mocks.MockDbContext();
        Vm.Dispose();

        var ctb = new Resources.Mocks.MockDbContext();
        (await ctb.Database.EnsureDeletedAsync()).Should().BeTrue();
    }

    [Test, Order(1)]
    public void SelectTest()
    {
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(100);

        Vm.Repository.PageSize = 45;

        Vm.Repository.CurrentPage.Should().Be(1);
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(45); // 1..45

        Vm.Repository.NextPage().Should().BeTrue();
        Vm.Repository.CurrentPage.Should().Be(2);
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(45); // 46..90

        Vm.Repository.NextPage().Should().BeTrue();
        Vm.Repository.CurrentPage.Should().Be(3);
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(10); // 91..100

        Vm.Repository.NextPage().Should().BeFalse();
        Vm.Repository.CurrentPage.Should().Be(3);

        Vm.Repository.PreviousPage().Should().BeTrue();
        Vm.Repository.CurrentPage.Should().Be(2);
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(45); // 45..90

        Vm.Repository.FirstPage().Should().BeTrue();
        Vm.Repository.CurrentPage.Should().Be(1);
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(45); // 1..45

        Vm.Repository.PreviousPage().Should().BeFalse();
        Vm.Repository.CurrentPage.Should().Be(1);

    }



    [Test, Order(2)]
    public void TabularConstructorTest()
    {
        Vm.AddTabular();
        Vm.Services.Should().HaveCount(2);
        Vm.Commands.Should().HaveCount(3); // + Save && Cancel
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).AsNoTracking.Should().BeFalse();
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

        Vm.RemoveTabular();
    }



    [Test, Order(4)]
    public async Task SingleEditTest_Navigation()
    {
        Vm.ViewModelAction += VmActions_Validation;

        Vm.AddSingledEdit();
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
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
        Vm.Repository.DataContext.Should().HaveCount(100);
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
        Vm.Commands["Cancel"].Execute(null); // but VM will lock
        await Task.Delay(100);

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
        Vm.Repository.DataContext.Should().HaveCount(100);

        shouldCancel = false;
        Vm.ViewModelAction -= VmActions_Validation;
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

        Vm.Repository.Filter = (e) => e.Name == "Updated Item";
        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Should().HaveCount(1);
        Vm.Repository.DataContext[0].Name.Should().Be("Updated Item");


        Vm.ViewModelAction -= VmActions_Validation;
        Vm.ShowMessage -= Vm_Dialog;
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
    }

    [Test, Order(7)]
    public async Task SingleEditTest_BatchInsert()
    {
        Vm.AddSingledEdit();
        Vm.Repository.Validator = new();
        Vm.Repository.Validator.Required(n => n.Name);
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);

        resultContext = null;
        var service = Vm.GetSingleEdit();
        service.BatchInsert = true;

        Vm.Commands["New"].Execute(null);
        await Task.Delay(50);
        service.CurrentEntry.Id = System.Guid.NewGuid();
        service.CurrentEntry.Name = "Added Item";
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(1000);
        resultContext.Should().BeNull();

        Vm.State.Should().Be(Enums.CRUD.State.Novo);

        service.CurrentEntry.Id = System.Guid.NewGuid();
        service.CurrentEntry.Name = "Added Item 2 ";
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(1000);
        resultContext.Should().BeNull();

        Vm.State.Should().Be(Enums.CRUD.State.Novo);


        Vm.ViewModelAction -= VmActions_Validation;
        Vm.RemoveSingleEdit();
    }

    private bool _refuseDelete = true;
    [Test, Order(8)]
    public async Task SingleEditTest_Delete()
    {
        Vm.AddSingledEdit();
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;

        Vm.Commands["Get"].Execute(null);

        resultContext = null;
        var service = Vm.GetSingleEdit();

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
    }

    bool _exceptionRaised = false;
    [Test, Order(14)]
    public async Task SingleEdit_Exceptions()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.FailAssertion = true;
        Vm.AddSingledEdit();
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        var service = Vm.GetSingleEdit();
        Vm.Commands["Get"].Execute(null);


        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        shouldCancel = false;
        _exceptionRaised = false;
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(250);
        _exceptionRaised.Should().BeTrue();

        _exceptionRaised = false;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(250);
        _exceptionRaised.Should().BeTrue();


        Vm.FailAssertion = false;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(250);

        Vm.FailAssertion = true;
        _refuseDelete = false;
        shouldCancel = false;
        _exceptionRaised = false;
        Vm.Commands["Delete"].Execute(service.CurrentEntry);
        await Task.Delay(250);
        _exceptionRaised.Should().BeTrue();
        _exceptionRaised = false;

        Vm.ShowMessage -= Vm_Dialog;
    }


    [Test, Order(10)]
    public async Task SingleEditDetailTest_NavigationProperties()
    {
        Vm.AddSingledEdit().AddSingledEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        SingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();

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
        await Task.Delay(200);
        Vm.Repository.DataContext.Count(p => p.Posts.Count <= 0).Should().Be(0);

        Vm.Commands["NewDetail_Posts"].Execute(null); // but VM will lock
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        Vm.Commands["DeleteDetail_Posts"].Execute(null); // but VM will lock
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

    }

    [Test, Order(11)]
    public async Task SingleEditDetailTest_Update()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;
        resultContext = null;

        Vm.WithNavigationByIndex().AddSingledEdit().AddSingledEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        SingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        service.MoveToFirst();
        ReferenceEquals(service.CurrentEntry, serviceMain.CurrentEntry.Posts.First()).Should().BeTrue();

        var bkpName = service.CurrentEntry.Title;
        Vm.Commands["EditDetail_Posts"].Execute(null);
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.EdicaoDeDelhe);
        service.CurrentEntry.Title = null;

        Vm.Commands["SaveDetail_Posts"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["CancelDetail_Posts"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Title.Should().Be(bkpName);
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        Vm.Commands["EditDetail_Posts"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Title = "Edited!";
        Vm.State.Should().Be(Enums.CRUD.State.EdicaoDeDelhe);

        Vm.Commands["SaveDetail_Posts"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.SelectMany(p => p.Posts).Where(p => p.Title.Contains("Edited!")).Should().HaveCount(1);

        Vm.ShowMessage -= Vm_Dialog;
        Vm.ViewModelAction -= VmActions_Validation;
    }

    [Test, Order(12)]
    public async Task SingleEditDetailTest_Insert()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;
        resultContext = null;

        Vm.WithNavigationByIndex().AddSingledEdit().AddSingledEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        SingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);
        serviceMain.MoveTo(Vm.Repository.DataContext.Single(b => b.Name == "Blog 1"));

        Vm.Commands["Edit"].Execute(null);

        await Task.Delay(100);
        service.MoveToFirst();
        ReferenceEquals(service.CurrentEntry, serviceMain.CurrentEntry.Posts.First()).Should().BeTrue();

        Vm.Commands["NewDetail_Posts"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.IsNew.Should().BeTrue();
        service.CurrentEntry.BlogId = serviceMain.CurrentEntry.Id;
        service.CurrentEntry.Title = null;
        Vm.State.Should().Be(Enums.CRUD.State.NovoDetalhe);

        Vm.Commands["SaveDetail_Posts"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["CancelDetail_Posts"].Execute(null);
        await Task.Delay(100);
        serviceMain.CurrentEntry.Posts.Should().HaveCount(1);
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        Vm.Commands["NewDetail_Posts"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.IsNew.Should().BeTrue();
        service.CurrentEntry.BlogId = serviceMain.CurrentEntry.Id;
        service.CurrentEntry.Title = "Postagem 2";
        Vm.State.Should().Be(Enums.CRUD.State.NovoDetalhe);

        Vm.Commands["SaveDetail_Posts"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();

        service.MoveNext();
        service.CurrentEntry.Title.Should().Be("Postagem 2");
        service.MoveNext();
        service.CurrentEntry.Title.Should().Be("Postagem 2");
        service.MovePrevious();
        service.CurrentEntry.Title.Should().Be("Post 1");
        service.MovePrevious();
        service.CurrentEntry.Title.Should().Be("Post 1");
        service.MoveToFirst();
        service.CurrentEntry.Title.Should().Be("Post 1");
        service.MoveToLast();
        service.CurrentEntry.Title.Should().Be("Postagem 2");
        service.MoveTo(serviceMain.CurrentEntry.Posts[0]);
        service.CurrentEntry.Title.Should().Be("Post 1");

        Vm.State.Should().Be(Enums.CRUD.State.Edicao);
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Count(b => b.Posts.Count == 2).Should().Be(1);

        Vm.ShowMessage -= Vm_Dialog;
        Vm.ViewModelAction -= VmActions_Validation;
    }

    [Test, Order(13)]
    public async Task SingleEditDetailTest_Delete()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;
        resultContext = null;

        Vm.WithNavigationByIndex().AddSingledEdit().AddSingledEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        SingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);
        serviceMain.MoveTo(Vm.Repository.DataContext.Single(b => b.Name == "Blog 1"));

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        service.MoveToFirst();
        ReferenceEquals(service.CurrentEntry, serviceMain.CurrentEntry.Posts.First()).Should().BeTrue();

        _refuseDelete = true;
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        service.DataContext.Should().HaveCount(1);

        _refuseDelete = false;
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(100);
        resultContext.Should().Be("ok");
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(1);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(100);
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(0);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        _refuseDelete = false;
        resultContext = null;
        service.MoveToFirst();
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(100);
        resultContext.Should().Be("ok");
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(1);

        Vm.State.Should().Be(Enums.CRUD.State.Edicao);
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        serviceMain.CurrentEntry.Posts.Should().HaveCount(0);
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(0);

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Count(b => b.Posts.Count == 0).Should().Be(1);

        Vm.ShowMessage -= Vm_Dialog;
        Vm.ViewModelAction -= VmActions_Validation;
    }

    [Test, Order(14)]
    public async Task SingleEditDetailTest_DeleteWithAutoCommit()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;
        resultContext = null;

        Vm.WithNavigationByIndex().AddSingledEdit().AddSingledEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        SingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);
        service.CommitOnSave = true;

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);
        serviceMain.MoveTo(Vm.Repository.DataContext.Single(b => b.Name == "Blog 1"));

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        service.MoveToFirst();
        ReferenceEquals(service.CurrentEntry, serviceMain.CurrentEntry.Posts.First()).Should().BeTrue();

        _refuseDelete = true;
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        service.DataContext.Should().HaveCount(1);

        _refuseDelete = false;
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(250);
        resultContext.Should().Be("ok");
        service.DataContext.Should().HaveCount(0);
        serviceMain.CurrentEntry.Posts.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(0);

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Count(b => b.Posts.Count == 0).Should().Be(1);

        Vm.RemoveSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        Vm.ShowMessage -= Vm_Dialog;
        Vm.ViewModelAction -= VmActions_Validation;
    }

    [Test, Order(15)]
    public async Task SingleEditDetail_Exceptions()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.FailAssertion = true;
        Vm.WithNavigationByIndex().AddSingledEdit().AddSingledEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        SingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);
        service.CommitOnSave = true;

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);
        serviceMain.MoveTo(Vm.Repository.DataContext.Single(b => b.Name == "Blog 1"));

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        service.MoveToFirst();
        Vm.Commands["EditDetail_Posts"].Execute(null);
        await Task.Delay(100);


        shouldCancel = false;
        _exceptionRaised = false;
        Vm.Commands["SaveDetail_Posts"].Execute(null);
        await Task.Delay(250);
        _exceptionRaised.Should().BeTrue();

        _exceptionRaised = false;
        Vm.Commands["CancelDetail_Posts"].Execute(null);
        await Task.Delay(250);
        _exceptionRaised.Should().BeTrue();


        Vm.FailAssertion = false;
        Vm.Commands["CancelDetail_Posts"].Execute(null);
        await Task.Delay(250);

        Vm.FailAssertion = true;
        _refuseDelete = false;
        shouldCancel = false;
        _exceptionRaised = false;
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(250);
        _exceptionRaised.Should().BeTrue();
        _exceptionRaised = false;

        Vm.ShowMessage -= Vm_Dialog;

    }



    [Test, Order(16)]
    public async Task TabularEditDetailTest_NavigationProperties()
    {
        Vm.AddSingledEdit().AddTabularEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        TabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetTabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);
        Vm.Repository.DataContext.Count(p => p.Posts.Count <= 0).Should().Be(0);
    }

    [Test, Order(17)]
    public async Task TabularEditDetailTest_Update()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;
        resultContext = null;

        Vm.WithNavigationByIndex().AddSingledEdit().AddTabularEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        TabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetTabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        service.MoveToFirst();
        ReferenceEquals(service.CurrentEntry, serviceMain.CurrentEntry.Posts.First()).Should().BeTrue();

        var bkpName = service.CurrentEntry.Title;
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);
        service.CurrentEntry.Title = null;

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.Title.Should().Be(bkpName);
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        service.MoveToFirst();
        service.CurrentEntry.Title = "Edited!";
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.SelectMany(p => p.Posts).Where(p => p.Title.Contains("Edited!")).Should().HaveCount(1);

        Vm.ShowMessage -= Vm_Dialog;
        Vm.ViewModelAction -= VmActions_Validation;
    }

    [Test, Order(18)]
    public async Task TabularEditDetailTest_Insert()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;
        resultContext = null;

        Vm.WithNavigationByIndex().AddSingledEdit().AddTabularEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        TabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetTabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);
        serviceMain.MoveTo(Vm.Repository.DataContext.Single(b => b.Name == "Blog 1"));

        Vm.Commands["Edit"].Execute(null);

        await Task.Delay(100);
        service.MoveToFirst();
        ReferenceEquals(service.CurrentEntry, serviceMain.CurrentEntry.Posts.First()).Should().BeTrue();

        Vm.Commands["NewDetail_Posts"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.IsNew.Should().BeTrue();
        service.CurrentEntry.BlogId = serviceMain.CurrentEntry.Id;
        service.CurrentEntry.Title = null;
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().Be(Resources.Strings.Validation.Dialog_Title);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(100);
        Vm.State.Should().Be(Enums.CRUD.State.Leitura);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        Vm.Commands["NewDetail_Posts"].Execute(null);
        await Task.Delay(100);
        service.CurrentEntry.IsNew.Should().BeTrue();
        service.CurrentEntry.BlogId = serviceMain.CurrentEntry.Id;
        service.CurrentEntry.Title = "Postagem 2";
        Vm.State.Should().Be(Enums.CRUD.State.Edicao);

        service.MoveNext();
        service.CurrentEntry.Title.Should().Be("Postagem 2");
        service.MoveNext();
        service.CurrentEntry.Title.Should().Be("Postagem 2");
        service.MovePrevious();
        service.CurrentEntry.Title.Should().Be("Post 1");
        service.MovePrevious();
        service.CurrentEntry.Title.Should().Be("Post 1");
        service.MoveToFirst();
        service.CurrentEntry.Title.Should().Be("Post 1");
        service.MoveToLast();
        service.CurrentEntry.Title.Should().Be("Postagem 2");
        service.MoveTo(serviceMain.CurrentEntry.Posts[0]);
        service.CurrentEntry.Title.Should().Be("Post 1");

        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Count(b => b.Posts.Count == 2).Should().Be(1);

        Vm.ShowMessage -= Vm_Dialog;
        Vm.ViewModelAction -= VmActions_Validation;
    }

    [Test, Order(19)]
    public async Task TabularEditDetailTest_Delete()
    {
        Vm.ShowMessage += Vm_Dialog;
        Vm.ViewModelAction += VmActions_Validation;
        resultContext = null;

        Vm.WithNavigationByIndex().AddSingledEdit().AddTabularEditDetail(dt => dt.Posts);
        Vm.Repository.OrderByDefinitions.Add(new Collections.SortDescription()
        {
            PropertyName = "Name",
            Direction = Enums.Collection.SortOrientation.Asceding
        });
        ((Repositories.EntityRepository<Resources.Mocks.Classes.Blog>)Vm.Repository).Includes.Add(i => i.Posts);
        var serviceMain = Vm.GetSingleEdit();
        TabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post> service = Vm.GetTabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        service.DetailValidator = new();
        service.DetailValidator.Required(p => p.Title);

        Vm.Commands["Get"].Execute(null);
        await Task.Delay(200);
        serviceMain.MoveTo(Vm.Repository.DataContext.Single(b => b.Name == "Blog 1"));

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        service.MoveToFirst();
        ReferenceEquals(service.CurrentEntry, serviceMain.CurrentEntry.Posts.First()).Should().BeTrue();

        _refuseDelete = true;
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        service.DataContext.Should().HaveCount(1);

        _refuseDelete = false;
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(100);
        resultContext.Should().Be("ok");
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(1);

        resultContext = null;
        Vm.Commands["Cancel"].Execute(null);
        await Task.Delay(100);
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(0);

        Vm.Commands["Edit"].Execute(null);
        await Task.Delay(100);

        _refuseDelete = false;
        resultContext = null;
        service.MoveToFirst();
        Vm.Commands["DeleteDetail_Posts"].Execute(service.CurrentEntry);
        await Task.Delay(100);
        resultContext.Should().Be("ok");
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(1);

        Vm.State.Should().Be(Enums.CRUD.State.Edicao);
        Vm.Commands["Save"].Execute(null);
        await Task.Delay(100);
        resultContext.Should().BeNull();
        serviceMain.CurrentEntry.Posts.Should().HaveCount(0);
        service.DataContext.Should().HaveCount(0);
        service.DeleteDataContext.Should().HaveCount(0);

        Vm.Commands["Get"].Execute(null);
        Vm.Repository.DataContext.Count(b => b.Posts.Count == 0).Should().Be(1);

        Vm.RemoveTabularEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        Vm.ShowMessage -= Vm_Dialog;
        Vm.ViewModelAction -= VmActions_Validation;
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

        if (e.StackTrace != null)
            _exceptionRaised = true;
    }

}