using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EficazFramework.Extensions;

public static class Enums
{
    public static IEnumerable<EnumMember> GetValues<TEnum>()
    {
        if (typeof(TEnum).IsEnum == false & !ReferenceEquals(typeof(TEnum).BaseType, typeof(TEnum))) { return null; }
        TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        return values.Select(e => new EnumMember { Description = GetDescription(e), Value = e }).ToList();
    }

    public static IEnumerable<EnumMember> GetValues(Type enumType)
    {
        if (enumType.IsEnum == false & !ReferenceEquals(enumType.BaseType, enumType)) { return null; }
        var values = Enum.GetValues(enumType);
        var result = new List<EnumMember>();
        for (int i = 0; i < values.Length; i++)
        {
            result.Add(new EnumMember { Description = GetDescription(values.GetValue(i)), Value = values.GetValue(i) });
        }
        return result;
    }

    public static IEnumerable<EnumMember> GetLocalizedValues<TEnum>()
    {
        if (typeof(TEnum).IsEnum == false & !ReferenceEquals(typeof(TEnum).BaseType, typeof(TEnum))) { return null; }
        TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        return values.Select(e => new EnumMember { Description = GetLocalizedDescription(e), Value = e }).ToList();
    }

    public static IEnumerable<EnumMember> GetLocalizedValues(Type enumType)
    {
        if (enumType.IsEnum == false & !ReferenceEquals(enumType.BaseType, enumType)) { return null; }
        var values = Enum.GetValues(enumType);
        var result = new List<EnumMember>();
        for (int i = 0; i < values.Length; i++)
        {
            result.Add(new EnumMember { Description = GetLocalizedDescription(values.GetValue(i)), Value = values.GetValue(i) });
        }
        return result;
    }

    public static IEnumerable<EnumMember> GetLocalizedValues<TEnum>(string resourceTypeName)
    {
        if (typeof(TEnum).IsEnum == false & !ReferenceEquals(typeof(TEnum).BaseType, typeof(TEnum))) { return null; }
        TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        return values.Select(e => new EnumMember { Description = GetLocalizedDescription(e, typeof(TEnum).Assembly, resourceTypeName), Value = e }).ToList();
    }

    public static IEnumerable<EnumMember> GetBoolValues()
    {
        var result = new List<EnumMember>
        {
            new EnumMember() { Value = true, Description = EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_True },
            new EnumMember() { Value = false, Description = EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_False }
        };
        var arr = result.ToArray();
        return arr;
    }

#pragma warning disable IDE0060 // Remover o parâmetro não utilizado
    public static IEnumerable<GroupedEnumMember> GetValuesWithCategory<TEnum>(this Type EnumType)
    {
        if (typeof(TEnum).IsEnum == false & !ReferenceEquals(typeof(TEnum).BaseType, typeof(TEnum))) { return null; }
        TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        return values.Select(e => new GroupedEnumMember { Category = GetCategory(e), Description = GetDescription(e), Value = e }).ToList();
    }

    public static IEnumerable<GroupedEnumMember> GetLocalizedValuesWithCategory<TEnum>(this Type EnumType)
#pragma warning restore IDE0060 // Remover o parâmetro não utilizado
    {
        if (typeof(TEnum).IsEnum == false & !ReferenceEquals(typeof(TEnum).BaseType, typeof(TEnum))) { return null; }
        TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        return values.Select(e => new GroupedEnumMember { Category = GetLocalizedCategory(e), Description = GetLocalizedDescription(e), Value = e }).ToList();
    }

    public static IEnumerable<GroupedEnumMember> GetLocalizedValuesWithCategory<TEnum>(string resourceTypeName)
    {
        if (typeof(TEnum).IsEnum == false & !ReferenceEquals(typeof(TEnum).BaseType, typeof(TEnum))) { return null; }
        TEnum[] values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        return values.Select(e => new GroupedEnumMember { Category = GetLocalizedCategory(e, resourceTypeName), Description = GetLocalizedDescription(e, resourceTypeName), Value = e }).ToList();
    }

    public static string GetDescription(this object value)
    {
        string result = value.ToString();
        var enumType = value.GetType();
        try
        {
            // Dim att = value.GetType().GetField(value.ToString).GetCustomAttributes(GetType(Common.Attributes.UIEditor.EditorGeneration.EnumDescriptionAttribute), True)
            var att = enumType.GetMember(result)?.First().GetCustomAttributes(typeof(EficazFramework.Attributes.DisplayNameAttribute), true);
            if ((att?.Length) <= 0 == true)
                att = enumType.GetField(value.ToString())?.GetCustomAttributes(typeof(EficazFramework.Attributes.DisplayNameAttribute), true);
            if (att is not null)
            {
                if (att.Length > 0)
                {
                    result = ((EficazFramework.Attributes.DisplayNameAttribute)att[0]).DisplayName;
                }
            }
        }
        catch
        {
            // result = value.ToString
        } // ex As Exception

        return result;
    }

    public static string GetCategory(this object value)
    {
        string result = value.ToString();
        var enumType = value.GetType();
        try
        {
            // Dim att = value.GetType().GetField(value.ToString).GetCustomAttributes(GetType(Common.Attributes.UIEditor.EditorGeneration.EnumDescriptionAttribute), True)
            var att = enumType.GetMember(result)?.First().GetCustomAttributes(typeof(CategoryAttribute), true);
            if ((att?.Length) <= 0 == true)
                att = enumType.GetField(value.ToString())?.GetCustomAttributes(typeof(CategoryAttribute), true);
            if (att is not null)
            {
                if (att.Length > 0)
                {
                    result = ((CategoryAttribute)att[0]).Category;
                }
            }
        }
        catch
        {
            // result = value.ToString
        } // ex As Exception

        return result;
    }

    public static string GetLocalizedDescription(this bool value, BoolDescriptionType mode)
    {
        return mode switch
        {
            BoolDescriptionType.YesNo => value == true ? Resources.Strings.Descriptions.BoolToYesNo_True : Resources.Strings.Descriptions.BoolToYesNo_False,
            _ => value == true ? Resources.Strings.Descriptions.BoolToTrueFalse_True : Resources.Strings.Descriptions.BoolToTrueFalse_False
        };
    }

    public static string GetLocalizedDescription(this bool value, string trueValue, string falseValue)
    {
        return value == true ? trueValue : falseValue;
    }

    public static string GetLocalizedDescription(this object value)
    {
        string result = value.ToString();
        var enumType = value.GetType();
        try
        {
            // Dim att = value.GetType().GetField(value.ToString).GetCustomAttributes(GetType(Common.Attributes.UIEditor.EditorGeneration.EnumDescriptionAttribute), True)
            var att = enumType.GetMember(result)?.First().GetCustomAttributes(typeof(EficazFramework.Attributes.DisplayNameAttribute), true);
            if ((att?.Length) <= 0 == true)
                att = enumType.GetField(value.ToString())?.GetCustomAttributes(typeof(EficazFramework.Attributes.DisplayNameAttribute), true);
            if (att is not null)
            {
                if (att.Length > 0)
                {
                    var attr = (EficazFramework.Attributes.DisplayNameAttribute)att[0];
                    result = attr.DisplayName;
                    if (attr.ResourceType != null)
                    {
                        return result.Localize(attr.ResourceType, "{0}");
                    }
                }
            }
        }
        catch
        {
            // result = value.ToString
        } // ex As Exception

        return result.Localize();
    }

    public static string GetLocalizedDescription(this object value, string resourceTypeName)
    {
        return value.GetDescription().Localize(resourceTypeName, null);
    }

    public static string GetLocalizedDescription(this object value, string assembly, string resourceTypeName)
    {
        return value.GetDescription().Localize(resourceTypeName, assembly, null);
    }

    public static string GetLocalizedDescription(this object value, System.Reflection.Assembly assembly, string resourceTypeName)
    {
        return value.GetDescription().Localize(resourceTypeName, assembly, null);
    }

    public static string GetLocalizedCategory(this object value)
    {
        return value.GetCategory().Localize();
    }

    public static string GetLocalizedCategory(this object value, string resourceTypeName)
    {
        return value.GetCategory().Localize(resourceTypeName, null);
    }

    public static string GetLocalizedCategory(this object value, string assembly, string resourceTypeName)
    {
        return value.GetCategory().Localize(resourceTypeName, assembly, null);
    }

    public static string GetLocalizedCategory(this object value, System.Reflection.Assembly assembly, string resourceTypeName)
    {
        return value.GetCategory().Localize(resourceTypeName, assembly, null);
    }
}

public class EnumMember
{
    public string Description { get; set; }
    public object Value { get; set; }

    public override string ToString()
    {
        return Description;
    }
}

public class GroupedEnumMember : EnumMember
{
    public string Category { get; set; }

    public override string ToString()
    {
        return string.Format("[{0}] {1}", Category, Description);
    }
}

public enum BoolDescriptionType
{
    YesNo = 0,
    TrueFalse = 1
}
