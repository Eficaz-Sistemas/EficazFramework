using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EficazFramework.Extensions;

public static class Enums
{
    private static TEnum[] GetEnumList<TEnum>()
    {
        if (typeof(TEnum).IsEnum == false & !ReferenceEquals(typeof(TEnum).BaseType, typeof(TEnum))) { return null; }
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
    }
    private static object[] GetEnumList(Type enumType)
    {
        if (enumType.IsEnum == false & !ReferenceEquals(enumType.BaseType, enumType)) { return null; }
        return Enum.GetValues(enumType).Cast<object>().ToArray();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição de cada membro de TEnum
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<EnumMember> GetValues<TEnum>()
    {
        return GetEnumList<TEnum>().Select(e => new EnumMember { Description = e.GetDescription(), Value = e }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição de cada membro de enumType
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<EnumMember> GetValues(Type enumType)
    {
        return GetEnumList(enumType).Select(e => new EnumMember { Description = e.GetDescription(), Value = e }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição do Enumerador Booleano
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<EnumMember> GetBoolValues(BoolDescriptionType boolText = BoolDescriptionType.YesNo)
    {
        return new List<EnumMember>
        {
            new EnumMember() { Value = true, Description = boolText switch
            {
                BoolDescriptionType.YesNo =>  EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_True,
                _ => EficazFramework.Resources.Strings.Descriptions.BoolToTrueFalse_True
            } },
            new EnumMember() { Value = false, Description = boolText switch
            {
                BoolDescriptionType.YesNo =>  EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_False,
                _ => EficazFramework.Resources.Strings.Descriptions.BoolToTrueFalse_False
            } }
        };
    }

    /// <summary>
    /// Obtém uma listagem de Valor/Categoria/Descrição de cada membro de TEnum
    /// </summary>
    /// <returns>IEnumerable of GroupedEnumMember</returns>
    public static IEnumerable<GroupedEnumMember> GetValuesWithCategory<TEnum>()
    {
        return GetEnumList<TEnum>().Select(e => new GroupedEnumMember { Category = e.GetCategory(), Description = e.GetDescription(), Value = e }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de Valor/Categoria/Descrição de cada membro de enumType
    /// </summary>
    /// <returns>IEnumerable of GroupedEnumMember</returns>
    public static IEnumerable<GroupedEnumMember> GetValuesWithCategory(this Type EnumType)
    {
        return GetEnumList(EnumType).Select(e => new GroupedEnumMember { Category = e.GetCategory(), Description = e.GetDescription(), Value = e }).ToList();
    }





    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<EnumMember> GetLocalizedValues<TEnum>()
    {
        return GetValues<TEnum>().Select(e => new EnumMember { Description = e.Value.GetLocalizedDescription(), Value = e.Value }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<EnumMember> GetLocalizedValues<TEnum>(Type resourceType)
    {
        return GetValues<TEnum>().Select(e => new EnumMember { Description = e.Value.GetLocalizedDescription(resourceType), Value = e.Value }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<EnumMember> GetLocalizedValues(Type enumType)
    {
        return GetValues(enumType).Select(e => new EnumMember { Description = e.Value.GetLocalizedDescription(), Value = e.Value }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<EnumMember> GetLocalizedValues(Type enumType, Type resourceType)
    {
        return GetValues(enumType).Select(e => new EnumMember { Description = e.Value.GetLocalizedDescription(resourceType), Value = e.Value }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<GroupedEnumMember> GetLocalizedValuesWithCategory<TEnum>()
    {
        return GetEnumList<TEnum>().Select(e => new GroupedEnumMember { Category = e.GetLocalizedCategory(), Description = e.GetLocalizedDescription(), Value = e }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<GroupedEnumMember> GetLocalizedValuesWithCategory(this Type EnumType)
    {
        return GetEnumList(EnumType).Select(e => new GroupedEnumMember { Category = e.GetLocalizedCategory(), Description = e.GetLocalizedDescription(), Value = e }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<GroupedEnumMember> GetLocalizedValuesWithCategory<TEnum>(Type resourceType)
    {
        return GetEnumList<TEnum>().Select(e => new GroupedEnumMember { Category = e.GetLocalizedCategory(resourceType), Description = e.GetLocalizedDescription(resourceType), Value = e }).ToList();
    }

    /// <summary>
    /// Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static IEnumerable<GroupedEnumMember> GetLocalizedValuesWithCategory(this Type EnumType, Type resourceType)
    {
        return GetEnumList(EnumType).Select(e => new GroupedEnumMember { Category = e.GetLocalizedCategory(resourceType), Description = e.GetLocalizedDescription(resourceType), Value = e }).ToList();
    }




    /// <summary>
    /// Retorna a descrição para o valor de Enum desejado
    /// </summary>
    /// <returns></returns>
    public static string GetDescription(this object value)
    {
        string result = value.ToString();
        var enumType = value.GetType();
            
        var att = enumType.GetMember(result)?.First().GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true).FirstOrDefault();
        if (att != null)
            result = ((System.ComponentModel.DescriptionAttribute)att).Description;
        else
        {
            att = enumType.GetField(value.ToString())?.GetCustomAttributes(typeof(EficazFramework.Attributes.DisplayNameAttribute), true).FirstOrDefault();
            if (att != null)
                result = ((EficazFramework.Attributes.DisplayNameAttribute)att).DisplayName;
        }
        return result;
    }

    /// <summary>
    /// Retorna a descrição para o valor de Enum desejado
    /// </summary>
    /// <returns></returns>
    public static string GetLocalizedDescription(this object value)
    {
        string result = value.ToString();
        Type resourceManager = default;
        var enumType = value.GetType();

        var att = enumType.GetMember(result)?.First().GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true).FirstOrDefault();
        if (att != null)
            result = ((System.ComponentModel.DescriptionAttribute)att).Description;
        else
        {
            att = enumType.GetField(value.ToString())?.GetCustomAttributes(typeof(EficazFramework.Attributes.DisplayNameAttribute), true).FirstOrDefault();
            if (att != null)
            {
                result = ((EficazFramework.Attributes.DisplayNameAttribute)att).DisplayName;
                resourceManager = ((EficazFramework.Attributes.DisplayNameAttribute)att).ResourceType;
            }
        }

        return result.Localize(resourceManager, null);
    }

    /// <summary>
    /// Retorna a descrição para o valor de Enum desejado
    /// </summary>
    /// <returns></returns>
    public static string GetLocalizedDescription(this object value, Type resourceType)
    {
        string result = value.ToString();
        var enumType = value.GetType();

        var att = enumType.GetMember(result)?.First().GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true).FirstOrDefault();
        if (att != null)
            result = ((System.ComponentModel.DescriptionAttribute)att).Description;
        else
        {
            att = enumType.GetField(value.ToString())?.GetCustomAttributes(typeof(EficazFramework.Attributes.DisplayNameAttribute), true).FirstOrDefault();
            if (att != null)
            {
                result = ((EficazFramework.Attributes.DisplayNameAttribute)att).DisplayName;
            }
        }

        return result.Localize(resourceType, null);
    }

    /// <summary>
    /// Retorna a Categoria para o valor de Enum desejado
    /// </summary>
    /// <returns></returns>
    public static string GetCategory(this object value)
    {
        string result = "";
        var enumType = value.GetType();

        var att = enumType.GetMember(value.ToString())?.First().GetCustomAttributes(typeof(CategoryAttribute), true).FirstOrDefault();
        if (att != null)
            result = ((CategoryAttribute)att).Category;

        return result;
    }

    /// <summary>
    /// Retorna a Categoria para o valor de Enum desejado
    /// </summary>
    /// <returns></returns>
    public static string GetLocalizedCategory(this object value)
    {
        return value.GetCategory().Localize();
    }

    /// <summary>
    /// Retorna a Categoria para o valor de Enum desejado
    /// </summary>
    /// <returns></returns>
    public static string GetLocalizedCategory(this object value, Type resourceType)
    {
        return value.GetCategory().Localize(resourceType, null);
    }

    /// <summary>
    /// Retorna a string para o valor bool especificado
    /// </summary>
    /// <returns>IEnumerable of EnumMember</returns>
    public static string GetBoolValue(this bool value, BoolDescriptionType boolText = BoolDescriptionType.YesNo)
    {
        return boolText switch
        {
            BoolDescriptionType.YesNo => value ? EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_True : EficazFramework.Resources.Strings.Descriptions.BoolToYesNo_False,
            _ => value ? EficazFramework.Resources.Strings.Descriptions.BoolToTrueFalse_True : EficazFramework.Resources.Strings.Descriptions.BoolToTrueFalse_False
        };
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
