using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EficazFramework.Collections;

public class ObservableDictionaryTests
{
    [Test, Order(1)]
    public void Constructor()
    {
        var internalDictionary = new Dictionary<int, string>
        {
            { 1, "abc" }
        };
        var collection = new ObservableDictionary<int, string>(internalDictionary);
        collection.Count.Should().Be(1);


        var collection1 = new ObservableDictionary<int, string>();
        collection1.Count.Should().Be(0);

        var collection2 = new ObservableDictionary<int, string>(2);
        collection2.Count.Should().Be(0);
        collection2.Add(1, "abc");
        collection2.Add(2, "def");
        collection2.Add(3, "ghi");
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

    [Test, Order(4)]
    public void GetAndSet()
    {
        var internalDictionary = new Dictionary<object, string>
        {
            { 1, "abc" },
            { 2, "def" }
        };
        var collection = new ObservableDictionary<object, string>(internalDictionary);

        collection[2].Should().Be("def");
        collection[3].Should().BeNull();

        collection.Should().HaveCount(2);
        collection[3] = "ghi";
        collection.Should().HaveCount(3);
        collection[2] = "zzz";
        collection.Should().HaveCount(3);
    }

    [Test, Order(5)]
    public void Insert()
    {
        var internalDictionary = new Dictionary<object, string>
        {
            { 1, "abc" }
        };
        var collection = new ObservableDictionary<object, string>(internalDictionary);

        Exception ex = null;
        try
        {
            collection.Add(null, "null key");
        }
        catch (Exception addEx)
        {
            ex = addEx;
        }
        ex.Should().NotBeNull();

        ex = null;
        try
        {
            collection.Add(2, "abc");
        }
        catch (Exception addEx)
        {
            ex = addEx;
        }
        ex.Should().BeNull();

        ex = null;
        try
        {
            collection.Add(2, "abc");
        }
        catch (ArgumentException addEx)
        {
            ex = addEx;
        }
        ex.Should().NotBeNull();

        collection[2].Should().Be("abc");
        collection.AddOrReplace(2, "replaced");
        collection[2].Should().Be("replaced");
    }

    [Test, Order(6)]
    public void Remove()
    {
        var internalDictionary = new Dictionary<object, string>
        {
            { 1, "abc" },
            { 2, "def" }
        };
        var collection = new ObservableDictionary<object, string>(internalDictionary);

        Exception ex = null;
        try
        {
            collection.Remove(null);
        }
        catch (Exception removeEx)
        {
            ex = removeEx;
        }
        ex.Should().NotBeNull();

        ex = null;
        try
        {
            collection.Remove(1);
        }
        catch (Exception removeEx)
        {
            ex = removeEx;
        }
        ex.Should().BeNull();

        ex = null;
        try
        {
            collection.Remove(1);
        }
        catch (KeyNotFoundException removeEx)
        {
            ex = removeEx;
        }
        ex.Should().NotBeNull();
    }

    [Test, Order(7)]
    public void CopyTo()
    {
        var internalDictionary = new Dictionary<object, string>
        {
            { 1, "abc" },
            { 2, "def" }
        };
        var collection = new ObservableDictionary<object, string>(internalDictionary);
        collection.IsReadOnly.Should().BeFalse();

        KeyValuePair<object, string>[] destinationCollection = { new(98, "zzz"), new(99, "zzz") };
        collection.CopyTo(destinationCollection, 0);
        destinationCollection.Should().HaveCount(2);
        destinationCollection[0].Key.Should().Be(1);
        destinationCollection[0].Value.Should().Be("abc");
        destinationCollection[1].Key.Should().Be(2);
        destinationCollection[1].Value.Should().Be("def");

        KeyValuePair<object, string>[] destinationCollection1 = { new(99, "zzz"), new(99, "zzz"), new(99, "zzz") };
        collection.CopyTo(destinationCollection1, 1);
        destinationCollection1.Should().HaveCount(3);
        destinationCollection1[0].Key.Should().Be(99);
        destinationCollection1[0].Value.Should().Be("zzz");
        destinationCollection1[1].Key.Should().Be(1);
        destinationCollection1[1].Value.Should().Be("abc");
        destinationCollection1[2].Key.Should().Be(2);
        destinationCollection1[2].Value.Should().Be("def");

    }


}