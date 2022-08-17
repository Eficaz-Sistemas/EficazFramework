#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.AddRestApi<T>(this ViewModel<T>, HttpClient, Action<RestApiBuilderOptions>) Method

Adiciona os serviços de operações CRUD via API's REST.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, System.Net.Http.HttpClient client, System.Action<EficazFramework.ViewModels.Services.RestApiBuilderOptions> options=null)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,System.Action_EficazFramework.ViewModels.Services.RestApiBuilderOptions_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,System.Action_EficazFramework.ViewModels.Services.RestApiBuilderOptions_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddRestApi_T_(thisViewModel_T_,HttpClient,Action_RestApiBuilderOptions_).md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,System.Action_EficazFramework.ViewModels.Services.RestApiBuilderOptions_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, System.Action<EficazFramework.ViewModels.Services.RestApiBuilderOptions>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,System.Action_EficazFramework.ViewModels.Services.RestApiBuilderOptions_).client'></a>

`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,System.Action_EficazFramework.ViewModels.Services.RestApiBuilderOptions_).options'></a>

`options` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[RestApiBuilderOptions](EficazFramework.ViewModels.Services/RestApiBuilderOptions.md 'EficazFramework.ViewModels.Services.RestApiBuilderOptions')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddRestApi_T_(thisViewModel_T_,HttpClient,Action_RestApiBuilderOptions_).md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,System.Action_EficazFramework.ViewModels.Services.RestApiBuilderOptions_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, System.Action<EficazFramework.ViewModels.Services.RestApiBuilderOptions>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')