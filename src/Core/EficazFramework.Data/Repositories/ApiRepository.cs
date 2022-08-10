using EficazFramework.Expressions;
using EficazFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace EficazFramework.Repositories;

public sealed class ApiRepository<TEntity> : Repositories.RepositoryBase<TEntity> where TEntity : class
{
    public ApiRepository(HttpClient client) : base() =>
        _client = client;
    
    private readonly HttpClient _client;

    /// <summary>
    /// URL de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UrlGet { get; set; } = "/myRestApi/get";

    /// <summary>
    /// URL de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UrlInsert { get; set; } = "/myRestApi/insert";

    /// <summary>s
    /// URL de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UrlUpdate { get; set; } = "/myRestApi/update";

    /// <summary>
    /// URL de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UrlDelete { get; set; } = "/myRestApi/delete";

    /// <summary>
    /// URL de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UrlCancel { get; set; } = "/myRestApi/cancel";

    /// <summary>
    /// (Opcional) Instância de DbContext para Tracking de modificações.
    /// NOTA: Não exponha a connection string real nesta instância.
    /// </summary>
    public Microsoft.EntityFrameworkCore.DbContext TrackingContext { get; set; }



    /// <summary>
    /// método POST base para implementações
    /// </summary>
    public async Task<TResult> PostMethod<TBody, TResult>(string requestUri, TBody body, CancellationToken cancellationToken)
    {
        if (cancellationToken != default && cancellationToken.IsCancellationRequested) return default;
        try
        {
            var response = await _client.PostAsJsonAsync(requestUri, body, cancellationToken);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<TResult>(new System.Text.Json.JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }
        catch (TaskCanceledException tkex)
        {
            Debug.WriteLine(tkex.ToString());
            return default;
        }
        return default;
    }


    /// <summary>
    /// Paramêtros para filtragem de dados.
    /// Efetua shadowing de <see cref="RepositoryBase{T}.Filter"/>
    /// </summary>
    public new Expressions.ExpressionQuery Filter { get; set; }


    /// <summary>s
    /// Efetua a instrução GET contra o datasource
    /// </summary>
    public override ObservableCollection<TEntity> FetchItems()
    {
        return FetchItemsAsync(default).Result;
    }

    /// <summary>s
    /// Efetua a instrução GET contra o datasource
    /// </summary>
    public override async Task<ObservableCollection<TEntity>> FetchItemsAsync(CancellationToken cancellationToken)
    {
        List<TEntity> result = new();
        var response = await PostMethod<object, List<TEntity>>(UrlGet, new GetSchema(Filter, OrderByDefinitions), cancellationToken);
        if (response != null)
            result.AddRange(response as IList<TEntity>);

        TrackingContext?.Dispose();
        TrackingContext = DbContextRequest?.Invoke();
        TrackingContext?.AttachRange(result);
        return result.ToObservableCollection<TEntity>();
    }

    /// <summary>
    /// Solicita o cancelamento das alterações efetuadas no argumento item.
    /// Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext
    /// </summary>
    public override Exception Cancel(object item)
    {
        return CancelAsync(item).Result;
    }

    /// <summary>
    /// Solicita o cancelamento das alterações efetuadas no argumento item.
    /// Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext
    /// </summary>
    public override async Task<Exception> CancelAsync(object item)
    {
        if (TrackingContext != null)
            return await CancelByDbContextAsync(item);
        else
            return await CancelByApiAsync(item);
    }

    /// <summary>
    /// Executa o cancelamento da edição por meio do ChangeTracker da instância DbContext
    /// </summary>
    private async Task<Exception> CancelByDbContextAsync(object item)
    {
        try
        {
            if (item != null)
            {
                var entity = item as EficazFramework.Entities.EntityBase;
                var entry = TrackingContext.ChangeTracker.Entries().SingleOrDefault(e => e.Entity == item);
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
                            entity?.ReportPropertyChanged(null);
                            break;
                        }

                    case EntityState.Deleted:
                        {
                            entry.State = EntityState.Unchanged;
                            if (!DataContext.Contains(item) & ReferenceEquals(item.GetType(), typeof(TEntity)))
                                DataContext.Add((TEntity)item);

                            break;
                        }
                }
            }
            else
            {
                foreach (var entry in TrackingContext.ChangeTracker.Entries().ToList())
                {
                    var ex = await CancelAsync(entry.Entity);
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
    /// Executa o cancelamento da edição por meio da API 'UriCancel'
    /// </summary>
    private async Task<Exception> CancelByApiAsync(object item)
    {
        try
        {
            var result = await PostMethod<object, string>(UrlCancel, item, default);
            return null;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }














    public override Exception Commit()
    {
        throw new NotImplementedException();
    }

    public override Task<Exception> CommitAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }



    public override TEntity Create()
    {
        throw new NotImplementedException();
    }

    public override T2 Create<T2>()
    {
        throw new NotImplementedException();
    }



    public override void Detach(object item)
    {
        throw new NotImplementedException();
    }

    internal override void ItemAdded(object item)
    {
        throw new NotImplementedException();
    }

    internal override void ItemDeleted(object item)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Evento disparado quando o Repositório precisa de uma nova instância de DbContext.
    /// </summary>
    public Func<Microsoft.EntityFrameworkCore.DbContext> DbContextRequest { get; set; } = null;

}

public class GetSchema
{
    [JsonConstructor]
    public GetSchema()
    { }
    
    public GetSchema(Expressions.ExpressionQuery filter, IEnumerable<Collections.SortDescription> orderBy)
    {
        Filter = filter;
        OrderBy.AddRange(orderBy);
    }
    
    public Expressions.ExpressionQuery Filter { get; set; } = null;
    public List<Collections.SortDescription> OrderBy { get; set; } = new();
}
