#### [EficazFramework.Blazor](EficazFrameworkBlazor.md 'EficazFramework Blazor')
### [EficazFramework.Components](EficazFrameworkBlazor.md#EficazFramework_Components 'EficazFramework.Components')
## BaseItemsControl&lt;TChildComponent&gt; Class
```csharp
public abstract class BaseItemsControl<TChildComponent> : EficazFramework.Components.ComponentBase
    where TChildComponent : EficazFramework.Components.ComponentBase
```
#### Type parameters
<a name='EficazFramework_Components_BaseItemsControl_TChildComponent__TChildComponent'></a>
`TChildComponent`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [ComponentBase](ComponentBase.md 'EficazFramework.Components.ComponentBase') &#129106; BaseItemsControl&lt;TChildComponent&gt;  

Derived  
&#8627; [BaseBindableItemsControl&lt;TChildComponent,TData&gt;](BaseBindableItemsControl_TChildComponent_TData_.md 'EficazFramework.Components.BaseBindableItemsControl&lt;TChildComponent,TData&gt;')  

| Properties | |
| :--- | :--- |
| [ChildContent](BaseItemsControl_TChildComponent__ChildContent.md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.ChildContent') | Collection of T<br/> |
| [Items](BaseItemsControl_TChildComponent__Items.md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.Items') | Items - will be ignored when ItemsSource is not null<br/> |
| [LastContainer](BaseItemsControl_TChildComponent__LastContainer.md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.LastContainer') | Gets the Selected TChildComponent<br/> |
| [SelectedContainer](BaseItemsControl_TChildComponent__SelectedContainer.md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.SelectedContainer') | Gets the Selected TChildComponent<br/> |
| [SelectedIndex](BaseItemsControl_TChildComponent__SelectedIndex.md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.SelectedIndex') | Selected MudCarouselItem's index<br/> |

| Methods | |
| :--- | :--- |
| [MoveTo(int)](BaseItemsControl_TChildComponent__MoveTo(int).md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.MoveTo(int)') | Move to Item at desired index<br/> |
| [Next()](BaseItemsControl_TChildComponent__Next().md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.Next()') | Move to Next Item<br/> |
| [Previous()](BaseItemsControl_TChildComponent__Previous().md 'EficazFramework.Components.BaseItemsControl&lt;TChildComponent&gt;.Previous()') | Move to Previous Item<br/> |
