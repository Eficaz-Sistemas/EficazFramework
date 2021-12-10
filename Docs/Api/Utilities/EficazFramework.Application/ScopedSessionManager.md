#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Application](EficazFrameworkData.md#EficazFramework.Application 'EficazFramework.Application')

## ScopedSessionManager Class

```csharp
public class ScopedSessionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ScopedSessionManager

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')

| Fields | |
| :--- | :--- |
| [SessionsIDs](EficazFramework.Application/ScopedSessionManager/SessionsIDs.md 'EficazFramework.Application.ScopedSessionManager.SessionsIDs') | Dicionário das seções ativas, útil para evitar ativação em duplicidade. |

| Properties | |
| :--- | :--- |
| [ApplicationManager](EficazFramework.Application/ScopedSessionManager/ApplicationManager.md 'EficazFramework.Application.ScopedSessionManager.ApplicationManager') | Armazena e gerencia informações sobre aplicativos neste scopo de seções. |
| [CurrentSession](EficazFramework.Application/ScopedSessionManager/CurrentSession.md 'EficazFramework.Application.ScopedSessionManager.CurrentSession') | Contém informações acerca da Seção Ativa. |
| [Sessions](EficazFramework.Application/ScopedSessionManager/Sessions.md 'EficazFramework.Application.ScopedSessionManager.Sessions') | Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho") |
