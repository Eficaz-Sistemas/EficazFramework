#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application').[IApplicationManager](EficazFramework.Application/IApplicationManager.md 'EficazFramework.Application.IApplicationManager')

## IApplicationManager.Activate(ApplicationDefinition) Method

Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.

```csharp
EficazFramework.Application.ApplicationInstance Activate(EficazFramework.Application.ApplicationDefinition application);
```
#### Parameters

<a name='EficazFramework.Application.IApplicationManager.Activate(EficazFramework.Application.ApplicationDefinition).application'></a>

`application` [ApplicationDefinition](EficazFramework.Application/ApplicationDefinition.md 'EficazFramework.Application.ApplicationDefinition')

Manifesto de aplicativo a ser iniciado ou ativado.

#### Returns
[ApplicationInstance](EficazFramework.Application/ApplicationInstance.md 'EficazFramework.Application.ApplicationInstance')