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

    public static List<List<T>> Split<T>(this List<T> items, int sliceSize = 100)
    {
        var list = new List<List<T>>();

        if (sliceSize <= 0)
        {
            list.Add(items);
            return list;
        }

        int i = 0;
        while (i < items.Count)
        {
            list.Add(items.GetRange(i, Math.Min(sliceSize, items.Count - i)));
            i += sliceSize;
        }

        return list;
    }
}
