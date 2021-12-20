#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## SectionManager Class

```csharp
public class SectionManager :
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SectionManager

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')
### Fields

<a name='EficazFramework.Application.SectionManager.SectionsIDs'></a>

## SectionManager.SectionsIDs Field

Dicionário das seções ativas, útil para evitar ativação em duplicidade.

```csharp
private readonly Dictionary<long,Section> SectionsIDs;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EficazFramework.Application.Section](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Section 'EficazFramework.Application.Section')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Properties

<a name='EficazFramework.Application.SectionManager.ApplicationManager'></a>

## SectionManager.ApplicationManager Property

Instância de ApplicationManager para sincronização de aplicativos por área de trabalho

```csharp
public EficazFramework.Application.ApplicationManager ApplicationManager { get; }
```

#### Property Value
[ApplicationManager](EficazFramework.Application/ApplicationManager.md 'EficazFramework.Application.ApplicationManager')

<a name='EficazFramework.Application.SectionManager.CurrentSection'></a>

## SectionManager.CurrentSection Property

Contém informações acerca da Seção Ativa.

```csharp
public EficazFramework.Application.Section CurrentSection { get; set; }
```

#### Property Value
[EficazFramework.Application.Section](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Section 'EficazFramework.Application.Section')

<a name='EficazFramework.Application.SectionManager.Sections'></a>

## SectionManager.Sections Property

Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho")

```csharp
public System.Collections.ObjectModel.ReadOnlyCollection<EficazFramework.Application.Section> Sections { get; }
```

#### Property Value
[System.Collections.ObjectModel.ReadOnlyCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')[EficazFramework.Application.Section](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Section 'EficazFramework.Application.Section')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ReadOnlyCollection-1 'System.Collections.ObjectModel.ReadOnlyCollection`1')