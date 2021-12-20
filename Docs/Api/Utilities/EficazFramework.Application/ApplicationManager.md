#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## ApplicationManager Class

```csharp
public class ApplicationManager
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ApplicationManager
### Properties

<a name='EficazFramework.Application.ApplicationManager.AllAplications'></a>

## ApplicationManager.AllAplications Property

Listagem de aplicações disponíveis para trabalho (pode ser utilizada como menu principal)

```csharp
public System.Collections.ObjectModel.ObservableCollection<EficazFramework.Application.ApplicationDefinition> AllAplications { get; }
```

#### Property Value
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')

<a name='EficazFramework.Application.ApplicationManager.Instance'></a>

## ApplicationManager.Instance Property

Retorna em padrão singleton a Última Instância de ApplicationManager instanciada.

```csharp
public static EficazFramework.Application.ApplicationManager Instance { get; set; }
```

#### Property Value
[ApplicationManager](EficazFramework.Application/ApplicationManager.md 'EficazFramework.Application.ApplicationManager')

<a name='EficazFramework.Application.ApplicationManager.RunningAplications'></a>

## ApplicationManager.RunningAplications Property

Cache de aplicativos em execução

```csharp
public System.Collections.ObjectModel.ObservableCollection<EficazFramework.Application.ApplicationInstance> RunningAplications { get; }
```

#### Property Value
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[EficazFramework.Application.ApplicationInstance](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationInstance 'EficazFramework.Application.ApplicationInstance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')

<a name='EficazFramework.Application.ApplicationManager.SectionManager'></a>

## ApplicationManager.SectionManager Property

Instância de SectionManager para gestão de múltiplas área de trabalho.

```csharp
public EficazFramework.Application.SectionManager SectionManager { get; }
```

#### Property Value
[SectionManager](EficazFramework.Application/SectionManager.md 'EficazFramework.Application.SectionManager')
### Methods

<a name='EficazFramework.Application.ApplicationManager.Activate(EficazFramework.Application.ApplicationDefinition)'></a>

## ApplicationManager.Activate(ApplicationDefinition) Method

Ativa uma aplicação para trabalho. Caso ainda não esteja em execução, uma nova intância é criada.

```csharp
public void Activate(EficazFramework.Application.ApplicationDefinition application);
```
#### Parameters

<a name='EficazFramework.Application.ApplicationManager.Activate(EficazFramework.Application.ApplicationDefinition).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Manifesto de aplicativo a ser iniciado ou ativado.

<a name='EficazFramework.Application.ApplicationManager.IsRunning(EficazFramework.Application.ApplicationDefinition)'></a>

## ApplicationManager.IsRunning(ApplicationDefinition) Method

Retorna se um aplicativo está em execução atualmente.

```csharp
public bool IsRunning(EficazFramework.Application.ApplicationDefinition application);
```
#### Parameters

<a name='EficazFramework.Application.ApplicationManager.IsRunning(EficazFramework.Application.ApplicationDefinition).application'></a>

`application` [EficazFramework.Application.ApplicationDefinition](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationDefinition 'EficazFramework.Application.ApplicationDefinition')

Instância de aplicativo a ser verificado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')