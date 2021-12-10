#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## SessionManager Class

```csharp
public class SessionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SessionManager

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')

| Fields | |
| :--- | :--- |
| [SessionsIDs](SessionManager.SessionsIDs.md 'EficazFramework.Application.SessionManager.SessionsIDs') | Dicionário das seções ativas, útil para evitar ativação em duplicidade. |

| Properties | |
| :--- | :--- |
| [CurrentSession](SessionManager.CurrentSession.md 'EficazFramework.Application.SessionManager.CurrentSession') | Contém informações acerca da Seção Ativa. |
| [Instance](SessionManager.Instance.md 'EficazFramework.Application.SessionManager.Instance') | Instância singleton para uso com Binding e INotifyPropertyChanged. |
| [Sessions](SessionManager.Sessions.md 'EficazFramework.Application.SessionManager.Sessions') | Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho") |
