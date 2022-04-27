using Bunit;
using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.Converters;

[TestFixture]
public class ObjectToBoolConverterTests
{
    [Test]
    public void SetValueTest()
    {
        EficazFramework.Converters.ObjectToBoolConverter converter = new();
        converter.Set(true).Should().BeTrue();
        converter.Set(false).Should().BeFalse();
        bool? nullable = true;
        converter.Set(nullable).Should().BeTrue();
        nullable = false;
        converter.Set(nullable).Should().BeFalse();

        object anytype = new ObjectToBoolConverter();
        converter.Set(anytype).Should().BeNull();
    }
}
