using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Extensions;

public static class IEnumerableExtensions
{
    public static System.Collections.ObjectModel.ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
    {
        return new System.Collections.ObjectModel.ObservableCollection<T>(source);
    }

    public static System.Collections.ObjectModel.ObservableCollection<T> ToObservableCollection<T>(this IEnumerable source)
    {
        return new System.Collections.ObjectModel.ObservableCollection<T>(source.Cast<T>());
    }

    public static void AddRange<T>(this System.Collections.ObjectModel.ObservableCollection<T> source, IEnumerable<T> items)
    {
        foreach (var it in items)
            source.Add(it);
    }

    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        var knownKeys = new HashSet<TKey>();
        return source.Where(element => knownKeys.Add(keySelector(element)));
    }
}
