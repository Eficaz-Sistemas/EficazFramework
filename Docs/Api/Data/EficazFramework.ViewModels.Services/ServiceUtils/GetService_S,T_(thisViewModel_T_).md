#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.GetService<S,T>(this ViewModel<T>) Method

Retorna a instancia de serviço pelo tipo S especificado

```csharp
public static S GetService<S,T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where S : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_).S'></a>

`S`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/GetService_S,T_(thisViewModel_T_).md#EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.GetService<S,T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[S](EficazFramework.ViewModels.Services/ServiceUtils/GetService_S,T_(thisViewModel_T_).md#EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_).S 'EficazFramework.ViewModels.Services.ServiceUtils.GetService<S,T>(this EficazFramework.ViewModels.ViewModel<T>).S')