using AwesomeAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EficazFramework.Repositories;

public class ApiRepositoryTests
{
    internal EficazFramework.Tests.Resources.Mock.API.ApiApplicationFactory Aplication { get; private set; }
    public IServiceScope Scope { get; private set; }
    public IServiceProvider Provider { get; private set; }
    public HttpClient Client { get; private set; }
    
    [OneTimeSetUp]
    public void Setup()
    {
        Aplication = new();
        Scope = Aplication.Services.CreateScope();
        Provider = Scope.ServiceProvider;
        Client = Aplication.CreateClient();
    }

    [Test]
    public async Task ApiTest()
    {
        var response = await Client.GetAsync("/mock/get");
        response.IsSuccessStatusCode.Should().BeTrue();
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var result = await response.Content.ReadFromJsonAsync<List<Resources.Mocks.Classes.MockClass>>();
        result.Should().HaveCount(300);
    }

    [Test]
    public void SelectTest()
    {
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/get",
            GetRequestMode = Enums.CRUD.RequestAction.Get,
        };
        repository.DataContext.Should().HaveCount(0);
        repository.Get();
        repository.DataContext.Should().HaveCount(300);
    }

    [Test]
    public async Task SelectAsyncTest()
    {
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/get"
        };
        repository.DataContext.Should().HaveCount(0);
        await repository.GetAsync(default);
        repository.DataContext.Should().HaveCount(300);
        repository.DataContext.Where(r => r.Id == 1).Count().Should().BeGreaterThan(0);
        repository.DataContext.Where(r => r.Id != 1).Count().Should().BeGreaterThan(0);
    }

    [Test]
    public async Task SelectWithPostAsyncTest()
    {
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/get",
            GetRequestMode = Enums.CRUD.RequestAction.Post,
        };
        repository.DataContext.Should().HaveCount(0);
        await repository.GetAsync(default);
        repository.DataContext.Should().HaveCount(300);
        repository.DataContext.Where(r => r.Id == 1).Count().Should().BeGreaterThan(0);
        repository.DataContext.Where(r => r.Id != 1).Count().Should().BeGreaterThan(0);
    }


    [Test]
    public async Task SelectStressAsyncTest()
    {
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/getBig",
        };
        repository.DataContext.Should().HaveCount(0);
        await repository.GetAsync(default);
        repository.DataContext.Should().HaveCount(1500000);
    }

    [Test]
    public async Task SelectFilteredAsyncTest()
    {
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/get",
            GetRequestMode = Enums.CRUD.RequestAction.Post,
            Filter =
            [
                new Expressions.ExpressionObjectQuery()
                {
                    FieldName = "Id",
                    Operator = Enums.CompareMethod.Equals,
                    Value = 1
                }
            ]
        };
        repository.DataContext.Should().HaveCount(0);
        await repository.GetAsync(default);
        repository.DataContext.Where(r => r.Id == 1).Count().Should().BeGreaterThan(0);
        repository.DataContext.Where(r => r.Id != 1).Count().Should().Be(0);
    }

    [Test]
    public async Task UpdateTest()
    {
        string newName = System.Guid.NewGuid().ToString();

        var dataContext = EficazFramework.API.Mock.MockDb;
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/getForCrudTest",
            UrlPut = "/mock/update"
        };
        repository.Get();
        repository.DataContext.Should().HaveCount(5);

        repository.CurrentEntry = repository.DataContext.First();
        repository.CurrentEntry.Name.Should().NotBe(newName);
        repository.CurrentEntry.Name = newName;
        var id = repository.CurrentEntry.Id;
        await repository.CommitAsync(default);
        repository.DataContext.Clear();

        repository.Get();
        var item = repository.DataContext.Where(i => i.Id == id).FirstOrDefault();
        item.Should().NotBeNull();
        item.Name.Should().Be(newName);
    }

    [Test]
    public async Task ResponseUnauthorized()
    {
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/fail/401"
        };
        await repository.Invoking(async (a) => await repository.GetAsync(default)).Should().ThrowAsync<UnauthorizedAccessException>();
        ;
        repository.DataContext.Should().HaveCount(0);
    }

    [Test]
    public async Task ResponseValidationFailed()
    {
        var repository = new ApiRepository<Resources.Mocks.Classes.MockClass>(Client)
        {
            UrlGet = "/mock/fail/422"
        };
        await repository.Invoking(async (a) => await repository.GetAsync(default)).Should().ThrowAsync<ValidationException>();
        repository.DataContext.Should().HaveCount(0);
    }

}
