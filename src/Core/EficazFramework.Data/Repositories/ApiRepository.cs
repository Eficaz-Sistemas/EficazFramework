using EficazFramework.Expressions;
using EficazFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace EficazFramework.Repositories;

public sealed class ApiRepository<TEntity> : Repositories.RepositoryBase<TEntity> where TEntity : EficazFramework.Entities.EntityBase, IEntity
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
    /// Obtém ou define as definições para serialização Json nas requisições contra o servidor Http.
    /// </summary>
    public JsonSerializerOptions SerializerOptions { get; set;} = default;

    /// <summary>
    /// (Opcional) Instância de DbContext para Tracking de modificações.
    /// NOTA: Não exponha a connection string real nesta instância.
    /// </summary>
    public Microsoft.EntityFrameworkCore.DbContext TrackingContext { get; set; }


    /// <summary>
    /// Request base para implementações
    /// </summary>
    public async Task<TResult> RequestMethod<TBody, TResult>(Enums.CRUD.RequestAction action,
        string requestUri, 
        TBody body, 
        CancellationToken cancellationToken)
    {
        if (cancellationToken != default && cancellationToken.IsCancellationRequested) return default;
        try
        {
            return action switch
            {
                Enums.CRUD.RequestAction.Get => await PostAsync<TBody, TResult>(requestUri, body, cancellationToken),
                Enums.CRUD.RequestAction.Post => await PostAsync<TBody, TResult>(requestUri, body, cancellationToken),
                Enums.CRUD.RequestAction.Put => await PostAsync<TBody, TResult>(requestUri, body, cancellationToken),
                _ => default
            };
        }
        catch (TaskCanceledException tkex)
        {
            Debug.WriteLine(tkex.ToString());
            return default;
        }
    }

    /// <summary>
    /// Método Post executado por <see cref="RequestMethod{TBody, TResult}(Enums.CRUD.RequestAction, string, TBody, CancellationToken)"/>
    /// </summary>
    private async Task<TResult> PostAsync<TBody, TResult>(string requestUri,
        TBody body,
        CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync(requestUri, body, SerializerOptions, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            try
            {
                return await response.Content.ReadFromJsonAsync<TResult>(new System.Text.Json.JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                }, cancellationToken);
            }
            catch
            {
                return default;
            }
        }
        else
        {
            string responseResult = await response.Content.ReadAsStringAsync(cancellationToken);
            

            throw response.StatusCode switch
            {
                System.Net.HttpStatusCode.Unauthorized => new UnauthorizedAccessException(Resources.Strings.Security.GPO_AccessViolationMessage),
                System.Net.HttpStatusCode.Forbidden => new UnauthorizedAccessException(Resources.Strings.Security.GPO_AccessViolationMessage),
                System.Net.HttpStatusCode.UnprocessableEntity => new ValidationException(ParseValidationFromResponseString(responseResult)),
                _ => new HttpRequestException(string.Format(Resources.Strings.ViewModel.UnhandledError_Message, response.ReasonPhrase)),
            };
        }
    }

    /// <summary>
    /// Extrai os erros de validação do Http Response.
    /// </summary>
    /// <param name="responseString"></param>
    /// <returns></returns>
    private static string ParseValidationFromResponseString(string responseString)
    {
        var jsonParse = JsonDocument.Parse(responseString);
        var jsonFilter = jsonParse.RootElement
                            .GetProperty("errors")
                            .GetRawText();

        EficazFramework.Validation.Fluent.ValidationResult result = new();
        result.AddRange(JsonSerializer.Deserialize<Dictionary<string, string[]>>(jsonFilter).First().Value.ToList());
        return result.ToString();
    }

    
    /// <summary>
    /// Paramêtros para filtragem de dados.
    /// Efetua shadowing de <see cref="RepositoryBase{T}.Filter"/>
    /// </summary>
    public new Expressions.ExpressionQuery Filter { get; set; }

    /// <summary>s
    /// Efetua a instrução GET contra o datasource
    /// </summary>
    public override ObservableCollection<TEntity> FetchItems() =>
        FetchItemsAsync(default).Result;
    
    /// <summary>s
    /// Efetua a instrução GET contra o datasource
    /// </summary>
    public override async Task<ObservableCollection<TEntity>> FetchItemsAsync(CancellationToken cancellationToken)
    {
        List<TEntity> result = new();
        var response = await RequestMethod<Expressions.QueryDescription, List<TEntity>>(Enums.CRUD.RequestAction.Post, UrlGet, new Expressions.QueryDescription(Filter, OrderByDefinitions), cancellationToken);
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
    public override Exception Cancel(object item) =>
        CancelAsync(item).Result;
    
    /// <summary>
    /// Solicita o cancelamento das alterações efetuadas no argumento item.
    /// Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext
    /// </summary>
    public override async Task<Exception> CancelAsync(object item)
    {
        if (TrackingContext != null)
            return await CancelByDbContextAsync(item);
        else
            try
            {
                CancelByCustomHandler?.Invoke(item);
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
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
    /// Executa o cancelamento da edição por meio de uma Custom Action
    /// </summary>
    private Action<object> CancelByCustomHandler { get; set; } = default;

    /// <summary>
    /// Desanexa uma entidade da instância de <see cref="TrackingContext"/>, caso nao seja nula.
    /// </summary>
    public override void Detach(object item)
    {
        if (TrackingContext == null)
            return;
        
        var entry = TrackingContext.ChangeTracker.Entries().Where((it) => it.Entity == item).FirstOrDefault();
        if (entry != null) entry.State = EntityState.Detached;
    }

    
    /// <summary>
    /// Solicita a criação de uma nova instância de Entidade de Base de Dados
    /// </summary>
    public override TEntity Create()
    {
        if (TrackingContext == null)
            TrackingContext = DbContextRequest?.Invoke();

        return EficazFramework.Entities.EntityBase.Create<TEntity>();
    }
    
    /// <summary>
    /// Solicita a criação de uma nova instância de Entidade de Base de Dados
    /// </summary>
    public override T2 Create<T2>()
    {
        if (TrackingContext == null)
            TrackingContext = DbContextRequest?.Invoke();

        return EficazFramework.Entities.EntityBase.Create<T2>();
    }

    /// <summary>
    /// Adicina uma nova entidade às intruções INSERT do TrackingContext
    /// </summary>
    /// <param name="item"></param>
    internal override void ItemAdded(object item)
    {
        if (TrackingContext == null)
            return;
        
        TrackingContext?.Add(item);
    }


    /// <summary>
    /// Executa as instruções de persistência do Servidor
    /// </summary>
    public override Exception Commit() =>
        CommitAsync(default).Result;
    
    /// <summary>
    /// Executa as instruções de persistência do Servidor
    /// </summary>
    public override async Task<Exception> CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (CurrentEntry != null)
            {
                if (CurrentEntry.IsNew)
                    var response = await RequestMethod<TEntity, TEntity>(Enums.CRUD.RequestAction.Post, UrlInsert, CurrentEntry, cancellationToken);
                else if (_isDeleting)
                    var response = await RequestMethod<TEntity, TEntity>(Enums.CRUD.RequestAction.Post, UrlDelete, CurrentEntry, cancellationToken);
                else
                    var response = await RequestMethod<TEntity, TEntity>(Enums.CRUD.RequestAction.Post, UrlUpdate, CurrentEntry, cancellationToken);
                
            }
            else
            {
                var response = await RequestMethod<List<TEntity>, List<TEntity>>(Enums.CRUD.RequestAction.Post, UrlUpdate, DataContext.ToList(), cancellationToken);
            }
            _isDeleting = false;
            return default;
        }
        catch (Exception ex)
        {
            _isDeleting = false;
            return ex;
        }
    }

    private bool _isDeleting = false;
    /// <summary>
    /// Adicina uma nova entidade às intruções DELETE do TrackingContext
    /// </summary>
    /// <param name="item"></param>
    internal override void ItemDeleted(object item)
    {
        _isDeleting = true;
        CurrentEntry = item;
        
        if (TrackingContext == null)
            return;
        
        TrackingContext?.Remove(item);
    }

    
    /// <summary>
    /// Descartando o estado gerenciado (objetos gerenciados)
    /// </summary>
    internal override void DisposeManagedCallerObjects()
    {
        if (TrackingContext != null) TrackingContext.Dispose();
        TrackingContext = null;
    }


    /// <summary>
    /// Evento disparado quando o Repositório precisa de uma nova instância de DbContext.
    /// </summary>
    public Func<Microsoft.EntityFrameworkCore.DbContext> DbContextRequest { get; set; } = null;

}

