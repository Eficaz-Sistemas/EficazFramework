#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;

namespace EficazFramework.Tests
{
    [Apartment(System.Threading.ApartmentState.STA)]
    public class BaseTest
    {
        internal static EficazFramework.Tests.WPF.Views.App Application { get; private set; }
        internal static EficazFramework.Tests.WPF.Views.MainWindow MainWindow { get; private set; }


        [OneTimeSetUp]
        public void Setup()
        {
            if (Application == null)
            {
                Application = new EficazFramework.Tests.WPF.Views.App();
                Application.InitializeComponent();
                MainWindow = new();
                MainWindow.InitializeComponent();
                Application.MainWindow = MainWindow;
            }

            if (!MainWindow.IsLoaded)
                MainWindow.Show();
        }

    }
}
