using System;
using System.Globalization;

namespace EficazFramework.Converters;

public partial class BlurEffectConverter : IValueConverter
{
    public int Radius { get; set; } = 6;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        Configuration.Visual.Effects ? new BlurEffect() { Radius = Radius } : null;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}
