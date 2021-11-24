using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Threading;

public class ModalAssist
{
    private TaskCompletionSource<EficazFramework.Events.MessageResult> task = null;

    public async Task<EficazFramework.Events.MessageResult> Push()
    {
        if (task == null)
            task = new TaskCompletionSource<Events.MessageResult>();
        return await task.Task;
    }

    public void Release(EficazFramework.Events.MessageResult result)
    {
        if (task == null)
            task = new TaskCompletionSource<Events.MessageResult>();
        task.SetResult(result);
    }
}
