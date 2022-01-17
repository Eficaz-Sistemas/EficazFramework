
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
    Tests.WPF.Views.Events.DialogTest? mock = null;


    [SetUp]
    public void Setup()
    {
        mock = new();
        Tests.TestContext.MainWindow.Content = mock;
        Tests.TestContext.Application?.MainWindow.Show();
    }

    public async Task DefaultTest()
    {
        EficazFramework.Events.MessageEventArgs args = new()
        {
            Type = Events.MessageType.Default,
        };

        await EficazFramework.Commands.DelayedAction.InvokeAsync(() =>
        {
            args.ModalAssist.Release(Events.MessageResult.Yes);
        },500);

        await EficazFramework.Behaviors.ModalAssist.ShowMaterialDialog(args, "teste001", null);
        var result = await args.ModalAssist.Push();
        ((EficazFramework.Events.MessageResult)result).Should().Be(EficazFramework.Events.MessageResult.Yes);
    }
}
