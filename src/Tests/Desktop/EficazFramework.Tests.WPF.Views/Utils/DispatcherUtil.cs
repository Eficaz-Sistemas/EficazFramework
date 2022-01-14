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
