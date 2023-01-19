using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace EficazFramework.Commands;
public class CommandBase : ICommand
{
    public CommandBase([NotNull] Events.ExecuteEventHandler execute)
    {
        Action = execute;
    }

    /// <summary>
    /// A Ação que deve ser invocada pelo método .Execute()
    /// </summary>
    public Events.ExecuteEventHandler? Action { get; }

    private bool _canexecute = true;
    /// <summary>
    /// Obtém ou define se o comando está ativo para que sua Ação seja invocada.
    /// </summary>
    public bool IsEnabled
    {
        get => _canexecute;
        set
        {
            _canexecute = value;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Retorna se o comando está ativo para que sua Ação seja invocada (IsEnabled).
    /// Implementa ICommand.CanExecute.
    /// </summary>
    /// <returns></returns>
    public bool CanExecute(object? parameter) =>
        IsEnabled;

    /// <summary>
    /// Executa a Action vinculada na instância.
    /// Implementa ICommand.Execute.
    /// </summary>
    public void Execute(object? parameter)
    {
        if (IsEnabled && Action != null)
            Action.Invoke(Action.Target ?? this, new EficazFramework.Events.ExecuteEventArgs(parameter));
    }

    public event EventHandler? CanExecuteChanged;
}
