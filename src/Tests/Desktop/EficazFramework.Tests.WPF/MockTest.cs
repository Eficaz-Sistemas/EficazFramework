using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;

namespace EficazFramework.Tests
{
    public class Resources : BaseTest
    {
       
        [Test, Order(0)]
        public void InitialTest()
        {
            MainWindow.Should().NotBeNull();
        }

        [TestCase("Color.Darken")]
        [TestCase("Color.Primary.Background")]
        [TestCase("Font.SourceSansPro")]
        [TestCase("Brush.Primary.Background")]
        [TestCase("Icon.MaterialDesign.AccessPointPlus")]
        [Test, Order(0)]
        public void ResourcesTest(string resourceName)
        {
            Application.GetResource(resourceName).Should().NotBeNull();
            MainWindow.GetResource(resourceName).Should().NotBeNull();
        }


    }
}
