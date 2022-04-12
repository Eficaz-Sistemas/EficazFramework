namespace Controls;

public partial class DataGridEnumComboboxColumn : System.Windows.Controls.DataGridComboBoxColumn
{
    public Type LocalizationResourceType { get; set; } = typeof(EficazFramework.Resources.Strings.Descriptions);

    public DataGridEnumComboboxColumn() =>
        EditingElementStyle = (System.Windows.Style)System.Windows.Application.Current.FindResource("Style.Combobox.DataGridCellEditor");

    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
        TextBlock tb = (TextBlock)base.GenerateElement(cell, dataItem);
        if (SelectedValueBinding is object)
        {
            var b = new Binding();
            Binding vlBinding = (Binding)SelectedValueBinding;
            b.Path = vlBinding.Path;
            b.UpdateSourceTrigger = vlBinding.UpdateSourceTrigger;
            b.Mode = BindingMode.OneWay;
            b.Converter = new Converters.EnumDescriptionConverter() { LocalizationResourceType = LocalizationResourceType };
            tb.SetBinding(TextBlock.TextProperty, b);
        }

        return tb;
    }
}
