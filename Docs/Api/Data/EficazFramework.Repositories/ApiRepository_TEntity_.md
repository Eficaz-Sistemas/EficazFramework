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

| Methods | |
| :--- | :--- |
| [Cancel(object)](EficazFramework.Repositories/ApiRepository_TEntity_/Cancel(object).md 'EficazFramework.Repositories.ApiRepository<TEntity>.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [CancelAsync(object)](EficazFramework.Repositories/ApiRepository_TEntity_/CancelAsync(object).md 'EficazFramework.Repositories.ApiRepository<TEntity>.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [CancelByApiAsync(object)](EficazFramework.Repositories/ApiRepository_TEntity_/CancelByApiAsync(object).md 'EficazFramework.Repositories.ApiRepository<TEntity>.CancelByApiAsync(object)') | Executa o cancelamento da edição por meio da API 'UriCancel' |
| [CancelByDbContextAsync(object)](EficazFramework.Repositories/ApiRepository_TEntity_/CancelByDbContextAsync(object).md 'EficazFramework.Repositories.ApiRepository<TEntity>.CancelByDbContextAsync(object)') | Executa o cancelamento da edição por meio do ChangeTracker da instância DbContext |
| [FetchItems()](EficazFramework.Repositories/ApiRepository_TEntity_/FetchItems().md 'EficazFramework.Repositories.ApiRepository<TEntity>.FetchItems()') | s<br/>            Efetua a instrução GET contra o datasource |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/ApiRepository_TEntity_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.ApiRepository<TEntity>.FetchItemsAsync(System.Threading.CancellationToken)') | s<br/>            Efetua a instrução GET contra o datasource |
| [PostMethod&lt;TBody,TResult&gt;(string, TBody, CancellationToken)](EficazFramework.Repositories/ApiRepository_TEntity_/PostMethod_TBody,TResult_(string,TBody,CancellationToken).md 'EficazFramework.Repositories.ApiRepository<TEntity>.PostMethod<TBody,TResult>(string, TBody, System.Threading.CancellationToken)') | método POST base para implementações |
