#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Application](EficazFrameworkData.md#EficazFramework.Application 'EficazFramework.Application').[ScopedSessionManager](EficazFramework.Application/ScopedSessionManager.md 'EficazFramework.Application.ScopedSessionManager')

## ScopedSessionManager.SessionsIDs Field

Dicionário das seções ativas, útil para evitar ativação em duplicidade.

```csharp
private readonly Dictionary<long,Session> SessionsIDs;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[EficazFramework.Application.Session](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.Session 'EficazFramework.Application.Session')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')