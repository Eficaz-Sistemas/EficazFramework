#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.AddSingledEdit<T>(this ViewModel<T>, bool) Method

Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddSingledEdit<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, bool notifyOnSave=true)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEdit_T_(thisViewModel_T_,bool).md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit<T>(this EficazFramework.ViewModels.ViewModel<T>, bool).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).notifyOnSave'></a>

`notifyOnSave` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEdit_T_(thisViewModel_T_,bool).md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit<T>(this EficazFramework.ViewModels.ViewModel<T>, bool).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')