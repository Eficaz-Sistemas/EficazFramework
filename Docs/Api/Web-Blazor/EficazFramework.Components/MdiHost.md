#### [EficazFramework.Blazor](EficazFrameworkBlazor.md 'EficazFramework Blazor')
### [EficazFramework.Components](EficazFrameworkBlazor.md#EficazFramework.Components 'EficazFramework.Components')

## MdiHost Class

```csharp
public class MdiHost : MudBlazor.MudBaseBindableItemsControl<EficazFramework.Components.MdiWindow, EficazFramework.Application.ApplicationInstance>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Microsoft.AspNetCore.Components.ComponentBase](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.AspNetCore.Components.ComponentBase 'Microsoft.AspNetCore.Components.ComponentBase') &#129106; [MudBlazor.MudComponentBase](https://docs.microsoft.com/en-us/dotnet/api/MudBlazor.MudComponentBase 'MudBlazor.MudComponentBase') &#129106; [MudBlazor.MudBaseItemsControl&lt;](https://docs.microsoft.com/en-us/dotnet/api/MudBlazor.MudBaseItemsControl-1 'MudBlazor.MudBaseItemsControl`1')[MdiWindow](EficazFramework.Components/MdiWindow.md 'EficazFramework.Components.MdiWindow')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/MudBlazor.MudBaseItemsControl-1 'MudBlazor.MudBaseItemsControl`1') &#129106; [MudBlazor.MudBaseBindableItemsControl&lt;](https://docs.microsoft.com/en-us/dotnet/api/MudBlazor.MudBaseBindableItemsControl-2 'MudBlazor.MudBaseBindableItemsControl`2')[MdiWindow](EficazFramework.Components/MdiWindow.md 'EficazFramework.Components.MdiWindow')[,](https://docs.microsoft.com/en-us/dotnet/api/MudBlazor.MudBaseBindableItemsControl-2 'MudBlazor.MudBaseBindableItemsControl`2')[EficazFramework.Application.ApplicationInstance](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Application.ApplicationInstance 'EficazFramework.Application.ApplicationInstance')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/MudBlazor.MudBaseBindableItemsControl-2 'MudBlazor.MudBaseBindableItemsControl`2') &#129106; MdiHost

| Properties | |
| :--- | :--- |
| [ApplicationManager](EficazFramework.Components/MdiHost/ApplicationManager.md 'EficazFramework.Components.MdiHost.ApplicationManager') | IApplicationManager service instance, if available on DI |
| [AppSearchFilter](EficazFramework.Components/MdiHost/AppSearchFilter.md 'EficazFramework.Components.MdiHost.AppSearchFilter') | The literal for searching for applications on the list |
| [Breakpoint](EficazFramework.Components/MdiHost/Breakpoint.md 'EficazFramework.Components.MdiHost.Breakpoint') | Breakpoint that defines the view on Frames (windows) or Full Screen |
| [CurrentSection](EficazFramework.Components/MdiHost/CurrentSection.md 'EficazFramework.Components.MdiHost.CurrentSection') | Current MDI Section (for multi tenant purposes) |
| [CurrentSectionTemplate](EficazFramework.Components/MdiHost/CurrentSectionTemplate.md 'EficazFramework.Components.MdiHost.CurrentSectionTemplate') | The template for Current Section representation on StartMenu's right |
| [StartMenuAppsHostHeight](EficazFramework.Components/MdiHost/StartMenuAppsHostHeight.md 'EficazFramework.Components.MdiHost.StartMenuAppsHostHeight') | Gets and Sets the available Application Menu Height. <br/><br/>It's possible to use CSS expressions, like calc. <br/><br/>Ex: calc(100vh - 428px) (default value) |
| [StartMenuFooter](EficazFramework.Components/MdiHost/StartMenuFooter.md 'EficazFramework.Components.MdiHost.StartMenuFooter') | Start Menu Footer content |
| [StartMenuIcon](EficazFramework.Components/MdiHost/StartMenuIcon.md 'EficazFramework.Components.MdiHost.StartMenuIcon') | The Start Menu Icon |
| [StartMenuTabs](EficazFramework.Components/MdiHost/StartMenuTabs.md 'EficazFramework.Components.MdiHost.StartMenuTabs') | Aditional left tabs for Start Menu |

| Methods | |
| :--- | :--- |
| [AddItem(MdiWindow)](EficazFramework.Components/MdiHost/AddItem(MdiWindow).md 'EficazFramework.Components.MdiHost.AddItem(EficazFramework.Components.MdiWindow)') | Add a new MdiWindow to the Host |
| [CloseApplication(MdiWindow)](EficazFramework.Components/MdiHost/CloseApplication(MdiWindow).md 'EficazFramework.Components.MdiHost.CloseApplication(EficazFramework.Components.MdiWindow)') | Closes the application from the [appHost](EficazFramework.Components/MdiHost/CloseApplication(MdiWindow).md#EficazFramework.Components.MdiHost.CloseApplication(EficazFramework.Components.MdiWindow).appHost 'EficazFramework.Components.MdiHost.CloseApplication(EficazFramework.Components.MdiWindow).appHost') parameter. |
| [LoadApplication(ApplicationDefinition)](EficazFramework.Components/MdiHost/LoadApplication(ApplicationDefinition).md 'EficazFramework.Components.MdiHost.LoadApplication(EficazFramework.Application.ApplicationDefinition)') | Start a new application instance (from [app](EficazFramework.Components/MdiHost/LoadApplication(ApplicationDefinition).md#EficazFramework.Components.MdiHost.LoadApplication(EficazFramework.Application.ApplicationDefinition).app 'EficazFramework.Components.MdiHost.LoadApplication(EficazFramework.Application.ApplicationDefinition).app') metadata) and adds it to the host. |
| [ToggleSectionsMenuOpen(bool)](EficazFramework.Components/MdiHost/ToggleSectionsMenuOpen(bool).md 'EficazFramework.Components.MdiHost.ToggleSectionsMenuOpen(bool)') | Toggle the Sections Menu on Open and Closed states. |
| [ToggleStartMenuOpen(bool)](EficazFramework.Components/MdiHost/ToggleStartMenuOpen(bool).md 'EficazFramework.Components.MdiHost.ToggleStartMenuOpen(bool)') | Toggle the Start Menu on Open and Closed states. |
| [ToggleStartMenuView()](EficazFramework.Components/MdiHost/ToggleStartMenuView().md 'EficazFramework.Components.MdiHost.ToggleStartMenuView()') | Toggle between Full and Compact (list) Application Menu |
