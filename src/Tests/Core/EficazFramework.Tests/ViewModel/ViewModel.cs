using EficazFramework.ViewModels.Services;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Security.Policy;

namespace EficazFramework.ViewModels;

public class ViewModel
{
    private ViewModels.ViewModel<Resources.Mocks.Classes.Blog> Vm;

    public void Setup(long? sectionID = null)
    {
        if (sectionID.HasValue)
            Vm = new ViewModel<Resources.Mocks.Classes.Blog>(sectionID.Value);
        else
            Vm = new ViewModel<Resources.Mocks.Classes.Blog>();
    }

    [Test, Order(1)]
    public void ConstructorTest()
    {
        Setup();
        Vm.SectionID.Should().Be(0);
        Vm.Commands.Should().HaveCount(1);
        Vm.Commands.ContainsKey("Get").Should().BeTrue();

        Setup(1);
        Vm.SectionID.Should().Be(1);
        Vm.Commands.Should().HaveCount(1);
        Vm.Commands.ContainsKey("Get").Should().BeTrue();

        Vm.State.Should().Be(Enums.CRUD.State.Bloqueado);
        Vm.Repository.Should().BeNull();
        Vm.Services.Should().HaveCount(0);

        Vm.Dispose();
    }

    [Test, Order(2)]
    public void NavigationIndexTest()
    {
        Setup();
        Vm.WithNavigationByIndex().Should().NotBeNull();
        Vm.GetIndexNavigator().Should().NotBeNull();
        var navigator = Vm.GetIndexNavigator();
        object.ReferenceEquals(navigator, Vm.GetService<IndexViewNavigator<Resources.Mocks.Classes.Blog>, Resources.Mocks.Classes.Blog>()).Should().BeTrue();
        navigator.SelectedIndex.Should().Be(0);

        //avoid duplicate:
        Exception ex = null;
        try
        {
            ex.Should().BeNull();
            Vm.WithNavigationByIndex();
        }
        catch (Exception argEx)
        {
            ex = argEx;
        }
        ex.Should().NotBeNull();

        //commands
        Vm.Commands.Should().HaveCount(2);
        Vm.Commands.ContainsKey("GoToFindPage").Should().BeTrue();

        // navigation
        navigator = Vm.GetIndexNavigator();

        Vm.SetState(Enums.CRUD.State.Novo, false, null);
        navigator.SelectedIndex.Should().Be(navigator.FormIndex);

        Vm.SetState(Enums.CRUD.State.Edicao, false, null);
        navigator.SelectedIndex.Should().Be(navigator.FormIndex);

        Vm.SetState(Enums.CRUD.State.Bloqueado, false, null);
        navigator.SelectedIndex.Should().Be(navigator.EntriesIndex);

        navigator.SearchIndex = 0;
        Vm.SetState(Enums.CRUD.State.Leitura, false, null);
        navigator.SelectedIndex.Should().Be(navigator.SearchIndex);

        Vm.SetState(Enums.CRUD.State.Bloqueado, false, null);
        navigator.SelectedIndex.Should().Be(navigator.SearchIndex);

        // master / detail
        navigator.DetailFormIndex.Add("Posts", 2);
        navigator.CurrentDetail = "Posts";

        Vm.SetState(Enums.CRUD.State.NovoDetalhe, false, null);
        navigator.SelectedIndex.Should().Be(navigator.DetailFormIndex[navigator.CurrentDetail]);

        Vm.SetState(Enums.CRUD.State.EdicaoDeDelhe, false, null);
        navigator.SelectedIndex.Should().Be(navigator.DetailFormIndex[navigator.CurrentDetail]);

        Vm.Commands["GoToFindPage"].Execute(null);
        navigator.SelectedIndex.Should().Be(navigator.SearchIndex);

        Vm.RemoveNavigationByIndex();
        Vm.Services.Should().HaveCount(0);

        // invalid constructor
        ex = null;
        try
        {
            IndexViewNavigator<Resources.Mocks.Classes.Post> navigator1 = new(null);
        }
        catch (Exception constructorEx)
        {
            ex = constructorEx;
        }
        ex.Should().NotBeNull();
    }

    [Test, Order(3)]
    public void ServiceUtilsTest()
    {
        Setup();
        Vm.WithNavigationByIndex().Should().NotBeNull();
        Vm.Invoking(y => y.WithNavigationByIndex()).Should().Throw<ArgumentException>();
        Vm.RemoveNavigationByIndex();

        Vm.AddEntityFramework();
        Vm.Invoking(y => y.AddEntityFramework()).Should().Throw<ArgumentException>();
        Vm.RemoveEntityFramework();

        Vm.AddSingledEdit();
        Vm.Invoking(y => y.AddSingledEdit()).Should().Throw<ArgumentException>();
        Vm.RemoveSingleEdit();

        Vm.Invoking(y => y.AddSingledEditDetail(p => p.Posts)).Should().Throw<PolicyException>();
        Vm.AddSingledEdit();
        Vm.AddSingledEditDetail(p => p.Posts);
        Vm.Invoking(y => y.AddSingledEditDetail(p => p.Posts)).Should().Throw<ArgumentException>();
        Vm.RemoveSingleEditDetail<Resources.Mocks.Classes.Blog, Resources.Mocks.Classes.Post>();
        Vm.RemoveSingleEdit();

        Vm.AddTabular();
        Vm.Invoking(y => y.AddTabular()).Should().Throw<ArgumentException>();
        Vm.RemoveTabular();

        Vm.Invoking(y => y.AddTabularEditDetail(p => p.Posts)).Should().Throw<PolicyException>();
        Vm.AddSingledEdit();
        Vm.AddTabularEditDetail(p => p.Posts);
        Vm.Invoking(y => y.AddTabularEditDetail(p => p.Posts)).Should().Throw<ArgumentException>();
        Vm.Services.Clear();

        Vm.AddCustom("customOne", new Resources.Mocks.Classes.CustomViewModelService<Resources.Mocks.Classes.Blog>(Vm));
        Vm.RemoveCustom("customOne");

        Vm.Invoking(p => Vm.RemoveCustom("customTwo")).Should().Throw<System.Collections.Generic.KeyNotFoundException>();
    }
}