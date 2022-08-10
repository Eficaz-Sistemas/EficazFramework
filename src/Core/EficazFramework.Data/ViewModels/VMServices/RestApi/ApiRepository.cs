using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EficazFramework.ViewModels.Services;

class RestApi<T> : ViewModelService<T> where T : class
{
    public RestApi(ViewModel<T> viewmodel, HttpClient client, RestApiBuilderOptions options = null) : base(viewmodel)
    {
        var repo = new Repositories.ApiRepository<T>(client);
        if (options != null)
        {
            repo.UrlGet = options.UrlGet;
        }
        viewmodel.Repository = repo;
    }
}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.
    /// </summary>
    public static ViewModel<T> AddRestApi<T>(this ViewModel<T> viewmodel, HttpClient client) where T : class
    {
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_REST))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_REST));

        var service = new RestApi<T>(viewmodel, client);
        viewmodel.Services.Add(ServiceUtils.KEY_REST, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.
    /// </summary>
    public static ViewModel<T> RemoveRestApi<T>(this ViewModel<T> viewmodel) where T : Entities.EntityBase, Entities.IEntity
    {
        RestApi<T> service = (RestApi<T>)viewmodel.Services[ServiceUtils.KEY_REST];
        service.Dispose();
        return viewmodel;
    }
}

public class RestApiBuilderOptions
{
    public string UrlGet { get; set; }
    
}
