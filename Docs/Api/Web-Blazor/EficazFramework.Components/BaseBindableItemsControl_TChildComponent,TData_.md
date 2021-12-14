#### [EficazFramework.Blazor](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Components](EficazFrameworkData.md#EficazFramework.Components 'EficazFramework.Components')

## BaseBindableItemsControl<TChildComponent,TData> Class

```csharp
public abstract class BaseBindableItemsControl<TChildComponent,TData> : EficazFramework.Components.BaseItemsControl<TChildComponent>
    where TChildComponent : EficazFramework.Components.ComponentBase
```
#### Type parameters

<a name='EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.TChildComponent'></a>

`TChildComponent`

<a name='EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.TData'></a>

`TData`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [ComponentBase](EficazFramework.Components/ComponentBase.md 'EficazFramework.Components.ComponentBase') &#129106; [EficazFramework.Components.BaseItemsControl&lt;](EficazFramework.Components/BaseItemsControl_TChildComponent_.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>')[TChildComponent](EficazFramework.Components/BaseBindableItemsControl_TChildComponent,TData_.md#EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.TChildComponent 'EficazFramework.Components.BaseBindableItemsControl<TChildComponent,TData>.TChildComponent')[&gt;](EficazFramework.Components/BaseItemsControl_TChildComponent_.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>') &#129106; BaseBindableItemsControl<TChildComponent,TData>
### Properties

<a name='EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.ItemsSource'></a>

## BaseBindableItemsControl<TChildComponent,TData>.ItemsSource Property

Items Collection - For databinding usage

```csharp
public System.Collections.Generic.IEnumerable<TData> ItemsSource { get; set; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TData](EficazFramework.Components/BaseBindableItemsControl_TChildComponent,TData_.md#EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.TData 'EficazFramework.Components.BaseBindableItemsControl<TChildComponent,TData>.TData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.ItemTemplate'></a>

## BaseBindableItemsControl<TChildComponent,TData>.ItemTemplate Property

Template for each Item in ItemsSource collection

```csharp
public Microsoft.AspNetCore.Components.RenderFragment<TData> ItemTemplate { get; set; }
```

#### Property Value
[Microsoft.AspNetCore.Components.RenderFragment&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment-1 'Microsoft.AspNetCore.Components.RenderFragment`1')[TData](EficazFramework.Components/BaseBindableItemsControl_TChildComponent,TData_.md#EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.TData 'EficazFramework.Components.BaseBindableItemsControl<TChildComponent,TData>.TData')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.RenderFragment-1 'Microsoft.AspNetCore.Components.RenderFragment`1')

<a name='EficazFramework.Components.BaseBindableItemsControl_TChildComponent,TData_.SelectedItem'></a>

## BaseBindableItemsControl<TChildComponent,TData>.SelectedItem Property

Gets the Selected Item from ItemsSource, or Selected TChildComponent, when it's null

```csharp
public object SelectedItem { get; }
```

#### Property Value
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')