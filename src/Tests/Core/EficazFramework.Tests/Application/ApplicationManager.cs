using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace EficazFramework.Application;

public class Apps
{
    EficazFramework.Application.ApplicationManager _appManager = new();

    private void GenerateAppList()
    {
        if (_appManager.AllAplications.Count > 0)
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
        _appManager.AllAplications.Add(index);
        _appManager.AllAplications.Add(clientes);
        _appManager.AllAplications.Add(produtos);
        _appManager.AllAplications.Add(requisicoes);
        _appManager.AllAplications.Add(cobranca);
        _appManager.AllAplications.Add(suporte);
        _appManager.AllAplications.Add(manuais);
    }

    [Test, Order(0)]
    public void Init()
    {
        _appManager.AllAplications.Count.Should().Be(0);
        _appManager.RunningAplications.Count.Should().Be(0);
    }

    [Test, Order(1)]
    public void CreateList()
    {
        GenerateAppList();
        var list = _appManager.AllAplications;
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
        _appManager.AllAplications[1].Activate();
        _appManager.RunningAplications.Count.Should().Be(1);
        _appManager.RunningAplications[0].ToString().Should().Be("[0] - Clientes");
        _appManager.AllAplications[5].Activate();
        _appManager.RunningAplications.Count.Should().Be(2);
        try
        {
            Resources.Strings.Application.Culture = Resources.Strings.Application.Culture;
            _appManager.AllAplications[4].Activate();
            throw new NullReferenceException("bad");

        }
        catch (InvalidDataException ex)
        {
            ex.Message.Should().Be(Resources.Strings.Application.NoSessionForPrivateApp);
        }
        _appManager.RunningAplications.First().Content.Should().BeNull();
        _appManager.RunningAplications.First().NotifyContent.Should().BeNull();
        _appManager.RunningAplications.First().PropertyChanged += PropertyChanged;
        _appManager.RunningAplications.First().Content = "client app";
        _appManager.RunningAplications.First().PropertyChanged -= PropertyChanged;
        _appManager.RunningAplications.First().NotifyContent.Should().Be("3 novos");

        _appManager.RunningAplications.Last().Content = new EficazFramework.Repositories.EntityRepository<Resources.Mocks.Classes.Blog>();
        _appManager.RunningAplications.Last().Close();
        _appManager.RunningAplications.Count.Should().Be(1);

        _appManager.AllAplications[6].Condition.Should().Be("AppTitle = value1");
    }

    [Test, Order(3)]
    public void AvoidDuplicated()
    {
        GenerateAppList();
        _appManager.AllAplications[1].Activate();
        _appManager.RunningAplications.Count.Should().Be(1);
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
