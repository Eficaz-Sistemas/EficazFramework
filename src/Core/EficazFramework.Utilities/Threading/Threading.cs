using System.Threading;

namespace EficazFramework.Utilities.Threading;

/// <summary>
/// This singleton class provides a common application situations that requires platform invariant actions,
/// such Request Message Box, Sincronization Context (for multi-thread sync), etc.
/// </summary>
public class Thread
{

    static Thread()
    {
        SynchronizationContext = SynchronizationContext.Current;
    }

    public static SynchronizationContext SynchronizationContext { get; private set; }

    public static void RequestMessageBox(object sender, EficazFramework.Events.MessageEventArgs args)
    {
        MessageBoxRequest?.Invoke(sender, args);
    }

    public static event EficazFramework.Events.MessageEventHandler MessageBoxRequest;

}

public interface IAppActionCenterContent
{
    string ID { get; }
    string MimeType { get; }
    string MimeTypeDescription { get; }
}
