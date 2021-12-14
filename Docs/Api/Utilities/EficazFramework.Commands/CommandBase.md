#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Commands](EficazFrameworkUtilities.md#EficazFramework.Commands 'EficazFramework.Commands')

## CommandBase Class

```csharp
public class CommandBase :
System.Windows.Input.ICommand
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CommandBase

Implements [System.Windows.Input.ICommand](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Input.ICommand 'System.Windows.Input.ICommand')
### Properties

<a name='EficazFramework.Commands.CommandBase.Action'></a>

## CommandBase.Action Property

A Ação que deve ser invocada pelo método .Execute()

```csharp
public EficazFramework.Events.ExecuteEventHandler Action { get; }
```

#### Property Value
[EficazFramework.Events.ExecuteEventHandler](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventHandler 'EficazFramework.Events.ExecuteEventHandler')

<a name='EficazFramework.Commands.CommandBase.IsEnabled'></a>

## CommandBase.IsEnabled Property

Obtém ou define se o comando está ativo para que sua Ação seja invocada.

```csharp
public bool IsEnabled { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='EficazFramework.Commands.CommandBase.CanExecute(object)'></a>

## CommandBase.CanExecute(object) Method

Retorna se o comando está ativo para que sua Ação seja invocada (IsEnabled).  
Implementa ICommand.CanExecute.

```csharp
public bool CanExecute(object parameter);
```
#### Parameters

<a name='EficazFramework.Commands.CommandBase.CanExecute(object).parameter'></a>

`parameter` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Implements [CanExecute(object)](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Input.ICommand.CanExecute#System_Windows_Input_ICommand_CanExecute_System_Object_ 'System.Windows.Input.ICommand.CanExecute(System.Object)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Commands.CommandBase.Execute(object)'></a>

## CommandBase.Execute(object) Method

Executa a Action vinculada na instância.  
Implementa ICommand.Execute.

```csharp
public void Execute(object parameter);
```
#### Parameters

<a name='EficazFramework.Commands.CommandBase.Execute(object).parameter'></a>

`parameter` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Implements [Execute(object)](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Input.ICommand.Execute#System_Windows_Input_ICommand_Execute_System_Object_ 'System.Windows.Input.ICommand.Execute(System.Object)')