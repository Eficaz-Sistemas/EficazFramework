#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Application](EficazFrameworkUtilities.md#EficazFramework.Application 'EficazFramework.Application').[SessionManager](SessionManager.md 'EficazFramework.Application.SessionManager')

## SessionManager.SessionsIDs Field

Dicionário das seções ativas, útil para evitar ativação em duplicidade.

```csharp
private static readonly Dictionary<long,Session> SessionsIDs;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')