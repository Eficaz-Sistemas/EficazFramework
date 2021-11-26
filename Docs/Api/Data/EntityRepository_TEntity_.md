#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories')
## EntityRepository&lt;TEntity&gt; Class
```csharp
public sealed class EntityRepository<TEntity> : EficazFramework.Repositories.RepositoryBase<TEntity>
    where TEntity : EficazFramework.Entities.EntityBase, EficazFramework.Entities.IEntity
```
#### Type parameters
<a name='EficazFramework_Repositories_EntityRepository_TEntity__TEntity'></a>
`TEntity`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;')[TEntity](EntityRepository_TEntity_.md#EficazFramework_Repositories_EntityRepository_TEntity__TEntity 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.TEntity')[&gt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;') &#129106; EntityRepository&lt;TEntity&gt;  

| Properties | |
| :--- | :--- |
| [AsNoTrackking](EntityRepository_TEntity__AsNoTrackking.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.AsNoTrackking') | Obtém ou define se as queries de FetchItems() e FetchItemsAsync() devem usar o sufixo .AsNoTracking() <br/>para obter ganho de performance pelo não-monitoramento de alterações de valores nas entidades.<br/>O valor inicial padrão é TRUE.<br/> |
| [CustomFetch](EntityRepository_TEntity__CustomFetch.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.CustomFetch') | Obtém ou define se o Repositório deve executar uma função customizada em FetchItems e FetchItemsAsync.<br/> |
| [DbContext](EntityRepository_TEntity__DbContext.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.DbContext') | Instância de DbContext do EntityFrameworkCore<br/> |
| [Includes](EntityRepository_TEntity__Includes.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.Includes') | Expressão IIncludable para JOINs<br/> |
| [TrackingIgnores](EntityRepository_TEntity__TrackingIgnores.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.TrackingIgnores') | Informa ao DbContext os tipo de entidades que não devem ser monitorados pelo ChangeTracker.<br/>Evita marcar entidades desconectadas como .Added().<br/> |

| Methods | |
| :--- | :--- |
| [Cancel(object)](EntityRepository_TEntity__Cancel(object).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext<br/> |
| [CancelAsync(object)](EntityRepository_TEntity__CancelAsync(object).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext<br/> |
| [Commit()](EntityRepository_TEntity__Commit().md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.Commit()') | Executa as instruções de persistência do DbContext<br/> |
| [CommitAsync(CancellationToken)](EntityRepository_TEntity__CommitAsync(CancellationToken).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.CommitAsync(System.Threading.CancellationToken)') | Executa as instruções de persistência do DbContext<br/> |
| [Create()](EntityRepository_TEntity__Create().md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.Create()') | Solicita a criação de uma nova instância de Entidade de Base de Dados<br/> |
| [Create&lt;T2&gt;()](EntityRepository_TEntity__Create_T2_().md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.Create&lt;T2&gt;()') | Solicita a criação de uma nova instância de Entidade de Base de Dados<br/> |
| [Detach(object)](EntityRepository_TEntity__Detach(object).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.Detach(object)') | Desconecta a instância de EntityBase do monitoramento de alterações (ChangeTracking) do<br/>DbContext<br/> |
| [DisposeManagedCallerObjects()](EntityRepository_TEntity__DisposeManagedCallerObjects().md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.DisposeManagedCallerObjects()') | Descartando o estado gerenciado (objetos gerenciados)<br/> |
| [FetchItems()](EntityRepository_TEntity__FetchItems().md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.FetchItems()') | s<br/>            Efetua a instrução SELECT contra a base de dados<br/>             |
| [FetchItemsAsync(CancellationToken)](EntityRepository_TEntity__FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.FetchItemsAsync(System.Threading.CancellationToken)') | Efetua a instrução SELECT contra a base de dados<br/> |
| [GetIOrderedQueryable(IQueryable&lt;TEntity&gt;, SortDescription, bool)](EntityRepository_TEntity__GetIOrderedQueryable(IQueryable_TEntity__SortDescription_bool).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.GetIOrderedQueryable(System.Linq.IQueryable&lt;TEntity&gt;, EficazFramework.Collections.SortDescription, bool)') | Obtém uma instância de query ordenável (instrução ORDER BY em T-SQL) do tipo IOrderedQueryable.<br/> |
| [ItemAdded(object)](EntityRepository_TEntity__ItemAdded(object).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.ItemAdded(object)') | Adicina uma nova entidade às intruções INSERT do DbContext<br/> |
| [ItemDeleted(object)](EntityRepository_TEntity__ItemDeleted(object).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.ItemDeleted(object)') | Adicina uma nova entidade às intruções DELETE do DbContext<br/> |
| [PrepareDbContext()](EntityRepository_TEntity__PrepareDbContext().md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.PrepareDbContext()') | Aciona o evento DbContextInstanceRequest possibilitando a passagem de uma instância de DbContext ao repositório<br/> |
| [PrepareQuery()](EntityRepository_TEntity__PrepareQuery().md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.PrepareQuery()') | Elabora a criação da instância IQueryable(Of TEntity) para execução contra a base de dados.<br/> |
| [RunCommandAsync(string)](EntityRepository_TEntity__RunCommandAsync(string).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.RunCommandAsync(string)') | Executa comando com query bruta em string, sem parâmetros nem retorno de resultado.<br/> |
| [Validate(TEntity)](EntityRepository_TEntity__Validate(TEntity).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.Validate(TEntity)') | Efetua Validação da instância especificada ou das entidades marcadas como alteradas no ChangeTracker do DbContext<br/> |
| [ValidateAsync(TEntity)](EntityRepository_TEntity__ValidateAsync(TEntity).md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.ValidateAsync(TEntity)') | Efetua Validação da instância especificada ou das entidades marcadas como alteradas no ChangeTracker do DbContext<br/> |

| Events | |
| :--- | :--- |
| [DbContextInstanceRequest](EntityRepository_TEntity__DbContextInstanceRequest.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;.DbContextInstanceRequest') | Evento disparado quando o Repositório precisa de uma nova instância de DbContext.<br/> |
