using EficazFramework.Entities;
using EficazFramework.Events;
using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text.Json;
using System.Threading;

namespace EficazFramework.ViewModels.Services;

public class SingleEditDetail<T, D> : ViewModelService<T>
    where T : class
    where D : class
{
    public SingleEditDetail(ViewModel<T> viewmodel,
                            SingleEdit<T> singleEditInstance,
                            System.Linq.Expressions.Expression<Func<T, IList<D>>> navigationProperty,
                            Enums.CRUD.ViewModelEditDetailMode editMode = Enums.CRUD.ViewModelEditDetailMode.Paged) : base(viewmodel)
    {
        EditMode = editMode;
        PART_SingleEditT = singleEditInstance;
        PART_NavigationProperty = navigationProperty;

        viewmodel.ViewModelAction += OnViewModelAction;
        viewmodel.StateChanged += OnStateChanged;
        singleEditInstance.PropertyChanged += OnMasterPropertyChanged;

        _cmd_add_name = $"NewDetail_{navigationProperty.GetName()}";
        _cmd_edit_name = $"EditDetail_{navigationProperty.GetName()}";
        _cmd_save_name = $"SaveDetail_{navigationProperty.GetName()}";
        _cmd_cancel_Name = $"CancelDetail_{navigationProperty.GetName()}";
        _cmd_delete_name = $"DeleteDetail_{navigationProperty.GetName()}";
        viewmodel.Commands.Add(_cmd_add_name, new Commands.CommandBase(NewDetailCommand_Executed));
        viewmodel.Commands.Add(_cmd_edit_name, new Commands.CommandBase(EditDetailCommand_Executed));
        viewmodel.Commands.Add(_cmd_save_name, new Commands.CommandBase(SaveDetailCommand_Executed));
        viewmodel.Commands.Add(_cmd_cancel_Name, new Commands.CommandBase(CancelDetailCommand_Executed));
        viewmodel.Commands.Add(_cmd_delete_name, new Commands.CommandBase(DeleteDetailCommand_Executed));
    }

    private readonly string _cmd_add_name, _cmd_edit_name, _cmd_save_name, _cmd_cancel_Name, _cmd_delete_name;

    private readonly SingleEdit<T> PART_SingleEditT = null;
    private readonly System.Linq.Expressions.Expression<Func<T, IList<D>>> PART_NavigationProperty = null;
    private bool commitOperationAllowed = false;
    private Enums.CRUD.State _targetVMState = Enums.CRUD.State.Bloqueado;
    private D _originalValues = null;
    private readonly System.Text.Json.JsonSerializerOptions _jsonOptions = new()
    {
        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
    };

    /// <summary>
    /// Validador para Entidades Detalhe
    /// </summary>
    public Validation.Fluent.Validator<D> DetailValidator { get; set; }

    /// <summary>
    /// Contém a cópia da enumeração dos resultados obtidos na propriedade de Navegação.
    /// </summary>
    /// <returns></returns>
    public Collections.AsyncObservableCollection<D> DataContext { get; private set; } = new Collections.AsyncObservableCollection<D>();

    /// <summary>
    /// Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.
    /// </summary>
    /// <returns></returns>
    public Collections.AsyncObservableCollection<D> InsertDataContext { get; private set; } = new Collections.AsyncObservableCollection<D>();

    /// <summary>
    /// Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.
    /// </summary>
    /// <returns></returns>
    public Collections.AsyncObservableCollection<D> DeleteDataContext { get; private set; } = new Collections.AsyncObservableCollection<D>();



    private D _currentEntry = null;
    /// <summary>
    /// Obtém ou define a entidade atual em edição ou inserção.
    /// </summary>
    public D CurrentEntry
    {
        get
        {
            return _currentEntry;
        }

        set
        {
            if (_currentEntry != value)
            {
                _currentEntry = value;
                RaisePropertyChanged(nameof(CurrentEntry));
                RaisePropertyChanged(nameof(CanAdd));
                RaisePropertyChanged(nameof(CanModifyOrDelete));
            }
        }
    }



    /// <summary>
    /// Obtém ou define se os dados devem ser persistidos no repositório após salvar
    /// a entidade detalhe D, ou se a efetiva gravação deve ser feita após o comando
    /// salvar de edição da entidade mestre T.
    /// </summary>
    public bool CommitOnSave { get; set; } = false;



    /// <summary>
    /// Notifica a View se os comando Novo está habilitado.
    /// </summary>
    public bool CanAdd
    {
        get
        {
            return ViewModelInstance.State == Enums.CRUD.State.Novo | ViewModelInstance.State == Enums.CRUD.State.Edicao;
        }
    }

    /// <summary>
    /// Notifica a View se o comando salvar está habilitado.
    /// </summary>
    public bool CanSave
    {
        get
        {
            return ViewModelInstance.State == Enums.CRUD.State.NovoDetalhe | ViewModelInstance.State == Enums.CRUD.State.EdicaoDeDelhe;
        }
    }

    /// <summary>
    /// Notifica a View se os comandos Editar, Salvar e Excluir estão habilitados.
    /// </summary>
    public bool CanModifyOrDelete
    {
        get
        {
            return CanAdd & CurrentEntry != null;
        }
    }

    /// <summary>
    /// Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.
    /// </summary>
    public bool CanCancelAsyncSave { get; private set; } = false;


    /// <summary>
    /// Determinar se a entidade detalhe deve ser exibida para edição em uma nova página ou em um popup
    /// </summary>
    public Enums.CRUD.ViewModelEditDetailMode EditMode { get; set; } = Enums.CRUD.ViewModelEditDetailMode.Paged;


    /// <summary>
    /// Monitora a mudança de estado do ViewModel e executa os procedimentos 
    /// necessários para exibição e tracking de entidades detalhes
    /// </summary>
    private void OnViewModelAction(object sender, Events.CRUDEventArgs<T> e)
    {
        bool _mustAttachDataContext = false;
        bool _mustDetachDataContext = false;

        switch (e.Action)
        {
            case Enums.CRUD.Action.EntryAdding:
                commitOperationAllowed = false;
                break;

            case Enums.CRUD.Action.EntryAdded:
                _mustAttachDataContext = true;
                _targetVMState = Enums.CRUD.State.Novo;
                break;

            case Enums.CRUD.Action.EntryEditing:
                if (CommitOnSave == true) commitOperationAllowed = true;
                _targetVMState = Enums.CRUD.State.Edicao;
                _mustAttachDataContext = true;
                break;

            case Enums.CRUD.Action.Canceled:
                foreach (D canceled in DataContext)
                {
                    ViewModelInstance.Repository.Cancel(canceled);
                }
                _mustDetachDataContext = true;
                break;

            case Enums.CRUD.Action.EntryValidated:
                foreach (D newItem in InsertDataContext)
                {
                    ViewModelInstance.Repository.Add(newItem, false);
                }
                foreach (D recylingItem in DeleteDataContext)
                {
                    ViewModelInstance.Repository.Delete(recylingItem, false);
                }
                break;

            case Enums.CRUD.Action.Saved:
                _mustDetachDataContext = true;

                foreach (D newItem in InsertDataContext)
                {
                    (newItem as EntityBase)?.UnSetNew();
                }
                foreach (D recylingItem in DeleteDataContext)
                {
                    PART_NavigationProperty.Invoke(PART_SingleEditT.CurrentEntry).Remove(recylingItem);
                }
                break;

            case Enums.CRUD.Action.EntryDetached:
                foreach (D item in PART_NavigationProperty.Invoke(e.CurrentEntry))
                {
                    ViewModelInstance.Repository.Detach(item);
                }
                break;
        }


        if (_mustAttachDataContext == true)
        {
            if (PART_SingleEditT == null) return;
            DataContext.Clear();
            DataContext.AddRange(PART_NavigationProperty.Invoke(PART_SingleEditT.CurrentEntry));
        }

        if (_mustDetachDataContext == true)
        {
            if (PART_SingleEditT == null) return;
            DataContext.Clear();
            InsertDataContext.Clear();
            DeleteDataContext.Clear();
        }

    }

    /// <summary>
    /// Acompanha a mudança de Entidade Atual do Serviço-Mestre.
    /// </summary>
    private void OnMasterPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SingleEdit<T>.CurrentEntry))
        {
            DataContext.Clear();
        }
    }


    /// <summary>
    /// Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel Mestre.
    /// </summary>
    private void OnStateChanged(object sender, EventArgs e)
    {
        RaisePropertyChanged(nameof(CanAdd));
        RaisePropertyChanged(nameof(CanSave));
        RaisePropertyChanged(nameof(CanCancelAsyncSave));
        RaisePropertyChanged(nameof(CanModifyOrDelete));
    }



    /// <summary>
    /// Ações do comando Novo
    /// </summary>
    private void NewDetailCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanAdd == false)
            return;


        // New Creating:
        D entry = ViewModelInstance.Repository.Create<D>();
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryAdding, ViewModelInstance.State, PART_SingleEditT.CurrentEntry) { Tag = entry };
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
            return;


        // Initializing T instance:
        AttachValidatorAndINotifyPropertyChanges(entry);
        MoveTo(entry);


        // Created:
        ((Services.IndexViewNavigator<T>)ViewModelInstance.Services[ServiceUtils.KEY_INDEXVIEWNAVIGATOR]).CurrentDetail = PART_NavigationProperty.GetName();
        ((Services.IndexViewNavigator<T>)ViewModelInstance.Services[ServiceUtils.KEY_INDEXVIEWNAVIGATOR]).DetailHasOwnPage = EditMode == Enums.CRUD.ViewModelEditDetailMode.Paged;
        ViewModelInstance.SetState(Enums.CRUD.State.NovoDetalhe, false, null);
        args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryAdded, ViewModelInstance.State, PART_SingleEditT.CurrentEntry) { Tag = entry };
        ViewModelInstance.RaiseViewModelEvent(args);

        if (EditMode == Enums.CRUD.ViewModelEditDetailMode.Popup)
        {
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Certificate,
                Title = string.Empty,
                Content = entry,
                Buttons = Events.MessageButtons.OKCancel,
                Tag = $"Popup:{PART_NavigationProperty.GetName()}"
            });
        };

    }

    /// <summary>
    /// Ações do comando Salvar
    /// </summary>
    private async void SaveDetailCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanSave == false) return;


        // Saving:
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailSaving, ViewModelInstance.State, PART_SingleEditT.CurrentEntry) { Tag = CurrentEntry };
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
        {
            CancelSave();
            return;
        }


        // Start Async Actions
        CancellationToken tk = default;
        ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultSavingMessage);
        if (CommitOnSave == true && commitOperationAllowed == true)
        {
            tk = ViewModelInstance.CreatActionToken().Token;
            tk.Register(CancelSave);
        }


        // Validate:
        var validation = await ViewModelInstance.Repository.ValidateAsync(CurrentEntry, DetailValidator);
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


        // Unlocking Async Cancel
        if (CommitOnSave == true && commitOperationAllowed == true)
        {
            CanCancelAsyncSave = true;
            RaisePropertyChanged(nameof(CanCancelAsyncSave));
            if (args.State == EficazFramework.Enums.CRUD.State.NovoDetalhe)
                await ViewModelInstance.Repository.AddAsync(CurrentEntry, false, tk);
            Exception ex = await ViewModelInstance.Repository.CommitAsync(tk);
            CanCancelAsyncSave = false;
            RaisePropertyChanged(nameof(CanCancelAsyncSave));


            // Saved (or not):
            if (ex is null && !ViewModelInstance.FailAssertion)
            {

                var savedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailSaved, args.State, args.CurrentEntry);
                ViewModelInstance.RaiseViewModelEvent(savedargs);

                ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
                {
                    IconReference = Events.MessageIcon.Like,
                    Type = MessageType.SnackBar,
                    Title = Resources.Strings.ViewModel.StoreService_SavedSucessfull_Title,
                    Content = Resources.Strings.ViewModel.StoreService_SavedSucessfull_Message
                });

                // Post save State setup:
                DataContext.Add(CurrentEntry);
                MoveTo(CurrentEntry);
                DetachValidatorAndINotifyPropertyChanges(CurrentEntry);
                ViewModelInstance.SetState(EficazFramework.Enums.CRUD.State.Edicao, false, null);
            }
            else
            {
                if (args.State == EficazFramework.Enums.CRUD.State.NovoDetalhe)
                {
                    await ViewModelInstance.Repository.CancelAsync(args.CurrentEntry);
                    CurrentEntry = (D)args.Tag;
                }

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
        else
        {
            if (args.State == EficazFramework.Enums.CRUD.State.NovoDetalhe)
            {
                DataContext.Add(CurrentEntry);
                InsertDataContext.Add(CurrentEntry);
                MoveTo(CurrentEntry);
            }
            DetachValidatorAndINotifyPropertyChanges((D)args.Tag);
            ViewModelInstance.SetState(_targetVMState, false, null);
        }
    }

    /// <summary>
    /// Ações do comando Cancelar
    /// </summary>
    private async void CancelDetailCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailCanceled, ViewModelInstance.State, PART_SingleEditT.CurrentEntry) { Tag = CurrentEntry };
        ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultCancelingMessage);
        var ex = await ViewModelInstance.Repository.CancelAsync(CurrentEntry);
        if (ex is null && !ViewModelInstance.FailAssertion)
        {
            var index = DataContext.IndexOf(CurrentEntry);
            if ((args.State == Enums.CRUD.State.Novo ||
                args.State == Enums.CRUD.State.Edicao ||
                args.State == Enums.CRUD.State.EdicaoDeDelhe) &&
                !ViewModelInstance.Repository.TrackChanges)
            {
                CurrentEntry = System.Text.Json.JsonSerializer.Deserialize<D>(System.Text.Json.JsonSerializer.Serialize(_originalValues, _jsonOptions));
                DataContext[index] = CurrentEntry;
            }

            ViewModelInstance.RaiseViewModelEvent(args);
            DetachValidatorAndINotifyPropertyChanges((D)args.Tag);
            if (args.State == Enums.CRUD.State.NovoDetalhe)
                MoveToFirst();
            ViewModelInstance.SetState(_targetVMState, false, null);

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
    private void EditDetailCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {

        D entry;
        if (e.Parameter != null && e.Parameter is D d)
        {
            entry = d;
            CurrentEntry = entry;
        }
        else
        {
            entry = CurrentEntry;
        }
        if (CanModifyOrDelete == false) return;
        AttachValidatorAndINotifyPropertyChanges(entry);

        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryEditing, ViewModelInstance.State, PART_SingleEditT.CurrentEntry) { Tag = entry };
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
            return;

        ((Services.IndexViewNavigator<T>)ViewModelInstance.Services[ServiceUtils.KEY_INDEXVIEWNAVIGATOR]).CurrentDetail = PART_NavigationProperty.GetName();
        ((Services.IndexViewNavigator<T>)ViewModelInstance.Services[ServiceUtils.KEY_INDEXVIEWNAVIGATOR]).DetailHasOwnPage = EditMode == Enums.CRUD.ViewModelEditDetailMode.Paged;

        if (!ViewModelInstance.Repository.TrackChanges)
            _originalValues = System.Text.Json.JsonSerializer.Deserialize<D>(System.Text.Json.JsonSerializer.Serialize(entry, _jsonOptions));

        ViewModelInstance.SetState(Enums.CRUD.State.EdicaoDeDelhe, false, null);

        if (EditMode == Enums.CRUD.ViewModelEditDetailMode.Popup)
        {
            ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
            {
                IconReference = Events.MessageIcon.Certificate,
                Title = string.Empty,
                Content = entry,
                Buttons = Events.MessageButtons.OKCancel,
                Tag = $"Popup:{PART_NavigationProperty.GetName()}"
            });
        }
        else
        {
            ViewModelInstance.SetState(Enums.CRUD.State.EdicaoDeDelhe, false, null);
        }
    }


    /// <summary>
    /// Ações do comando Delete
    /// </summary>
    private async void DeleteDetailCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        D entry;
        if (e.Parameter != null && e.Parameter is D d)
        {
            entry = d;
        }
        else
        {
            entry = CurrentEntry;
        }
        if (CanModifyOrDelete == false) return;

        // TODO: verify if operation is a BatchDelete...

        // Confirming:
        Events.MessageEventArgs deletMessageargs = new()
        {
            IconReference = Events.MessageIcon.Exclamation,
            Title = Resources.Strings.ViewModel.StoreService_DeleteConfirmation_Title,
            Buttons = Events.MessageButtons.YesNo,
            Content = Resources.Strings.ViewModel.StoreService_DeleteConfirmation_Message,
        };
        ViewModelInstance.RaiseDialogMessage(deletMessageargs);
        Events.MessageResult result = await deletMessageargs.ModalAssist.Push();
        if (result != Events.MessageResult.Yes) return;


        // Deleting:
        var args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryDeleting, ViewModelInstance.State, PART_SingleEditT.CurrentEntry) { Tag = entry };
        ViewModelInstance.RaiseViewModelEvent(args);
        if (args.Cancel == true)
            return;


        // Delete Commit:
        if (CommitOnSave == true && commitOperationAllowed == true)
        {
            ViewModelInstance.SetState(Enums.CRUD.State.Processando, true, Resources.Strings.ViewModel.DefaultDeletingMessage);
            var tk = ViewModelInstance.CreatActionToken().Token;
            var ex = await ViewModelInstance.Repository.DeleteAsync(entry, true, tk);

            // Deleted (or not):
            if (ex is null && !ViewModelInstance.FailAssertion)
            {
                DataContext.Remove(entry);
                MovePrevious();

                var deletedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryDeleted, args.State, args.CurrentEntry) { Tag = entry };
                ViewModelInstance.RaiseViewModelEvent(deletedargs);

                // Post delete State setup:
                DetachValidatorAndINotifyPropertyChanges(entry);
                ViewModelInstance.SetState(Enums.CRUD.State.Edicao, false, null);
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
        else
        {
            DeleteDataContext.Add(entry);
            DataContext.Remove(entry);
            MovePrevious();
            var deletedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryDeleted, args.State, args.CurrentEntry) { Tag = entry };
            ViewModelInstance.RaiseViewModelEvent(deletedargs);
        }

    }

    /// <summary>
    /// Acão ao acionar o cancelamento da operação de gravação assíncrona
    /// </summary>
    public void CancelSave()
    {
        if (CommitOnSave == false) return;
        ViewModelInstance.RaiseDialogMessage(new Events.MessageEventArgs()
        {
            IconReference = Events.MessageIcon.Warning,
            Title = Resources.Strings.ViewModel.OperationCanceled_Title,
            Content = Resources.Strings.ViewModel.StoreService_SaveCanceled_Message
        });
    }



    /// <summary>
    /// Obtém o índice de alocação do item selecionado para com o DataContext
    /// </summary>
    /// <returns></returns>
    private int GetCurrentEntryIndex()
    {
        if (DataContext is null | CurrentEntry is null)
            return int.MinValue;
        return DataContext.IndexOf(CurrentEntry);
    }

    /// <summary>
    /// Seleciona o primeiro item do DataContext
    /// </summary>
    public void MoveToFirst()
    {
        if (DataContext != null && DataContext.Count > 0)
            CurrentEntry = DataContext.FirstOrDefault();
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
            CurrentEntry = DataContext.FirstOrDefault();
        else
        {
            if (index > 0)
                CurrentEntry = DataContext[index - 1];
        }
    }

    /// <summary>
    /// Seleciona o item definido em argumento
    /// </summary>
    public void MoveTo(D entry)
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

        if (DataContext.Count > index + 1)
            CurrentEntry = DataContext[index + 1];
    }

    /// <summary>
    /// Seleciona o último item do DataContext
    /// </summary>
    public void MoveToLast()
    {
        if (DataContext != null && DataContext.Count > 0)
            CurrentEntry = DataContext.LastOrDefault();
        else
            CurrentEntry = null;
    }



    //



    /// <summary>
    /// Anexa a instância de validação do repositório ao item especificado no parâmetro,
    /// além de iniciar a notificação de alteração pela interface INotifyPropertyChanged
    /// </summary>
    private void AttachValidatorAndINotifyPropertyChanges(D entry)
    {
        if (entry is INotifyPropertyChanged changed)
            changed.PropertyChanged += ViewModelInstance.OnEntryPropertyChanged;
        if (entry is Validation.IFluentValidatableClass ifluent)
            ifluent.Validator = DetailValidator;
    }

    /// <summary>
    /// Remove a instância de validação do repositório ao item especificado no parâmetro,
    /// além de finalizar a notificação de alteração pela interface INotifyPropertyChanged
    /// </summary>
    private void DetachValidatorAndINotifyPropertyChanges(D entry)
    {
        if (entry is INotifyPropertyChanged changed)
            changed.PropertyChanged -= ViewModelInstance.OnEntryPropertyChanged;
        if (entry is Validation.IFluentValidatableClass ifluent)
            ifluent.Validator = null;
    }



    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        ViewModelInstance.ViewModelAction -= OnViewModelAction;
        ViewModelInstance.StateChanged += OnStateChanged;
        PART_SingleEditT.PropertyChanged -= OnMasterPropertyChanged;
        ViewModelInstance.Commands.Remove(_cmd_add_name);
        ViewModelInstance.Commands.Remove(_cmd_edit_name);
        ViewModelInstance.Commands.Remove(_cmd_save_name);
        ViewModelInstance.Commands.Remove(_cmd_cancel_Name);
        ViewModelInstance.Commands.Remove(_cmd_delete_name);
        InsertDataContext.Clear();
        DeleteDataContext.Clear();
        DataContext.Clear();
        ViewModelInstance.Services.Remove(string.Join(",", ServiceUtils.KEY_SINGLEEDITDETAIL, typeof(D).ToString()));
    }

}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> AddSingledEditDetail<T, D>(
        this ViewModel<T> viewmodel,
        System.Linq.Expressions.Expression<Func<T, IList<D>>> navigationProperty,
        Enums.CRUD.ViewModelEditDetailMode editMode = Enums.CRUD.ViewModelEditDetailMode.Paged)
        where T : class
        where D : class
    {
        var mainservice = viewmodel.Services.Where(p => p.Key == ServiceUtils.KEY_SINGLEEDIT).Select(p => p.Value).FirstOrDefault() ?? throw new PolicyException(Resources.Strings.ViewModel.SingleEditDetailWithoutMaster);
        var service = new SingleEditDetail<T, D>(viewmodel, (SingleEdit<T>)mainservice, navigationProperty, editMode);
        if (viewmodel.Services.ContainsKey(string.Join(",", ServiceUtils.KEY_SINGLEEDITDETAIL, typeof(D).ToString())))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, string.Join(",", ServiceUtils.KEY_SINGLEEDITDETAIL, typeof(D).ToString())));
        viewmodel._servicesInternal.Add(string.Join(",", ServiceUtils.KEY_SINGLEEDITDETAIL, typeof(D).ToString()), service);
        return viewmodel;
    }


    /// <summary>
    /// Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> RemoveSingleEditDetail<T, D>(this ViewModel<T> viewmodel)
        where T : class
        where D : class
    {
        SingleEditDetail<T, D> service = (SingleEditDetail<T, D>)viewmodel.Services[string.Join(",", ServiceUtils.KEY_SINGLEEDITDETAIL, typeof(D).ToString())];
        service.Dispose();
        return viewmodel;
    }

    public static SingleEditDetail<T, D> GetSingleEditDetail<T, D>(this ViewModel<T> viewmodel)
        where T : class
        where D : class
    {
        return (SingleEditDetail<T, D>)viewmodel.Services[string.Join(",", ServiceUtils.KEY_SINGLEEDITDETAIL, typeof(D).ToString())];
    }

}
