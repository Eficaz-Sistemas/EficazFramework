#### [EficazFramework.Blazor](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Components](EficazFrameworkData.md#EficazFramework.Components 'EficazFramework.Components')

## Animation Class

```csharp
public class Animation : EficazFramework.Components.ComponentBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [ComponentBase](EficazFramework.Components/ComponentBase.md 'EficazFramework.Components.ComponentBase') &#129106; Animation
### Properties

<a name='EficazFramework.Components.Animation.ChildContent'></a>

## Animation.ChildContent Property

Child content of the component.

```csharp
public Microsoft.AspNetCore.Components.RenderFragment ChildContent { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.RenderFragment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment 'Microsoft.AspNetCore.Components.RenderFragment')

<a name='EficazFramework.Components.Animation.Delay'></a>

## Animation.Delay Property

The Animation Start Delay, int miliseconds

```csharp
public int Delay { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Components.Animation.Direction'></a>

## Animation.Direction Property

animation-direction: normal|reverse|alternate|alternate-reverse;

```csharp
public EficazFramework.Enums.AnimationDirection Direction { get; set; }
```

#### Property Value
[EficazFramework.Enums.AnimationDirection](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Enums.AnimationDirection 'EficazFramework.Enums.AnimationDirection')

<a name='EficazFramework.Components.Animation.Duration'></a>

## Animation.Duration Property

The Animation Duration, int miliseconds

```csharp
public int Duration { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Components.Animation.Infinite'></a>

## Animation.Infinite Property

The Animation Duration, on CSS format (ex: 1s, 0.25s, etc)

```csharp
public bool Infinite { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Components.Animation.KeyFrameName'></a>

## Animation.KeyFrameName Property

Keyframe Name. See MudBlazor.Animations class for built-in ones.  
Some of then could require aditional values with String.Format or string interpolation

```csharp
public string KeyFrameName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Components.Animation.TimmingFunction'></a>

## Animation.TimmingFunction Property

The timming effect function to be applied to element

```csharp
public EficazFramework.Enums.AnimationTimmingFunc TimmingFunction { get; set; }
```

#### Property Value
[EficazFramework.Enums.AnimationTimmingFunc](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Enums.AnimationTimmingFunc 'EficazFramework.Enums.AnimationTimmingFunc')

<a name='EficazFramework.Components.Animation.Trigger'></a>

## Animation.Trigger Property

animation-direction: normal|reverse|alternate|alternate-reverse;

```csharp
public EficazFramework.Enums.AnimationTrigger Trigger { get; set; }
```

#### Property Value
[EficazFramework.Enums.AnimationTrigger](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Enums.AnimationTrigger 'EficazFramework.Enums.AnimationTrigger')
### Methods

<a name='EficazFramework.Components.Animation.TriggerAnimation()'></a>

## Animation.TriggerAnimation() Method

Execute the animation

```csharp
public void TriggerAnimation();
```