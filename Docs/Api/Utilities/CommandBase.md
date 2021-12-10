#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Commands](EficazFrameworkUtilities.md#EficazFramework.Commands 'EficazFramework.Commands')

## CommandBase Class

```csharp
public class CommandBase :
System.Windows.Input.ICommand
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CommandBase

Implements [System.Windows.Input.ICommand](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Input.ICommand 'System.Windows.Input.ICommand')

| Properties | |
| :--- | :--- |
| [Action](CommandBase.Action.md 'EficazFramework.Commands.CommandBase.Action') | A Ação que deve ser invocada pelo método .Execute() |
| [IsEnabled](CommandBase.IsEnabled.md 'EficazFramework.Commands.CommandBase.IsEnabled') | Obtém ou define se o comando está ativo para que sua Ação seja invocada. |

| Methods | |
| :--- | :--- |
| [CanExecute(object)](CommandBase.CanExecute(object).md 'EficazFramework.Commands.CommandBase.CanExecute(object)') | Retorna se o comando está ativo para que sua Ação seja invocada (IsEnabled).<br/>Implementa ICommand.CanExecute. |
| [Execute(object)](CommandBase.Execute(object).md 'EficazFramework.Commands.CommandBase.Execute(object)') | Executa a Action vinculada na instância.<br/>Implementa ICommand.Execute. |
