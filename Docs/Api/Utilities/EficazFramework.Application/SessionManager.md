#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## SessionManager Class

```csharp
public class SessionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SessionManager

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')
### Fields

<a name='EficazFramework.Application.SessionManager.SessionsIDs'></a>

## SessionManager.SessionsIDs Field

Dicionário das seções ativas, útil para evitar ativação em duplicidade.

```csharp
private static readonly Dictionary<long,Session> SessionsIDs;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Properties

<a name='EficazFramework.Application.SessionManager.CurrentSession'></a>

## SessionManager.CurrentSession Property

Contém informações acerca da Seção Ativa.

```csharp
public EficazFramework.Application.Session CurrentSession { get; set; }
```

#### Property Value
[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')

<a name='EficazFramework.Application.SessionManager.Instance'></a>

## SessionManager.Instance Property

Instância singleton para uso com Binding e INotifyPropertyChanged.

```csharp
public static EficazFramework.Application.SessionManager Instance { get; }
```

#### Property Value
[SessionManager](EficazFramework.Application/SessionManager.md 'EficazFramework.Application.SessionManager')

<a name='EficazFramework.Application.SessionManager.Sessions'></a>

## SessionManager.Sessions Property

Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")

```csharp
public static System.Collections.ObjectModel.ReadOnlyCollection<EficazFramework.Application.Session> Sessions { get; }
```

#### Property Value
[System.Collections.ObjectModel.ReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')