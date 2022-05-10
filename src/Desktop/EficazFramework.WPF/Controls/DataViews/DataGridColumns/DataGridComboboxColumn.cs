namespace EficazFramework.Controls;

public partial class DataGridComboBoxColumn : System.Windows.Controls.DataGridComboBoxColumn
{
    public DataGridComboBoxColumn() =>
        EditingElementStyle = (System.Windows.Style)System.Windows.Application.Current.FindResource("Style.Combobox.DataGridCellEditor");


    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
        TextBlock tb = (TextBlock)base.GenerateElement(cell, dataItem);
        if (SelectedItemBinding is object)
            tb.SetBinding(TextBlock.TextProperty, SelectedItemBinding);
        else
            tb.SetBinding(TextBlock.TextProperty, SelectedValueBinding);

        return tb;
    }
}
