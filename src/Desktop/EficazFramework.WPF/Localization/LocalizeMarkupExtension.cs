using EficazFramework.Extensions;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace EficazFramework.Localization;

public class LocalizeText : MarkupExtension
{

    public LocalizeText(string key) : base()
    {
        if (string.IsNullOrEmpty(key)) throw new NullReferenceException("key argument cannot be null");
        Key = key;
    }

    [ConstructorArgument("key")]
    public string Key { get; set; } = null;
    public string DictionaryName { get; set; } = null;
    public string Assembly { get; set; } = null;
    public string StringFormat { get; set; } = null;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        string internal_dictionary = DictionaryName;
        string internal_assembly = Assembly;

        try
        {
            if (serviceProvider.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget target && target.TargetProperty is DependencyProperty)
            {
                if (string.IsNullOrEmpty(internal_assembly)) internal_assembly = ResourceManager.GetAssembly((DependencyObject)target.TargetObject);
                if (string.IsNullOrEmpty(internal_dictionary)) internal_dictionary = ResourceManager.GetDictionaryName((DependencyObject)target.TargetObject);
            }
        }
        catch { }
        return Key.Localize(internal_dictionary, internal_assembly, StringFormat);
    }
}
