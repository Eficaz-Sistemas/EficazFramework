#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework_Application 'EficazFramework.Application').[ApplicationManager](ApplicationManager.md 'EficazFramework.Application.ApplicationManager')
## ApplicationManager.Activate(ApplicationDefinition, ScopedApplicationManager) Method
Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.  
```csharp
public static void Activate(this EficazFramework.Application.ApplicationDefinition application, EficazFramework.Application.ScopedApplicationManager scope=null);
```
#### Parameters
<a name='EficazFramework_Application_ApplicationManager_Activate(EficazFramework_Application_ApplicationDefinition_EficazFramework_Application_ScopedApplicationManager)_application'></a>
`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')  
Manifesto de aplicativo a ser iniciado ou ativado.
  
<a name='EficazFramework_Application_ApplicationManager_Activate(EficazFramework_Application_ApplicationDefinition_EficazFramework_Application_ScopedApplicationManager)_scope'></a>
`scope` [ScopedApplicationManager](ScopedApplicationManager.md 'EficazFramework.Application.ScopedApplicationManager')  
(Opcional) Instância de ApplicationManager em escopo, caso não esteja utilizando em Singleton.
  
