#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## IndexViewNavigator<T> Class

```csharp
public class IndexViewNavigator<T> : EficazFramework.ViewModels.Services.ViewModelService<T>,
EficazFramework.Navigation.IIndexViewNavigator
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/IndexViewNavigator_T_.md#EficazFramework.ViewModels.Services.IndexViewNavigator_T_.T 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; IndexViewNavigator<T>

Implements [EficazFramework.Navigation.IIndexViewNavigator](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Navigation.IIndexViewNavigator 'EficazFramework.Navigation.IIndexViewNavigator')
### Methods

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.GoToFindPage_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## IndexViewNavigator<T>.GoToFindPage_Executed(object, ExecuteEventArgs) Method

Ações do comando GoToFindPage

```csharp
private void GoToFindPage_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.GoToFindPage_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.GoToFindPage_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.OnViewModel_StateChanged(object,System.EventArgs)'></a>

## IndexViewNavigator<T>.OnViewModel_StateChanged(object, EventArgs) Method

Altera o índice selecionado pelo estado do ViewModel

```csharp
private void OnViewModel_StateChanged(object sender, System.EventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.OnViewModel_StateChanged(object,System.EventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.OnViewModel_StateChanged(object,System.EventArgs).e'></a>

`e` [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs')