#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework_Application 'EficazFramework.Application')
## SessionManager Class
```csharp
public class SessionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SessionManager  

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')  

| Fields | |
| :--- | :--- |
| [SessionsIDs](SessionManager_SessionsIDs.md 'EficazFramework.Application.SessionManager.SessionsIDs') | Dicionário das seções ativas, útil para evitar ativação em duplicidade.<br/> |

| Properties | |
| :--- | :--- |
| [CurrentSession](SessionManager_CurrentSession.md 'EficazFramework.Application.SessionManager.CurrentSession') | Contém informações acerca da Seção Ativa.<br/> |
| [Instance](SessionManager_Instance.md 'EficazFramework.Application.SessionManager.Instance') | Instância singleton para uso com Binding e INotifyPropertyChanged.<br/> |
| [Sessions](SessionManager_Sessions.md 'EficazFramework.Application.SessionManager.Sessions') | Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")<br/> |
