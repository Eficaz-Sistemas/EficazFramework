using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EficazFramework.Behaviors;

public class ModalAssist
{
    public static async Task ShowMaterialDialog(EficazFramework.Events.MessageEventArgs args,
                                         string dialogRef,
                                         Snackbar sbar)
    {
        if (args.Type == EficazFramework.Events.MessageType.Default)
        {
            object result = await MaterialDesignThemes.Wpf.DialogHost.Show(args, dialogRef);
            if (result is EficazFramework.Events.MessageResult result1)
            {
                args.ModalAssist.Release(result1);
                return;
            }
            args.ModalAssist.Release(Events.MessageResult.NotSet);
        }
        else
        {
            if (sbar == null) return;
            var queue = sbar.MessageQueue;
            await System.Threading.Tasks.Task.Factory.StartNew(() => queue.Enqueue(args.Content.ToString()));
        }
    }
}
