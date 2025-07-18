﻿using AwesomeAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace EficazFramework.Application;

public class Sessions
{
    readonly EficazFramework.Application.IApplicationManager _appManager = EficazFramework.Application.IApplicationManager.Instance;
    EficazFramework.Application.ISectionManager manager;

    [TearDown]
    public void TearDown()
    {
        _appManager.Clear();
    }

    [Test, Order(0)]
    public void Init()
    {
        manager = _appManager.SectionManager;
        _ = Resources.Strings.Application.Culture;
        manager.Sections.Count.Should().Be(1);
        manager.CurrentSection.Should().NotBeNull();
        manager.CurrentSection.ID.Should().Be(0);
        manager.CurrentSection.Name = Resources.Strings.Application.SessionZeroTooltip;
    }

    [Test, Order(1)]
    public void Create()
    {
        manager.ApplicationManager.Should().NotBeNull();
        manager.ActivateSection(new EficazFramework.Application.Section(1)
        {
            Name = "Desktop 1",
            Icon = "<svg/>",
            ShowIdAsIcon = true,
            Tag = "My first app"
        });
        manager.CurrentSection.Icon = "";
        manager.CurrentSection.Should().NotBeNull();
        manager.CurrentSection.Should().NotBeNull();
        manager.CurrentSection.SectionIdLargerText.Should().BeFalse();
        manager.CurrentSection.Name.Should().Be("Desktop 1");
        manager.CurrentSection.ShowIdAsIcon.Should().BeTrue();
        manager.CurrentSection.Tag.Should().Be("My first app");
        manager.CurrentSection.ToString().Should().Be("1 - Desktop 1");
        manager.CurrentSection.Name = "Old App";
        manager.CurrentSection.ToString().Should().Be("1 - Old App");
        manager.CurrentSection.Icon.Should().NotBe("<svg/>");
        manager.CurrentSection.ID.Should().Be(1);
        manager.CurrentSection.Name = "new name";
        manager.CurrentSection.ShowIdAsIcon = false;
        manager.CurrentSection.Tag = null;
    }

    [Test, Order(2)]
    public void Activate()
    {
        manager.CurrentSection.ID.Should().Be(1);
        manager.ActivateSection(new EficazFramework.Application.Section(2222)
        {
            Name = "Desktop 2222"
        });
        manager.CurrentSection.PropertyChanged += PropertyChanged;
        manager.CurrentSection.ShowIdAsIcon = true;
        manager.CurrentSection.Tag.Should().Be("mudou o ícone");
        manager.CurrentSection.ID.Should().Be(2222);
        manager.CurrentSection.SectionIdLargerText.Should().BeTrue();

        manager.ActivateSection(1);
        manager.CurrentSection.ID.Should().Be(1);
        try
        {
            manager.ActivateSection(99);
            throw new NullReferenceException("bad");
        }
        catch (NullReferenceException ex)
        {
            ex.Message.Should().Be(String.Format(Resources.Strings.Application.SessionNotFoundByID, 99));
        }
    }

    [Test, Order(3)]
    public void AvoidDuplicated()
    {
        manager.ActivateSection(new EficazFramework.Application.Section(2222)
        {
            Name = "Desktop 3, Copy"
        }, true);
        _ = manager.Sections.GroupBy(i => i.ID).Count(gp => gp.Count() > 1).Should().Be(0);

    }

    [Test, Order(4)]
    public void Dispose()
    {
        manager.DisposeSection(1);
        manager.CurrentSection.ID.Should().Be(2222);
        manager.ApplicationManager.Activate(new ApplicationDefinition() { Title = "App001", IsPublic = false });
        manager.ApplicationManager.Activate(new ApplicationDefinition() { Title = "App002", IsPublic = false });
        manager.ApplicationManager.RunningApplications.Should().HaveCount(2);
        manager.DisposeSection(manager.CurrentSection);
        manager.ApplicationManager.RunningApplications.Should().HaveCount(0);
        manager.CurrentSection.ID.Should().Be(0);
    }

    private void PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Application.Section.ShowIdAsIcon))
        {
            var mngr = sender as Application.Section;
            mngr.PropertyChanged -= PropertyChanged;
            mngr.Tag = "mudou o ícone";
        }
    }

}
