using System;
using System.Collections.Generic;
using System.Text;

namespace EficazFramework.ViewModels.Services;

class EfCore<T> : ViewModelService<T> where T : Entities.EntityBase, Entities.IEntity
{

    public EfCore(ViewModel<T> viewmodel) : base(viewmodel)
    {
        viewmodel.Repository = new Repositories.EntityRepository<T>();
    }

}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.
    /// </summary>
    public static ViewModel<T> AddEntityFramework<T>(this ViewModel<T> viewmodel) where T : Entities.EntityBase, Entities.IEntity
    {
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_EFCORE))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_EFCORE));

        var service = new EfCore<T>(viewmodel);
        viewmodel.Services.Add(ServiceUtils.KEY_EFCORE, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais.
    /// </summary>
    public static ViewModel<T> RemoveEntityFramework<T>(this ViewModel<T> viewmodel) where T : Entities.EntityBase, Entities.IEntity
    {
        EfCore<T> service = (EfCore<T>)viewmodel.Services[ServiceUtils.KEY_EFCORE];
        service.Dispose();
        return viewmodel;
    }
}
