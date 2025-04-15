using EficazFramework.Entities;
using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.ViewModels.Services;

/// <summary>
/// Serviço de gravação e/ou cancelamento de alterações para ViewModel
/// </summary>
public class SingleEdit<T> : ViewModelService<T> where T : class
{
    public SingleEdit(ViewModel<T> viewmodel) : base(viewmodel)
    {
        viewmodel.Commands.Add("New", new Commands.CommandBase(NewCommand_Executed));
        viewmodel.Commands.Add("Edit", new Commands.CommandBase(EditCommand_Executed));
        viewmodel.Commands.Add("Save", new Commands.CommandBase(SaveCommand_Executed));
        viewmodel.Commands.Add("Cancel", new Commands.CommandBase(CancelCommand_Executed));
        viewmodel.Commands.Add("Delete", new Commands.CommandBase(DeleteCommand_Executed));

        viewmodel.StateChanged += OnStateChanged;
        viewmodel.ItemsFetching += OnItemsFetching;
        viewmodel.ItemsFetched += OnItemsFetched;

        Validate = async (model, propertyName) =>
            await viewmodel.Repository.Validator.ValidateAsync(model, propertyName[(propertyName.IndexOf(nameof(CurrentEntry)) + 13)..]);
    }

    [ExcludeFromCodeCoverage]
    public static Guid CommonGUIDs_ADDED => Guid.Parse("81961B4B-5ABE-4F67-BD02-5201095946F5");
    [ExcludeFromCodeCoverage]
    public static Guid CommonGUIDs_EDITING => Guid.Parse("8C4F51CF-1DF3-4D7A-8761-E95D16FBA920");
    [ExcludeFromCodeCoverage]
    public static Guid CommonGUIDs_SAVED => Guid.Parse("E6232EA7-6026-469D-869C-C65D220F75DF");
    [ExcludeFromCodeCoverage]
    public static Guid CommonGUIDs_DELETED => Guid.Parse("B1D6CD4A-805F-44E6-9F3D-66ACE19DCA98");

    private T _currentEntry = null;
    /// <summary>
    /// Obtém ou define a entidade atual em edição ou inserção.
    /// </summary>
    public T CurrentEntry
    {
        get => _currentEntry;
        set
        {
            if (_currentEntry != value)
            {
                _currentEntry = value;
                RaisePropertyChanged(nameof(CurrentEntry));
                RaisePropertyChanged(nameof(CanEdit));
            }

        }
    }

    /// <summary>
    /// Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação.
    /// </summary>
    public bool NotifyOnSave { get; set; } = true;

    /// <summary>
    /// Obtém ou define se o ViewModel deve iniciar em modo de inserção e iniciar novas inserções após o comando salvar.
    /// </summary>
    public bool BatchInsert { get; set; } = false;

    /// <summary>
    /// Notifica a View se o comando Novo está habilitado.
    /// </summary>
    public bool CanAdd => ViewModelInstance.State == Enums.CRUD.State.Bloqueado | ViewModelInstance.State == Enums.CRUD.State.Leitura;

    /// <summary>
    /// Notifica a View se o comando Editar está habilitado.
    /// </summary>
    public bool CanEdit => ViewModelInstance.State == Enums.CRUD.State.Leitura & CurrentEntry != null;

    /// <summary>
    /// Notifica a View se o comando salvar está habilitado.
    /// </summary>
    public bool CanSave => ViewModelInstance.State != Enums.CRUD.State.Bloqueado & ViewModelInstance.State != Enums.CRUD.State.Processando & ViewModelInstance.State != Enums.CRUD.State.Leitura;

    /// <summary>
    /// Notifica a View se o comando Excluir está habilitado.
    /// </summary>
    public bool CanDelete => ViewModelInstance.State == Enums.CRUD.State.Leitura & CurrentEntry != null;

    /// <summary>
    /// Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.
    /// </summary>
    public bool CanCancelAsyncSave { get; private set; } = false;

    /// <summary>
    /// Notifica a View se o comando cancelar está disponível.
    /// </summary>
    public bool CanCancelEntry => ViewModelInstance.State == Enums.CRUD.State.Edicao | ViewModelInstance.State == Enums.CRUD.State.Novo;

    /// <summary>
    /// Ações do comando Novo
    /// </summary>
    private void NewCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanAdd == false)
            return;


        // New Creating:
        var entry = ViewModelInstance.Repository.Create();
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryAdding, ViewModelInstance.State, entry);
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
            return;


        // Initializing T instance:
        AttachValidatorAndINotifyPropertyChanges(entry);
        MoveTo(entry);
        ViewModelInstance.Repository.CurrentEntry = entry;

        // Created:
        args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryAdded, ViewModelInstance.State, entry);
        ViewModelInstance.RaiseViewModelEvent(args);
        ViewModelInstance.SetState(Enums.CRUD.State.Novo, false, null);
    }

    /// <summary>
    /// Ações do comando Salvar
    /// </summary>
    private async void SaveCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanSave == false) return;


        // Saving:
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Saving, ViewModelInstance.State, CurrentEntry);
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
        var validation = await ViewModelInstance.Repository.ValidateAsync(CurrentEntry);

        Events.CRUDEventArgs<T> validatingargs = new(Enums.CRUD.Action.EntryValidating, args.State, args.CurrentEntry);
        ViewModelInstance.RaiseViewModelEvent(validatingargs);
        validation.AddRange(validatingargs.ValidationErrors);

        if (validation.Count > 0)
        {
            args.ValidationErrors.AddRange(validation);
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.Validation.Dialog_Title,
                Content = string.Format(Resources.Strings.Validation.Dialog_Message, Environment.NewLine, validation.ToString())
            });
            var failArgs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryValidationFailed, args.State, args.CurrentEntry);
            failArgs.ValidationErrors.AddRange(validation);
            ViewModelInstance.RaiseViewModelEvent(failArgs);
            ViewModelInstance.SetState(args.State, false, null);
            return;
        }
        ViewModelInstance.RaiseViewModelEvent(new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryValidated, args.State, args.CurrentEntry));

        ViewModelInstance.SetState(ViewModelInstance.State, true);
        // Unlocking Async Cancel
        CanCancelAsyncSave = true;
        RaisePropertyChanged(nameof(CanCancelAsyncSave));
        if (args.State == EficazFramework.Enums.CRUD.State.Novo)
            await ViewModelInstance.Repository.AddAsync(args.CurrentEntry, false, tk);
        Exception ex = await ViewModelInstance.Repository.CommitAsync(tk);
        CanCancelAsyncSave = false;
        RaisePropertyChanged(nameof(CanCancelAsyncSave));


        // Saved (or not):
        if (ex is null && !ViewModelInstance.FailAssertion)
        {
            var savedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Saved, args.State, args.CurrentEntry);
            ViewModelInstance.RaiseViewModelEvent(savedargs);
            if (NotifyOnSave)
            {
                ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
                {
                    IconReference = Events.MessageIcon.Like,
                    Type = Events.MessageType.SnackBar,
                    Title = Resources.Strings.ViewModel.StoreService_SavedSucessfull_Title,
                    Content = Resources.Strings.ViewModel.StoreService_SavedSucessfull_Message
                });
            }

            DetachValidatorAndINotifyPropertyChanges(args.CurrentEntry);
            if (args.State == EficazFramework.Enums.CRUD.State.Novo)
                (args.CurrentEntry as EntityBase)?.UnSetNew();


            // Post save State setup:
            ViewModelInstance.Repository.CurrentEntry = null;
            if (BatchInsert == false)
            {
                MoveTo(args.CurrentEntry);
                ViewModelInstance.SetState(EficazFramework.Enums.CRUD.State.Leitura, false, null);
            }
            else
            {
                ViewModelInstance.SetState(EficazFramework.Enums.CRUD.State.Bloqueado, true, null);
                ViewModelInstance.Commands["New"].Execute(null);
            }
        }
        else
        {
            var messageData = new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.ViewModel.UnhandledError_Title,
                Content = string.Format(Resources.Strings.ViewModel.UnhandledError_Message, ex?.Message),
                StackTrace = ex?.ToString() ?? "Assertion Exception",
                EnableReporting = true
            };
            
            if (ex != null && ex.GetType() == typeof(ValidationException))
            {
                messageData.Title = EficazFramework.Resources.Strings.Validation.Dialog_Title;
                messageData.Content = string.Format(EficazFramework.Resources.Strings.Validation.Dialog_Message, Environment.NewLine, ex.Message);
            }
            ViewModelInstance.SetState(args.State, false, null);
            ViewModelInstance.RaiseDialogMessage(messageData);
        }
        tokenregistration.Unregister();
        await tokenregistration.DisposeAsync();
    }

    /// <summary>
    /// Ações do comando Cancelar
    /// </summary>
    private async void CancelCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanCancelEntry == false) return;

        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.Canceled, ViewModelInstance.State, CurrentEntry);
        ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultCancelingMessage);
        var ex = await ViewModelInstance.Repository.CancelAsync(CurrentEntry);
        if (ex is null && !ViewModelInstance.FailAssertion)
        {
            if (args.State == Enums.CRUD.State.Edicao) 
                ViewModelInstance.Repository.RollbackEdit();

            ViewModelInstance.Repository.CurrentEntry = null;
            ViewModelInstance.RaiseViewModelEvent(args);
            DetachValidatorAndINotifyPropertyChanges(args.CurrentEntry);
            if (args.State == Enums.CRUD.State.Novo)
                MoveToFirst();
            if (ViewModelInstance.Repository.DataContext.Count > 0)
                ViewModelInstance.SetState(Enums.CRUD.State.Leitura, false, null);
            else
                ViewModelInstance.SetState(Enums.CRUD.State.Bloqueado, false, null);
        }
        else
        {
            // todo: report message
            ViewModelInstance.SetState(args.State, false, null);
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.ViewModel.UnhandledError_Title,
                Content = string.Format(Resources.Strings.ViewModel.UnhandledError_Message, ex?.Message),
                StackTrace = ex?.ToString() ?? "Assertion Exception",
                EnableReporting = true
            });
        }
    }

    /// <summary>
    /// Ações do comando Edit
    /// </summary>
    private async void EditCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanEdit == false) return;


        T entry;
        if (e.Parameter != null && e.Parameter is T t)
        {
            entry = t;
            CurrentEntry = entry;
        }
        else
        {
            entry = CurrentEntry;
        }
        ViewModelInstance.Repository.CurrentEntry = entry;

        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryEditing, ViewModelInstance.State, entry);
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
            return;

        ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, null);
        AttachValidatorAndINotifyPropertyChanges(entry);
        await ViewModelInstance.OnEntrySetup(entry);
        (entry as EntityBase)?.SetIsLoaded();
        
        args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntrySetupCompleted, ViewModelInstance.State, entry);
        ViewModelInstance.RaiseViewModelEvent(args);
        ViewModelInstance.Repository.PrepareToEdit();

        args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryEdited, ViewModelInstance.State, entry);
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
            return;

        ViewModelInstance.SetState(Enums.CRUD.State.Edicao, false, null);
    }

    /// <summary>
    /// Ações do comando Delete
    /// </summary>
    private async void DeleteCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanDelete == false)
            return;

        T entry;
        bool batchdelete = false;
        if (e.Parameter != null && e.Parameter is T t)
        {
            entry = t; //delete entry from CommandParameter
        }
        else if (e.Parameter != null && e.Parameter is bool boolean && boolean == true)
        {
            entry = null;
            batchdelete = true; //delete every Entry with IsSelected == true (if T is EntityType)
        }
        else
        {
            entry = CurrentEntry; //delete CurrentEntry
        }
        ViewModelInstance.Repository.CurrentEntry = entry;

        // TODO: verify if operation is a BatchDelete...
        string messagetext = Resources.Strings.ViewModel.StoreService_DeleteConfirmation_Message;
        if (batchdelete)
        {
            if (!(typeof(T) == typeof(EntityBase))) return;

            messagetext = Resources.Strings.ViewModel.StoreService_BatchDeleteConfirmation_Message;
        }

        // Confirming:
        Events.MessageEventArgs deletMessageargs = new()
        {
            IconReference = Events.MessageIcon.Exclamation,
            Title = Resources.Strings.ViewModel.StoreService_DeleteConfirmation_Title,
            Buttons = Events.MessageButtons.YesNo,
            Content = messagetext,
        };
        ViewModelInstance.RaiseDialogMessage(deletMessageargs);
        Events.MessageResult result = await deletMessageargs.ModalAssist.Push();
        if (result != Events.MessageResult.Yes) return;


        // Deleting:
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryDeleting, ViewModelInstance.State, entry);
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
            return;


        // Delete Commit:
        ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultDeletingMessage);
        var tk = ViewModelInstance.CreatActionToken().Token;

        Exception ex;
        if (batchdelete == false)
            ex = await ViewModelInstance.Repository.DeleteAsync(entry, true, tk);
        else
            ex = null; //TODO: Batch Delete action


        // Deleted (or not):
        if (ex is null && !ViewModelInstance.FailAssertion)
        {
            var deletedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryDeleted, args.State, args.CurrentEntry);
            ViewModelInstance.RaiseViewModelEvent(deletedargs);
            DetachValidatorAndINotifyPropertyChanges(args.CurrentEntry);

            // Post delete State setup:
            ViewModelInstance.Repository.CurrentEntry = null;
            if (ViewModelInstance.Repository.DataContext.Count > 0)
            {
                ViewModelInstance.SetState(Enums.CRUD.State.Leitura, false, null);
            }
            else
            {
                ViewModelInstance.SetState(Enums.CRUD.State.Bloqueado, false, null);
            }
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Like,
                Type = Events.MessageType.SnackBar,
                Title = Resources.Strings.ViewModel.StoreService_DeletedSucessfull_Title,
                Content = batchdelete == false ? Resources.Strings.ViewModel.StoreService_DeletedSucessfull_Message : Resources.Strings.ViewModel.StoreService_DeletedSucessfull_MessageForBatch
            }); ;

        }
        else
        {

            // todo: report message
            ViewModelInstance.SetState(args.State, false, null);
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Error,
                Title = Resources.Strings.ViewModel.UnhandledError_Title,
                Content = string.Format(Resources.Strings.ViewModel.UnhandledError_Message, ex?.Message),
                StackTrace = ex?.ToString() ?? "Assertion Exception",
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
    /// Anexa a instância de validação do repositório ao item especificado no parâmetro,
    /// além de iniciar a notificação de alteração pela interface INotifyPropertyChanged
    /// </summary>
    private void AttachValidatorAndINotifyPropertyChanges(T entry)
    {
        if (entry is INotifyPropertyChanged changed)
            changed.PropertyChanged += ViewModelInstance.OnEntryPropertyChanged;
        if (entry is Validation.IFluentValidatableClass ifluent)
            ifluent.Validator = ViewModelInstance.Repository.Validator;
        if (entry is EntityBase entity && entity.IsNew == false)
        {
            if (typeof(Repositories.IEntityRepository).IsAssignableFrom(ViewModelInstance.Repository.GetType()))
            {
                Repositories.IEntityRepository repo = (Repositories.IEntityRepository)ViewModelInstance.GetPropertyValue(nameof(ViewModelInstance.Repository));
                if (repo.AsNoTracking)
                {
                    repo.DbContext.Attach(entry);
                    repo.DbContext.Entry(entry).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
            }
        }
    }

    /// <summary>
    /// Remove a instância de validação do repositório ao item especificado no parâmetro,
    /// além de finalizar a notificação de alteração pela interface INotifyPropertyChanged
    /// </summary>
    private void DetachValidatorAndINotifyPropertyChanges(T entry)
    {
        if (entry is INotifyPropertyChanged changed)
            changed.PropertyChanged -= ViewModelInstance.OnEntryPropertyChanged;
        if (entry is Validation.IFluentValidatableClass ifluent)
            ifluent.Validator = null;
        if (entry is EntityBase)
        {
            if (typeof(Repositories.IEntityRepository).IsAssignableFrom(ViewModelInstance.Repository.GetType()))
            {
                Repositories.IEntityRepository repo = (Repositories.IEntityRepository)ViewModelInstance.GetPropertyValue(nameof(ViewModelInstance.Repository));
                if (repo.AsNoTracking)
                {
                    repo.Detach(entry);
                    ViewModelInstance.RaiseViewModelEvent(new Events.CRUDEventArgs<T>(Enums.CRUD.Action.EntryDetached, ViewModelInstance.State, entry));
                }
            }
        }
    }

    /// <summary>
    /// Obtém o índice de alocação do item selecionado para com o DataContext
    /// </summary>
    /// <returns></returns>
    private int GetCurrentEntryIndex()
    {
        if (ViewModelInstance.Repository.DataContext is null | CurrentEntry is null)
            return int.MinValue;
        return ViewModelInstance.Repository.DataContext.IndexOf(CurrentEntry);
    }

    /// <summary>
    /// Seleciona o primeiro item do DataContext
    /// </summary>
    public void MoveToFirst()
    {
        if (ViewModelInstance.Repository.DataContext != null && ViewModelInstance.Repository.DataContext.Count > 0)
            CurrentEntry = ViewModelInstance.Repository.DataContext.FirstOrDefault();
        else
            CurrentEntry = null;
    }

    /// <summary>
    /// Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado
    /// </summary>
    public void MovePrevious()
    {
        int index = GetCurrentEntryIndex();
        if (index == int.MinValue)
        {
            CurrentEntry = null;
            return;
        }

        if (index == -1)
            CurrentEntry = ViewModelInstance.Repository.DataContext.FirstOrDefault();
        else
        {
            if (ViewModelInstance.Repository.DataContext.Count > index - 1)
                CurrentEntry = ViewModelInstance.Repository.DataContext[index - 1];
            else
                CurrentEntry = null;
        }
    }

    /// <summary>
    /// Seleciona o item definido em argumento
    /// </summary>
    public void MoveTo(T entry)
    {
        CurrentEntry = entry;
    }

    /// <summary>
    /// Seleciona o próximo item do DataContext, baseado no item atualmente selecionado
    /// </summary>
    public void MoveNext()
    {
        int index = GetCurrentEntryIndex();
        if (index == int.MinValue)
        {
            CurrentEntry = null;
            return;
        }

        if (ViewModelInstance.Repository.DataContext.Count > index + 1)
            CurrentEntry = ViewModelInstance.Repository.DataContext[index + 1];
    }

    /// <summary>
    /// Seleciona o último item do DataContext
    /// </summary>
    public void MoveToLast()
    {
        if (ViewModelInstance.Repository.DataContext != null && ViewModelInstance.Repository.DataContext.Count > 0)
            CurrentEntry = ViewModelInstance.Repository.DataContext.LastOrDefault();
        else
            CurrentEntry = null;
    }


    /// <summary>
    /// Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel.
    /// </summary>
    private void OnStateChanged(object sender, EventArgs e)
    {
        RaisePropertyChanged(nameof(CanSave));
        RaisePropertyChanged(nameof(CanCancelEntry));
        RaisePropertyChanged(nameof(CanAdd));
        RaisePropertyChanged(nameof(CanEdit));
    }

    /// <summary>
    /// Efetua os procedimentos pré-get
    /// </summary>
    private void OnItemsFetching(object sender, Events.CRUDEventArgs<T> e)
    {
        if (CurrentEntry is null)
            return;
        if (!typeof(INotifyPropertyChanged).IsAssignableFrom(typeof(T)))
            return;
        ((INotifyPropertyChanged)CurrentEntry).PropertyChanged -= ViewModelInstance.OnEntryPropertyChanged;
    }

    /// <summary>
    /// Efetua os procedimentos post-get
    /// </summary>
    private void OnItemsFetched(object sender, Events.CRUDEventArgs<T> e)
    {
        if (ViewModelInstance.Repository.DataContext.Count > 0)
            MoveToFirst();
    }


    public Func<object, string, Task<IEnumerable<string>>> Validate { get; }


    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        ViewModelInstance.StateChanged -= OnStateChanged;
        ViewModelInstance.ItemsFetching -= OnItemsFetching;
        ViewModelInstance.ItemsFetched -= OnItemsFetched;
        ViewModelInstance.Commands.Remove("New");
        ViewModelInstance.Commands.Remove("Save");
        ViewModelInstance.Commands.Remove("Edit");
        ViewModelInstance.Commands.Remove("Cancel");
        ViewModelInstance.Commands.Remove("Delete");
        ViewModelInstance.Services.Remove(ServiceUtils.KEY_SINGLEEDIT);
    }
}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> AddSingledEdit<T>(this ViewModel<T> viewmodel, bool notifyOnSave = true) where T : class
    {
        var service = new SingleEdit<T>(viewmodel) { NotifyOnSave = notifyOnSave };
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_SINGLEEDIT))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_SINGLEEDIT));
        viewmodel._servicesInternal.Add(ServiceUtils.KEY_SINGLEEDIT, service);
        return viewmodel;
    }

    /// <summary>
    /// Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> RemoveSingleEdit<T>(this ViewModel<T> viewmodel) where T : class
    {
        SingleEdit<T> service = (SingleEdit<T>)viewmodel.Services[ServiceUtils.KEY_SINGLEEDIT];
        service.Dispose();
        return viewmodel;
    }

    public static SingleEdit<T> GetSingleEdit<T>(this ViewModel<T> viewmodel) where T : class
    {
        return viewmodel.Services.ContainsKey(KEY_SINGLEEDIT) == true ? (SingleEdit<T>)viewmodel.Services[ServiceUtils.KEY_SINGLEEDIT] : null;
    }

}
