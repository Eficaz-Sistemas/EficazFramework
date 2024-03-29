﻿namespace EficazFramework.Tests;

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
    public async Task ResourcesTest(string resourceName)
    {
        (await Application.GetResource(resourceName)).Should().NotBeNull();
        (await MainWindow.GetResource(resourceName)).Should().NotBeNull();
    }


}
