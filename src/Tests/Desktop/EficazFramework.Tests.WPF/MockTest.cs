using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;

namespace EficazFramework.Tests
{
    [Apartment(System.Threading.ApartmentState.STA)]
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
            Application.Resources.Should().NotBeNull();
            MainWindow.Resources.Should().NotBeNull();
            
            MainWindow.TryFindResource(resourceName).Should().NotBeNull();
        }


    }
}
