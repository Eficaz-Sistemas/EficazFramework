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

public sealed class ApiRepository<T> : Repositories.RepositoryBase<T> where T : class
{
    public ApiRepository(HttpClient client) : base()
    {
        _client = client;
        TrackChanges = true;
    }

    private readonly HttpClient _client;

    /// <summary>
    /// Paramêtros para filtragem de dados para pesquisas com POST (body contendo instruções de query dinâmica).
    /// Efetua shadowing de <see cref="RepositoryBase{T}.Filter"/>
    /// </summary>
    public new Expressions.ExpressionQuery Filter { get; set; }

    /// <summary>
    /// URL de requisição para métodos FetchItems() e FetchItemsAsync()
    /// </summary>
    public Func<string> UrlGet { get; set; } = () => "/myRestApi/get";

    /// <summary>
    /// Opção para utilizar uma <see cref="Expressions.ExpressionQuery"/> persinalizada, 
    /// definida em <see cref="Repositories.ApiRepository{T}.Filter"/>
    /// no corpo da requisição da API. Automaticamente o método da requisição será alterado para POST.
    /// <br/>
    /// O padrão é <c>false</c>.
    /// </summary>
    public bool AttachFilterExpressionOnBodyAtGet { get; set; } = false;

    /// <summary>
    /// URL de requisição para método PutAsync()
    /// </summary>
    public Func<T, string> UrlPut { get; set; } = (obj) => "/myRestApi/put";

    /// <summary>s
    /// URL de requisição para método PostAsync()
    /// </summary>
    public Func<T, string> UrlPost { get; set; } = (obj) => "/myRestApi/post";

    /// <summary>
    /// URL de requisição para o método DeleteAsync()
    /// </summary>
    public Func<T, string> UrlDelete { get; set; } = (obj) => "/myRestApi/delete";

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
                Enums.CRUD.RequestAction.Get => await GetAsync<TResult>(requestUri, cancellationToken),
                Enums.CRUD.RequestAction.Post => await PostAsync<TBody, TResult>(requestUri, body, cancellationToken),
                Enums.CRUD.RequestAction.Put => await PutAsync<TBody, TResult>(requestUri, body, cancellationToken),
                Enums.CRUD.RequestAction.Delete => await DeleteAsync<TBody, TResult>(requestUri, cancellationToken),
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
    /// Método GET executado por <see cref="RequestMethod{TBody, TResult}(Enums.CRUD.RequestAction, string, Func{TBody, string}, TBody, CancellationToken)"/>
    /// </summary>
    private async Task<TResult> GetAsync<TResult>(string requestUri,
        CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(requestUri, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            try
            {
                return await response.Content.ReadFromJsonAsync<TResult>(SerializerOptions, cancellationToken);
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
    /// Método POST executado por <see cref="RequestMethod{TBody, TResult}(Enums.CRUD.RequestAction, string, Func{TBody, string}, TBody, CancellationToken)"/>
    /// </summary>
    private async Task<TResult> PostAsync<TBody, TResult>(string requestUri,
        TBody body,
        CancellationToken cancellationToken)
    {
        var response = await _client.PostAsJsonAsync(requestUri, body, SerializerOptions, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            if (_isAdding)
                _isAdding = false;

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
    /// Método PUT executado por <see cref="RequestMethod{TBody, TResult}(Enums.CRUD.RequestAction, string, Func{TBody, string}, TBody, CancellationToken)"/>
    /// </summary>
    private async Task<TResult> PutAsync<TBody, TResult>(string requestUri,
        TBody body,
        CancellationToken cancellationToken)
    {
        var response = await _client.PutAsJsonAsync(requestUri, body, SerializerOptions, cancellationToken);
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
    /// Método DELETE executado por <see cref="RequestMethod{TBody, TResult}(Enums.CRUD.RequestAction, string, Func{TBody, string}, TBody, CancellationToken)"/>
    /// </summary>
    private async Task<TResult> DeleteAsync<TBody, TResult>(string requestUri,
        CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync(requestUri, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            _isDeleting = false;
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
        EficazFramework.Validation.Fluent.ValidationResult result = [];
        result.AddRange(JsonSerializer.Deserialize<string[]>(responseString));
        return result.ToString();
    }

  
    /// <summary>s
    /// Efetua a instrução GET contra o datasource
    /// </summary>
    public override ObservableCollection<T> FetchItems() =>
        FetchItemsAsync(default).Result;

    /// <summary>s
    /// Efetua a instrução GET contra o datasource (OU POST com QueryDescription no corpo)
    /// </summary>
    public override async Task<ObservableCollection<T>> FetchItemsAsync(CancellationToken cancellationToken)
    {
        List<T> result = [];

        var response = await RequestMethod<Expressions.QueryDescription, List<T>>(
            AttachFilterExpressionOnBodyAtGet ? 
                Enums.CRUD.RequestAction.Post : 
                Enums.CRUD.RequestAction.Get, 
            UrlGet.Invoke(),
            AttachFilterExpressionOnBodyAtGet ? 
                new Expressions.QueryDescription(Filter, OrderByDefinitions) :
                null, 
            cancellationToken);

        if (response != null)
            result.AddRange(response as IList<T>);

        TrackingContext?.Dispose();
        TrackingContext = DbContextRequest?.Invoke();
        TrackingContext?.AttachRange(result);
        return result.ToObservableCollection<T>();
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
        _isAdding = false;
        _isDeleting = false;
        
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
                                DataContext.Remove((T)item);
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
                            if (!DataContext.Contains(item) & ReferenceEquals(item.GetType(), typeof(T)))
                                DataContext.Add((T)item);

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
    public override T Create()
    {
        TrackingContext ??= DbContextRequest?.Invoke();
        return Activator.CreateInstance<T>();
    }
    
    /// <summary>
    /// Solicita a criação de uma nova instância de Entidade de Base de Dados
    /// </summary>
    public override T2 Create<T2>()
    {
        TrackingContext ??= DbContextRequest?.Invoke();
        return EficazFramework.Entities.EntityBase.Create<T2>();
    }

    private bool _isAdding = false;
    /// <summary>
    /// Adicina uma nova entidade às intruções INSERT do TrackingContext
    /// </summary>
    /// <param name="item"></param>
    internal override void ItemAdded(object item)
    {
        _isAdding = true;
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
                T response;
                if (_isAdding)
                    response = await RequestMethod<T, T>(Enums.CRUD.RequestAction.Post, UrlPost.Invoke(CurrentEntry), CurrentEntry, cancellationToken);
                else if (_isDeleting)
                    response = await RequestMethod<T, T>(Enums.CRUD.RequestAction.Delete, UrlDelete.Invoke(CurrentEntry), CurrentEntry, cancellationToken);
                else
                    response = await RequestMethod<T, T>(Enums.CRUD.RequestAction.Put, UrlPut.Invoke(CurrentEntry), CurrentEntry, cancellationToken);
            }
            else
            {
                var response = await RequestMethod<List<T>, List<T>>(Enums.CRUD.RequestAction.Post, UrlPost.Invoke(null), DataContext.ToList(), cancellationToken);
            }
            return default;
        }
        catch (Exception ex)
        {
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
        CurrentEntry = item as T;
        
        if (TrackingContext == null)
            return;
        
        TrackingContext?.Remove(item);
    }

    
    /// <summary>
    /// Descartando o estado gerenciado (objetos gerenciados)
    /// </summary>
    internal override void DisposeManagedCallerObjects()
    {
        TrackingContext?.Dispose();
        TrackingContext = null;
    }


    /// <summary>
    /// Evento disparado quando o Repositório precisa de uma nova instância de DbContext.
    /// </summary>
    public Func<Microsoft.EntityFrameworkCore.DbContext> DbContextRequest { get; set; } = null;

}

