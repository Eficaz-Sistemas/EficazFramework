#pragma warning disable CS8601 // Possível atribuição de referência nula.
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

global using FluentAssertions;
global using NUnit.Framework;
global using System;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Windows;
global using System.Windows.Controls;
global using XamlTest;

namespace EficazFramework.Tests
{
    public class BaseTest
    {
        internal static IApp Application { get; private set; }
        internal static IWindow MainWindow { get; private set; }

        internal System.Windows.Media.Color ThemeColorPrimary { get; private set; }
        internal System.Windows.Media.Color ThemeColorSecondary { get; private set; }
        internal System.Windows.Media.Color ThemeColorTertiary { get; private set; }
        internal System.Windows.Media.Color ThemeColorSurface { get; private set; }

        public BaseTest()
        {
            if (Application == null)
                Application = XamlTest.App.StartRemote<EficazFramework.Tests.WPF.Views.App>();
        }
        
        [OneTimeSetUp]
        public async Task Setup()
        {
            if (MainWindow == null)
                MainWindow = await Application.GetMainWindow() ?? throw new System.Exception("Fail on get Main Window");

            ThemeColorPrimary = (await MainWindow.GetResource("Color.Primary.Background")).GetAs<System.Windows.Media.Color?>() ?? throw new System.Exception($"Failed to convert resource 'Color.Primary.Background' to color");
            ThemeColorSecondary = (await MainWindow.GetResource("Color.Secondary.Background")).GetAs<System.Windows.Media.Color?>() ?? throw new System.Exception($"Failed to convert resource 'Color.Secondary.Background' to color");
            ThemeColorTertiary = (await MainWindow.GetResource("Color.Tertiary.Background")).GetAs<System.Windows.Media.Color?>() ?? throw new System.Exception($"Failed to convert resource 'Color.Tertiary.Background' to color");
            ThemeColorSurface = (await MainWindow.GetResource("Color.Surface.Background")).GetAs<System.Windows.Media.Color?>() ?? throw new System.Exception($"Failed to convert resource 'Color.Surface.Background' to color");
        }

    }
}
