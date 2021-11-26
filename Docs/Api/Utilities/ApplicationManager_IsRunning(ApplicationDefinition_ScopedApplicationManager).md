#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework_Application 'EficazFramework.Application').[ApplicationManager](ApplicationManager.md 'EficazFramework.Application.ApplicationManager')
## ApplicationManager.IsRunning(ApplicationDefinition, ScopedApplicationManager) Method
Retorna se um aplicativo está em execução atualmente.  
```csharp
public static bool IsRunning(this EficazFramework.Application.ApplicationDefinition application, EficazFramework.Application.ScopedApplicationManager scope=null);
```
#### Parameters
<a name='EficazFramework_Application_ApplicationManager_IsRunning(EficazFramework_Application_ApplicationDefinition_EficazFramework_Application_ScopedApplicationManager)_application'></a>
`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')  
Instância de aplicativo a ser verificado.
  
<a name='EficazFramework_Application_ApplicationManager_IsRunning(EficazFramework_Application_ApplicationDefinition_EficazFramework_Application_ScopedApplicationManager)_scope'></a>
`scope` [ScopedApplicationManager](ScopedApplicationManager.md 'EficazFramework.Application.ScopedApplicationManager')  
(Opcional) Instância de ApplicationManager em escopo, caso não esteja utilizando em Singleton.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
