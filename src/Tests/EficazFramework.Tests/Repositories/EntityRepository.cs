using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using EficazFramework.Validation.Fluent.Rules;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EficazFramework.Extensions;
using System.Collections.Generic;

namespace EficazFramework.Repositories;

public class EntityRepositoryTests
{
    [Test, Order(1)]
    public async Task SelectTest()
    {
        var repository = new EntityRepository<Resources.Mocks.Classes.Blog>();
        repository.DbContextInstanceRequest += (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
        repository.DbContext.Should().BeNull();
        repository.PageSize = 10;
        repository.Get();
        repository.DbContext.Should().NotBeNull();
        repository.DataContext.Should().HaveCount(0);
        repository.OrderByDefinitions.Add(new Collections.SortDescription() { PropertyName = "Name", Direction = Enums.Collection.SortOrientation.Asceding });
        await repository.GetAsync(default);
        repository.DataContext.Should().HaveCount(0);
        repository.CurrentPage.Should().Be(1);

        repository.OrderByDefinitions.Clear();
        repository.CustomFetch = async () => (await repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToListAsync()).ToObservableCollection<Resources.Mocks.Classes.Blog>();
        var result = repository.FetchItems();
        result.Count.Should().Be(0);
        result = await repository.FetchItemsAsync(default);
        result.Count.Should().Be(0);

        repository.DbContextInstanceRequest -= (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
        repository.Dispose();
    }

    [Test, Order(2)]
    public void CreateEntry()
    {
        var repository = new EntityRepository<Resources.Mocks.Classes.Blog>();
        var newEntry = repository.Create();
        (newEntry as Resources.Mocks.Classes.Blog).Should().NotBeNull();
        var newPost = repository.Create<Resources.Mocks.Classes.Post>();
        (newPost as Resources.Mocks.Classes.Post).Should().NotBeNull();
    }

    [Test, Order(3)]
    public async Task ValidationTest()
    {
        var repository = new EntityRepository<Resources.Mocks.Classes.Blog>();
        repository.Validator = new Validation.Fluent.Validator<Resources.Mocks.Classes.Blog>();
        repository.Validator.Required(x => x.Name);
        var newEntry = repository.Create();

        repository.Validate(newEntry).Should().HaveCount(1);
        (await repository.ValidateAsync(newEntry)).Should().HaveCount(1);

        repository.Validate(null).Should().HaveCount(0);
        (await repository.ValidateAsync(null)).Should().HaveCount(0);

        repository.Validator = null;
        repository.Validate(newEntry).Should().HaveCount(0);
        (await repository.ValidateAsync(newEntry)).Should().HaveCount(0);

    }

    [Test, Order(4)]
    public async Task InsertTest()
    {
        var repository = new EntityRepository<Resources.Mocks.Classes.Blog>();
        
        var newEntry = repository.Create();
        newEntry.Name = "My New Blog";
        repository.DbContextInstanceRequest += (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
        repository.Add(newEntry, false);
        repository.DataContext.Should().HaveCount(1);

        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(0);

        var newEntry2 = repository.Create();
        newEntry2.Name = "My Second New Blog!";
        await repository.AddAsync(newEntry2, false, default);
        repository.DataContext.Should().HaveCount(2);

        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(0);

        var ex = await repository.CommitAsync(default);
        ex.Should().BeNull();
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(2);

        var newEntry3 = repository.Create();
        newEntry3.Name = "Another New Blog";
        repository.Add(newEntry3, true);
        repository.DataContext.Should().HaveCount(3);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(3);

        var newEntry4 = repository.Create();
        newEntry4.Name = "The last blog";
        await repository.AddAsync(newEntry4, true, default);
        repository.DataContext.Should().HaveCount(4);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(4);

        repository.DbContextInstanceRequest -= (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
    }

    [Test, Order(5)]
    public async Task DeleteTest()
    {
        var repository = new EntityRepository<Resources.Mocks.Classes.Blog>();
        repository.DbContextInstanceRequest += (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
        repository.PrepareDbContext();
        //clear if running all tests.
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().RemoveRange(repository.DbContext.Set<Resources.Mocks.Classes.Blog>());
        var ex = repository.Commit();

        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(0);
        var newEntry = repository.Create();
        newEntry.Name = "My New Blog";
        await repository.AddAsync(newEntry, true, default);
        var newEntry2 = repository.Create();
        newEntry2.Name = "My Second New Blog!";
        await repository.AddAsync(newEntry2, true, default);
        var newEntry3 = repository.Create();
        newEntry3.Name = "Another New Blog";
        await repository.AddAsync(newEntry3, true, default);
        var newEntry4 = repository.Create();
        newEntry4.Name = "The last blog";
        await repository.AddAsync(newEntry4, true, default);

        repository.DataContext.Should().HaveCount(4);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(4);

        repository.Delete(newEntry, false);
        repository.DataContext.Should().HaveCount(3);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(4);

        await repository.DeleteAsync(newEntry2, false, default);
        repository.DataContext.Should().HaveCount(2);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(4);

        ex = repository.Commit();
        ex.Should().BeNull();
        repository.DataContext.Should().HaveCount(2);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(2);

        repository.Delete(newEntry3, true);
        repository.DataContext.Should().HaveCount(1);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(1);

        await repository.DeleteAsync(newEntry4, true, default);
        repository.DataContext.Should().HaveCount(0);
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().ToList().Should().HaveCount(0);

        repository.DbContextInstanceRequest -= (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
    }

    [Test, Order(6)]
    public async Task UpdateTest()
    {
        var repository = new EntityRepository<Resources.Mocks.Classes.Blog>();
        repository.DbContextInstanceRequest += (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
        repository.PrepareDbContext();
        //clear if running all tests.
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().RemoveRange(repository.DbContext.Set<Resources.Mocks.Classes.Blog>());
        var ex = repository.Commit();

        var newEntry = repository.Create();
        newEntry.Name = "My New Blog";
        repository.Add(newEntry, true);

        await repository.FetchItemsAsync(default);
        repository.DataContext.Should().HaveCount(1);
        repository.DbContext.Attach(repository.DataContext.First());
        repository.DataContext.First().Name = "My Updated Blog!";

        ex = repository.Commit();
        ex.Should().BeNull();
        repository.DbContext.Set<Resources.Mocks.Classes.Blog>().AsNoTracking().FirstOrDefault().Name.Should().Be("My Updated Blog!");

        repository.PrepareDbContext();
        await repository.FetchItemsAsync(default);
        repository.DataContext.First().Name.Should().Be("My Updated Blog!");

    }

    [Test, Order(6)]
    public async Task CancelEditingTest()
    {
        var repository = new EntityRepository<Resources.Mocks.Classes.Blog>();
        repository.DbContextInstanceRequest += (s, e) => e.Instance = new Resources.Mocks.InMemoryDbContext();
        repository.PrepareDbContext();

        var newEntry = repository.Create();
        newEntry.Name = "My New Blog";
        repository.Add(newEntry, true);
        var ex = repository.Commit();

        await repository.FetchItemsAsync(default);
        repository.DataContext.Should().HaveCount(1);
        repository.DbContext.Attach(repository.DataContext.First());

        repository.DataContext.First().Name = "My Updated Blog!";
        ex = repository.Cancel(newEntry);
        ex.Should().BeNull();
        newEntry.Name.Should().Be("My New Blog");

        repository.DataContext.First().Name = "My Updated Blog!";
        ex = await repository.CancelAsync(newEntry);
        ex.Should().BeNull();
        newEntry.Name.Should().Be("My New Blog");
    }

}
