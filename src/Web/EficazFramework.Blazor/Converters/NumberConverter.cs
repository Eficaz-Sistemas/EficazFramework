using System;
using System.Globalization;

namespace EficazFramework.Converters
{
    public class NumberConverter<T> : MudBlazor.DefaultConverter<T>
    {
        public NumberConverter(int decimals = 0)
        {
            _setCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            _setCulture.NumberFormat.PercentGroupSeparator = "";
            _setCulture.NumberFormat.CurrencyGroupSeparator = "";
            _setCulture.NumberFormat.NumberGroupSeparator = "";
            DecimalPlaces = decimals;

            OnGetBase = base.GetFunc;
            GetFunc = OnGet;

            OnSetBase = base.SetFunc;
            SetFunc = OnSet;
        }

        private int _decimals = 0;
        private CultureInfo _setCulture;
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
                return default(T);

            // short
            else if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
            {
                if (short.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)parsedValue;
                UpdateGetError("Not a valid number");
            }
            // ushort
            else if (typeof(T) == typeof(ushort) || typeof(T) == typeof(ushort?))
            {
                if (ushort.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)parsedValue;
                UpdateGetError("Not a valid number");
            }
            // int
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)parsedValue;
                UpdateGetError("Not a valid number");
            }
            // uint
            else if (typeof(T) == typeof(uint) || typeof(T) == typeof(uint?))
            {
                if (uint.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)parsedValue;
                UpdateGetError("Not a valid number");
            }
            // long
            else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
            {
                if (long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)parsedValue;
                UpdateGetError("Not a valid number");
            }
            // ulong
            else if (typeof(T) == typeof(ulong) || typeof(T) == typeof(ulong?))
            {
                if (ulong.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)parsedValue;
                UpdateGetError("Not a valid number");
            }
            // float
            else if (typeof(T) == typeof(float) || typeof(T) == typeof(float?))
            {
                if (float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)System.Math.Round(parsedValue, DecimalPlaces);
                UpdateGetError("Not a valid number");
            }
            // double
            else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
            {
                if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)System.Math.Round(parsedValue, DecimalPlaces);
                UpdateGetError("Not a valid number");
            }
            // decimal
            else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?) || typeof(T) == typeof(object))
            {
                if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
                    return (T)(object)System.Math.Round(parsedValue, DecimalPlaces);
                UpdateGetError("Not a valid number");
            }
            // object
            else if (typeof(T) == typeof(object))
            {
                if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
                {
                    var final = (T)(object)System.Math.Round(parsedValue, DecimalPlaces);
                    Console.WriteLine($"OnGet T: {final}");
                    return final;
                }
                     
                UpdateGetError("Not a valid number");
            }

            return OnGetBase(value);
        }

        private string OnSet(T arg)
        {
            if (arg == null)
                return null;

            // short
            if (typeof(T) == typeof(short))
                return ((short)(object)arg).ToString(Format, _setCulture);
            if (typeof(T) == typeof(short?))
                return ((short?)(object)arg).Value.ToString(Format, _setCulture);
            // ushort
            if (typeof(T) == typeof(ushort))
                return ((ushort)(object)arg).ToString(Format, _setCulture);
            if (typeof(T) == typeof(ushort?))
                return ((ushort?)(object)arg).Value.ToString(Format, _setCulture);
            // int
            else if (typeof(T) == typeof(int))
                return ((int)(object)arg).ToString(Format, _setCulture);
            else if (typeof(T) == typeof(int?))
                return ((int?)(object)arg).Value.ToString(Format, _setCulture);
            // uint
            else if (typeof(T) == typeof(uint))
                return ((uint)(object)arg).ToString(Format, _setCulture);
            else if (typeof(T) == typeof(uint?))
                return ((uint?)(object)arg).Value.ToString(Format, _setCulture);
            // long
            else if (typeof(T) == typeof(long))
                return ((long)(object)arg).ToString(Format, _setCulture);
            else if (typeof(T) == typeof(long?))
                return ((long?)(object)arg).Value.ToString(Format, _setCulture);
            // ulong
            else if (typeof(T) == typeof(ulong))
                return ((ulong)(object)arg).ToString(Format, _setCulture);
            else if (typeof(T) == typeof(ulong?))
                return ((ulong?)(object)arg).Value.ToString(Format, _setCulture);
            // float
            if (typeof(T) == typeof(float))
                return ((float)(object)arg).ToString(Format, _setCulture);
            else if (typeof(T) == typeof(float?))
                return ((float?)(object)arg).Value.ToString(Format, _setCulture);
            // double
            else if (typeof(T) == typeof(double))
                return ((double)(object)arg).ToString(Format, _setCulture);
            else if (typeof(T) == typeof(double?))
                return ((double?)(object)arg).Value.ToString(Format, _setCulture);
            // decimal
            else if (typeof(T) == typeof(decimal))
                return ((decimal)(object)arg).ToString(Format, _setCulture);
            else if (typeof(T) == typeof(decimal?))
                return ((decimal?)(object)arg).Value.ToString(Format, _setCulture);
            //object (yeah, it can happen)
            else if (typeof(T) == typeof(object))
                return decimal.Parse(arg.ToString()).ToString(Format, _setCulture);

            return OnSetBase(arg);
        }

        private readonly Func<string, T> OnGetBase;
        private readonly Func<T, string> OnSetBase;
    }
}
