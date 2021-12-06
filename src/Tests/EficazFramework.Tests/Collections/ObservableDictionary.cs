using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Collections;

public class ObservableDictionaryTests
{
    [Test, Order(1)]
    public void Constructor()
    {
        var internalDictionary = new Dictionary<int, string>();
        internalDictionary.Add(1, "abc");
        var collection = new ObservableDictionary<int, string>(internalDictionary);
        collection.Count.Should().Be(1);


        var collection1 = new ObservableDictionary<int, string>();
        collection1.Count.Should().Be(0);
    }

    [Test, Order(2)]    
    public void IterateWithin()
    {
        var internalDictionary = new Dictionary<int, string>
        {
            { 1, "abc" }
        };
        var collection = new ObservableDictionary<int, string>(internalDictionary);
        collection.Count.Should().Be(1);

        collection.Add(2, "def");
        collection.Count.Should().Be(2);

        collection.Add(new KeyValuePair<int, string>(3, "ghi"));
        collection.Count.Should().Be(3);
        collection.IndexOf(3).Should().Be(2);

        collection.Remove(new KeyValuePair<int, string>(3, "ghi"));
        collection.Count.Should().Be(2);

        collection.Remove(2);
        collection.Count.Should().Be(1);

        collection[1].Should().Be("abc");
        collection.Keys.Count.Should().Be(1);
        collection.Values.Count.Should().Be(1);
        collection.ContainsKey(1).Should().BeTrue();
        collection.ContainsKey(0).Should().BeFalse();
        collection.ContainsValue("abc").Should().BeTrue();
        collection.ContainsValue("def").Should().BeFalse();
        collection.Contains(new KeyValuePair<int, string>(1, "abc")).Should().BeTrue();
        collection.Contains(new KeyValuePair<int, string>(1, "ghi")).Should().BeFalse();
        collection.Contains(new KeyValuePair<int, string>(3, "ghi")).Should().BeFalse();

        collection.Clear();
        collection.Count.Should().Be(0);

        var collection1 = new ObservableDictionary<int, string>();
        collection1.Count.Should().Be(0);
    }

    [Test, Order(3)]
    public void TrackCollectionChanges()
    {
        bool AddTest = false;
        bool RemoveTest = false;
        bool ReplaceTest = false;

        var collection = new ObservableDictionary<int, string>();
        collection.CollectionChanged += (s, e) =>
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    e.NewItems.Count.Should().BeGreaterThan(0);
                    e.OldItems.Should().BeNull();
                    AddTest = true;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    e.NewItems.Should().BeNull();
                    e.OldItems.Count.Should().BeGreaterThan(0);
                    RemoveTest = true;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    e.NewItems.Count.Should().BeGreaterThan(0);
                    e.OldItems.Count.Should().BeGreaterThan(0);
                    ReplaceTest = true;
                    break;
            }
        };

        collection.Add(1, "abc");
        collection.Remove(1);
        AddTest.Should().BeTrue();
        RemoveTest.Should().BeTrue();
        AddTest = false;
        RemoveTest = false;

        collection.Add(new KeyValuePair<int, string>(1, "abc"));
        collection.Remove(new KeyValuePair<int, string>(1, "abc"));
        AddTest.Should().BeTrue();
        RemoveTest.Should().BeTrue();
        AddTest = false;
        RemoveTest = false;

        collection.AddOrReplace(1, "abc");
        collection[1].Should().Be("abc");
        AddTest.Should().BeTrue();
        collection.AddOrReplace(1, "def");
        ReplaceTest.Should().BeTrue();
        collection[1].Should().Be("def");
    }

}