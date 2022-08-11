using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        var response = await Client.PostAsJsonAsync("/mock/get", new object(), default);
        response.IsSuccessStatusCode.Should().BeTrue();
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var result = await response.Content.ReadFromJsonAsync<List<Shared.MockClass>>();
        result.Should().HaveCount(300);
    }

    [Test]
    public void SelectTest()
    {
        var repository = new ApiRepository<Shared.MockClass>(Client);
        repository.UrlGet = "/mock/get";
        repository.DataContext.Should().HaveCount(0);
        repository.Get();
        repository.DataContext.Should().HaveCount(300);
    }

    [Test]
    public async Task SelectAsyncTest()
    {
        var repository = new ApiRepository<Shared.MockClass>(Client);
        repository.UrlGet = "/mock/get";
        repository.DataContext.Should().HaveCount(0);
        await repository.GetAsync(default);
        repository.DataContext.Should().HaveCount(300);
        repository.DataContext.Where(r => r.Id == 1).Count().Should().BeGreaterThan(0);
        repository.DataContext.Where(r => r.Id != 1).Count().Should().BeGreaterThan(0);
    }

    [Test]
    public async Task SelectStressAsyncTest()
    {
        var repository = new ApiRepository<Shared.MockClass>(Client);
        repository.UrlGet = "/mock/getBig";
        repository.DataContext.Should().HaveCount(0);
        await repository.GetAsync(default);
        repository.DataContext.Should().HaveCount(1500000);
    }

    [Test]
    public async Task SelectFilteredAsyncTest()
    {
        var repository = new ApiRepository<Shared.MockClass>(Client);
        repository.UrlGet = "/mock/get";
        repository.Filter = new()
        {
            new Expressions.ExpressionObjectQuery()
            {
                FieldName = "Id",
                Operator = Enums.CompareMethod.Equals, 
                Value = 1
            }
        };
        repository.DataContext.Should().HaveCount(0);
        await repository.GetAsync(default);
        repository.DataContext.Where(r => r.Id == 1).Count().Should().BeGreaterThan(0);
        repository.DataContext.Where(r => r.Id != 1).Count().Should().Be(0);
    }

}
