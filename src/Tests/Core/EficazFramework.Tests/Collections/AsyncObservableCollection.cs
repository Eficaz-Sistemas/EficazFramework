using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Collections;

public class AsyncObservableCollectionTests
{
    [Test, Order(1)]
    public void Constructor()
    {
        var collection = new AsyncObservableCollection<string>(new List<string> { "abc", "def" });
        collection.Count.Should().Be(2);
    }

    [Test, Order(2)]
    public void IterateWithin()
    {
        var collection = new AsyncObservableCollection<string>();
        collection.Count.Should().Be(0);
        collection.Insert(0, "abc");
        collection.Insert(1, "def");
        collection.Count.Should().Be(2);
        collection.Remove("abc");
        collection.RemoveAt(0);
        collection.Count.Should().Be(0);
        collection.Insert(0, "abc");
        collection.Insert(1, "def");
        collection.Insert(2, "ghi");
        collection.Move(0, 2);
        collection.IndexOf("def").Should().Be(0);
        collection.IndexOf("ghi").Should().Be(1);
        collection.IndexOf("abc").Should().Be(2);
        collection.Clear();
        collection.Count.Should().Be(0);
    }

}