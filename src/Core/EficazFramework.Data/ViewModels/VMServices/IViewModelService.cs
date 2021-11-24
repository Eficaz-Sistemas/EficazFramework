using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace EficazFramework.ViewModels.Services;

public abstract class ViewModelService<T> : IDisposable, INotifyPropertyChanged where T : class
{
    private bool disposedValue;

    public ViewModelService(ViewModel<T> viewmodel)
    {
        if (viewmodel is null)
            throw new ArgumentNullException(nameof(viewmodel));
        ViewModelInstance = viewmodel;
    }

    public ViewModel<T> ViewModelInstance { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Notifica às views que houve alteração em alguma propriedade do ViewModel
    /// </summary>
    /// <param name="propertyName">Nome da propriedade que deve notificar a View para atualização de Binding</param>
    public void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                DisposeManagedCallerObjects();
            }

            // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
            // Tarefa pendente: definir campos grandes como nulos
            DisposeUnManagedCallerObjects();
            disposedValue = true;
        }
    }

    // ' Tarefa pendente: substituir o finalizador somente se 'Dispose(disposing As Boolean)' tiver o código para liberar recursos não gerenciados
    // Protected Overrides Sub Finalize()
    // ' Não altere este código. Coloque o código de limpeza no método 'Dispose(disposing As Boolean)'
    // Dispose(disposing:=False)s
    // MyBase.Finalize()
    // End Sub

    public void Dispose()
    {
        // Não altere este código. Coloque o código de limpeza no método 'Dispose(disposing As Boolean)'
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
    /// </summary>
    internal virtual void DisposeManagedCallerObjects()
    {
    }

    /// <summary>
    /// Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
    /// Tarefa pendente: definir campos grandes como nulos
    /// </summary>
    internal virtual void DisposeUnManagedCallerObjects()
    {
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public static partial class ServiceUtils
{

    /// <summary>
    /// Known Services by EficazFramework.Data
    /// </summary>
    public const string KEY_AUDIT = "Audit";
    public const string KEY_EFCORE = "EntityFrameworkCore";
    public const string KEY_REST = "RestApi";
    public const string KEY_GPO = "GPO";
    public const string KEY_DATAIMPORT = "DataImport";
    public const string KEY_INDEXVIEWNAVIGATOR = "IndexViewNavigator";
    public const string KEY_PAGEDVIEWNAVIGATOR = "PagedViewNavigator";
    public const string KEY_SINGLEEDIT = "SingleEdit";
    public const string KEY_TABULAREDIT = "TabularEdit";
    public const string KEY_SINGLEEDITDETAIL = "SingleEditDetail";
    public const string KEY_TABULAREDITDETAIL = "TabularEditDetail";


    /// <summary>
    /// Retorna a instancia de serviço pelo tipo S especificado
    /// </summary>
    public static S GetService<S, T>(this ViewModel<T> viewmodel)
        where T : class
        where S : ViewModelService<T>
    {
        return (S)viewmodel.Services.Where((svc) => svc.Value is S).Select((svc) => svc.Value).FirstOrDefault();
    }

    /// <summary>
    /// Adiciona um serviço customizado, criado em ambientes externos.
    /// </summary>
    public static ViewModel<T> AddCustom<T>(this ViewModel<T> viewmodel, string name, ViewModelService<T> service) where T : class
    {
        var stype = service.GetType();
        if (viewmodel.Services.Where(f => object.ReferenceEquals(f.GetType(), stype)).Count() > 0)
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, stype.Name));
        viewmodel._servicesInternal.Add(name, service);
        return viewmodel;
    }

    /// <summary>
    /// Remove um serviço customizado, criado em ambientes externos.
    /// </summary>
    public static ViewModel<T> RemoveCustom<T>(this ViewModel<T> viewmodel, ViewModelService<T> service, string[] removeCommandsByKeys) where T : class
    {
        foreach (var cmdkey in removeCommandsByKeys)
            viewmodel.Commands.Remove(cmdkey);
        string entrykey = viewmodel.Services.Where(f => object.ReferenceEquals(f.GetType(), service.GetType())).FirstOrDefault().Key;
        viewmodel._servicesInternal.Remove(entrykey);
        service.Dispose();
        return viewmodel;
    }
}
