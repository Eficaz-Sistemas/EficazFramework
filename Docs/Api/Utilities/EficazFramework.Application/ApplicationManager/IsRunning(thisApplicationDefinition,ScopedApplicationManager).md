#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Application](EficazFrameworkData.md#EficazFramework.Application 'EficazFramework.Application').[ApplicationManager](EficazFramework.Application/ApplicationManager.md 'EficazFramework.Application.ApplicationManager')

## ApplicationManager.IsRunning(this ApplicationDefinition, ScopedApplicationManager) Method

Retorna se um aplicativo está em execução atualmente.

```csharp
public static bool IsRunning(this EficazFramework.Application.ApplicationDefinition application, EficazFramework.Application.ScopedApplicationManager scope=null);
```
#### Parameters

<a name='EficazFramework.Application.ApplicationManager.IsRunning(thisEficazFramework.Application.ApplicationDefinition,EficazFramework.Application.ScopedApplicationManager).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Instância de aplicativo a ser verificado.

<a name='EficazFramework.Application.ApplicationManager.IsRunning(thisEficazFramework.Application.ApplicationDefinition,EficazFramework.Application.ScopedApplicationManager).scope'></a>

`scope` [ScopedApplicationManager](EficazFramework.Application/ScopedApplicationManager.md 'EficazFramework.Application.ScopedApplicationManager')

(Opcional) Instância de ApplicationManager em escopo, caso não esteja utilizando em Singleton.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')