#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework_Application 'EficazFramework.Application')
## ScopedSessionManager Class
```csharp
public class ScopedSessionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ScopedSessionManager  

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')  

| Fields | |
| :--- | :--- |
| [SessionsIDs](ScopedSessionManager_SessionsIDs.md 'EficazFramework.Application.ScopedSessionManager.SessionsIDs') | Dicionário das seções ativas, útil para evitar ativação em duplicidade.<br/> |

| Properties | |
| :--- | :--- |
| [ApplicationManager](ScopedSessionManager_ApplicationManager.md 'EficazFramework.Application.ScopedSessionManager.ApplicationManager') | Armazena e gerencia informações sobre aplicativos neste scopo de seções.<br/> |
| [CurrentSession](ScopedSessionManager_CurrentSession.md 'EficazFramework.Application.ScopedSessionManager.CurrentSession') | Contém informações acerca da Seção Ativa.<br/> |
| [Sessions](ScopedSessionManager_Sessions.md 'EficazFramework.Application.ScopedSessionManager.Sessions') | Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")<br/> |
