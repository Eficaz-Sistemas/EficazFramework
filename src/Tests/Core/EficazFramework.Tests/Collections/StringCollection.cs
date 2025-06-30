using AwesomeAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace EficazFramework.Collections;

public class StringCollectionTests
{
    [Test, Order(1)]
    public void Constructor()
    {
        var collection0 = new StringCollection() { "", "" };
        collection0.Should().HaveCount(2);

        var collection = new StringCollection();
        collection.Should().HaveCount(0);
    }

    [Test, Order(2)]
    public void IterateWithin()
    {
        var collection = new StringCollection
        {
            "0200"
        };
        collection.ToString().Trim().Should().Be("0200");
        collection.Add("123");
        collection.ToString().Trim().Should().Be($"0200{Environment.NewLine}123");
        collection.Add("Produto Exemplo");
        collection.ToString().Trim().Should().Be($"0200{Environment.NewLine}123{Environment.NewLine}Produto Exemplo");
    }

}