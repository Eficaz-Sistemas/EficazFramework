#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## Audit<T> Class

```csharp
public class Audit<T> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.Audit_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/Audit_T_.md#EficazFramework.ViewModels.Services.Audit_T_.T 'EficazFramework.ViewModels.Services.Audit<T>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; Audit<T>
### Methods

<a name='EficazFramework.ViewModels.Services.Audit_T_.OnViewModelAction(object,EficazFramework.Events.CRUDEventArgs_T_)'></a>

## Audit<T>.OnViewModelAction(object, CRUDEventArgs<T>) Method

Monitora a mudança de estado do ViewModel.

```csharp
private void OnViewModelAction(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.Audit_T_.OnViewModelAction(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.Audit_T_.OnViewModelAction(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels.Services/Audit_T_.md#EficazFramework.ViewModels.Services.Audit_T_.T 'EficazFramework.ViewModels.Services.Audit<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')