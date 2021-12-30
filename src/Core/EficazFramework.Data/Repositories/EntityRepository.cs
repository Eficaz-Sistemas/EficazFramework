using EficazFramework.Entities;
using EficazFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Repositories;

public sealed class EntityRepository<TEntity> : Repositories.RepositoryBase<TEntity> where TEntity : EficazFramework.Entities.EntityBase, IEntity
{
    /// <summary>
    /// Expressão IIncludable para JOINs
    /// </summary>
    public List<System.Linq.Expressions.Expression<Func<TEntity, object>>> Includes { get; private set; } = new List<System.Linq.Expressions.Expression<Func<TEntity, object>>>();

    /// <summary>
    /// Instância de DbContext do EntityFrameworkCore
    /// </summary>
    public Microsoft.EntityFrameworkCore.DbContext DbContext { get; private set; } = null;

    /// <summary>
    /// Obtém ou define se as queries de FetchItems() e FetchItemsAsync() devem usar o sufixo .AsNoTracking() 
    /// para obter ganho de performance pelo não-monitoramento de alterações de valores nas entidades.
    /// O valor inicial padrão é TRUE.
    /// </summary>
    public bool AsNoTrackking { get; set; } = true;

    /// <summary>
    /// Informa ao DbContext os tipo de entidades que não devem ser monitorados pelo ChangeTracker.
    /// Evita marcar entidades desconectadas como .Added().
    /// </summary>
    public List<Type> TrackingIgnores { get; } = new List<Type>();

    /// <summary>
    /// Obtém ou define se o Repositório deve executar uma função customizada em FetchItems e FetchItemsAsync.
    /// </summary>
    /// <example>
    /// repository.CustomFetch = () => mySource.Take(5).ToList();
    /// </example>
    public Func<Task<IEnumerable<TEntity>>> CustomFetch { get; set; }


    /// <summary>s
    /// Efetua a instrução SELECT contra a base de dados
    /// </summary>
    /// <returns></returns>
    public override System.Collections.ObjectModel.ObservableCollection<TEntity> FetchItems()
    {
        if (CustomFetch != null)
        {
            PrepareDbContext();
            return CustomFetch.Invoke().GetAwaiter().GetResult().ToAsyncObservableCollection();
        }
        var query = PrepareQuery();
        var result = query.ToList();
        return result.ToAsyncObservableCollection();
    }

    /// <summary>
    /// Efetua a instrução SELECT contra a base de dados
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<System.Collections.ObjectModel.ObservableCollection<TEntity>> FetchItemsAsync(System.Threading.CancellationToken cancellationToken)
    {
        if (cancellationToken != default && cancellationToken.IsCancellationRequested) return new System.Collections.ObjectModel.ObservableCollection<TEntity>();
        try
        {
            if (CustomFetch != null)
            {
                PrepareDbContext();
                cancellationToken.ThrowIfCancellationRequested();
                return (await CustomFetch.Invoke()).ToAsyncObservableCollection();
            }
            var query = PrepareQuery();
            var result = await query.ToListAsync(cancellationToken);
            return result.ToAsyncObservableCollection();
        }
        catch (OperationCanceledException tkex)
        {
            Console.WriteLine(tkex.ToString());
            return new System.Collections.ObjectModel.ObservableCollection<TEntity>();
        }
    }

    /// <summary>
    /// Solicita a criação de uma nova instância de Entidade de Base de Dados
    /// </summary>
    /// <returns></returns>
    public override TEntity Create()
    {
        if (DbContext is null)
            PrepareDbContext();
        return EficazFramework.Entities.EntityBase.Create<TEntity>();
    }

    /// <summary>
    /// Solicita a criação de uma nova instância de Entidade de Base de Dados
    /// </summary>
    /// <returns></returns>
    public override T2 Create<T2>() where T2 : class
    {
        if (DbContext is null)
            PrepareDbContext();
        return EficazFramework.Entities.EntityBase.Create<T2>();
    }

    /// <summary>
    /// Adicina uma nova entidade às intruções INSERT do DbContext
    /// </summary>
    internal override void ItemAdded(object item)
    {
        if (DbContext is null)
            PrepareDbContext();
        DbContext.Add(item);
    }

    /// <summary>
    /// Adicina uma nova entidade às intruções DELETE do DbContext
    /// </summary>
    internal override void ItemDeleted(object item)
    {
        if (item == null) return;
        if (DbContext is null)
            PrepareDbContext();
        DbContext.Remove(item);
    }


    /// <summary>
    /// Executa as instruções de persistência do DbContext
    /// </summary>
    /// <returns></returns>
    public override Exception Commit()
    {
        try
        {
            foreach (EntityEntry it in DbContext.ChangeTracker.Entries().Where(e => TrackingIgnores.Contains(e.Entity.GetType())))
            {
                it.State = EntityState.Unchanged;
            }
            DbContext.SaveChanges();
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Executa as instruções de persistência do DbContext
    /// </summary>
    public override async Task<Exception> CommitAsync(System.Threading.CancellationToken cancelationToken)
    {
        try
        {
            foreach (EntityEntry it in DbContext.ChangeTracker.Entries().Where(e => TrackingIgnores.Contains(e.Entity.GetType())))
            {
                it.State = EntityState.Unchanged;
            }
            await DbContext.SaveChangesAsync(cancelationToken);
            return null;
        }
        catch (Exception ex)
        {
            var teste = DbContext.ChangeTracker.Entries().ToList();
            return ex;
        }
    }

    /// <summary>
    /// Solicita o cancelamento das alterações efetuadas no argumento item.
    /// Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext
    /// </summary>
    public override Exception Cancel(object item)
    {
        try
        {
            if (item != null)
            {
                EficazFramework.Entities.EntityBase entity = (EficazFramework.Entities.EntityBase)item;
                var entry = DbContext.ChangeTracker.Entries().SingleOrDefault(e => e.Entity == item);
                if (entry == null) return null;
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            entry.State = EntityState.Detached;
                            if (DataContext.Contains(item))
                                DataContext.Remove((TEntity)item);
                            break;
                        }

                    case EntityState.Modified:
                        {
                            entry.State = EntityState.Unchanged;
                            entity.ReportPropertyChanged(null);
                            break;
                        }

                    case EntityState.Deleted:
                        {
                            if (entry.Entity is EficazFramework.Entities.EntityBase)
                            {
                                if (entity.IsNew)
                                {
                                    entry.State = EntityState.Detached;
                                }
                                else
                                {
                                    entry.State = EntityState.Unchanged;
                                    if (!DataContext.Contains(item) & ReferenceEquals(item.GetType(), typeof(TEntity)))
                                        DataContext.Add((TEntity)item);
                                }
                            }

                            break;
                        }
                }
            }
            else
            {
                foreach (var entry in DbContext.ChangeTracker.Entries().ToList())
                {
                    var ex = Cancel(entry.Entity);
                    if (ex != null)
                        return ex;
                }
            }

            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    /// <summary>
    /// Solicita o cancelamento das alterações efetuadas no argumento item.
    /// Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext
    /// </summary>
    public override async Task<Exception> CancelAsync(object item)
    {
        var ex = await Task.Run(() => Cancel(item));
        return ex;
    }

    /// <summary>
    /// Desconecta a instância de EntityBase do monitoramento de alterações (ChangeTracking) do
    /// DbContext
    /// </summary>
    public override void Detach(object item)
    {
        var entry = DbContext.ChangeTracker.Entries().Where((it) => it.Entity == item).FirstOrDefault();
        if (entry != null) entry.State = EntityState.Detached;
    }

    /// <summary>
    /// Descartando o estado gerenciado (objetos gerenciados)
    /// </summary>
    internal override void DisposeManagedCallerObjects()
    {
        if (Includes != null) Includes.Clear();
        if (TrackingIgnores != null) TrackingIgnores.Clear();
        if (OrderByDefinitions != null) OrderByDefinitions.Clear();
        if (DbContext != null) DbContext.Dispose();
        DbContext = null;
    }

    /// <summary>
    /// Aciona o evento DbContextInstanceRequest possibilitando a passagem de uma instância de DbContext ao repositório
    /// </summary>
    public void PrepareDbContext()
    {
        var args = new Events.DbContextInstanceCreatingEventArgs();
        DbContextInstanceRequest?.Invoke(this, args);
        DbContext = args.Instance;
    }

    /// <summary>
    /// Obtém uma instância de query ordenável (instrução ORDER BY em T-SQL) do tipo IOrderedQueryable.
    /// </summary>
    /// <param name="query">Instância IQueryable principal, contendo instruções SELECT e WHERE (esta última opcional).</param>
    /// <param name="orderbyDefinition">Definições de ordenação (SortDescription).</param>
    /// <param name="use_thenby">Define se deve ser utilizado o método ThenBy, para multiciplidade de ocorrências de ordenação.</param>
    /// <returns></returns>
    private static IQueryable<TEntity> GetIOrderedQueryable(IQueryable<TEntity> query, Collections.SortDescription orderbyDefinition, bool use_thenby = false)
    {
        var t = typeof(TEntity);
        var parameter = System.Linq.Expressions.Expression.Parameter(t, "p");
        var propertyReference = System.Linq.Expressions.Expression.Property(parameter, orderbyDefinition.PropertyName);
        object sortExpression;
        var propType = typeof(TEntity).GetProperty(orderbyDefinition.PropertyName).PropertyType;
        if (orderbyDefinition.Direction == EficazFramework.Enums.Collection.SortOrientation.Asceding)
        {
            sortExpression = System.Linq.Expressions.Expression.Call(typeof(Queryable), !use_thenby ? "OrderBy" : "ThenBy", new Type[] { t, propType }, query.Expression, System.Linq.Expressions.Expression.Lambda(propertyReference, parameter));
        }
        else
        {
            sortExpression = System.Linq.Expressions.Expression.Call(typeof(Queryable), !use_thenby ? "OrderByDescending" : "ThenByDescending", new Type[] { t, propType }, query.Expression, System.Linq.Expressions.Expression.Lambda(propertyReference, parameter));
        }

        var result = query.Provider.CreateQuery((System.Linq.Expressions.Expression)sortExpression);
        return (IQueryable<TEntity>)result;
    }

    /// <summary>
    /// Elabora a criação da instância IQueryable(Of TEntity) para execução contra a base de dados.
    /// </summary>
    /// <returns></returns>
    private IQueryable<TEntity> PrepareQuery()
    {
        PrepareDbContext();
        IQueryable<TEntity> query = DbContext.Set<TEntity>();
        foreach (var iincludable in Includes)
            query = query.Include(iincludable);
        if (Filter != null)
            query = query.Where(Filter);
        for (int i = 0, loopTo = OrderByDefinitions.Count - 1; i <= loopTo; i++)
        {
            if (i == 0)
                query = GetIOrderedQueryable(query, OrderByDefinitions[i]);
            else
                query = GetIOrderedQueryable(query, OrderByDefinitions[i], true);
        }

        if (PageSize > 0)
            query = query.Skip((CurrentPage - 1) * PageSize).Take(PageSize);

        if (AsNoTrackking == true)
            query = query.AsNoTracking();

        return query;
    }

    /// <summary>
    /// Executa comando com query bruta em string, sem parâmetros nem retorno de resultado.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task RunCommandAsync(string command)
    {
        PrepareDbContext();
        System.Data.Common.DbCommand cmd = DbContext.Database.GetDbConnection().CreateCommand();
        cmd.CommandText = command;
        cmd.CommandTimeout = int.MaxValue;
        if (DbContext.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
            await DbContext.Database.GetDbConnection().OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }


    /// <summary>
    /// Evento disparado quando o Repositório precisa de uma nova instância de DbContext.
    /// </summary>
    public event Events.DbContextInstanceCreatingEventHandler DbContextInstanceRequest;
}
