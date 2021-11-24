#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services').[ServiceUtils](ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')
## ServiceUtils.WithGPO&lt;T&gt;(ViewModel&lt;T&gt;, string) Method
Adiciona o serviço de políticas de acesso e gravação. Adicione após todos os demais serviços.  
```csharp
public static EficazFramework.ViewModels.ViewModel<T> WithGPO<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, string role)
    where T : class;
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_ServiceUtils_WithGPO_T_(EficazFramework_ViewModels_ViewModel_T__string)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_ViewModels_Services_ServiceUtils_WithGPO_T_(EficazFramework_ViewModels_ViewModel_T__string)_viewmodel'></a>
`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')[T](ServiceUtils_WithGPO_T_(ViewModel_T__string).md#EficazFramework_ViewModels_Services_ServiceUtils_WithGPO_T_(EficazFramework_ViewModels_ViewModel_T__string)_T 'EficazFramework.ViewModels.Services.ServiceUtils.WithGPO&lt;T&gt;(EficazFramework.ViewModels.ViewModel&lt;T&gt;, string).T')[&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')  
  
<a name='EficazFramework_ViewModels_Services_ServiceUtils_WithGPO_T_(EficazFramework_ViewModels_ViewModel_T__string)_role'></a>
`role` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')[T](ServiceUtils_WithGPO_T_(ViewModel_T__string).md#EficazFramework_ViewModels_Services_ServiceUtils_WithGPO_T_(EficazFramework_ViewModels_ViewModel_T__string)_T 'EficazFramework.ViewModels.Services.ServiceUtils.WithGPO&lt;T&gt;(EficazFramework.ViewModels.ViewModel&lt;T&gt;, string).T')[&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')  
