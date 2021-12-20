#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## ApplicationExtensions Class

```csharp
public static class ApplicationExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApplicationExtensions
### Methods

<a name='EficazFramework.Application.ApplicationExtensions.Activate(thisEficazFramework.Application.ApplicationDefinition)'></a>

## ApplicationExtensions.Activate(this ApplicationDefinition) Method

Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.

```csharp
public static void Activate(this EficazFramework.Application.ApplicationDefinition application);
```
#### Parameters

<a name='EficazFramework.Application.ApplicationExtensions.Activate(thisEficazFramework.Application.ApplicationDefinition).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Manifesto de aplicativo a ser iniciado ou ativado.

<a name='EficazFramework.Application.ApplicationExtensions.IsRunning(thisEficazFramework.Application.ApplicationDefinition)'></a>

## ApplicationExtensions.IsRunning(this ApplicationDefinition) Method

Retorna se um aplicativo está em execução atualmente.

```csharp
public static bool IsRunning(this EficazFramework.Application.ApplicationDefinition application);
```
#### Parameters

<a name='EficazFramework.Application.ApplicationExtensions.IsRunning(thisEficazFramework.Application.ApplicationDefinition).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Instância de aplicativo a ser verificado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')