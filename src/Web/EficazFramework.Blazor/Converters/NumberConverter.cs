using System;
using System.Globalization;

#pragma warning disable CS8603 // Possível retorno de referência nula.

namespace EficazFramework.Converters;

public class NumberConverter<T> : MudBlazor.DefaultConverter<T>
{
    public NumberConverter(int decimals = 0)
    {
        DecimalPlaces = decimals;

        OnGetBase = base.GetFunc;
        GetFunc = OnGet;

        OnSetBase = base.SetFunc;
        SetFunc = OnSet;
    }

    private int _decimals = 0;
    public int DecimalPlaces
    {
        get => _decimals;
        set
        {
            _decimals = value;
            Format = $"N{value}";
        }
    }


    private T OnGet(string value)
    {
        // this is important, or otherwise all the TryParse down there might fail.
        if (string.IsNullOrEmpty(value))
            return default;

        try
        {

            // short
            if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
                return (T)(object)Convert.ToInt16(Math.Round(double.Parse(value)), Culture);
            // ushort
            else if (typeof(T) == typeof(ushort) || typeof(T) == typeof(ushort?))
                return (T)(object)Convert.ToUInt16(Math.Round(double.Parse(value)), Culture);
            // int
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                return (T)(object)Convert.ToInt32(Math.Round(double.Parse(value)), Culture);
            // uint
            else if (typeof(T) == typeof(uint) || typeof(T) == typeof(uint?))
                return (T)(object)Convert.ToUInt32(Math.Round(double.Parse(value)), Culture);
            // long
            else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                return (T)(object)Convert.ToInt64(Math.Round(double.Parse(value)), Culture);
            // ulong
            else if (typeof(T) == typeof(ulong) || typeof(T) == typeof(ulong?))
                return (T)(object)Convert.ToUInt64(Math.Round(double.Parse(value)), Culture);
            // float or Single
            else if (typeof(T) == typeof(float) || typeof(T) == typeof(float?) || typeof(T) == typeof(Single) || typeof(T) == typeof(Single?))
                return DecimalPlaces != 0 ? (T)(object)Convert.ToSingle(Math.Round(double.Parse(value), DecimalPlaces), Culture) : 
                                            (T)(object)Convert.ToSingle(Math.Round(double.Parse(value)), Culture);
            // double
            else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                return DecimalPlaces != 0 ? (T)(object)Convert.ToDouble(Math.Round(double.Parse(value), DecimalPlaces), Culture) :
                                            (T)(object)Convert.ToDouble(Math.Round(double.Parse(value)), Culture);
            // decimal
            else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
                return DecimalPlaces != 0 ? (T)(object)Convert.ToDecimal(Math.Round(double.Parse(value), DecimalPlaces), Culture) :
                                            (T)(object)Convert.ToDecimal(Math.Round(double.Parse(value)), Culture);
            // object
            else if (typeof(T) == typeof(object))
                return DecimalPlaces != 0 ? (T)(object)Convert.ToDecimal(Math.Round(double.Parse(value), DecimalPlaces), Culture) :
                                            (T)(object)Convert.ToDecimal(Math.Round(double.Parse(value)), Culture);
        }
        catch
        {
            UpdateGetError($"Conversion to type {typeof(T)} not implemented");
        }

        return OnGetBase(value);
    }

    private string OnSet(T arg)
    {
        if (arg == null)
            return null;

        // short
        if (typeof(T) == typeof(short))
            return ((short)(object)arg).ToString(Format, Culture);
        if (typeof(T) == typeof(short?))
            return ((short?)(object)arg).Value.ToString(Format, Culture);
        // ushort
        if (typeof(T) == typeof(ushort))
            return ((ushort)(object)arg).ToString(Format, Culture);
        if (typeof(T) == typeof(ushort?))
            return ((ushort?)(object)arg).Value.ToString(Format, Culture);
        // int
        else if (typeof(T) == typeof(int))
            return ((int)(object)arg).ToString(Format, Culture);
        else if (typeof(T) == typeof(int?))
            return ((int?)(object)arg).Value.ToString(Format, Culture);
        // uint
        else if (typeof(T) == typeof(uint))
            return ((uint)(object)arg).ToString(Format, Culture);
        else if (typeof(T) == typeof(uint?))
            return ((uint?)(object)arg).Value.ToString(Format, Culture);
        // long
        else if (typeof(T) == typeof(long))
            return ((long)(object)arg).ToString(Format, Culture);
        else if (typeof(T) == typeof(long?))
            return ((long?)(object)arg).Value.ToString(Format, Culture);
        // ulong
        else if (typeof(T) == typeof(ulong))
            return ((ulong)(object)arg).ToString(Format, Culture);
        else if (typeof(T) == typeof(ulong?))
            return ((ulong?)(object)arg).Value.ToString(Format, Culture);
        // float
        if (typeof(T) == typeof(float))
            return ((float)(object)arg).ToString(Format, Culture);
        else if (typeof(T) == typeof(float?))
            return ((float?)(object)arg).Value.ToString(Format, Culture);
        // double
        else if (typeof(T) == typeof(double))
            return ((double)(object)arg).ToString(Format, Culture);
        else if (typeof(T) == typeof(double?))
            return ((double?)(object)arg).Value.ToString(Format, Culture);
        // decimal
        else if (typeof(T) == typeof(decimal))
            return ((decimal)(object)arg).ToString(Format, Culture);
        else if (typeof(T) == typeof(decimal?))
            return ((decimal?)(object)arg).Value.ToString(Format, Culture);
        //object (yeah, it can happen)
        else if (typeof(T) == typeof(object))
            return arg.ToString();

        return OnSetBase(arg);
    }

    private readonly Func<string, T> OnGetBase;
    private readonly Func<T, string> OnSetBase;
}
#pragma warning restore CS8603 // Possível retorno de referência nula.