#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.AddRestApi<T>(this ViewModel<T>, HttpClient, RestApiBuilderOptions) Method

Adiciona os serviços de operações CRUD via API's REST.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, System.Net.Http.HttpClient client, EficazFramework.ViewModels.Services.RestApiBuilderOptions options=null)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,EficazFramework.ViewModels.Services.RestApiBuilderOptions).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,EficazFramework.ViewModels.Services.RestApiBuilderOptions).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddRestApi_T_(thisViewModel_T_,HttpClient,RestApiBuilderOptions).md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,EficazFramework.ViewModels.Services.RestApiBuilderOptions).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, EficazFramework.ViewModels.Services.RestApiBuilderOptions).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,EficazFramework.ViewModels.Services.RestApiBuilderOptions).client'></a>

`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,EficazFramework.ViewModels.Services.RestApiBuilderOptions).options'></a>

`options` [RestApiBuilderOptions](EficazFramework.ViewModels.Services/RestApiBuilderOptions.md 'EficazFramework.ViewModels.Services.RestApiBuilderOptions')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddRestApi_T_(thisViewModel_T_,HttpClient,RestApiBuilderOptions).md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,EficazFramework.ViewModels.Services.RestApiBuilderOptions).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, EficazFramework.ViewModels.Services.RestApiBuilderOptions).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')