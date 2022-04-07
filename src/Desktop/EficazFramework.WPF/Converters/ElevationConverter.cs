using System;
using System.Globalization;

namespace EficazFramework.Converters;

public partial class ElevationEffectConverter : IValueConverter
{
    public int Direction { get; set; } = 258;
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (int.TryParse(value.ToString(), out int result))
            return new DropShadowEffect() { BlurRadius = result * 4, Direction = Direction, ShadowDepth = 0 };
        else
            return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}
