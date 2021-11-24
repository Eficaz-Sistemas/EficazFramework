using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EficazFramework.Extensions;

public static class IListExtensions
{
    public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IList<T> source)
    {
        return new ReadOnlyCollection<T>(source);
    }

    public static IList<TSource> DistinctBy<TSource, TKey>(this IList<TSource> source, Func<TSource, TKey> keySelector)
    {
        var knownKeys = new HashSet<TKey>();
        return (IList<TSource>)source.Where(element => knownKeys.Add(keySelector(element)));
    }

    public static List<List<T>> Split<T>(this List<T> items, int sliceSize = 100)
    {
        var list = new List<List<T>>();
        int i = 0;
        while (i < items.Count)
        {
            list.Add(items.GetRange(i, Math.Min(sliceSize, items.Count - i)));
            i += sliceSize;
        }

        return list;
    }
}
