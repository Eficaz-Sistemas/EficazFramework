using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Tests;

internal class TestContext
{
    internal static System.Windows.Application? Application { get; }
    internal static System.Windows.Window MainWindow { get; }

    static TestContext()
    {
        //AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
        //{
        //    if (e.Name.Contains("EficazFramework") || e.Name.Contains("MaterialDesign"))
        //        return System.Reflection.Assembly.Load(@$"{Environment.CurrentDirectory}\{e.Name.Split(',')[0]}.dll");

        //    return null;
        //};
        Application =  new EficazFramework.Tests.WPF.App();
        Application.Run();
        //AppDomain.CurrentDomain.Load(System.Reflection.AssemblyName.GetAssemblyName(@$"{Environment.CurrentDirectory}\EficazFramework.WPF.dll"));
        //AppDomain.CurrentDomain.Load(System.Reflection.AssemblyName.GetAssemblyName(@$"{Environment.CurrentDirectory}\MaterialDesignThemes.Wpf.dll"));
        //AppDomain.CurrentDomain.Load(System.Reflection.AssemblyName.GetAssemblyName(@$"{Environment.CurrentDirectory}\MaterialDesignColors.dll"));

        //var dictbase = new System.Windows.ResourceDictionary();
        //dictbase.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
        //{
        //    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml")
        //});
        //dictbase.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
        //{
        //    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.DataGrid.xaml")
        //});
        //dictbase.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
        //{
        //    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml")
        //});
        //dictbase.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
        //{
        //    Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ProgressBar.xaml")
        //});
        //dictbase.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
        //{
        //    Source = new Uri("pack://application:,,,/EficazFrameworkCore.WPF;component/Themes/Generic.xaml")
        //});
        //dictbase.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
        //{
        //    Source = new Uri("pack://application:,,,/EficazFrameworkCore.WPF;component/Themes/MaterialDesign.xaml")
        //});
        //Application.Resources = dictbase;
        MainWindow = new();

    }

}
