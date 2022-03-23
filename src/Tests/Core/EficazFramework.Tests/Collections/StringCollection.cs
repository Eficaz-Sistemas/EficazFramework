﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Collections;

public class StringCollectionTests
{
    [Test, Order(1)]
    public void Constructor()
    {
        var collection0 = new StringCollection() { "", ""};
        collection0.Count().Should().Be(2);

        var collection = new StringCollection();
        collection.Count().Should().Be(0);
    }

    [Test, Order(2)]    
    public void IterateWithin()
    {
        var collection = new StringCollection();
        collection.Add("0200");
        collection.ToString().Trim().Should().Be("0200");
        collection.Add("123");
        collection.ToString().Trim().Should().Be($"0200{Environment.NewLine}123");
        collection.Add("Produto Exemplo");
        collection.ToString().Trim().Should().Be($"0200{Environment.NewLine}123{Environment.NewLine}Produto Exemplo");
    }

}