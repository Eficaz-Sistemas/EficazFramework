using System;
using System.Windows.Input;

namespace EficazFramework.Commands;
public class CommandBase : ICommand
{
    public CommandBase(Events.ExecuteEventHandler execute)
    {
        Action = execute;
    }

    public Events.ExecuteEventHandler Action { get; } = null;

    private bool _canexecute = true;
    public bool IsEnabled
    {
        get
        {
            return _canexecute;
        }

        set
        {
            _canexecute = value;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool CanExecute(object parameter)
    {
        return IsEnabled;
    }

    public void Execute(object parameter)
    {
        if (IsEnabled && Action != null)
        {
            Action.Invoke(Action.Target, new EficazFramework.Events.ExecuteEventArgs(parameter));
        }
    }

    public event EventHandler CanExecuteChanged;
}
