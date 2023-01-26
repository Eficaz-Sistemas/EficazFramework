using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EficazFramework.Tests.WPF.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e) =>
        maintab.SelectedIndex = 1;

    #region "Global"
    public static IEnumerable<Extensions.EnumMember>? Colors => EficazFramework.Extensions.Enums.GetLocalizedValues<EficazFramework.Controls.AttachedProperties.Color>();

    public static IEnumerable<Extensions.EnumMember>? TabsOrientation => EficazFramework.Extensions.Enums.GetLocalizedValues<System.Windows.Controls.Dock>();

    #endregion


    #region WindowCommands

    private void ShutdownCmd_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        SystemCommands.CloseWindow(this);
        System.Windows.Application.Current.Shutdown();
    }

    private void FullScreenCmd_Executed(object sender, ExecutedRoutedEventArgs e) =>
        SystemCommands.MaximizeWindow(this);

    private void RestoreCmd_Executed(object sender, ExecutedRoutedEventArgs e) =>
        SystemCommands.RestoreWindow(this);

    private void MininizeCms_Executed(object sender, ExecutedRoutedEventArgs e) =>
        SystemCommands.MinimizeWindow(this);

    #endregion


    #region Configurations

    private void Animationck_Checked(object sender, RoutedEventArgs e)
    {
        EficazFramework.Configuration.Visual.Effects = ((CheckBox)sender).IsChecked ?? true;
    }

    #endregion


    #region Inputs

    readonly string[] itemsToFind = { "Audi", "Aston Martin", "BMW", "Ferrari", "Mercedes", "Porsche", "Volkswagen" };
    private void Autocomplete_Find(object sender, Events.FindRequestEventArgs e)
    {
        e.Data = itemsToFind.Where(x => x.Contains(e.Literal, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }

    #endregion


    #region DataGrid

    private void NomeCl_CheckChanged(object sender, RoutedEventArgs e)
    {
        EficazFramework.Controls.AttachedProperties.DataGrid.SetShowFilter(nomeCl, (((CheckBox)sender).IsChecked ?? true));
        var value = EficazFramework.Controls.AttachedProperties.DataGrid.GetShowFilter(nomeCl);
        //dgMain.Columns[0].Visibility = Visibility.Collapsed;
        //dgMain.Dispatcher.Invoke(() => dgMain.Columns[0].Visibility = Visibility.Visible);
        //dgMain.ApplyTemplate();
    }

    private void UfCl_CheckChanged(object sender, RoutedEventArgs e)
    {
        EficazFramework.Controls.AttachedProperties.DataGrid.SetShowFilter(nomeCl, (((CheckBox)sender).IsChecked ?? true));
        dgMain.InvalidateVisual();
    }

    #endregion

}
