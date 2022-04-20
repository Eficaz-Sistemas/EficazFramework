
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

namespace EficazFramework.Tests.Commands;

[Apartment(System.Threading.ApartmentState.STA)]
public class WindowCommandsTests : BaseTest
{


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
            EficazFramework.Commands.Window.Maximize.Execute(MainWindow?.Content);
        };
        maximize2.Should().NotThrow<Exception>();

    }

    [Test]
    public void Minimize()
    {
        EficazFramework.Commands.Window.Restore.Execute(MainWindow?.Content);
        MainWindow?.WindowState.Should().NotBe(WindowState.Minimized);
        EficazFramework.Commands.Window.Minimize.Execute(MainWindow?.Content);
        MainWindow?.WindowState.Should().Be(WindowState.Minimized);
    }

    [Test]
    public void Maximize()
    {
        EficazFramework.Commands.Window.Restore.Execute(MainWindow?.Content);
        MainWindow?.WindowState.Should().NotBe(WindowState.Maximized);
        EficazFramework.Commands.Window.Maximize.Execute(MainWindow?.Content);
        MainWindow?.WindowState.Should().Be(WindowState.Maximized);
    }

    [Test]
    public void Restore()
    {
        EficazFramework.Commands.Window.Maximize.Execute(MainWindow?.Content);
        MainWindow?.WindowState.Should().NotBe(WindowState.Normal);
        EficazFramework.Commands.Window.Restore.Execute(MainWindow?.Content);
        MainWindow?.WindowState.Should().Be(WindowState.Normal);
    }

}
