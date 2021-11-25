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

    public static ICommand ShutDown { get; private set; } = new EficazFramework.Commands.CommandBase(ShutDown_Execute);
    private static void ShutDown_Execute(object sender, Events.ExecuteEventArgs e)
    {
        System.Windows.Application.Current.Shutdown();
    }

    public static ICommand ShutDown_MaterialWindow { get; private set; } = new EficazFramework.Commands.CommandBase(ShutDown_MaterialWindow_Execute);
    private static void ShutDown_MaterialWindow_Execute(object sender, Events.ExecuteEventArgs e)
    {
        System.Windows.Window win = XAML.Utilities.VisualTreeHelpers.FindAnchestor<System.Windows.Window>((DependencyObject)e.Parameter);
        Application.ApplicationEvents.RequestShutDown_Material(win);
    }




}
