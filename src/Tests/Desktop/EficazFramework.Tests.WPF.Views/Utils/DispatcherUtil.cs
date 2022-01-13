using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EficazFramework.Tests.Utils;

public class DispatcherUtil
{
    [SecurityPermissionAttribute(SecurityAction.Demand,
    Flags = SecurityPermissionFlag.UnmanagedCode)]
    public static void DoEvents()
    {
        var frame = new DispatcherFrame();
        Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
        Dispatcher.PushFrame(frame);
    }

    public static void DoEventsSync()
    {
        var frame = new DispatcherFrame();
        Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
        Dispatcher.PushFrame(frame);
    }

    private static object? ExitFrame(object frame)
    {
        ((DispatcherFrame)frame).Continue = false;
        return null;
    }

    public static Task<T> StartSTATask<T>(Func<T> func)
    {
        var tcs = new TaskCompletionSource<T>();
        System.Threading.Thread thread = new(() =>
        {
            try
            {
                tcs.SetResult(func());
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        return tcs.Task;
    }

}
