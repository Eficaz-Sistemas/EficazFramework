﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf.Converters;

public class FloatingHintOffsetCalculationConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var fontFamily = (FontFamily)values[0];
        double fontSize = (double)values[1];
        double floatingScale = (double)values[2];

        double hintHeight = fontFamily.LineSpacing * fontSize;
        double floatingHintHeight = hintHeight * floatingScale;

        double offset = (values.Length > 3 ? values[3] : null) switch
        {
            Thickness padding => floatingHintHeight / 2 + padding.Top,
            double parentHeight => (parentHeight - hintHeight + floatingHintHeight) / 2,
            _ => floatingHintHeight
        };

        if (IsType<Point>(targetType))
        {
            return new Point(0, -offset);
        }

        if (IsType<Thickness>(targetType))
        {
            return new Thickness(0, offset, 0, 0);
        }

        throw new NotSupportedException(targetType.FullName);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();

    private static bool IsType<T>(Type type) => type == typeof(T);
}
