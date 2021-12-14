#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## PagedViewNavigator<T> Class

```csharp
public class PagedViewNavigator<T> : EficazFramework.ViewModels.Services.ViewModelService<T>,
EficazFramework.Navigation.IPagedViewNavigator
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.PagedViewNavigator_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/PagedViewNavigator_T_.md#EficazFramework.ViewModels.Services.PagedViewNavigator_T_.T 'EficazFramework.ViewModels.Services.PagedViewNavigator<T>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; PagedViewNavigator<T>

Implements [EficazFramework.Navigation.IPagedViewNavigator](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Navigation.IPagedViewNavigator 'EficazFramework.Navigation.IPagedViewNavigator')
### Methods

<a name='EficazFramework.ViewModels.Services.PagedViewNavigator_T_.OnViewModel_StateChanged(object,System.EventArgs)'></a>

## PagedViewNavigator<T>.OnViewModel_StateChanged(object, EventArgs) Method

Altera o índice selecionado pelo estado do ViewModel

```csharp
private void OnViewModel_StateChanged(object sender, System.EventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.PagedViewNavigator_T_.OnViewModel_StateChanged(object,System.EventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.PagedViewNavigator_T_.OnViewModel_StateChanged(object,System.EventArgs).e'></a>

`e` [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs')