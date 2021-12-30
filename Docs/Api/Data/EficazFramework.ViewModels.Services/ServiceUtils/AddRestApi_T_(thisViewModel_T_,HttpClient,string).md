#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.AddRestApi<T>(this ViewModel<T>, HttpClient, string) Method

Adiciona os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, System.Net.Http.HttpClient client, string contentType="application/json")
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddRestApi_T_(thisViewModel_T_,HttpClient,string).md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).client'></a>

`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).contentType'></a>

`contentType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddRestApi_T_(thisViewModel_T_,HttpClient,string).md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')