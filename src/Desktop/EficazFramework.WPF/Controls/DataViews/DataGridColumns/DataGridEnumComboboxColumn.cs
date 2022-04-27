namespace EficazFramework.Controls;

public partial class DataGridEnumComboboxColumn : System.Windows.Controls.DataGridComboBoxColumn
{
    public Type LocalizationResourceType { get; set; }

    public DataGridEnumComboboxColumn() =>
        EditingElementStyle = (System.Windows.Style)System.Windows.Application.Current.FindResource("Style.Combobox.DataGridCellEditor");

    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
        TextBlock tb = new() { DataContext = dataItem };
        tb.SetResourceReference(TextBlock.StyleProperty, "Style.TextBlock.DataGrid");
        if (SelectedValueBinding != null)
        {
            var b = new Binding();
            Binding vlBinding = (Binding)SelectedValueBinding;
            b.Path = vlBinding.Path;
            b.UpdateSourceTrigger = vlBinding.UpdateSourceTrigger;
            b.Mode = BindingMode.OneWay;
            
            if (LocalizationResourceType != null)
                b.Converter = new Converters.EnumDescriptionConverter() { LocalizationResourceType = LocalizationResourceType };
            
            tb.SetBinding(TextBlock.TextProperty, b);
        }

        return tb;
    }
}
