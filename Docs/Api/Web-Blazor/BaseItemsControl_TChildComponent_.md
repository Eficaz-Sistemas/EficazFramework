#### [EficazFramework.Blazor](EficazFrameworkBlazor.md 'EficazFramework Blazor')
### [EficazFramework.Components](EficazFrameworkBlazor.md#EficazFramework.Components 'EficazFramework.Components')

## BaseItemsControl<TChildComponent> Class

```csharp
public abstract class BaseItemsControl<TChildComponent> : EficazFramework.Components.ComponentBase
    where TChildComponent : EficazFramework.Components.ComponentBase
```
#### Type parameters

<a name='EficazFramework.Components.BaseItemsControl_TChildComponent_.TChildComponent'></a>

`TChildComponent`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [ComponentBase](ComponentBase.md 'EficazFramework.Components.ComponentBase') &#129106; BaseItemsControl<TChildComponent>

Derived  
&#8627; [BaseBindableItemsControl&lt;TChildComponent,TData&gt;](BaseBindableItemsControl_TChildComponent,TData_.md 'EficazFramework.Components.BaseBindableItemsControl<TChildComponent,TData>')

| Properties | |
| :--- | :--- |
| [ChildContent](BaseItemsControl_TChildComponent_.ChildContent.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.ChildContent') | Collection of T |
| [Items](BaseItemsControl_TChildComponent_.Items.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.Items') | Items - will be ignored when ItemsSource is not null |
| [LastContainer](BaseItemsControl_TChildComponent_.LastContainer.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.LastContainer') | Gets the Selected TChildComponent |
| [SelectedContainer](BaseItemsControl_TChildComponent_.SelectedContainer.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.SelectedContainer') | Gets the Selected TChildComponent |
| [SelectedIndex](BaseItemsControl_TChildComponent_.SelectedIndex.md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.SelectedIndex') | Selected MudCarouselItem's index |

| Methods | |
| :--- | :--- |
| [MoveTo(int)](BaseItemsControl_TChildComponent_.MoveTo(int).md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.MoveTo(int)') | Move to Item at desired index |
| [Next()](BaseItemsControl_TChildComponent_.Next().md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.Next()') | Move to Next Item |
| [Previous()](BaseItemsControl_TChildComponent_.Previous().md 'EficazFramework.Components.BaseItemsControl<TChildComponent>.Previous()') | Move to Previous Item |
