using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Application;

public class ApplicationEvents
{
    public static string DialogTitle { get; set; } = EficazFramework.Resources.Strings.Commands.ShutDown_TItle;
    public static string DialogMessage { get; set; } = EficazFramework.Resources.Strings.Commands.ShutDown_Message;

    public static async void RequestShutDown_Material(System.Windows.Window window)
    {
        MaterialDesignThemes.Wpf.DialogHost dialog = XAML.Utilities.VisualTreeHelpers.FindVisualChild<MaterialDesignThemes.Wpf.DialogHost>(window);
        dialog.Identifier = new System.Guid().ToString();
        var args = new Events.MessageEventArgs()
        {
            Title = DialogTitle,
            Content = DialogMessage,
            IconReference = Events.MessageIcon.Warning,
            Buttons = Events.MessageButtons.YesNo
        };
        await Behaviors.ModalAssist.ShowMaterialDialog(args, dialog.Identifier.ToString(), null);
        Events.MessageResult result = await args.ModalAssist.Push();
        if (result != Events.MessageResult.Yes) return;
        System.Windows.Application.Current.Shutdown();

    }

}
