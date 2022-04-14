using EficazFramework.Extensions;
using System.Globalization;

namespace EficazFramework.Converters;

public partial class EnumDescriptionConverter : IValueConverter
{
    public Type LocalizationResourceType { get; set; } = typeof(EficazFramework.Resources.Strings.Descriptions);

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        ((Enum)value).GetLocalizedDescription(LocalizationResourceType);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new System.NotImplementedException();
}