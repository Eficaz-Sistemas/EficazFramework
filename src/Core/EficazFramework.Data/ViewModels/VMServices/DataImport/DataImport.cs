using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EficazFramework.ViewModels.Services;

public class DataImport<TSource, TCache> : ViewModelService<TSource>
    where TSource : class
    where TCache : Repositories.DataImportCache
{
    public DataImport(ViewModel<TSource> viewmodel) : base(viewmodel)
    {
        viewmodel.Repository = new Repositories.DataImportRepository<TSource, TCache>();
    }

    #region =========== Dispose
    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        Repositories.DataImportRepository<TSource, TCache> repo = ViewModelInstance.Repository as Repositories.DataImportRepository<TSource, TCache>;
        if (repo == null) return;
        repo.Cache.Clear();
        repo.DataContext.Clear();
        repo.Log.Clear();
        GC.Collect();
    }
    #endregion

}

public static partial class ServiceUtils
{
    /// <summary>
    /// Adiciona o serviço de importação ao ViewModel.
    /// </summary>
    public static ViewModel<TSource> AddDataImport<TSource, TCache>(this ViewModel<TSource> viewmodel)
        where TSource : class
        where TCache : Repositories.DataImportCache
    {
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_DATAIMPORT))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_DATAIMPORT));

        var service = new DataImport<TSource, TCache>(viewmodel);
        viewmodel.Services.Add(ServiceUtils.KEY_DATAIMPORT, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove o serviço de importação ao ViewModel.
    /// </summary>
    public static ViewModel<TSource> RemoveDataImport<TSource, TCache>(this ViewModel<TSource> viewmodel)
        where TSource : class
        where TCache : Repositories.DataImportCache
    {
        DataImport<TSource, TCache> service = (DataImport<TSource, TCache>)viewmodel.Services[ServiceUtils.KEY_DATAIMPORT];
        service.Dispose();
        return viewmodel;
    }
}
