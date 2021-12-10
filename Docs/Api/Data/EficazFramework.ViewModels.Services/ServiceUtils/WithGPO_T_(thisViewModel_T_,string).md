#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.WithGPO<T>(this ViewModel<T>, string) Method

Adiciona o serviço de políticas de acesso e gravação. Adicione após todos os demais serviços.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> WithGPO<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, string role)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/WithGPO_T_(thisViewModel_T_,string).md#EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithGPO<T>(this EficazFramework.ViewModels.ViewModel<T>, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).role'></a>

`role` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/WithGPO_T_(thisViewModel_T_,string).md#EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithGPO<T>(this EficazFramework.ViewModels.ViewModel<T>, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')