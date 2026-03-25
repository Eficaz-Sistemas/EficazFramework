using System.Globalization;

namespace EficazFramework.Converters;

public class NumberConverter<T> : MudBlazor.IReversibleConverter<T?, string>, MudBlazor.ICultureAwareConverter
{
    public NumberConverter(int decimalPlaces)
    {
        DecimalPlaces = decimalPlaces;
        Format = () => $"N{decimalPlaces}";
    }

    public string Convert(T? input)
    {
        if (input == null)
            return null;

        // short
        if (typeof(T) == typeof(short))
            return ((short)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        if (typeof(T) == typeof(short?))
            return ((short?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // ushort
        if (typeof(T) == typeof(ushort))
            return ((ushort)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        if (typeof(T) == typeof(ushort?))
            return ((ushort?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // int
        else if (typeof(T) == typeof(int))
            return ((int)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        else if (typeof(T) == typeof(int?))
            return ((int?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // uint
        else if (typeof(T) == typeof(uint))
            return ((uint)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        else if (typeof(T) == typeof(uint?))
            return ((uint?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // long
        else if (typeof(T) == typeof(long))
            return ((long)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        else if (typeof(T) == typeof(long?))
            return ((long?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // ulong
        else if (typeof(T) == typeof(ulong))
            return ((ulong)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        else if (typeof(T) == typeof(ulong?))
            return ((ulong?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // float
        if (typeof(T) == typeof(float))
            return ((float)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        else if (typeof(T) == typeof(float?))
            return ((float?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // double
        else if (typeof(T) == typeof(double))
            return ((double)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        else if (typeof(T) == typeof(double?))
            return ((double?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        // decimal
        else if (typeof(T) == typeof(decimal))
            return ((decimal)(object)input).ToString(Format.Invoke(), Culture.Invoke());
        else if (typeof(T) == typeof(decimal?))
            return ((decimal?)(object)input).Value.ToString(Format.Invoke(), Culture.Invoke());
        //object (yeah, it can happen)
        else if (typeof(T) == typeof(object))
            return input.ToString();

        return input.ToString();
    }

    public T ConvertBack(string input)
    {
        // this is important, or otherwise all the TryParse down there might fail.
        if (string.IsNullOrEmpty(input))
            return default;


        // short
        if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
            return (T)(object)System.Convert.ToInt16(Math.Round(double.Parse(input)), Culture.Invoke());
        // ushort
        else if (typeof(T) == typeof(ushort) || typeof(T) == typeof(ushort?))
            return (T)(object)System.Convert.ToUInt16(Math.Round(double.Parse(input)), Culture.Invoke());
        // int
        else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            return (T)(object)System.Convert.ToInt32(Math.Round(double.Parse(input)), Culture.Invoke());
        // uint
        else if (typeof(T) == typeof(uint) || typeof(T) == typeof(uint?))
            return (T)(object)System.Convert.ToUInt32(Math.Round(double.Parse(input)), Culture.Invoke());
        // long
        else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
            return (T)(object)System.Convert.ToInt64(Math.Round(double.Parse(input)), Culture.Invoke());
        // ulong
        else if (typeof(T) == typeof(ulong) || typeof(T) == typeof(ulong?))
            return (T)(object)System.Convert.ToUInt64(Math.Round(double.Parse(input)), Culture.Invoke());
        // float or Single
        else if (typeof(T) == typeof(float) || typeof(T) == typeof(float?) || typeof(T) == typeof(Single) || typeof(T) == typeof(Single?))
            return DecimalPlaces != 0 ? (T)(object)System.Convert.ToSingle(Math.Round(double.Parse(input), DecimalPlaces), Culture.Invoke()) :
                                        (T)(object)System.Convert.ToSingle(Math.Round(double.Parse(input)), Culture.Invoke());
        // double
        else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
            return DecimalPlaces != 0 ? (T)(object)System.Convert.ToDouble(Math.Round(double.Parse(input), DecimalPlaces), Culture.Invoke()) :
                                        (T)(object)System.Convert.ToDouble(Math.Round(double.Parse(input)), Culture.Invoke());
        // decimal
        else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
            return DecimalPlaces != 0 ? (T)(object)System.Convert.ToDecimal(Math.Round(double.Parse(input), DecimalPlaces), Culture.Invoke()) :
                                        (T)(object)System.Convert.ToDecimal(Math.Round(double.Parse(input)), Culture.Invoke());
        // object
        else if (typeof(T) == typeof(object))
            return DecimalPlaces != 0 ? (T)(object)System.Convert.ToDecimal(Math.Round(double.Parse(input), DecimalPlaces), Culture.Invoke()) :
                                        (T)(object)System.Convert.ToDecimal(Math.Round(double.Parse(input)), Culture.Invoke());

        return default;
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