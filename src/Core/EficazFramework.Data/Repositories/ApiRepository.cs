using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EficazFramework.Repositories;

public sealed class ApiRepository<TEntity> : Repositories.RepositoryBase<TEntity> where TEntity : class
{
    public ApiRepository(HttpClient client) : base()
    {
        _client = client;
        _contentType = contentType;
    }
    private readonly HttpClient _client;

    /// <summary>
    /// URI de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UriGet { get; set; } = "/myRestApi/get";

    /// <summary>
    /// URI de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UriInsert { get; set; } = "/myRestApi/insert";

    /// <summary>s
    /// URI de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UriUpdate { get; set; } = "/myRestApi/update";

    /// <summary>
    /// URI de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UriDelete { get; set; } = "/myRestApi/delete";

    /// <summary>
    /// URI de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public string UriCancel { get; set; } = "/myRestApi/cancel";

    /// <summary>
    /// (Opcional) Instância de DbContext para Tracking de modificações.
    /// NOTA: Não exponha a connection string real nesta instância.
    /// </summary>
    public DbContext TrackingContext { get; set; }



    /// <summary>
    /// método POST base para implementações
    /// </summary>
    private async Task<TResult> PostMethod<TBody, TResult>(string requestUri, TBody content, CancellationToken cancellationToken)
    {
        if (cancellationToken != default && cancellationToken.IsCancellationRequested) return default;
        try
        {
            var response = await _client.PostAsJsonAsync(requestUri, content, cancellationToken);
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
        return await PostMethod<object, ObservableCollection<TEntity>>(UriGet, new { Filter, OrderByDefinitions }, cancellationToken);
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
            var result = await PostMethod<object, string>(UriCancel, item, default);
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

}
