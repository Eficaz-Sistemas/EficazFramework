﻿using FluentAssertions;
using NUnit.Framework;
using EficazFramework.Validation.Fluent.Rules;
using System.Collections.Generic;
using System.Threading.Tasks;
using EficazFramework.ViewModels.Services;
using System;

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
    }
}