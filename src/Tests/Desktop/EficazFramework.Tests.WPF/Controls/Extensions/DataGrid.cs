namespace EficazFramework.Tests.Controls.Extensions;

public class DataGridExtensionsTests : BaseTest
{
    [SetUp]
    public async Task Setup()
    {
        var tabControl = await MainWindow.GetElement<TabControl>("maintab");
        await tabControl.SetSelectedIndex(2);
    }

    [Test]
    public async Task NavigationTest()
    {
        var dataGrid = await MainWindow.GetElement<DataGrid>("dgMain");
        (await dataGrid.GetSelectedIndex()).Should().Be(0);

        await dataGrid.SetProperty(EficazFramework.Controls.AttachedProperties.TabControl.NavigationTemplateProperty, true);
        
        var row0 = await dataGrid.GetElement<DataGridRow>("/DataGridRow[0]");
        row0.Should().NotBeNull();
        (await row0.GetIsSelected()).Should().BeTrue();

        var row1 = await dataGrid.GetElement<DataGridRow>("/DataGridRow[1]");
        row1.Should().NotBeNull();
        (await row1.GetIsSelected()).Should().BeFalse();
        await row1.MoveCursorTo();
        await row1.LeftClick();
        await Task.Delay(150);
        (await dataGrid.GetSelectedIndex()).Should().Be(1);
        (await row1.GetIsSelected()).Should().BeTrue();
        (await row0.GetIsSelected()).Should().BeFalse();

        await dataGrid.SetSelectionUnit(DataGridSelectionUnit.Cell);
        var row0_cell2 = await row0.GetElement<DataGridCell>("/DataGridCell[2]");
        row0_cell2.Should().NotBeNull();
        Console.WriteLine($"row0_cell2: {await row0_cell2.GetDataContext()}");
        (await row0_cell2.GetIsSelected()).Should().BeFalse();
        await row0_cell2.MoveCursorTo();
        await row0_cell2.LeftClick();
        await Task.Delay(150);
        await row0_cell2.LeftClick();
        await Task.Delay(150);
        (await row0_cell2.GetIsSelected()).Should().BeTrue();
        (await row1.GetIsSelected()).Should().BeFalse();
        var value = await dataGrid.GetProperty<object>("Items");

        var row1_cell3 = await row1.GetElement<DataGridCell>("/DataGridCell[3]");
        row1_cell3.Should().NotBeNull();
        (await row1_cell3.GetIsSelected()).Should().BeFalse();
        await row1_cell3.MoveCursorTo();
        await row1_cell3.LeftClick();
        await Task.Delay(150);
        await row1_cell3.LeftClick();
        await Task.Delay(150);
        (await row1_cell3.GetIsSelected()).Should().BeTrue();
        (await row0_cell2.GetIsSelected()).Should().BeFalse();
    }
}
