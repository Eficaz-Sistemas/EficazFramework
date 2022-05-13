using System.Windows.Input;

namespace EficazFramework.Tests.Controls.Extensions;

public class DataGridExtensionsTests : BaseTest
{
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    private IVisualElement<DataGrid> DataGrid;
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    
    [SetUp]
    public async Task Setup()
    {
        var tabControl = await MainWindow.GetElement<TabControl>("maintab");
        await tabControl.SetSelectedIndex(2);
        DataGrid = await MainWindow.GetElement<DataGrid>("dgMain") ?? throw new NullReferenceException("Can't find any DataGrid.");
    }

    [Test]
    public async Task NavigationTest()
    {
        (await DataGrid.GetSelectedIndex()).Should().Be(0);

        await DataGrid.SetProperty(EficazFramework.Controls.AttachedProperties.TabControl.NavigationTemplateProperty, false);
        await DataGrid.SetProperty(EficazFramework.Controls.AttachedProperties.TabControl.NavigationTemplateProperty, true);
        
        var row0 = await DataGrid.GetElement<DataGridRow>("/DataGridRow[0]");
        row0.Should().NotBeNull();
        (await row0.GetIsSelected()).Should().BeTrue();

        var row1 = await DataGrid.GetElement<DataGridRow>("/DataGridRow[1]");
        row1.Should().NotBeNull();
        (await row1.GetIsSelected()).Should().BeFalse();
        await row1.MoveCursorTo();
        await row1.LeftClick();
        await Task.Delay(150);
        (await DataGrid.GetSelectedIndex()).Should().Be(1);
        (await row1.GetIsSelected()).Should().BeTrue();
        (await row0.GetIsSelected()).Should().BeFalse();

        await DataGrid.SetSelectionUnit(DataGridSelectionUnit.Cell);
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
        var value = await DataGrid.GetProperty<object>("Items");

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

        var row1_cell4 = await row1.GetElement<DataGridCell>("/DataGridCell[4]");
        row1_cell4.Should().NotBeNull();
        (await row1_cell4.GetIsSelected()).Should().BeFalse();
        await row1_cell3.SendKeyboardInput($"{Key.Enter}");
        await Task.Delay(150);
        (await row1_cell4.GetIsSelected()).Should().BeTrue();
        (await row1_cell3.GetIsSelected()).Should().BeFalse();

    }

    [Test, Apartment(ApartmentState.STA)]
    public void AttachedPropertiesHandlersTest()
    {
        DataGrid dg = new DataGrid()
        { 
            AutoGenerateColumns = true, 
            SelectionUnit = DataGridSelectionUnit.FullRow, 
            ItemsSource = new Tests.Shared.MockList()
        };
        EficazFramework.Controls.AttachedProperties.TabControl.GetNavigationTemplate(dg).Should().BeFalse();
        EficazFramework.Controls.AttachedProperties.TabControl.SetNavigationTemplate(dg, true);
        EficazFramework.Controls.AttachedProperties.TabControl.GetNavigationTemplate(dg).Should().BeTrue();
        dg.UpdateLayout();

        
    }


}
