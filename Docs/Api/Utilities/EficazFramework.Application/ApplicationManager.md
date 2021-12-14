#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Application](EficazFrameworkData.md#EficazFramework.Application 'EficazFramework.Application')

## ApplicationManager Class

```csharp
public static class ApplicationManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApplicationManager
### Properties

<a name='EficazFramework.Application.ApplicationManager.AllAplications'></a>

## ApplicationManager.AllAplications Property

Listagem de aplicações disponíveis para trabalho (pode ser utilizada como menu principal)

```csharp
public static System.Collections.ObjectModel.ObservableCollection<EficazFramework.Application.ApplicationDefinition> AllAplications { get; }
```

#### Property Value
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')

<a name='EficazFramework.Application.ApplicationManager.RunningAplications'></a>

## ApplicationManager.RunningAplications Property

Cache de aplicativos em execução

```csharp
public static System.Collections.ObjectModel.ObservableCollection<EficazFramework.Application.ApplicationInstance> RunningAplications { get; }
```

#### Property Value
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[EficazFramework.Application.ApplicationInstance](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationInstance 'EficazFramework.Application.ApplicationInstance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')
### Methods

<a name='EficazFramework.Application.ApplicationManager.Activate(thisEficazFramework.Application.ApplicationDefinition,EficazFramework.Application.ScopedApplicationManager)'></a>

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

`scope` [ScopedApplicationManager](EficazFramework.Application/ScopedApplicationManager.md 'EficazFramework.Application.ScopedApplicationManager')

(Opcional) Instância de ApplicationManager em escopo, caso não esteja utilizando em Singleton.

<a name='EficazFramework.Application.ApplicationManager.IsRunning(thisEficazFramework.Application.ApplicationDefinition,EficazFramework.Application.ScopedApplicationManager)'></a>

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