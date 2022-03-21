using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace EficazFramework.Application;

public class Apps
{
    EficazFramework.Application.IApplicationManager _appManager = EficazFramework.Application.IApplicationManager.Create();

    private void GenerateAppList()
    {
        if (_appManager.AllApplications.Count > 0)
            return;

        EficazFramework.Application.ApplicationDefinition index = new()
        {
            Group = "",
            Title = "Início"
        };
        EficazFramework.Application.ApplicationDefinition clientes = new()
        {
            Group = "Cadastros",
            Title = "Clientes"
        };
        EficazFramework.Application.ApplicationDefinition produtos = new()
        {
            Group = "Cadastros",
            Title = "Produtos"
        };
        EficazFramework.Application.ApplicationDefinition requisicoes = new()
        {
            Group = "Licenças",
            Title = "Requisições"
        };
        EficazFramework.Application.ApplicationDefinition cobranca = new()
        {
            Group = "Financeiro",
            Title = "Cobrança",
            IsPublic = false
        };
        EficazFramework.Application.ApplicationDefinition suporte = new()
        {
            Group = "Suporte",
            Title = "Atendimentos"
        };
        EficazFramework.Application.ApplicationDefinition manuais = new()
        {
            Group = "Suporte",
            Title = "Manuais",
            Condition = "AppTitle = value1"
        };
        _appManager.AllApplications.Add(index);
        _appManager.AllApplications.Add(clientes);
        _appManager.AllApplications.Add(produtos);
        _appManager.AllApplications.Add(requisicoes);
        _appManager.AllApplications.Add(cobranca);
        _appManager.AllApplications.Add(suporte);
        _appManager.AllApplications.Add(manuais);
    }

    [Test, Order(0)]
    public void Init()
    {
        _appManager.AllApplications.Count.Should().Be(0);
        _appManager.RunningApplications.Count.Should().Be(0);
    }

    [Test, Order(1)]
    public void CreateList()
    {
        GenerateAppList();
        var list = _appManager.AllApplications;
        list.Count.Should().Be(7);
        foreach (var app in list)
        {
            app.IsRunning().Should().Be(false);
        }
        list.FirstOrDefault().FirstChar.Should().Be('I');

    }

    [Test, Order(2)]
    public void ActivateAndClose()
    {
        GenerateAppList();
        _appManager.AllApplications[1].Activate();
        _appManager.RunningApplications.Count.Should().Be(1);
        _appManager.RunningApplications[0].ToString().Should().Be("[0] - Clientes");
        _appManager.AllApplications[5].Activate();
        _appManager.RunningApplications.Count.Should().Be(2);
        _appManager.Invoking(app => app.AllApplications[4].Activate()).Should().Throw<InvalidDataException>();

        _appManager.RunningApplications.First().Content.Should().BeNull();
        _appManager.RunningApplications.First().NotifyContent.Should().BeNull();
        _appManager.RunningApplications.First().PropertyChanged += PropertyChanged;
        _appManager.RunningApplications.First().Content = "client app";
        _appManager.RunningApplications.First().PropertyChanged -= PropertyChanged;
        _appManager.RunningApplications.First().NotifyContent.Should().Be("3 novos");

        _appManager.RunningApplications.Last().Content = new EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>();
        _appManager.RunningApplications.Last().Close();
        _appManager.RunningApplications.Count.Should().Be(1);

        _appManager.AllApplications[6].Condition.Should().Be("AppTitle = value1");
    }

    [Test, Order(3)]
    public void AvoidDuplicated()
    {
        GenerateAppList();
        _appManager.AllApplications[1].Activate();
        _appManager.RunningApplications.Count.Should().Be(1);
    }

    private void PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(EficazFramework.Application.ApplicationInstance.Content))
        {
            var app = (EficazFramework.Application.ApplicationInstance)sender;
            app.NotifyContent = "3 novos";
        }
    }
}
