#### [EficazFramework.Blazor](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Components](EficazFrameworkData.md#EficazFramework.Components 'EficazFramework.Components')

## BaseItemsControl<TChildComponent> Class

```csharp
public abstract class BaseItemsControl<TChildComponent> : EficazFramework.Components.ComponentBase
    where TChildComponent : EficazFramework.Components.ComponentBase
```
#### Type parameters

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.TChildComponent'></a>

`TChildComponent`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [ComponentBase](EficazFramework.Components/ComponentBase.md 'EficazFramework.Components.ComponentBase') &#129106; BaseItemsControl<TChildComponent>

Derived  
&#8627; [BaseBindableItemsControl&lt;TChildComponent,TData&gt;](EficazFramework.Components/BaseBindableItemsControl_TChildComponent,TData_.md 'EficazFramework.Components.BaseBindableItemsControl<TChildComponent,TData>')
### Properties

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.ChildContent'></a>

## BaseItemsControl<TChildComponent>.ChildContent Property

Collection of T

```csharp
public Microsoft.AspNetCore.Components.RenderFragment ChildContent { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.RenderFragment](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment 'Microsoft.AspNetCore.Components.RenderFragment')

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.Items'></a>

## BaseItemsControl<TChildComponent>.Items Property

Items - will be ignored when ItemsSource is not null

```csharp
public System.Collections.Generic.List<TChildComponent> Items { get; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TChildComponent](EficazFramework.Components/BaseItemsControl_TChildComponent_.md#EficazFramework.Components.BaseItemsControl_TChildComponent_.TChildComponent 'EficazFramework.Components.BaseItemsControl<TChildComponent>.TChildComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.LastContainer'></a>

## BaseItemsControl<TChildComponent>.LastContainer Property

Gets the Selected TChildComponent

```csharp
public TChildComponent LastContainer { get; }
```

#### Property Value
[TChildComponent](EficazFramework.Components/BaseItemsControl_TChildComponent_.md#EficazFramework.Components.BaseItemsControl_TChildComponent_.TChildComponent 'EficazFramework.Components.BaseItemsControl<TChildComponent>.TChildComponent')

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.SelectedContainer'></a>

## BaseItemsControl<TChildComponent>.SelectedContainer Property

Gets the Selected TChildComponent

```csharp
public TChildComponent SelectedContainer { get; }
```

#### Property Value
[TChildComponent](EficazFramework.Components/BaseItemsControl_TChildComponent_.md#EficazFramework.Components.BaseItemsControl_TChildComponent_.TChildComponent 'EficazFramework.Components.BaseItemsControl<TChildComponent>.TChildComponent')

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.SelectedIndex'></a>

## BaseItemsControl<TChildComponent>.SelectedIndex Property

Selected MudCarouselItem's index

```csharp
public int SelectedIndex { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.MoveTo(int)'></a>

## BaseItemsControl<TChildComponent>.MoveTo(int) Method

Move to Item at desired index

```csharp
public void MoveTo(int index);
```
#### Parameters

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.MoveTo(int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.Next()'></a>

## BaseItemsControl<TChildComponent>.Next() Method

Move to Next Item

```csharp
public void Next();
```

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.Previous()'></a>

## BaseItemsControl<TChildComponent>.Previous() Method

Move to Previous Item

```csharp
public void Previous();
```