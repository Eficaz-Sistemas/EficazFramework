using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace EficazFramework.Application;

public class Sessions
{
    [Test, Order(0)]
    public void Init()
    {
        EficazFramework.Application.SessionManager.Sessions.Count.Should().Be(1);
        EficazFramework.Application.SessionManager.Instance.CurrentSession.Should().NotBeNull();
        EficazFramework.Application.SessionManager.Instance.CurrentSession.ID.Should().Be(0);
    }

    [Test, Order(1)]
    public void Create()
    {
        EficazFramework.Application.SessionManager.ActivateSession(new EficazFramework.Application.Session()
        {
            ID = 1,
            Name = "Desktop 2"
        });
        EficazFramework.Application.SessionManager.Instance.CurrentSession.Should().NotBeNull();
        EficazFramework.Application.SessionManager.Instance.CurrentSession.ID.Should().Be(1);
    }

    [Test, Order(2)]
    public void Activate()
    {
        EficazFramework.Application.SessionManager.Instance.CurrentSession.ID.Should().Be(1);
        EficazFramework.Application.SessionManager.ActivateSession(new EficazFramework.Application.Session()
        {
            ID = 2,
            Name = "Desktop 3"
        });
        EficazFramework.Application.SessionManager.Instance.CurrentSession.ID.Should().Be(2);
        EficazFramework.Application.SessionManager.ActivateSession(1);
        EficazFramework.Application.SessionManager.Instance.CurrentSession.ID.Should().Be(1);
    }

    [Test, Order(3)]
    public void AvoidDuplicated()
    {
        EficazFramework.Application.SessionManager.ActivateSession(new EficazFramework.Application.Session()
        {
            ID = 2,
            Name = "Desktop 3, Copy"
        });
        _ = EficazFramework.Application.SessionManager.Sessions.GroupBy(i => i.ID).Count(gp => gp.Count() > 1).Should().Be(0);

    }

    [Test, Order(4)]
    public void Dispose()
    {
        EficazFramework.Application.SessionManager.DisposeSession(1);
        EficazFramework.Application.SessionManager.Instance.CurrentSession.ID.Should().Be(2);
        EficazFramework.Application.SessionManager.DisposeSession(EficazFramework.Application.SessionManager.Sessions[1]); //SESSION 1 AT LAST POSITION
        EficazFramework.Application.SessionManager.Instance.CurrentSession.ID.Should().Be(0);
    }


    private EficazFramework.Application.ScopedSessionManager scp;

    [Test, Order(4)]
    public void Scoped_Init()
    {
        scp = new();
        scp.Sessions.Count.Should().Be(1);
        scp.CurrentSession.Should().NotBeNull();
        scp.CurrentSession.ID.Should().Be(0);
    }

    [Test, Order(5)]
    public void Scoped_Create()
    {
        scp.ActivateSession(new EficazFramework.Application.Session()
        {
            ID = 1,
            Name = "Desktop 2"
        });
        scp.CurrentSession.Should().NotBeNull();
        scp.CurrentSession.ID.Should().Be(1);
    }

    [Test, Order(6)]
    public void Scoped_Activate()
    {
        scp.ActivateSession(new EficazFramework.Application.Session()
        {
            ID = 2,
            Name = "Desktop 3"
        });
        scp.CurrentSession.ID.Should().Be(2);
        scp.ActivateSession(1);
        scp.CurrentSession.ID.Should().Be(1);
    }

    [Test, Order(7)]
    public void Scoped_AvoidDuplicated()
    {
        scp.ActivateSession(new EficazFramework.Application.Session()
        {
            ID = 2,
            Name = "Desktop 3, Copy"
        });
        _ = scp.Sessions.GroupBy(i => i.ID).Count(gp => gp.Count() > 1).Should().Be(0);

    }

    [Test, Order(8)]
    public void Scoped_Dispose()
    {
        scp.DisposeSession(1);
        scp.CurrentSession.ID.Should().Be(2);
        scp.DisposeSession(scp.Sessions[1]); //SESSION 1 AT LAST POSITION
        scp.CurrentSession.ID.Should().Be(0);
    }


}
