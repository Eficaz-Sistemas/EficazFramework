#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories')

## EntityRepository<TEntity> Class

```csharp
public sealed class EntityRepository<TEntity> : EficazFramework.Repositories.RepositoryBase<TEntity>,
EficazFramework.Repositories.IEntityRepository
    where TEntity : EficazFramework.Entities.EntityBase, EficazFramework.Entities.IEntity
```
#### Type parameters

<a name='EficazFramework.Repositories.EntityRepository_TEntity_.TEntity'></a>

`TEntity`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>')[TEntity](EficazFramework.Repositories/EntityRepository_TEntity_.md#EficazFramework.Repositories.EntityRepository_TEntity_.TEntity 'EficazFramework.Repositories.EntityRepository<TEntity>.TEntity')[&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>') &#129106; EntityRepository<TEntity>

Implements [IEntityRepository](EficazFramework.Repositories/IEntityRepository.md 'EficazFramework.Repositories.IEntityRepository')

| Properties | |
| :--- | :--- |
| [AsNoTracking](EficazFramework.Repositories/EntityRepository_TEntity_/AsNoTracking.md 'EficazFramework.Repositories.EntityRepository<TEntity>.AsNoTracking') | Obtém ou define se as queries de FetchItems() e FetchItemsAsync() devem usar o sufixo .AsNoTracking() <br/>para obter ganho de performance pelo não-monitoramento de alterações de valores nas entidades.<br/>O valor inicial padrão é TRUE. |
| [CustomFetch](EficazFramework.Repositories/EntityRepository_TEntity_/CustomFetch.md 'EficazFramework.Repositories.EntityRepository<TEntity>.CustomFetch') | Obtém ou define se o Repositório deve executar uma função customizada em FetchItems e FetchItemsAsync. |
| [DbContext](EficazFramework.Repositories/EntityRepository_TEntity_/DbContext.md 'EficazFramework.Repositories.EntityRepository<TEntity>.DbContext') | Instância de DbContext do EntityFrameworkCore |
| [DbContextRequest](EficazFramework.Repositories/EntityRepository_TEntity_/DbContextRequest.md 'EficazFramework.Repositories.EntityRepository<TEntity>.DbContextRequest') | Evento disparado quando o Repositório precisa de uma nova instância de DbContext. |
| [Includes](EficazFramework.Repositories/EntityRepository_TEntity_/Includes.md 'EficazFramework.Repositories.EntityRepository<TEntity>.Includes') | Expressão IIncludable para JOINs |
| [TrackingIgnores](EficazFramework.Repositories/EntityRepository_TEntity_/TrackingIgnores.md 'EficazFramework.Repositories.EntityRepository<TEntity>.TrackingIgnores') | Informa ao DbContext os tipo de entidades que não devem ser monitorados pelo ChangeTracker.<br/>Evita marcar entidades desconectadas como .Added(). |

| Methods | |
| :--- | :--- |
| [Cancel(object)](EficazFramework.Repositories/EntityRepository_TEntity_/Cancel(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [CancelAsync(object)](EficazFramework.Repositories/EntityRepository_TEntity_/CancelAsync(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [Commit()](EficazFramework.Repositories/EntityRepository_TEntity_/Commit().md 'EficazFramework.Repositories.EntityRepository<TEntity>.Commit()') | Executa as instruções de persistência do DbContext |
| [CommitAsync(CancellationToken)](EficazFramework.Repositories/EntityRepository_TEntity_/CommitAsync(CancellationToken).md 'EficazFramework.Repositories.EntityRepository<TEntity>.CommitAsync(System.Threading.CancellationToken)') | Executa as instruções de persistência do DbContext |
| [Create()](EficazFramework.Repositories/EntityRepository_TEntity_/Create().md 'EficazFramework.Repositories.EntityRepository<TEntity>.Create()') | Solicita a criação de uma nova instância de Entidade de Base de Dados |
| [Create&lt;T2&gt;()](EficazFramework.Repositories/EntityRepository_TEntity_/Create_T2_().md 'EficazFramework.Repositories.EntityRepository<TEntity>.Create<T2>()') | Solicita a criação de uma nova instância de Entidade de Base de Dados |
| [Detach(object)](EficazFramework.Repositories/EntityRepository_TEntity_/Detach(object).md 'EficazFramework.Repositories.EntityRepository<TEntity>.Detach(object)') | Desconecta a instância de EntityBase do monitoramento de alterações (ChangeTracking) do<br/>DbContext |
| [FetchItems()](EficazFramework.Repositories/EntityRepository_TEntity_/FetchItems().md 'EficazFramework.Repositories.EntityRepository<TEntity>.FetchItems()') | s<br/>            Efetua a instrução SELECT contra a base de dados |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/EntityRepository_TEntity_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.EntityRepository<TEntity>.FetchItemsAsync(System.Threading.CancellationToken)') | Efetua a instrução SELECT contra a base de dados |
| [PrepareDbContext()](EficazFramework.Repositories/EntityRepository_TEntity_/PrepareDbContext().md 'EficazFramework.Repositories.EntityRepository<TEntity>.PrepareDbContext()') | Aciona [DbContextRequest](EficazFramework.Repositories/EntityRepository_TEntity_/DbContextRequest.md 'EficazFramework.Repositories.EntityRepository<TEntity>.DbContextRequest') possibilitando a passagem de uma instância de DbContext ao repositório |
| [RunCommandAsync(string)](EficazFramework.Repositories/EntityRepository_TEntity_/RunCommandAsync(string).md 'EficazFramework.Repositories.EntityRepository<TEntity>.RunCommandAsync(string)') | Executa comando com query bruta em string, sem parâmetros nem retorno de resultado. |
