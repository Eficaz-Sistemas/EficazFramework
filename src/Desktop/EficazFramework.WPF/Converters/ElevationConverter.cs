﻿using System.Globalization;

namespace EficazFramework.Converters;

public partial class ElevationEffectConverter : IValueConverter
{
    public int Direction { get; set; } = 258;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (int.TryParse(value.ToString(), out int result))
            return result != 0 ? new DropShadowEffect() { BlurRadius = result * 4, Direction = Direction, ShadowDepth = 0 } : null;
        else
            return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}
