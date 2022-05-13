using EficazFramework.Events;
using EficazFramework.Extensions;
using System;
using System.ComponentModel;

namespace EficazFramework.ViewModels.Services;

/// <summary>
/// Serviço de gravação e/ou cancelamento de alterações para ViewModel
/// </summary>
public class TabularEdit<T> : ViewModelService<T> where T : class
{
    public TabularEdit(ViewModel<T> viewmodel) : base(viewmodel)
    {
        viewmodel.Commands.Add("Save", new Commands.CommandBase(SaveCommand_Executed));
        viewmodel.Commands.Add("Cancel", new Commands.CommandBase(CancelCommand_Executed));
        viewmodel.StateChanged += OnStateChanged;
        ViewModelInstance.ItemsFetching += OnItemsFetching;
        ViewModelInstance.ItemsFetched += OnItemsFetched;
    }

    /// <summary>
    /// Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação.
    /// </summary>
    public bool NotifyOnSave { get; set; } = true;

    /// <summary>
    /// Notifica a View se o comando salvar está habilitado.
    /// </summary>
    public bool CanSave
    {
        get
        {
            return ViewModelInstance.State != Enums.CRUD.State.Bloqueado & ViewModelInstance.State != Enums.CRUD.State.Processando;
        }
    }

    /// <summary>
    /// Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.
    /// </summary>
    public bool CanCancelAsyncSave { get; private set; } = false;

    /// <summary>
    /// Ações do comando Salvar
    /// </summary>
    private async void SaveCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanSave == false)
            return;


        // Saving:
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Saving, ViewModelInstance.State, null);
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
        {
            CancelSave();
            return;
        }


        // Start Async Actions
        ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultSavingMessage);
        var tk = ViewModelInstance.CreatActionToken().Token;
        var tokenregistration = tk.Register(CancelSave);


        // Validate:
        var validation = await ViewModelInstance.Repository.ValidateAsync(null);
        if (validation.Count > 0)
        {
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.Validation.Dialog_Title,
                Content = string.Format(Resources.Strings.Validation.Dialog_Title, Environment.NewLine, validation.ToString())
            });
            var failArgs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryValidationFailed, args.State, args.CurrentEntry);
            failArgs.ValidationErrors.AddRange(validation);
            ViewModelInstance.RaiseViewModelEvent(failArgs);
            ViewModelInstance.SetState(args.State, false, null);
            return;
        }


        // Unlocking Async Cancel
        CanCancelAsyncSave = true;
        RaisePropertyChanged(nameof(CanCancelAsyncSave));
        var ex = await ViewModelInstance.Repository.CommitAsync(tk);
        CanCancelAsyncSave = false;
        RaisePropertyChanged(nameof(CanCancelAsyncSave));

        // Saved (or not):
        ViewModelInstance.SetState(args.State, false, null);
        if (ex is null)
        {
            var savedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Saved, args.State, null);
            ViewModelInstance.RaiseViewModelEvent(savedargs);
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                Type = MessageType.SnackBar,
                IconReference = Events.MessageIcon.Like,
                Title = Resources.Strings.ViewModel.StoreService_SavedSucessfull_Title,
                Content = Resources.Strings.ViewModel.StoreService_SavedSucessfull_Message
            });
        }
        else
        {
            // todo: report message
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.ViewModel.UnhandledError_Title,
                Content = string.Format(Resources.Strings.ViewModel.UnhandledError_Message, ex.Message),
                StackTrace = ex.ToString(),
                EnableReporting = true
            });
        }
        tokenregistration.Unregister();
        await tokenregistration.DisposeAsync();
    }

    /// <summary>
    /// Ações do comando Cancelar
    /// </summary>
    private async void CancelCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Canceled, ViewModelInstance.State, null);
        var ex = await ViewModelInstance.Repository.CancelAsync(null);
        if (ex is null)
        {
            ViewModelInstance.RaiseViewModelEvent(args);
        }
        else
        {
            // todo: report message
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.ViewModel.UnhandledError_Title,
                Content = string.Format(Resources.Strings.ViewModel.UnhandledError_Message, ex.Message),
                StackTrace = ex.ToString(),
                EnableReporting = true
            });
        }
    }

    /// <summary>
    /// Acão ao acionar o cancelamento da operação de gravação assíncrona
    /// </summary>
    public void CancelSave()
    {
        ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
        {
            IconReference = Events.MessageIcon.Warning,
            Title = Resources.Strings.ViewModel.OperationCanceled_Title,
            Content = Resources.Strings.ViewModel.StoreService_SaveCanceled_Message
        });
    }

    /// <summary>
    /// Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel.
    /// </summary>
    private void OnStateChanged(object sender, EventArgs e)
    {
        RaisePropertyChanged(nameof(CanSave));
    }

    /// <summary>
    /// Uma vez que a edição é tabular, é preciso remover o tracking de alterações de propriedades a todos os items da
    /// coleção antiga antes de uma nova pesquisa.
    /// </summary>
    private void OnItemsFetching(object sender, Events.CRUDEventArgs<T> e)
    {
        if (!typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T)))
            return;
        if (ViewModelInstance.Repository.DataContext is null)
            return;
        ViewModelInstance.Repository.DataContext.ForEach((entry) => ((INotifyPropertyChanged)entry).PropertyChanged -= ViewModelInstance.OnEntryPropertyChanged);
    }

    /// <summary>
    /// Uma vez que a edição é tabular, é preciso adicionar o tracking de alterações de propriedades a todos os items da coleção.
    /// </summary>
    private void OnItemsFetched(object sender, Events.CRUDEventArgs<T> e)
    {
        if (!typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T)))
            return;
        if (ViewModelInstance.Repository.DataContext is null)
            return;
        ViewModelInstance.Repository.DataContext.ForEach((entry) => ((INotifyPropertyChanged)entry).PropertyChanged += ViewModelInstance.OnEntryPropertyChanged);
    }

    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        ViewModelInstance.StateChanged -= OnStateChanged;
        ViewModelInstance.ItemsFetching -= OnItemsFetching;
        ViewModelInstance.ItemsFetched -= OnItemsFetched;
        ViewModelInstance.Commands.Remove("Save");
        ViewModelInstance.Commands.Remove("Cancel");
        ViewModelInstance.Services.Remove(ServiceUtils.KEY_TABULAREDIT);
    }
}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona funções Tracking, Validação e Persistêcia Tabular para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> AddTabular<T>(this ViewModel<T> viewmodel, bool notifyOnSave = true) where T : class
    {
        var service = new TabularEdit<T>(viewmodel) { NotifyOnSave = notifyOnSave };
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_TABULAREDIT))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_TABULAREDIT));
        viewmodel._servicesInternal.Add(ServiceUtils.KEY_TABULAREDIT, service);
        if (typeof(Repositories.IEntityRepository).IsAssignableFrom(viewmodel.Repository.GetType()))
        {
            Repositories.IEntityRepository repo = (Repositories.IEntityRepository)viewmodel.GetPropertyValue(nameof(viewmodel.Repository));
            repo.AsNoTracking = false;
        }

        return viewmodel;
    }


    /// <summary>
    /// Reemove o serviço de Tracking, Validação e Persistêcia Tabular para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> RemoveTabular<T>(this ViewModel<T> viewmodel) where T : class
    {
        TabularEdit<T> service = (TabularEdit<T>)viewmodel.Services[ServiceUtils.KEY_TABULAREDIT];
        service.Dispose();
        return viewmodel;
    }

    public static TabularEdit<T> GetTabularEdit<T>(this ViewModel<T> viewmodel) where T : class
    {
        return viewmodel.Services.ContainsKey(KEY_TABULAREDIT) == true ? (TabularEdit<T>)viewmodel.Services[ServiceUtils.KEY_TABULAREDIT] : null;
    }

}
