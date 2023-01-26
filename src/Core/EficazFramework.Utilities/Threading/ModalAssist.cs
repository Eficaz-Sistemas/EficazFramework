using System.Threading.Tasks;

namespace EficazFramework.Threading;

public class ModalAssist
{
    private TaskCompletionSource<EficazFramework.Events.MessageResult>? task ;

    public async Task<EficazFramework.Events.MessageResult> Push()
    {
        task ??= new TaskCompletionSource<Events.MessageResult>();
        return await task.Task;
    }

    public void Release(EficazFramework.Events.MessageResult result)
    {
        task ??= new TaskCompletionSource<Events.MessageResult>();
        task.SetResult(result);
    }
}
