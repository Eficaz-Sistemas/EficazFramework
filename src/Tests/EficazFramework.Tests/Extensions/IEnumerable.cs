﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Extensions;

class IEnumerable
{
    [Test]
    public void ToObservableCollection()
    {
        IEnumerable<string> source = new List<string>() { "abc", "def", "ghi", "ghi" };
        var obs = source.ToAsyncObservableCollection();
        obs.Should().NotBeNull();
        obs.Should().HaveCount(4);
        obs.AddRange(new List<string>() { "jkl", "jkl" });
        obs.Should().HaveCount(6);
    }

}
