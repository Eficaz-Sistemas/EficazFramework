using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EficazFramework.ViewModels.Services;

public class Audit<T> : ViewModelService<T> where T : class
{
    public Audit(ViewModel<T> viewmodel) : base(viewmodel)
    {
        viewmodel.ViewModelAction += this.OnViewModelAction;
    }

    /// <summary>
    /// Monitora a mudança de estado do ViewModel.
    /// </summary>
    private void OnViewModelAction(object sender, Events.CRUDEventArgs<T> e)
    {
        switch (e.Action)
        {

            case Enums.CRUD.Action.Saving:
                {
                    //collect changes
                    if (e.State == Enums.CRUD.State.Novo)
                    {
                    }
                    else if (e.State == Enums.CRUD.State.Edicao)
                    {
                    }

                    break;
                }

            case Enums.CRUD.Action.Saved:
                {
                    //apply to log
                    if (e.State == Enums.CRUD.State.Novo)
                    {
                    }
                    else if (e.State == Enums.CRUD.State.Edicao)
                    {
                    }

                    break;
                }
        }
    }
    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        this.ViewModelInstance.ViewModelAction -= this.OnViewModelAction;
        this.ViewModelInstance.Services.Remove(ServiceUtils.KEY_AUDIT);
    }
}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona o serviço de políticas de acesso e gravação. Adicione após todos os demais serviços.
    /// </summary>
    public static ViewModel<T> WithAudit<T>(this ViewModel<T> viewmodel) where T : class
    {
        if (!typeof(Repositories.IAuditableRepository).IsAssignableFrom(viewmodel.Repository.GetType()))
            throw new InvalidCastException(Resources.Strings.Validation.NotAuditableRepository);
        var service = new Audit<T>(viewmodel);
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_AUDIT))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_AUDIT));
        viewmodel.Services.Add(ServiceUtils.KEY_AUDIT, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove o serviço políticas de acesso e gravação.
    /// </summary>
    public static ViewModel<T> RemoveAudit<T>(this ViewModel<T> viewmodel) where T : class
    {
        Audit<T> service = (Audit<T>)viewmodel.Services[ServiceUtils.KEY_AUDIT];
        service.Dispose();
        return viewmodel;
    }
}
