#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application').[ApplicationManager](ApplicationManager.md 'EficazFramework.Application.ApplicationManager')

## ApplicationManager.Activate(this ApplicationDefinition, ScopedApplicationManager) Method

Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.

```csharp
public static void Activate(this EficazFramework.Application.ApplicationDefinition application, EficazFramework.Application.ScopedApplicationManager scope=null);
```
#### Parameters

<a name='EficazFramework.Application.ApplicationManager.Activate(thisEficazFramework.Application.ApplicationDefinition,EficazFramework.Application.ScopedApplicationManager).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Manifesto de aplicativo a ser iniciado ou ativado.

<a name='EficazFramework.Application.ApplicationManager.Activate(thisEficazFramework.Application.ApplicationDefinition,EficazFramework.Application.ScopedApplicationManager).scope'></a>

`scope` [ScopedApplicationManager](ScopedApplicationManager.md 'EficazFramework.Application.ScopedApplicationManager')

(Opcional) Instância de ApplicationManager em escopo, caso não esteja utilizando em Singleton.