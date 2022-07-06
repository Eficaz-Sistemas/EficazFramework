using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace EficazFramework.Collections;

public class AsyncObservableCollection<T> : ObservableCollection<T>
{
    public AsyncObservableCollection(IEnumerable<T> list) : base(list) { }

    private static void ExecuteOnSyncContext(Action action)
    {
        if (ReferenceEquals(SynchronizationContext.Current, Threading.Thread.SynchronizationContext) || Threading.Thread.SynchronizationContext == null)
        {
            action();
        }
        else
        {
            Threading.Thread.SynchronizationContext.Send(new SendOrPostCallback((object state) => action()), null);
        }
    }

    protected override void InsertItem(int index, T item)
    {
        ExecuteOnSyncContext(() => base.InsertItem(index, item));
    }

    protected override void RemoveItem(int index)
    {
        ExecuteOnSyncContext(() => base.RemoveItem(index));
    }

    protected override void SetItem(int index, T item)
    {
        ExecuteOnSyncContext(() => base.SetItem(index, item));
    }

    protected override void MoveItem(int oldIndex, int newIndex)
    {
        ExecuteOnSyncContext(() => base.MoveItem(oldIndex, newIndex));
    }

    protected override void ClearItems()
    {
        ExecuteOnSyncContext(() => base.ClearItems());
    }
}
