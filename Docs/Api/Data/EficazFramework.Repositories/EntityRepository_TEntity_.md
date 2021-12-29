#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories')

## EntityRepository<TEntity> Class

```csharp
public sealed class EntityRepository<TEntity> : EficazFramework.Repositories.RepositoryBase<TEntity>
    where TEntity : EficazFramework.Entities.EntityBase, EficazFramework.Entities.IEntity
```
#### Type parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.TEntity'></a>

`TEntity`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>') &#129106; EntityRepository<TEntity>
### Properties

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.AsNoTrackking'></a>

## EntityRepository<TEntity>.AsNoTrackking Property

Obtém ou define se as queries de FetchItems() e FetchItemsAsync() devem usar o sufixo .AsNoTracking()   
para obter ganho de performance pelo não-monitoramento de alterações de valores nas entidades.  
O valor inicial padrão é TRUE.

```csharp
public bool AsNoTrackking { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.CustomFetch'></a>

## EntityRepository<TEntity>.CustomFetch Property

Obtém ou define se o Repositório deve executar uma função customizada em FetchItems e FetchItemsAsync.

```csharp
public System.Func<System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<TEntity>>> CustomFetch { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.DbContext'></a>

## EntityRepository<TEntity>.DbContext Property

Instância de DbContext do EntityFrameworkCore

```csharp
public Microsoft.EntityFrameworkCore.DbContext DbContext { get; set; }
```

#### Property Value
[Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContext 'Microsoft.EntityFrameworkCore.DbContext')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Includes'></a>

## EntityRepository<TEntity>.Includes Property

Expressão IIncludable para JOINs

```csharp
public System.Collections.Generic.List<System.Linq.Expressions.Expression<System.Func<TEntity,object>>> Includes { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.TrackingIgnores'></a>

## EntityRepository<TEntity>.TrackingIgnores Property

Informa ao DbContext os tipo de entidades que não devem ser monitorados pelo ChangeTracker.  
Evita marcar entidades desconectadas como .Added().

```csharp
public System.Collections.Generic.List<System.Type> TrackingIgnores { get; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')
### Methods

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Cancel(object)'></a>

## EntityRepository<TEntity>.Cancel(object) Method

Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext

```csharp
public override System.Exception Cancel(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Cancel(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.CancelAsync(object)'></a>

## EntityRepository<TEntity>.CancelAsync(object) Method

Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext

```csharp
public override System.Threading.Tasks.Task<System.Exception> CancelAsync(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.CancelAsync(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Commit()'></a>

## EntityRepository<TEntity>.Commit() Method

Executa as instruções de persistência do DbContext

```csharp
public override System.Exception Commit();
```

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.CommitAsync(System.Threading.CancellationToken)'></a>

## EntityRepository<TEntity>.CommitAsync(CancellationToken) Method

Executa as instruções de persistência do DbContext

```csharp
public override System.Threading.Tasks.Task<System.Exception> CommitAsync(System.Threading.CancellationToken cancelationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.CommitAsync(System.Threading.CancellationToken).cancelationToken'></a>

`cancelationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Create()'></a>

## EntityRepository<TEntity>.Create() Method

Solicita a criação de uma nova instância de Entidade de Base de Dados

```csharp
public override TEntity Create();
```

#### Returns
[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Create_T2_()'></a>

## EntityRepository<TEntity>.Create<T2>() Method

Solicita a criação de uma nova instância de Entidade de Base de Dados

```csharp
public override T2 Create<T2>()
    where T2 : class;
```
#### Type parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Create_T2_().T2'></a>

`T2`

#### Returns
[T2](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.Create_T2_().T2 'EficazFramework.Repositories.EntityRepository<TEntity>.Create<T2>().T2')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Detach(object)'></a>

## EntityRepository<TEntity>.Detach(object) Method

Desconecta a instância de EntityBase do monitoramento de alterações (ChangeTracking) do  
DbContext

```csharp
public override void Detach(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.Detach(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.DisposeManagedCallerObjects()'></a>

## EntityRepository<TEntity>.DisposeManagedCallerObjects() Method

Descartando o estado gerenciado (objetos gerenciados)

```csharp
internal override void DisposeManagedCallerObjects();
```

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.FetchItems()'></a>

## EntityRepository<TEntity>.FetchItems() Method

s  
            Efetua a instrução SELECT contra a base de dados

```csharp
public override System.Collections.ObjectModel.ObservableCollection<TEntity> FetchItems();
```

#### Returns
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.FetchItemsAsync(System.Threading.CancellationToken)'></a>

## EntityRepository<TEntity>.FetchItemsAsync(CancellationToken) Method

Efetua a instrução SELECT contra a base de dados

```csharp
public override System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<TEntity>> FetchItemsAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.FetchItemsAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.GetIOrderedQueryable(System.Linq.IQueryable_TEntity_,EficazFramework.Collections.SortDescription,bool)'></a>

## EntityRepository<TEntity>.GetIOrderedQueryable(IQueryable<TEntity>, SortDescription, bool) Method

Obtém uma instância de query ordenável (instrução ORDER BY em T-SQL) do tipo IOrderedQueryable.

```csharp
private static System.Linq.IQueryable<TEntity> GetIOrderedQueryable(System.Linq.IQueryable<TEntity> query, EficazFramework.Collections.SortDescription orderbyDefinition, bool use_thenby=false);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.GetIOrderedQueryable(System.Linq.IQueryable_TEntity_,EficazFramework.Collections.SortDescription,bool).query'></a>

`query` [System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')

Instância IQueryable principal, contendo instruções SELECT e WHERE (esta última opcional).

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.GetIOrderedQueryable(System.Linq.IQueryable_TEntity_,EficazFramework.Collections.SortDescription,bool).orderbyDefinition'></a>

`orderbyDefinition` [EficazFramework.Collections.SortDescription](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.SortDescription 'EficazFramework.Collections.SortDescription')

Definições de ordenação (SortDescription).

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.GetIOrderedQueryable(System.Linq.IQueryable_TEntity_,EficazFramework.Collections.SortDescription,bool).use_thenby'></a>

`use_thenby` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se deve ser utilizado o método ThenBy, para multiciplidade de ocorrências de ordenação.

#### Returns
[System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.ItemAdded(object)'></a>

## EntityRepository<TEntity>.ItemAdded(object) Method

Adicina uma nova entidade às intruções INSERT do DbContext

```csharp
internal override void ItemAdded(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.ItemAdded(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.ItemDeleted(object)'></a>

## EntityRepository<TEntity>.ItemDeleted(object) Method

Adicina uma nova entidade às intruções DELETE do DbContext

```csharp
internal override void ItemDeleted(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.ItemDeleted(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.PrepareDbContext()'></a>

## EntityRepository<TEntity>.PrepareDbContext() Method

Aciona o evento DbContextInstanceRequest possibilitando a passagem de uma instância de DbContext ao repositório

```csharp
public void PrepareDbContext();
```

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.PrepareQuery()'></a>

## EntityRepository<TEntity>.PrepareQuery() Method

Elabora a criação da instância IQueryable(Of TEntity) para execução contra a base de dados.

```csharp
private System.Linq.IQueryable<TEntity> PrepareQuery();
```

#### Returns
[System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.RunCommandAsync(string)'></a>

## EntityRepository<TEntity>.RunCommandAsync(string) Method

Executa comando com query bruta em string, sem parâmetros nem retorno de resultado.

```csharp
public System.Threading.Tasks.Task RunCommandAsync(string command);
```
#### Parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.RunCommandAsync(string).command'></a>

`command` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')
### Events

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.DbContextInstanceRequest'></a>

## EntityRepository<TEntity>.DbContextInstanceRequest Event

Evento disparado quando o Repositório precisa de uma nova instância de DbContext.

```csharp
public event DbContextInstanceCreatingEventHandler DbContextInstanceRequest;
```

#### Event Type
[EficazFramework.Events.DbContextInstanceCreatingEventHandler](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.DbContextInstanceCreatingEventHandler 'EficazFramework.Events.DbContextInstanceCreatingEventHandler')