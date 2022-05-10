using System.Globalization;

namespace EficazFramework.Converters;

public partial class DataGridColumnHeaderConverter : IValueConverter
{
    public string Operacao { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return false;
        try
        {
            return parameter switch
            {
                "show_filter" => Controls.AttachedProperties.DataGrid.GetShowFilter((DependencyObject)value),

                "show_filter_clear" => string.IsNullOrEmpty(Controls.AttachedProperties.DataGrid.GetFilterText((DependencyObject)value).ToString()) ? Visibility.Collapsed : Visibility.Visible,

                "filter_text" => value as Grid != null ? Controls.AttachedProperties.DataGrid.GetFilterText(((System.Windows.Controls.Primitives.DataGridColumnHeader)((FrameworkElement)value).TemplatedParent).Column) : null,

                _ => null,
            };
        }
        catch
        {
            return false;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        value;
}
