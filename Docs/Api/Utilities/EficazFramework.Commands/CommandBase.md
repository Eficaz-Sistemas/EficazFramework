#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Commands](EficazFrameworkUtilities.md#EficazFramework.Commands 'EficazFramework.Commands')

## CommandBase Class

```csharp
public class CommandBase :
System.Windows.Input.ICommand
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CommandBase

Implements [System.Windows.Input.ICommand](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Input.ICommand 'System.Windows.Input.ICommand')

| Constructors | |
| :--- | :--- |
| [CommandBase(ExecuteEventHandler)](EficazFramework.Commands/CommandBase/CommandBase(ExecuteEventHandler).md 'EficazFramework.Commands.CommandBase.CommandBase(EficazFramework.Events.ExecuteEventHandler)') | |

| Fields | |
| :--- | :--- |
| [_canexecute](EficazFramework.Commands/CommandBase/_canexecute.md 'EficazFramework.Commands.CommandBase._canexecute') | |

| Properties | |
| :--- | :--- |
| [Action](EficazFramework.Commands/CommandBase/Action.md 'EficazFramework.Commands.CommandBase.Action') | A Ação que deve ser invocada pelo método .Execute() |
| [IsEnabled](EficazFramework.Commands/CommandBase/IsEnabled.md 'EficazFramework.Commands.CommandBase.IsEnabled') | Obtém ou define se o comando está ativo para que sua Ação seja invocada. |

| Methods | |
| :--- | :--- |
| [CanExecute(object)](EficazFramework.Commands/CommandBase/CanExecute(object).md 'EficazFramework.Commands.CommandBase.CanExecute(object)') | Retorna se o comando está ativo para que sua Ação seja invocada (IsEnabled).<br/>Implementa ICommand.CanExecute. |
| [Execute(object)](EficazFramework.Commands/CommandBase/Execute(object).md 'EficazFramework.Commands.CommandBase.Execute(object)') | Executa a Action vinculada na instância.<br/>Implementa ICommand.Execute. |

| Events | |
| :--- | :--- |
| [CanExecuteChanged](EficazFramework.Commands/CommandBase/CanExecuteChanged.md 'EficazFramework.Commands.CommandBase.CanExecuteChanged') | |
