#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application')

## SectionManager Class

```csharp
internal class SectionManager :
EficazFramework.Application.ISectionManager,
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SectionManager

Implements [ISectionManager](EficazFramework.Application/ISectionManager.md 'EficazFramework.Application.ISectionManager'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')

| Constructors | |
| :--- | :--- |
| [SectionManager(IApplicationManager)](EficazFramework.Application/SectionManager/SectionManager(IApplicationManager).md 'EficazFramework.Application.SectionManager.SectionManager(EficazFramework.Application.IApplicationManager)') | |

| Fields | |
| :--- | :--- |
| [_appManager](EficazFramework.Application/SectionManager/_appManager.md 'EficazFramework.Application.SectionManager._appManager') | |
| [_current](EficazFramework.Application/SectionManager/_current.md 'EficazFramework.Application.SectionManager._current') | |
| [SectionsIDs](EficazFramework.Application/SectionManager/SectionsIDs.md 'EficazFramework.Application.SectionManager.SectionsIDs') | Dicionário das seções ativas, útil para evitar ativação em duplicidade. |

| Properties | |
| :--- | :--- |
| [ApplicationManager](EficazFramework.Application/SectionManager/ApplicationManager.md 'EficazFramework.Application.SectionManager.ApplicationManager') | Instância de ApplicationManager para sincronização de aplicativos por área de trabalho |
| [CurrentSection](EficazFramework.Application/SectionManager/CurrentSection.md 'EficazFramework.Application.SectionManager.CurrentSection') | Contém informações acerca da Seção Ativa. |
| [Sections](EficazFramework.Application/SectionManager/Sections.md 'EficazFramework.Application.SectionManager.Sections') | Listagem de Seções Iniciadas (aka "Múltiplas áreas de trabalho") |
| [SectionsInternal](EficazFramework.Application/SectionManager/SectionsInternal.md 'EficazFramework.Application.SectionManager.SectionsInternal') | |

| Methods | |
| :--- | :--- |
| [ActivateSection(Section, bool)](EficazFramework.Application/SectionManager/ActivateSection(Section,bool).md 'EficazFramework.Application.SectionManager.ActivateSection(EficazFramework.Application.Section, bool)') | |
| [ActivateSection(long)](EficazFramework.Application/SectionManager/ActivateSection(long).md 'EficazFramework.Application.SectionManager.ActivateSection(long)') | |
| [DisposeSection(Section)](EficazFramework.Application/SectionManager/DisposeSection(Section).md 'EficazFramework.Application.SectionManager.DisposeSection(EficazFramework.Application.Section)') | |
| [DisposeSection(long)](EficazFramework.Application/SectionManager/DisposeSection(long).md 'EficazFramework.Application.SectionManager.DisposeSection(long)') | |
| [Sections_CollectionChanged(object, NotifyCollectionChangedEventArgs)](EficazFramework.Application/SectionManager/Sections_CollectionChanged(object,NotifyCollectionChangedEventArgs).md 'EficazFramework.Application.SectionManager.Sections_CollectionChanged(object, System.Collections.Specialized.NotifyCollectionChangedEventArgs)') | |

| Events | |
| :--- | :--- |
| [CurrentSectionChanged](EficazFramework.Application/SectionManager/CurrentSectionChanged.md 'EficazFramework.Application.SectionManager.CurrentSectionChanged') | |
| [PropertyChanged](EficazFramework.Application/SectionManager/PropertyChanged.md 'EficazFramework.Application.SectionManager.PropertyChanged') | |
