using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

    private void Button_Click(object sender, RoutedEventArgs e)
    {
    }
    private void animationck_Checked(object sender, RoutedEventArgs e)
    {
        EficazFramework.Configuration.Visual.Effects = ((CheckBox)sender).IsChecked ?? true;
    }
}
