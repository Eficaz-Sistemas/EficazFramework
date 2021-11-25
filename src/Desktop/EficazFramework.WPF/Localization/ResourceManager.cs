using System.Net;
using System.Windows;

namespace EficazFramework.Localization;

public class ResourceManager
{

    #region Dictionary Name

    public static string GetDictionaryName(DependencyObject obj)
    {
        return (string)obj.GetValue(DictionaryNameProperty);
    }

    public static void SetDictionaryName(DependencyObject obj, string value)
    {
        obj.SetValue(DictionaryNameProperty, value);
    }

    public static readonly DependencyProperty DictionaryNameProperty =
        DependencyProperty.RegisterAttached("DictionaryName", typeof(string), typeof(ResourceManager), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

    #endregion

    #region Assembly

    public static string GetAssembly(DependencyObject obj)
    {
        return (string)obj.GetValue(AssemblyProperty);
    }

    public static void SetAssembly(DependencyObject obj, string value)
    {
        obj.SetValue(AssemblyProperty, value);
    }

    public static readonly DependencyProperty AssemblyProperty =
        DependencyProperty.RegisterAttached("Assembly", typeof(string), typeof(ResourceManager), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

    #endregion



}
