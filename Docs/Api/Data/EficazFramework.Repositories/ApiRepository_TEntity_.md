#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories')

## ApiRepository<TEntity> Class

```csharp
public sealed class ApiRepository<TEntity> : EficazFramework.Repositories.RepositoryBase<TEntity>
    where TEntity : class
```
#### Type parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.TEntity'></a>

`TEntity`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>')[TEntity](EficazFramework.Repositories/ApiRepository_TEntity_.md#EficazFramework.Repositories.ApiRepository_TEntity_.TEntity 'EficazFramework.Repositories.ApiRepository<TEntity>.TEntity')[&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>') &#129106; ApiRepository<TEntity>
### Properties

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.TrackingContext'></a>

## ApiRepository<TEntity>.TrackingContext Property

(Opcional) Instância de DbContext para Tracking de modificações.  
NOTA: Não exponha a connection string real nesta instância.

```csharp
public Microsoft.EntityFrameworkCore.DbContext TrackingContext { get; set; }
```

#### Property Value
[Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.UriCancel'></a>

## ApiRepository<TEntity>.UriCancel Property

URI de requisição para métodos FetchItems() e FetchItemsAsync()

```csharp
public string UriCancel { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.UriDelete'></a>

## ApiRepository<TEntity>.UriDelete Property

URI de requisição para métodos FetchItems() e FetchItemsAsync()

```csharp
public string UriDelete { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.UriGet'></a>

## ApiRepository<TEntity>.UriGet Property

URI de requisição para métodos FetchItems() e FetchItemsAsync()

```csharp
public string UriGet { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.UriInsert'></a>

## ApiRepository<TEntity>.UriInsert Property

URI de requisição para métodos FetchItems() e FetchItemsAsync()

```csharp
public string UriInsert { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.UriUpdate'></a>

## ApiRepository<TEntity>.UriUpdate Property

s  
            URI de requisição para métodos FetchItems() e FetchItemsAsync()

```csharp
public string UriUpdate { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.Cancel(object)'></a>

## ApiRepository<TEntity>.Cancel(object) Method

Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext

```csharp
public override System.Exception Cancel(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.Cancel(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.CancelAsync(object)'></a>

## ApiRepository<TEntity>.CancelAsync(object) Method

Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext

```csharp
public override System.Threading.Tasks.Task<System.Exception> CancelAsync(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.CancelAsync(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.CancelByApiAsync(object)'></a>

## ApiRepository<TEntity>.CancelByApiAsync(object) Method

Executa o cancelamento da edição por meio da API 'UriCancel'

```csharp
private System.Threading.Tasks.Task<System.Exception> CancelByApiAsync(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.CancelByApiAsync(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.CancelByDbContextAsync(object)'></a>

## ApiRepository<TEntity>.CancelByDbContextAsync(object) Method

Executa o cancelamento da edição por meio do ChangeTracker da instância DbContext

```csharp
private System.Threading.Tasks.Task<System.Exception> CancelByDbContextAsync(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.CancelByDbContextAsync(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.FetchItems()'></a>

## ApiRepository<TEntity>.FetchItems() Method

s  
            Efetua a instrução GET contra o datasource

```csharp
public override System.Collections.ObjectModel.ObservableCollection<TEntity> FetchItems();
```

#### Returns
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[TEntity](EficazFramework.Repositories/ApiRepository_TEntity_.md#EficazFramework.Repositories.ApiRepository_TEntity_.TEntity 'EficazFramework.Repositories.ApiRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.FetchItemsAsync(System.Threading.CancellationToken)'></a>

## ApiRepository<TEntity>.FetchItemsAsync(CancellationToken) Method

s  
            Efetua a instrução GET contra o datasource

```csharp
public override System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<TEntity>> FetchItemsAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.FetchItemsAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[TEntity](EficazFramework.Repositories/ApiRepository_TEntity_.md#EficazFramework.Repositories.ApiRepository_TEntity_.TEntity 'EficazFramework.Repositories.ApiRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken)'></a>

## ApiRepository<TEntity>.PostMethod<TBody,TResult>(string, TBody, CancellationToken) Method

método POST base para implementações

```csharp
private System.Threading.Tasks.Task<TResult> PostMethod<TBody,TResult>(string requestUri, TBody content, System.Threading.CancellationToken cancellationToken);
```
#### Type parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken).TBody'></a>

`TBody`

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken).TResult'></a>

`TResult`
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken).requestUri'></a>

`requestUri` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken).content'></a>

`content` [TBody](EficazFramework.Repositories/ApiRepository_TEntity_.md#EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken).TBody 'EficazFramework.Repositories.ApiRepository<TEntity>.PostMethod<TBody,TResult>(string, TBody, System.Threading.CancellationToken).TBody')

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](EficazFramework.Repositories/ApiRepository_TEntity_.md#EficazFramework.Repositories.ApiRepository_TEntity_.PostMethod_TBody,TResult_(string,TBody,System.Threading.CancellationToken).TResult 'EficazFramework.Repositories.ApiRepository<TEntity>.PostMethod<TBody,TResult>(string, TBody, System.Threading.CancellationToken).TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')