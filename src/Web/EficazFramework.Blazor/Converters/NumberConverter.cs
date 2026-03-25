using MudBlazor.Utilities.Exceptions;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
using static MudBlazor.Icons.Material;

namespace EficazFramework.Converters;

public class NumberConverter<T> : MudBlazor.IReversibleConverter<T?, string>, MudBlazor.ICultureAwareConverter 
    where T : struct, INumber<T>
{
    public NumberConverter(int decimalPlaces)
    {
        DecimalPlaces = decimalPlaces;
        Format = () => $"N{decimalPlaces}";
        Culture = () => CultureInfo.CurrentCulture;
    }

    public string Convert(T? input)
    {
        if (input is null)
            return string.Empty;

        return input.Value.ToString(Format.Invoke(), Culture.Invoke());
    }

    public T? ConvertBack(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        var currentCulture = Culture.Invoke();

        if (decimal.TryParse(input, NumberStyles.Any, currentCulture, out var resultT))
        {
            var asDecimal = System.Convert.ToDecimal(resultT, currentCulture);
            var rounded = Math.Round(asDecimal, DecimalPlaces);

            return T.CreateChecked(rounded);
        }

        throw new ConversionException("Invalid number");
    }


    private int _decimals = 0;
    public int DecimalPlaces
    {
        get => _decimals;
        set
        {
            _decimals = value;
            Format = () => $"N{value}";
        }
    }

    public Func<CultureInfo> Culture { get; set; }
    public Func<string?> Format { get; set; }
}