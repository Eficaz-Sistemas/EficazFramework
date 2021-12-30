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

### Example
repository.CustomFetch = () => mySource.Take(5).ToList();

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

| Methods | |
| :--- | :--- |
| [Cancel(object)](EficazFramework.Repositories/EntityRepository_TEntity_/Cancel(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [CancelAsync(object)](EficazFramework.Repositories/EntityRepository_TEntity_/CancelAsync(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [Commit()](EficazFramework.Repositories/EntityRepository_TEntity_/Commit().md 'EficazFramework.Repositories.EntityRepository<TEntity>.Commit()') | Executa as instruções de persistência do DbContext |
| [CommitAsync(CancellationToken)](EficazFramework.Repositories/EntityRepository_TEntity_/CommitAsync(CancellationToken).md 'EficazFramework.Repositories.EntityRepository<TEntity>.CommitAsync(System.Threading.CancellationToken)') | Executa as instruções de persistência do DbContext |
| [Create()](EficazFramework.Repositories/EntityRepository_TEntity_/Create().md 'EficazFramework.Repositories.EntityRepository<TEntity>.Create()') | Solicita a criação de uma nova instância de Entidade de Base de Dados |
| [Create&lt;T2&gt;()](EficazFramework.Repositories/EntityRepository_TEntity_/Create_T2_().md 'EficazFramework.Repositories.EntityRepository<TEntity>.Create<T2>()') | Solicita a criação de uma nova instância de Entidade de Base de Dados |
| [Detach(object)](EficazFramework.Repositories/EntityRepository_TEntity_/Detach(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.Detach(object)') | Desconecta a instância de EntityBase do monitoramento de alterações (ChangeTracking) do<br/>DbContext |
| [DisposeManagedCallerObjects()](EficazFramework.Repositories/EntityRepository_TEntity_/DisposeManagedCallerObjects().md 'EficazFramework.Repositories.EntityRepository<TEntity>.DisposeManagedCallerObjects()') | Descartando o estado gerenciado (objetos gerenciados) |
| [FetchItems()](EficazFramework.Repositories/EntityRepository_TEntity_/FetchItems().md 'EficazFramework.Repositories.EntityRepository<TEntity>.FetchItems()') | s<br/>            Efetua a instrução SELECT contra a base de dados |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/EntityRepository_TEntity_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.EntityRepository<TEntity>.FetchItemsAsync(System.Threading.CancellationToken)') | Efetua a instrução SELECT contra a base de dados |
| [GetIOrderedQueryable(IQueryable&lt;TEntity&gt;, SortDescription, bool)](EficazFramework.Repositories/EntityRepository_TEntity_/GetIOrderedQueryable(IQueryable_TEntity_,SortDescription,bool).md 'EficazFramework.Repositories.EntityRepository<TEntity>.GetIOrderedQueryable(System.Linq.IQueryable<TEntity>, EficazFramework.Collections.SortDescription, bool)') | Obtém uma instância de query ordenável (instrução ORDER BY em T-SQL) do tipo IOrderedQueryable. |
| [ItemAdded(object)](EficazFramework.Repositories/EntityRepository_TEntity_/ItemAdded(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.ItemAdded(object)') | Adicina uma nova entidade às intruções INSERT do DbContext |
| [ItemDeleted(object)](EficazFramework.Repositories/EntityRepository_TEntity_/ItemDeleted(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.ItemDeleted(object)') | Adicina uma nova entidade às intruções DELETE do DbContext |
| [PrepareDbContext()](EficazFramework.Repositories/EntityRepository_TEntity_/PrepareDbContext().md 'EficazFramework.Repositories.EntityRepository<TEntity>.PrepareDbContext()') | Aciona o evento DbContextInstanceRequest possibilitando a passagem de uma instância de DbContext ao repositório |
| [PrepareQuery()](EficazFramework.Repositories/EntityRepository_TEntity_/PrepareQuery().md 'EficazFramework.Repositories.EntityRepository<TEntity>.PrepareQuery()') | Elabora a criação da instância IQueryable(Of TEntity) para execução contra a base de dados. |
| [RunCommandAsync(string)](EficazFramework.Repositories/EntityRepository_TEntity_/RunCommandAsync(string).md 'EficazFramework.Repositories.EntityRepository<TEntity>.RunCommandAsync(string)') | Executa comando com query bruta em string, sem parâmetros nem retorno de resultado. |
### Events

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.DbContextInstanceRequest'></a>

## EntityRepository<TEntity>.DbContextInstanceRequest Event

Evento disparado quando o Repositório precisa de uma nova instância de DbContext.

```csharp
public event DbContextInstanceCreatingEventHandler DbContextInstanceRequest;
```

#### Event Type
[EficazFramework.Events.DbContextInstanceCreatingEventHandler](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.DbContextInstanceCreatingEventHandler 'EficazFramework.Events.DbContextInstanceCreatingEventHandler')