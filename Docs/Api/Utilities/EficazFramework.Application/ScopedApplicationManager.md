#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Application](EficazFrameworkData.md#EficazFramework.Application 'EficazFramework.Application')

## ScopedApplicationManager Class

```csharp
public class ScopedApplicationManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ScopedApplicationManager
### Properties

<a name='EficazFramework.Application.ScopedApplicationManager.AllAplications'></a>

## ScopedApplicationManager.AllAplications Property

Listagem de aplicações disponíveis para trabalho (pode ser utilizada como menu principal)

```csharp
public System.Collections.ObjectModel.ObservableCollection<EficazFramework.Application.ApplicationDefinition> AllAplications { get; }
```

#### Property Value
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')

<a name='EficazFramework.Application.ScopedApplicationManager.RunningAplications'></a>

## ScopedApplicationManager.RunningAplications Property

Cache de aplicativos em execução

```csharp
public System.Collections.ObjectModel.ObservableCollection<EficazFramework.Application.ApplicationInstance> RunningAplications { get; }
```

#### Property Value
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[EficazFramework.Application.ApplicationInstance](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationInstance 'EficazFramework.Application.ApplicationInstance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')
### Methods

<a name='EficazFramework.Application.ScopedApplicationManager.Activate(EficazFramework.Application.ApplicationDefinition)'></a>

## ScopedApplicationManager.Activate(ApplicationDefinition) Method

Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.

```csharp
public void Activate(EficazFramework.Application.ApplicationDefinition application);
```
#### Parameters

<a name='EficazFramework.Application.ScopedApplicationManager.Activate(EficazFramework.Application.ApplicationDefinition).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Manifesto de aplicativo a ser iniciado ou ativado.

<a name='EficazFramework.Application.ScopedApplicationManager.IsRunning(EficazFramework.Application.ApplicationDefinition)'></a>

## ScopedApplicationManager.IsRunning(ApplicationDefinition) Method

Retorna se um aplicativo está em execução atualmente.

```csharp
public bool IsRunning(EficazFramework.Application.ApplicationDefinition application);
```
#### Parameters

<a name='EficazFramework.Application.ScopedApplicationManager.IsRunning(EficazFramework.Application.ApplicationDefinition).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Instância de aplicativo a ser verificado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')