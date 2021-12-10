#### [EficazFramework.Blazor](EficazFrameworkBlazor.md 'EficazFramework Blazor')
### [EficazFramework.Components](EficazFrameworkBlazor.md#EficazFramework.Components 'EficazFramework.Components').[ComponentBase](ComponentBase.md 'EficazFramework.Components.ComponentBase')

## ComponentBase.UserAttributes Property

UserAttributes carries all attributes you add to the component that don't match any of its parameters.  
They will be splatted onto the underlying HTML tag.

```csharp
public System.Collections.Generic.Dictionary<string,object> UserAttributes { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')