using EficazFramework.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EficazFramework.ViewModels.Services;

class RestApi<T> : ViewModelService<T> where T : class
{
    public RestApi(ViewModel<T> viewmodel, HttpClient client, Action<RestApiBuilderOptions<T>> options = null) : base(viewmodel)
    {
        var repo = new Repositories.ApiRepository<T>(client);

        if (options != null)
        {
            RestApiBuilderOptions<T> optionsInstance = new();
            options.Invoke(optionsInstance);

            // GET
            repo.UrlGet = optionsInstance.GetOptions.UrlExpr;
            repo.AttachFilterExpressionOnBodyAtGet = optionsInstance.GetOptions.AttachFilterExpressionOnBodyAtGet;

            repo.UrlPut = optionsInstance.UrlPut;
            repo.UrlPost = optionsInstance.UrlPost;
            repo.UrlDelete = optionsInstance.UrlDelete;
        }
        viewmodel.Repository = repo;
    }
}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona os serviços de operações CRUD via API's REST.
    /// </summary>
    public static ViewModel<T> AddRestApi<T>(this ViewModel<T> viewmodel, HttpClient client, Action<RestApiBuilderOptions<T>> options = null) where T : class
    {
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_REST))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_REST));

        var service = new RestApi<T>(viewmodel, client, options);
        viewmodel.Services.Add(ServiceUtils.KEY_REST, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove os serviços de operações CRUD via API's REST.
    /// </summary>
    public static ViewModel<T> RemoveRestApi<T>(this ViewModel<T> viewmodel) where T : class
    {
        RestApi<T> service = (RestApi<T>)viewmodel.Services[ServiceUtils.KEY_REST];
        service.Dispose();
        return viewmodel;
    }
}

public sealed class RestApiBuilderOptions<T> where T : class
{
    /// <summary>
    /// Used to fecth data from the API. Generally used for GET requests, with list results.
    /// </summary>
    public RestApiBuilderFetchOptions<T> GetOptions { get; set; } = new();
    public Func<T, string> UrlPut { get; set; }
    public Func<T, string> UrlPost { get; set; }
    public Func<T, string> UrlDelete { get; set; }
}


public sealed class RestApiBuilderFetchOptions<T> where T : class
{
    /// <summary>
    /// The URL to fetch data from the API. Use an expression to build the URL dynamically.
    /// <br/>
    /// Ex: <b>()</b> => $"api/endpoint<b>?value1={myvalue1}&value2={myvalue2}</b>"
    /// </summary>
    public Func<string> UrlExpr { get; set; }

    /// <summary>
    /// Option to use a custom <see cref="Expressions.ExpressionQuery"/> defined in <see cref="Repositories.ApiRepository{T}.Filter"/>
    /// on the request body of the API. It will  change the request method to POST.
    /// <br/>
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool AttachFilterExpressionOnBodyAtGet { get; set; } = false;
}