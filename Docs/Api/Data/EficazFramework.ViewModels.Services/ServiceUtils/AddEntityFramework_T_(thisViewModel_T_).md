#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.AddEntityFramework<T>(this ViewModel<T>) Method

Adiciona os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : EficazFramework.Entities.EntityBase, EficazFramework.Entities.IEntity;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddEntityFramework_T_(thisViewModel_T_).md#EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddEntityFramework_T_(thisViewModel_T_).md#EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')