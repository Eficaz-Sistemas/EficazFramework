using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Input;

namespace EficazFramework.Commands;

public class Window
{


    public static ICommand Minimize { get; private set; } = new EficazFramework.Commands.CommandBase(Minimize_Execute);
    private static void Minimize_Execute(object sender, Events.ExecuteEventArgs e)
    {
        System.Windows.Window win = XAML.Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Window>((DependencyObject)e.Parameter);
        win.WindowState = System.Windows.WindowState.Minimized;
    }

    public static ICommand Maximize { get; private set; } = new EficazFramework.Commands.CommandBase(Maximize_Execute);
    private static void Maximize_Execute(object sender, Events.ExecuteEventArgs e)
    {
        System.Windows.Window win = XAML.Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Window>((DependencyObject)e.Parameter);
        win.WindowState = System.Windows.WindowState.Maximized;
    }

    public static ICommand Restore { get; private set; } = new EficazFramework.Commands.CommandBase(Restore_Execute);
    private static void Restore_Execute(object sender, Events.ExecuteEventArgs e)
    {
        System.Windows.Window win = XAML.Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Window>((DependencyObject)e.Parameter);
        win.WindowState = System.Windows.WindowState.Normal;
    }

    [ExcludeFromCodeCoverage]
    public static ICommand ShutDown { get; private set; } = new EficazFramework.Commands.CommandBase(ShutDown_Execute);
    [ExcludeFromCodeCoverage]
    private static void ShutDown_Execute(object sender, Events.ExecuteEventArgs e)
    {
        System.Windows.Application.Current.Shutdown();
    }

}
