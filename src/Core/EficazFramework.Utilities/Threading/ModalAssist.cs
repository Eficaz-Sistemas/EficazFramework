using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Threading;

public class ModalAssist
{
    private TaskCompletionSource<EficazFramework.Events.eMessageResult> task = null;

    public async Task<EficazFramework.Events.eMessageResult> Push()
    {
        if (task == null)
            task = new TaskCompletionSource<Events.eMessageResult>();
        return await task.Task;
    }

    public void Release(EficazFramework.Events.eMessageResult result)
    {
        if (task == null)
            task = new TaskCompletionSource<Events.eMessageResult>();
        task.SetResult(result);
    }
}
