#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## IApplicationManager Interface

```csharp
public interface IApplicationManager
```

Derived  
&#8627; [ApplicationManager](EficazFramework.Application/ApplicationManager.md 'EficazFramework.Application.ApplicationManager')

| Properties | |
| :--- | :--- |
| [AllApplications](EficazFramework.Application/IApplicationManager/AllApplications.md 'EficazFramework.Application.IApplicationManager.AllApplications') | Listagem de aplicações disponíveis para trabalho (pode ser utilizada como menu principal) |
| [Instance](EficazFramework.Application/IApplicationManager/Instance.md 'EficazFramework.Application.IApplicationManager.Instance') | Retorna em padrão singleton a Última Instância de ApplicationManager instanciada. |
| [RunningApplications](EficazFramework.Application/IApplicationManager/RunningApplications.md 'EficazFramework.Application.IApplicationManager.RunningApplications') | Cache de aplicativos em execução |
| [SectionManager](EficazFramework.Application/IApplicationManager/SectionManager.md 'EficazFramework.Application.IApplicationManager.SectionManager') | Instância de SectionManager para gestão de múltiplas área de trabalho. |

| Methods | |
| :--- | :--- |
| [Activate(ApplicationDefinition)](EficazFramework.Application/IApplicationManager/Activate(ApplicationDefinition).md 'EficazFramework.Application.IApplicationManager.Activate(EficazFramework.Application.ApplicationDefinition)') | Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada. |
| [Create()](EficazFramework.Application/IApplicationManager/Create().md 'EficazFramework.Application.IApplicationManager.Create()') | Inicia e retorna uma nova instância de ApplicationManager. |
| [IsRunning(ApplicationDefinition)](EficazFramework.Application/IApplicationManager/IsRunning(ApplicationDefinition).md 'EficazFramework.Application.IApplicationManager.IsRunning(EficazFramework.Application.ApplicationDefinition)') | Retorna se um aplicativo está em execução atualmente. |

| Events | |
| :--- | :--- |
| [ActiveAppChanged](EficazFramework.Application/IApplicationManager/ActiveAppChanged.md 'EficazFramework.Application.IApplicationManager.ActiveAppChanged') | |
