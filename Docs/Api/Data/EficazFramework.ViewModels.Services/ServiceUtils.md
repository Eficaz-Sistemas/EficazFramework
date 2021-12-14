#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## ServiceUtils Class

```csharp
public static class ServiceUtils
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceUtils
### Fields

<a name='EficazFramework.ViewModels.Services.ServiceUtils.KEY_AUDIT'></a>

## ServiceUtils.KEY_AUDIT Field

Known Services by EficazFramework.Data

```csharp
public const string KEY_AUDIT = Audit;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_)'></a>

## ServiceUtils.AddCustom<T>(this ViewModel<T>, string, ViewModelService<T>) Method

Adiciona um serviço customizado, criado em ambientes externos.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddCustom<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, string name, EficazFramework.ViewModels.Services.ViewModelService<T> service)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, string, EficazFramework.ViewModels.Services.ViewModelService<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_).service'></a>

`service` [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, string, EficazFramework.ViewModels.Services.ViewModelService<T>).T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,string,EficazFramework.ViewModels.Services.ViewModelService_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, string, EficazFramework.ViewModels.Services.ViewModelService<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_)'></a>

## ServiceUtils.AddDataImport<TSource,TCache>(this ViewModel<TSource>) Method

Adiciona o serviço de importação ao ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<TSource> AddDataImport<TSource,TCache>(this EficazFramework.ViewModels.ViewModel<TSource> viewmodel)
    where TSource : class
    where TCache : EficazFramework.Repositories.DataImportCache;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TSource'></a>

`TSource`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TCache'></a>

`TCache`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[TSource](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TSource 'EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport<TSource,TCache>(this EficazFramework.ViewModels.ViewModel<TSource>).TSource')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[TSource](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TSource 'EficazFramework.ViewModels.Services.ServiceUtils.AddDataImport<TSource,TCache>(this EficazFramework.ViewModels.ViewModel<TSource>).TSource')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

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

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string)'></a>

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

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).client'></a>

`client` [System.Net.Http.HttpClient](https://docs.microsoft.com/en-us/dotnet/api/System.Net.Http.HttpClient 'System.Net.Http.HttpClient')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).contentType'></a>

`contentType` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_,System.Net.Http.HttpClient,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>, System.Net.Http.HttpClient, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool)'></a>

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

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit<T>(this EficazFramework.ViewModels.ViewModel<T>, bool).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).notifyOnSave'></a>

`notifyOnSave` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit<T>(this EficazFramework.ViewModels.ViewModel<T>, bool).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___)'></a>

## ServiceUtils.AddSingledEditDetail<T,D>(this ViewModel<T>, Expression<Func<T,IList<D>>>) Method

Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>> navigationProperty)
    where T : class
    where D : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).D'></a>

`D`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).navigationProperty'></a>

`navigationProperty` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[D](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).D 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).D')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool)'></a>

## ServiceUtils.AddTabular<T>(this ViewModel<T>, bool) Method

Adiciona funções Tracking, Validação e Persistêcia Tabular para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddTabular<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, bool notifyOnSave=true)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabular<T>(this EficazFramework.ViewModels.ViewModel<T>, bool).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).notifyOnSave'></a>

`notifyOnSave` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_,bool).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabular<T>(this EficazFramework.ViewModels.ViewModel<T>, bool).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___)'></a>

## ServiceUtils.AddTabularEditDetail<T,D>(this ViewModel<T>, Expression<Func<T,IList<D>>>) Method

Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>> navigationProperty)
    where T : class
    where D : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).D'></a>

`D`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).navigationProperty'></a>

`navigationProperty` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[D](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).D 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).D')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

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

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.GetService<S,T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[S](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.GetService_S,T_(thisEficazFramework.ViewModels.ViewModel_T_).S 'EficazFramework.ViewModels.Services.ServiceUtils.GetService<S,T>(this EficazFramework.ViewModels.ViewModel<T>).S')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveAudit<T>(this ViewModel<T>) Method

Remove o serviço políticas de acesso e gravação.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveAudit<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveAudit<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveAudit<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[])'></a>

## ServiceUtils.RemoveCustom<T>(this ViewModel<T>, ViewModelService<T>, string[]) Method

Remove um serviço customizado, criado em ambientes externos.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveCustom<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, EficazFramework.ViewModels.Services.ViewModelService<T> service, string[] removeCommandsByKeys)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[]).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[]).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[]).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, EficazFramework.ViewModels.Services.ViewModelService<T>, string[]).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[]).service'></a>

`service` [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[]).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, EficazFramework.ViewModels.Services.ViewModelService<T>, string[]).T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[]).removeCommandsByKeys'></a>

`removeCommandsByKeys` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom_T_(thisEficazFramework.ViewModels.ViewModel_T_,EficazFramework.ViewModels.Services.ViewModelService_T_,string[]).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, EficazFramework.ViewModels.Services.ViewModelService<T>, string[]).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_)'></a>

## ServiceUtils.RemoveDataImport<TSource,TCache>(this ViewModel<TSource>) Method

Remove o serviço de importação ao ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<TSource> RemoveDataImport<TSource,TCache>(this EficazFramework.ViewModels.ViewModel<TSource> viewmodel)
    where TSource : class
    where TCache : EficazFramework.Repositories.DataImportCache;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TSource'></a>

`TSource`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TCache'></a>

`TCache`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[TSource](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TSource 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport<TSource,TCache>(this EficazFramework.ViewModels.ViewModel<TSource>).TSource')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[TSource](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport_TSource,TCache_(thisEficazFramework.ViewModels.ViewModel_TSource_).TSource 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveDataImport<TSource,TCache>(this EficazFramework.ViewModels.ViewModel<TSource>).TSource')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveEntityFramework<T>(this ViewModel<T>) Method

Remove os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : EficazFramework.Entities.EntityBase, EficazFramework.Entities.IEntity;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveGPO<T>(this ViewModel<T>) Method

Remove o serviço políticas de acesso e gravação.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveGPO<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveGPO<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveGPO<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveNavigationByIndex<T>(this ViewModel<T>) Method

Remove o serviço de orientação de navegação da View por Índice de página.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveNavigationByPage<T>(this ViewModel<T>) Method

Remove o serviço de orientação de navegação da View por Índice de página.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveNavigationByPage<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByPage<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByPage<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveRestApi<T>(this ViewModel<T>) Method

Remove os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveRestApi<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : EficazFramework.Entities.EntityBase, EficazFramework.Entities.IEntity;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveRestApi_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveRestApi<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveSingleEdit<T>(this ViewModel<T>) Method

Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveSingleEdit<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveSingleEditDetail<T,D>(this ViewModel<T>) Method

Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveSingleEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class
    where D : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).D'></a>

`D`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveTabular<T>(this ViewModel<T>) Method

Reemove o serviço de Tracking, Validação e Persistêcia Tabular para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveTabular<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.RemoveTabularEditDetail<T,D>(this ViewModel<T>) Method

Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> RemoveTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class
    where D : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).D'></a>

`D`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.WithAudit<T>(this ViewModel<T>) Method

Adiciona o serviço de políticas de acesso e gravação. Adicione após todos os demais serviços.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> WithAudit<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithAudit<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithAudit_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithAudit<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string)'></a>

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

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithGPO<T>(this EficazFramework.ViewModels.ViewModel<T>, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).role'></a>

`role` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithGPO_T_(thisEficazFramework.ViewModels.ViewModel_T_,string).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithGPO<T>(this EficazFramework.ViewModels.ViewModel<T>, string).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_,int,int)'></a>

## ServiceUtils.WithNavigationByIndex<T>(this ViewModel<T>, int, int) Method

Adiciona o serviço de orientação de navegação da View por Índice de página.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> WithNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, int entries=0, int form=1)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_,int,int).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_,int,int).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_,int,int).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T>, int, int).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_,int,int).entries'></a>

`entries` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_,int,int).form'></a>

`form` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex_T_(thisEficazFramework.ViewModels.ViewModel_T_,int,int).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T>, int, int).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_)'></a>

## ServiceUtils.WithNavigationByPage<T>(this ViewModel<T>) Method

Adiciona o serviço de orientação de navegação da View por Índice de página.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> WithNavigationByPage<T>(this EficazFramework.ViewModels.ViewModel<T> viewmodel)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByPage<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils.md#EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByPage_T_(thisEficazFramework.ViewModels.ViewModel_T_).T 'EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByPage<T>(this EficazFramework.ViewModels.ViewModel<T>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')