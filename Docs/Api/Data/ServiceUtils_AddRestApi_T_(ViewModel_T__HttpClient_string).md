#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services').[ServiceUtils](ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')
## ServiceUtils.AddRestApi&lt;T&gt;(ViewModel&lt;T&gt;, HttpClient, string) Method
Adiciona os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.  
```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, System.Net.Http.HttpClient client, string contentType="application/json")
    where T : class;
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_ServiceUtils_AddRestApi_T_(EficazFramework_ViewModels_ViewModel_T__System_Net_Http_HttpClient_string)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_ViewModels_Services_ServiceUtils_AddRestApi_T_(EficazFramework_ViewModels_ViewModel_T__System_Net_Http_HttpClient_string)_viewmodel'></a>
`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')[T](ServiceUtils_AddRestApi_T_(ViewModel_T__HttpClient_string).md#EficazFramework_ViewModels_Services_ServiceUtils_AddRestApi_T_(EficazFramework_ViewModels_ViewModel_T__System_Net_Http_HttpClient_string)_T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi&lt;T&gt;(EficazFramework.ViewModels.ViewModel&lt;T&gt;, System.Net.Http.HttpClient, string).T')[&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')  
  
<a name='EficazFramework_ViewModels_Services_ServiceUtils_AddRestApi_T_(EficazFramework_ViewModels_ViewModel_T__System_Net_Http_HttpClient_string)_client'></a>
`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')  
  
<a name='EficazFramework_ViewModels_Services_ServiceUtils_AddRestApi_T_(EficazFramework_ViewModels_ViewModel_T__System_Net_Http_HttpClient_string)_contentType'></a>
`contentType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')[T](ServiceUtils_AddRestApi_T_(ViewModel_T__HttpClient_string).md#EficazFramework_ViewModels_Services_ServiceUtils_AddRestApi_T_(EficazFramework_ViewModels_ViewModel_T__System_Net_Http_HttpClient_string)_T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi&lt;T&gt;(EficazFramework.ViewModels.ViewModel&lt;T&gt;, System.Net.Http.HttpClient, string).T')[&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')  
