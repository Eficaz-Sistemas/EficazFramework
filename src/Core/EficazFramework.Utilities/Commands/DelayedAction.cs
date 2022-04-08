using System;
using System.Threading.Tasks;

namespace EficazFramework.Commands;

public partial class DelayedAction
{

    public static void Invoke(Action action, int miliseconds)
    {
        var t = Task.Delay(miliseconds);
        t.Wait();
        action.Invoke();
    }

    public static async Task InvokeAsync(Action action, int miliseconds, System.Threading.CancellationToken cancellationtoken = default)
    {
        await Task.Delay(miliseconds, cancellationtoken);
        
        if (cancellationtoken != default)
        {
            if (cancellationtoken.IsCancellationRequested == true)
                return;
        }

        await Task.Run(action, cancellationtoken);
    }

}
