#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services').[ServiceUtils](ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')
## ServiceUtils.GetService&lt;S,T&gt;(ViewModel&lt;T&gt;) Method
Retorna a instancia de serviço pelo tipo S especificado  
```csharp
public static S GetService<S,T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where S : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class;
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_ServiceUtils_GetService_S_T_(EficazFramework_ViewModels_ViewModel_T_)_S'></a>
`S`  
  
<a name='EficazFramework_ViewModels_Services_ServiceUtils_GetService_S_T_(EficazFramework_ViewModels_ViewModel_T_)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_ViewModels_Services_ServiceUtils_GetService_S_T_(EficazFramework_ViewModels_ViewModel_T_)_viewmodel'></a>
`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')[T](ServiceUtils_GetService_S_T_(ViewModel_T_).md#EficazFramework_ViewModels_Services_ServiceUtils_GetService_S_T_(EficazFramework_ViewModels_ViewModel_T_)_T 'EficazFramework.ViewModels.Services.ServiceUtils.GetService&lt;S,T&gt;(EficazFramework.ViewModels.ViewModel&lt;T&gt;).T')[&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')  
  
#### Returns
[S](ServiceUtils_GetService_S_T_(ViewModel_T_).md#EficazFramework_ViewModels_Services_ServiceUtils_GetService_S_T_(EficazFramework_ViewModels_ViewModel_T_)_S 'EficazFramework.ViewModels.Services.ServiceUtils.GetService&lt;S,T&gt;(EficazFramework.ViewModels.ViewModel&lt;T&gt;).S')  
