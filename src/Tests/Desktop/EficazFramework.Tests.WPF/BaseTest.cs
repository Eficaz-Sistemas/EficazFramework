#pragma warning disable CS8601 // Possível atribuição de referência nula.
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using XamlTest;

namespace EficazFramework.Tests
{
    public class BaseTest
    {
        internal static IApp Application { get; private set; }
        internal static IWindow MainWindow { get; private set; }

        public BaseTest()
        {
            if (Application == null)
                Application = XamlTest.App.StartRemote<EficazFramework.Tests.WPF.Views.App>();
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            if (MainWindow == null)
                MainWindow = await Application.GetMainWindow();

        }

    }
}
