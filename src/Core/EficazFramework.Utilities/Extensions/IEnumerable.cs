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

}
