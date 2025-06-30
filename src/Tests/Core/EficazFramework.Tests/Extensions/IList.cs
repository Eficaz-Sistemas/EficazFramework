using AwesomeAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace EficazFramework.Extensions;

class IList
{
    [Test]
    public void ToReadOnlyCollection()
    {
        var collection = new List<string>() { "abc", "def", "ghi", "ghi" };
        var result = collection.ToReadOnlyCollection();
        result.Should().HaveCount(4);
    }

    [Test]
    public void Split()
    {
        var collection = new List<string>() { "abc", "def", "ghi", "ghi" };

        var half = collection.Split(2);
        half.Should().HaveCount(2);
        half[0].Should().HaveCount(2);
        half[1].Should().HaveCount(2);

        var once = collection.Split(1);
        once.Should().HaveCount(4);
        once[0].Should().HaveCount(1);
        once[1].Should().HaveCount(1);
        once[2].Should().HaveCount(1);
        once[3].Should().HaveCount(1);

        var three = collection.Split(3);
        three.Should().HaveCount(2);
        three[0].Should().HaveCount(3);
        three[1].Should().HaveCount(1);

        var four = collection.Split(4);
        four.Should().HaveCount(1);
        four[0].Should().HaveCount(4);

        var five = collection.Split(5);
        five.Should().HaveCount(1);
        five[0].Should().HaveCount(4);

        var zero = collection.Split(0);
        zero.Should().HaveCount(1);
        zero[0].Should().HaveCount(4);
    }


}
