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
        viewmodel.StateChanged += this.OnStateChanged;
        this.ViewModelInstance.ItemsFetching += this.OnItemsFetching;
        this.ViewModelInstance.ItemsFetched += this.OnItemsFetched;
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
            return this.ViewModelInstance.State != Enums.CRUD.State.Bloqueado & this.ViewModelInstance.State != Enums.CRUD.State.Processando;
        }
    }

    /// <summary>
    /// Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.
    /// </summary>
    public bool CanCancelAsyncSave { get; private set; } = false;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Ações do comando Salvar
    /// </summary>
    private async void SaveCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanSave == false)
            return;


        // Saving:
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Saving, this.ViewModelInstance.State, null);
        this.ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
        {
            CancelSave();
            return;
        }


        // Start Async Actions
        this.ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultSavingMessage);
        var tk = this.ViewModelInstance.CreatActionToken().Token;
        var tokenregistration = tk.Register(CancelSave);


        // Validate:
        var validation = await this.ViewModelInstance.Repository.ValidateAsync(null);
        if (validation.Count > 0)
        {
            this.ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.Validation.Dialog_Title,
                Content = string.Format(Resources.Strings.Validation.Dialog_Title, Environment.NewLine, validation.ToString())
            });
            return;
        }


        // Unlocking Async Cancel
        CanCancelAsyncSave = true;
        this.RaisePropertyChanged(nameof(CanCancelAsyncSave));
        var ex = await this.ViewModelInstance.Repository.CommitAsync(tk);
        CanCancelAsyncSave = false;
        this.RaisePropertyChanged(nameof(CanCancelAsyncSave));

        // Saved (or not):
        this.ViewModelInstance.SetState(args.State, false, null);
        if (ex is null)
        {
            var savedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Saved, args.State, null);
            this.ViewModelInstance.RaiseViewModelEvent(savedargs);
            this.ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
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
            this.ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
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
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Canceled, this.ViewModelInstance.State, null);
        var ex = await this.ViewModelInstance.Repository.CancelAsync(null);
        if (ex is null)
        {
            this.ViewModelInstance.RaiseViewModelEvent(args);
        }
        else
        {
            // todo: report message
            this.ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.ViewModel.UnhandledError_Title,
                Content = string.Format(Resources.Strings.ViewModel.UnhandledError_Message, ex.Message),
                StackTrace = ex.ToString(),
                EnableReporting = true
            });
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Acão ao acionar o cancelamento da operação de gravação assíncrona
    /// </summary>
    public void CancelSave()
    {
        this.ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
        {
            IconReference = Events.MessageIcon.Warning,
            Title = Resources.Strings.ViewModel.OperationCanceled_Title,
            Content = Resources.Strings.ViewModel.StoreService_SaveCanceled_Message
        });
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel.
    /// </summary>
    private void OnStateChanged(object sender, EventArgs e)
    {
        this.RaisePropertyChanged(nameof(CanSave));
    }

    /// <summary>
    /// Uma vez que a edição é tabular, é preciso remover o tracking de alterações de propriedades a todos os items da
    /// coleção antiga antes de uma nova pesquisa.
    /// </summary>
    private void OnItemsFetching(object sender, Events.CRUDEventArgs<T> e)
    {
        if (!typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T)))
            return;
        if (this.ViewModelInstance.Repository.DataContext is null)
            return;
        this.ViewModelInstance.Repository.DataContext.ForEach((entry) => ((INotifyPropertyChanged)entry).PropertyChanged -= this.ViewModelInstance.OnEntryPropertyChanged);
    }

    /// <summary>
    /// Uma vez que a edição é tabular, é preciso adicionar o tracking de alterações de propriedades a todos os items da coleção.
    /// </summary>
    private void OnItemsFetched(object sender, Events.CRUDEventArgs<T> e)
    {
        if (!typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T)))
            return;
        if (this.ViewModelInstance.Repository.DataContext is null)
            return;
        this.ViewModelInstance.Repository.DataContext.ForEach((entry) => ((INotifyPropertyChanged)entry).PropertyChanged += this.ViewModelInstance.OnEntryPropertyChanged);
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        this.ViewModelInstance.StateChanged -= this.OnStateChanged;
        this.ViewModelInstance.ItemsFetching -= this.OnItemsFetching;
        this.ViewModelInstance.ItemsFetched -= this.OnItemsFetched;
        this.ViewModelInstance.Commands.Remove("Save");
        this.ViewModelInstance.Commands.Remove("Cancel");
        this.ViewModelInstance.Services.Remove(ServiceUtils.KEY_TABULAREDIT);
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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
}
