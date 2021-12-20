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
            Title = "Manuais"
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
    }

    [Test, Order(2)]
    public void Activate()
    {
        _appManager.AllAplications[1].Activate();
        _appManager.RunningAplications.Count.Should().Be(1);
        _appManager.RunningAplications[0].ToString().Should().Be("[0] - Clientes");
        _appManager.AllAplications[5].Activate();
        _appManager.RunningAplications.Count.Should().Be(2);
        try
        {
            _appManager.AllAplications[4].Activate();
            throw new NullReferenceException("bad");

        }
        catch (InvalidDataException ex)
        {
            ex.Message.Should().Be(Resources.Strings.Application.NoSessionForPrivateApp);
        }
    }

    [Test, Order(3)]
    public void AvoidDuplicated()
    {
        _appManager.AllAplications[1].Activate();
        _appManager.RunningAplications.Count.Should().Be(2);
    }
}
