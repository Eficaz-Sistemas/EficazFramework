using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;

namespace EficazFramework.Tests.Utilties
{
    [Apartment(System.Threading.ApartmentState.STA)]
    public class DIPTest : EficazFramework.Tests.BaseTest
    {
        
        [TestCase(10.0d, 37.795d)]
        [TestCase(100.0d, 377.953d)]
        [TestCase(20.0d, 75.591d)]
        [TestCase(200.0d, 755.906d)]
        [TestCase(500.0d, 1889.764d)]
        [TestCase(25.0d, 94.488d)]
        public void MmToDip(double mm, double result) =>
            System.Math.Round(EficazFramework.Utilities.DipHelper.MmToDip(mm), 3).Should().Be(result);


        [Test]
        public void PleaseHelpMe()
        {
            EficazFramework.Controls.ColorZone colorZone = new EficazFramework.Controls.ColorZone();
            colorZone.IsVisible.Should().BeFalse();
        }
    }
}
