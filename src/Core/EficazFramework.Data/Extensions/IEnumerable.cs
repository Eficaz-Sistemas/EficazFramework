using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Extensions
{
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

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> metodoEquals, Func<T, int> metodoGetHashCode)
            => source.Distinct( FuncEqualityComparer<T>.Create(metodoEquals, metodoGetHashCode));
    }


    public class FuncEqualityComparer<T> : IEqualityComparer<T>
    {
        public Func<T, T, bool> MetodoEquals { get; }
        public Func<T, int> MetodoGetHashCode { get; }

        private FuncEqualityComparer(Func<T, T, bool> metodoEquals, Func<T, int> metodoGetHashCode)
        {
            MetodoEquals = metodoEquals;
            MetodoGetHashCode = metodoGetHashCode;
        }

        public static FuncEqualityComparer<T> Create(Func<T, T, bool> metodoEquals, Func<T, int> metodoGetHashCode) => new(metodoEquals, metodoGetHashCode);

        public bool Equals(T x, T y) => MetodoEquals(x, y);

        public int GetHashCode(T obj) => MetodoGetHashCode(obj);
    }
}