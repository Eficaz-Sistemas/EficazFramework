#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## ApplicationManager Class

```csharp
internal class ApplicationManager :
EficazFramework.Application.IApplicationManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApplicationManager

Implements [IApplicationManager](EficazFramework.Application/IApplicationManager.md 'EficazFramework.Application.IApplicationManager')

| Fields | |
| :--- | :--- |
| [_instance](EficazFramework.Application/ApplicationManager/_instance.md 'EficazFramework.Application.ApplicationManager._instance') | |
| [_sectionManager](EficazFramework.Application/ApplicationManager/_sectionManager.md 'EficazFramework.Application.ApplicationManager._sectionManager') | |

| Properties | |
| :--- | :--- |
| [AllApplications](EficazFramework.Application/ApplicationManager/AllApplications.md 'EficazFramework.Application.ApplicationManager.AllApplications') | Listagem de aplicações disponíveis para trabalho (pode ser utilizada como menu principal) |
| [Instance](EficazFramework.Application/ApplicationManager/Instance.md 'EficazFramework.Application.ApplicationManager.Instance') | Retorna em padrão singleton a Última Instância de ApplicationManager instanciada. |
| [RunningApplications](EficazFramework.Application/ApplicationManager/RunningApplications.md 'EficazFramework.Application.ApplicationManager.RunningApplications') | Cache de aplicativos em execução |
| [SectionManager](EficazFramework.Application/ApplicationManager/SectionManager.md 'EficazFramework.Application.ApplicationManager.SectionManager') | Instância de SectionManager para gestão de múltiplas área de trabalho. |

| Methods | |
| :--- | :--- |
| [Activate(ApplicationDefinition)](EficazFramework.Application/ApplicationManager/Activate(ApplicationDefinition).md 'EficazFramework.Application.ApplicationManager.Activate(EficazFramework.Application.ApplicationDefinition)') | Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada. |
| [AppClosed(object, EventArgs)](EficazFramework.Application/ApplicationManager/AppClosed(object,EventArgs).md 'EficazFramework.Application.ApplicationManager.AppClosed(object, System.EventArgs)') | |
| [IsRunning(ApplicationDefinition)](EficazFramework.Application/ApplicationManager/IsRunning(ApplicationDefinition).md 'EficazFramework.Application.ApplicationManager.IsRunning(EficazFramework.Application.ApplicationDefinition)') | Retorna se um aplicativo está em execução atualmente. |

| Events | |
| :--- | :--- |
| [ActiveAppChanged](EficazFramework.Application/ApplicationManager/ActiveAppChanged.md 'EficazFramework.Application.ApplicationManager.ActiveAppChanged') | |
