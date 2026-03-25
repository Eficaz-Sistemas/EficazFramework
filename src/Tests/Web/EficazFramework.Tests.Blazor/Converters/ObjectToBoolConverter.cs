using AwesomeAssertions;
using NUnit.Framework;

namespace EficazFramework.Converters;

[TestFixture]
public class ObjectToBoolConverterTests
{
    [Test]
    public void SetValueTest()
    {
        EficazFramework.Converters.ObjectToBoolConverter converter = new();
        ((bool)converter.ConvertBack(true)!).Should().BeTrue();
        ((bool)converter.ConvertBack(false)!).Should().BeFalse();
        bool? nullable = true;
        ((bool)converter.ConvertBack(nullable)!).Should().BeTrue();
        nullable = false;
        ((bool)converter.ConvertBack(nullable)!).Should().BeFalse();
    }
}
