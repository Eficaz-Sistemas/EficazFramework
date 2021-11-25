using System.Windows;

namespace EficazFramework.Events;

public sealed partial class WindowStateChangedEventArgs : RoutedEventArgs
{
    public WindowState OldValue { get; private set; }

    public WindowState NewValue { get; private set; }

    public WindowStateChangedEventArgs(RoutedEvent routedEvent, WindowState oldValue, WindowState newValue) : base(routedEvent)
    {
        NewValue = newValue;
        OldValue = oldValue;
    }
}

// Code-Base from Hammer UI KIT
// http://andrassebo.blogspot.com.br/p/hammer.html