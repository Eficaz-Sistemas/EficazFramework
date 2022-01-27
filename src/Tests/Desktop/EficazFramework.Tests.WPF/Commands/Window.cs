
using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using EficazFramework.XAML.Behaviors;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls.Primitives;
using System;

namespace EficazFramework.Commands;

[Apartment(System.Threading.ApartmentState.STA)]
public class WindowCommandsTests
{
    System.Windows.Window win = new();
    EficazFramework.Tests.WPF.Views.Behaviors.Inputs mock = new();


    [SetUp]
    public void Setup()
    {
        win = new();
        win.Content = mock;
        win.Show();
    }

    [TearDown]
    public void TearDown()
    {
        win.Close();
    }

    [Test]
    public void EnsureParameterIsNeeded()
    {
        Action maximize = () =>
        {
            EficazFramework.Commands.Window.Maximize.Execute(null);
        };
        maximize.Should().Throw<NullReferenceException>();

        Action maximize2 = () =>
        {
            EficazFramework.Commands.Window.Maximize.Execute(mock);
        };
        maximize2.Should().NotThrow<Exception>();

    }

    [Test]
    public void Minimize()
    {
        win.WindowState.Should().Be(WindowState.Normal);
        EficazFramework.Commands.Window.Minimize.Execute(mock);
        win.WindowState.Should().Be(WindowState.Minimized);
    }

    [Test]
    public void Maximize()
    {
        win.WindowState.Should().Be(WindowState.Normal);
        EficazFramework.Commands.Window.Maximize.Execute(mock);
        win.WindowState.Should().Be(WindowState.Maximized);
    }

    [Test]
    public void Restore()
    {
        win.WindowState.Should().Be(WindowState.Normal);
        EficazFramework.Commands.Window.Maximize.Execute(mock);
        win.WindowState.Should().Be(WindowState.Maximized);
        EficazFramework.Commands.Window.Restore.Execute(mock);
        win.WindowState.Should().Be(WindowState.Normal);
    }

}
