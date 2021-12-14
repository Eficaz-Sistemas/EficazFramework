#### [EficazFramework.Blazor](EficazFrameworkBlazor.md 'EficazFramework Blazor')
### [EficazFramework.Components](EficazFrameworkBlazor.md#EficazFramework.Components 'EficazFramework.Components')

## ComponentBase Class

```csharp
public class ComponentBase : Microsoft.AspNetCore.Components.ComponentBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; ComponentBase

Derived  
&#8627; [Animation](EficazFramework.Components/Animation.md 'EficazFramework.Components.Animation')  
&#8627; [BaseItemsControl&lt;TChildComponent&gt;](EficazFramework.Components/BaseItemsControl_TChildComponent_.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>')
### Properties

<a name='EficazFramework.Components.ComponentBase.Class'></a>

## ComponentBase.Class Property

User class names, separated by space

```csharp
public string Class { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Components.ComponentBase.Style'></a>

## ComponentBase.Style Property

User styles, applied on top of the component's own classes and styles

```csharp
public string Style { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Components.ComponentBase.Tag'></a>

## ComponentBase.Tag Property

Use Tag to attach any user data object to the component for your convenience.

```csharp
public object Tag { get; set; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Components.ComponentBase.UserAttributes'></a>

## ComponentBase.UserAttributes Property

UserAttributes carries all attributes you add to the component that don't match any of its parameters.  
They will be splatted onto the underlying HTML tag.

```csharp
public System.Collections.Generic.Dictionary<string,object> UserAttributes { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')