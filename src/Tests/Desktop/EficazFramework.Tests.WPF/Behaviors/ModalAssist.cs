
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

namespace EficazFramework.Behaviors;

[Apartment(System.Threading.ApartmentState.STA)]
public class ModalAssistTest
{

    [SetUp]
    public void Setup()
    {
        Tests.TestContext.Application?.MainWindow.Show();
    }

    //[Test]  
    //public void DefaultTest()
    //{

    //}
}
