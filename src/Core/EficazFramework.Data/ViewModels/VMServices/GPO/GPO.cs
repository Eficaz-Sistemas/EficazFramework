using System;
using System.Collections.Generic;

namespace EficazFramework.ViewModels.Services;

public class GPO<T> : ViewModelService<T> where T : class
{
    public GPO(ViewModel<T> viewmodel, string role) : base(viewmodel)
    {
        GPOROLE = role;
        viewmodel.ViewModelAction += this.OnViewModelAction;
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public string GPOROLE { get; private set; } = null;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Monitora a mudança de estado do ViewModel.
    /// </summary>
    private void OnViewModelAction(object sender, Events.CRUDEventArgs<T> e)
    {
        if (string.IsNullOrEmpty(GPOROLE)) { GPOROLE = typeof(T).ToString(); }
        System.Guid role = System.Guid.Empty;
        switch (e.Action)
        {
            case Enums.CRUD.Action.DataFetching:
            case Enums.CRUD.Action.EntryEditing:
                role = Security.CommonRoleGUIDs.SELECT_OR_READ;
                break;

            case Enums.CRUD.Action.EntryAdding:
                role = Security.CommonRoleGUIDs.ADD;
                break;

            case Enums.CRUD.Action.Saving:
                if (e.State == Enums.CRUD.State.Novo)
                    role = Security.CommonRoleGUIDs.ADD;

                else if (e.State == Enums.CRUD.State.Edicao)
                    role = Security.CommonRoleGUIDs.EDIT;

                break;

            case Enums.CRUD.Action.EntryDeleting:
                role = Security.CommonRoleGUIDs.DELETE;
                break;

        }

        if (role == System.Guid.Empty)
            return;
        if (Security.GPO.EnsureAccess(GPOROLE, role) == false)
        {
            e.Cancel = true;
            e.ValidationErrors.Add(Resources.Strings.Security.GPO_AccessViolationMessage);
            var dialogargs = new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.Security.GPO_AccessViolationHeader,
                Content = Resources.Strings.Security.GPO_AccessViolationMessage
            };
            this.ViewModelInstance.RaiseDialogMessage(dialogargs);
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        this.ViewModelInstance.ViewModelAction -= this.OnViewModelAction;
        this.ViewModelInstance.Services.Remove(ServiceUtils.KEY_GPO);
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona o serviço de políticas de acesso e gravação. Adicione após todos os demais serviços.
    /// </summary>
    public static ViewModel<T> WithGPO<T>(this ViewModel<T> viewmodel, string role) where T : class
    {
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_GPO))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_GPO));

        if (String.IsNullOrEmpty(role)) { role = typeof(T).ToString(); }
        var service = new GPO<T>(viewmodel, role);
        viewmodel.Services.Add(ServiceUtils.KEY_GPO, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove o serviço políticas de acesso e gravação.
    /// </summary>
    public static ViewModel<T> RemoveGPO<T>(this ViewModel<T> viewmodel) where T : class
    {
        GPO<T> service = (GPO<T>)viewmodel.Services[ServiceUtils.KEY_GPO];
        service.Dispose();
        return viewmodel;
    }
}
