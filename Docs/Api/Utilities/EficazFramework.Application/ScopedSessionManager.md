#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Application](EficazFrameworkData.md#EficazFramework.Application 'EficazFramework.Application')

## ScopedSessionManager Class

```csharp
public class ScopedSessionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ScopedSessionManager

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')
### Fields

<a name='EficazFramework.Application.ScopedSessionManager.SessionsIDs'></a>

## ScopedSessionManager.SessionsIDs Field

Dicionário das seções ativas, útil para evitar ativação em duplicidade.

```csharp
private readonly Dictionary<long,Session> SessionsIDs;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Properties

<a name='EficazFramework.Application.ScopedSessionManager.ApplicationManager'></a>

## ScopedSessionManager.ApplicationManager Property

Armazena e gerencia informações sobre aplicativos neste scopo de seções.

```csharp
public EficazFramework.Application.ScopedApplicationManager ApplicationManager { get; }
```

#### Property Value
[ScopedApplicationManager](EficazFramework.Application/ScopedApplicationManager.md 'EficazFramework.Application.ScopedApplicationManager')

<a name='EficazFramework.Application.ScopedSessionManager.CurrentSession'></a>

## ScopedSessionManager.CurrentSession Property

Contém informações acerca da Seção Ativa.

```csharp
public EficazFramework.Application.Session CurrentSession { get; set; }
```

#### Property Value
[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')

<a name='EficazFramework.Application.ScopedSessionManager.Sessions'></a>

## ScopedSessionManager.Sessions Property

Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")

```csharp
public System.Collections.ObjectModel.ReadOnlyCollection<EficazFramework.Application.Session> Sessions { get; }
```

#### Property Value
[System.Collections.ObjectModel.ReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')