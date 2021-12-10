#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Application](EficazFrameworkData.md#EficazFramework.Application 'EficazFramework.Application')

## SessionManager Class

```csharp
public class SessionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SessionManager

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')

| Fields | |
| :--- | :--- |
| [SessionsIDs](EficazFramework.Application/SessionManager/SessionsIDs.md 'EficazFramework.Application.SessionManager.SessionsIDs') | Dicionário das seções ativas, útil para evitar ativação em duplicidade. |

| Properties | |
| :--- | :--- |
| [CurrentSession](EficazFramework.Application/SessionManager/CurrentSession.md 'EficazFramework.Application.SessionManager.CurrentSession') | Contém informações acerca da Seção Ativa. |
| [Instance](EficazFramework.Application/SessionManager/Instance.md 'EficazFramework.Application.SessionManager.Instance') | Instância singleton para uso com Binding e INotifyPropertyChanged. |
| [Sessions](EficazFramework.Application/SessionManager/Sessions.md 'EficazFramework.Application.SessionManager.Sessions') | Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho") |
