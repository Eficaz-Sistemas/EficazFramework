using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace EficazFramework.Application;

public class Apps
{
    private void GenerateAppList(bool scoped = false)
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
        if (scoped)
        {
            sap.AllAplications.Add(index);
            sap.AllAplications.Add(clientes);
            sap.AllAplications.Add(produtos);
            sap.AllAplications.Add(requisicoes);
            sap.AllAplications.Add(cobranca);
            sap.AllAplications.Add(suporte);
            sap.AllAplications.Add(manuais);
        }
        else
        {
            EficazFramework.Application.ApplicationManager.AllAplications.Add(index);
            EficazFramework.Application.ApplicationManager.AllAplications.Add(clientes);
            EficazFramework.Application.ApplicationManager.AllAplications.Add(produtos);
            EficazFramework.Application.ApplicationManager.AllAplications.Add(requisicoes);
            EficazFramework.Application.ApplicationManager.AllAplications.Add(cobranca);
            EficazFramework.Application.ApplicationManager.AllAplications.Add(suporte);
            EficazFramework.Application.ApplicationManager.AllAplications.Add(manuais);
        }
    }

    [Test, Order(0)]
    public void Init()
    {
        EficazFramework.Application.ApplicationManager.AllAplications.Count.Should().Be(0);
        EficazFramework.Application.ApplicationManager.RunningAplications.Count.Should().Be(0);
        sap.Should().NotBeNull();
        sap.AllAplications.Count.Should().Be(0);
        sap.RunningAplications.Count.Should().Be(0);
    }

    [Test, Order(1)]
    public void CreateList()
    {
        GenerateAppList();
        var list = EficazFramework.Application.ApplicationManager.AllAplications;
        list.Count.Should().Be(7);
        foreach (var app in list)
        {
            app.IsRunning().Should().Be(false);
        }
    }

    [Test, Order(2)]
    public void Activate()
    {
        EficazFramework.Application.ApplicationManager.AllAplications[1].Activate();
        EficazFramework.Application.ApplicationManager.RunningAplications.Count.Should().Be(1);
        EficazFramework.Application.ApplicationManager.RunningAplications[0].ToString().Should().Be("[0] - Clientes");
        EficazFramework.Application.ApplicationManager.AllAplications[5].Activate();
        EficazFramework.Application.ApplicationManager.RunningAplications.Count.Should().Be(2);
        try
        {
            EficazFramework.Application.ApplicationManager.AllAplications[4].Activate();
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
        EficazFramework.Application.ApplicationManager.AllAplications[1].Activate();
        EficazFramework.Application.ApplicationManager.RunningAplications.Count.Should().Be(2);
    }

    private readonly EficazFramework.Application.ScopedApplicationManager sap = new();

    [Test, Order(4)]
    public void Scoped_CreateList()
    {
        GenerateAppList(true);
        sap.AllAplications.Count.Should().Be(7);
        foreach (var app in sap.AllAplications)
        {
            app.IsRunning().Should().Be(false);
        }

    }

    [Test, Order(5)]
    public void Scoped_Activate()
    {
        sap.AllAplications[1].Activate(sap);
        sap.RunningAplications.Count.Should().Be(1);
        sap.AllAplications[5].Activate(sap);
        sap.RunningAplications.Count.Should().Be(2);
    }

    [Test, Order(6)]
    public void Scoped_AvoidDuplicated()
    {
        sap.AllAplications[1].Activate(sap);
        sap.RunningAplications.Count.Should().Be(2);
    }
}
