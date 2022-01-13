#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application').[SectionManager](EficazFramework.Application/SectionManager.md 'EficazFramework.Application.SectionManager')

## SectionManager.SectionsIDs Field

Dicionário das seções ativas, útil para evitar ativação em duplicidade.

```csharp
private readonly Dictionary<long,Section> SectionsIDs;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[Section](EficazFramework.Application/Section.md 'EficazFramework.Application.Section')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')