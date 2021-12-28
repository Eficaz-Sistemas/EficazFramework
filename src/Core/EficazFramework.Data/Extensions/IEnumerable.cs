using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Extensions;

public static class IEnumerableExtensions
{
    public static EficazFramework.Collections.AsyncObservableCollection<T> ToAsyncObservableCollection<T>(this IEnumerable<T> source)
    {
        return new EficazFramework.Collections.AsyncObservableCollection<T>(source);
    }

    public static EficazFramework.Collections.AsyncObservableCollection<T> ToObservableCollection<T>(this IEnumerable source)
    {
        return new EficazFramework.Collections.AsyncObservableCollection<T>(source.Cast<T>());
    }

    public static void AddRange<T>(this EficazFramework.Collections.AsyncObservableCollection<T> source, IEnumerable<T> items)
    {
        foreach (var it in items)
            source.Add(it);
    }

}
