﻿using EficazFramework.Entities;
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
            repo.UrlGet = optionsInstance.UrlGet;
            repo.GetQueryFunc = optionsInstance.GetQueryFunc;
            repo.UrlPut = optionsInstance.UrlPut;
            repo.UrlPost = optionsInstance.UrlPost;
            repo.UrlDelete = optionsInstance.UrlDelete;
            repo.DeleteQueryFunc = optionsInstance.DeleteQueryFunc;
            repo.GetRequestMode = optionsInstance.GetRequestMode;
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

public class RestApiBuilderOptions<T> where T : class
{
    public string UrlGet { get; set; }
    public Func<T, string> GetQueryFunc { get; set; }
    public string UrlPut { get; set; }
    public string UrlPost { get; set; }
    public string UrlDelete { get; set; }
    public Func<T, string> DeleteQueryFunc { get; set; }
    public Enums.CRUD.RequestAction GetRequestMode { get; set; } = Enums.CRUD.RequestAction.Get;
}
