using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace EficazFramework.XAML.Behaviors;

public partial class DataGridEnterKeyNavigation : Behavior<DataGrid>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        this.AssociatedObject.PreviewKeyDown += DataGridAssist.DataGrid_NavigationTemplate_PreviewKeyDown;
        // Me.AssociatedObject.SelectionMode = DataGridSelectionMode.Single
        // Me.AssociatedObject.SelectionUnit = DataGridSelectionUnit.Cell
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        this.AssociatedObject.PreviewKeyDown -= DataGridAssist.DataGrid_NavigationTemplate_PreviewKeyDown;
    }
}
