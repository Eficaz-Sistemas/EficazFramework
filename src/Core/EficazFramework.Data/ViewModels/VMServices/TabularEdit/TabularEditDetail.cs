using EficazFramework.Entities;
using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;

namespace EficazFramework.ViewModels.Services;

public class TabularEditDetail<T, D> : ViewModelService<T>
    where T : class
    where D : class
{
    public TabularEditDetail(ViewModel<T> viewmodel,
                            SingleEdit<T> singleEditInstance,
                            System.Linq.Expressions.Expression<Func<T, IList<D>>> navigationProperty) : base(viewmodel)
    {
        PART_SingleEditT = singleEditInstance;
        PART_NavigationProperty = navigationProperty;

        viewmodel.ViewModelAction += OnViewModelAction;
        viewmodel.StateChanged += OnStateChanged;
        singleEditInstance.PropertyChanged += OnMasterPropertyChanged;

        _cmd_add_name = $"NewDetail_{navigationProperty.GetName()}";
        _cmd_delete_name = $"DeleteDetail_{navigationProperty.GetName()}";
        viewmodel.Commands.Add(_cmd_add_name, new Commands.CommandBase(NewDetailCommand_Executed));
        viewmodel.Commands.Add(_cmd_delete_name, new Commands.CommandBase(DeleteDetailCommand_Executed));
    }

    private readonly SingleEdit<T> PART_SingleEditT = null;
    private readonly System.Linq.Expressions.Expression<Func<T, IList<D>>> PART_NavigationProperty = null;

    private readonly string _cmd_add_name, _cmd_delete_name;


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
    /// Monitora a mudança de estado do ViewModel e executa os procedimentos 
    /// necessários para exibição e tracking de entidades detalhes
    /// </summary>
    private void OnViewModelAction(object sender, Events.CRUDEventArgs<T> e)
    {
        bool _mustAttachDataContext = false;
        bool _mustDetachDataContext = false;

        switch (e.Action)
        {
            case Enums.CRUD.Action.EntryAdded:
                _mustAttachDataContext = true;
                break;

            case Enums.CRUD.Action.EntrySetupCompleted:
                _mustAttachDataContext = true;
                break;

            case Enums.CRUD.Action.Canceled:
                foreach (D canceled in DataContext)
                {
                    ViewModelInstance.Repository.Cancel(canceled);
                }
                _mustDetachDataContext = true;
                break;

            case Enums.CRUD.Action.EntryValidating:
                if (DetailValidator == null) break;
                foreach (D it in DataContext)
                {
                    e.ValidationErrors.AddRange(DetailValidator.Validate(it));
                    //ViewModelInstance.Repository.TrackIgnored(it);
                }
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
                //ViewModelInstance.Repository.TrackIgnored(PART_SingleEditT.CurrentEntry);
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
            foreach (D it in PART_NavigationProperty.Invoke(PART_SingleEditT.CurrentEntry))
            {
                DataContext.Add(it);
                AttachValidatorAndINotifyPropertyChanges(it);
            }
        }

        if (_mustDetachDataContext == true)
        {
            if (PART_SingleEditT == null) return;
            foreach (D it in DataContext)
            {
                DetachValidatorAndINotifyPropertyChanges(it);
            }
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


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
        DataContext.Add(entry);
        InsertDataContext.Add(entry);
        MoveTo(entry);


        // Created:
        args = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryAdded, ViewModelInstance.State, PART_SingleEditT.CurrentEntry) { Tag = entry };
        ViewModelInstance.RaiseViewModelEvent(args);

    }

    /// <summary>
    /// Ações do comando Delete
    /// </summary>
    private async void DeleteDetailCommand_Executed(object sender, Events.ExecuteEventArgs e)
    {
        if (CanModifyOrDelete == false && e.Parameter as D == null)
            return;
        D entry;
        if (e.Parameter != null && e.Parameter is D d)
        {
            entry = d;
        }
        else
        {
            entry = CurrentEntry;
        }

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


        // Delete:
        DeleteDataContext.Add(entry);
        DataContext.Remove(entry);
        MovePrevious();
        var deletedargs = new Events.CRUDEventArgs<T>(Enums.CRUD.Action.DetailEntryDeleted, args.State, args.CurrentEntry) { Tag = entry };
        ViewModelInstance.RaiseViewModelEvent(deletedargs);

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



    //



    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        ViewModelInstance.ViewModelAction -= OnViewModelAction;
        ViewModelInstance.StateChanged += OnStateChanged;
        PART_SingleEditT.PropertyChanged -= OnMasterPropertyChanged;
        ViewModelInstance.Commands.Remove(_cmd_add_name);
        ViewModelInstance.Commands.Remove(_cmd_delete_name);
        InsertDataContext.Clear();
        DeleteDataContext.Clear();
        DataContext.Clear();
    }

}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> AddTabularEditDetail<T, D>(this ViewModel<T> viewmodel,
                                                              System.Linq.Expressions.Expression<Func<T, IList<D>>> navigationProperty)
        where T : class
        where D : class
    {
        var mainservice = viewmodel.Services.Where(p => p.Key == ServiceUtils.KEY_SINGLEEDIT).Select(p => p.Value).FirstOrDefault();
        if (mainservice == null)
        {
            throw new PolicyException(Resources.Strings.ViewModel.SingleEditDetailWithoutMaster);
        }

        var service = new TabularEditDetail<T, D>(viewmodel, (SingleEdit<T>)mainservice, navigationProperty);
        if (viewmodel.Services.ContainsKey(string.Join(",", ServiceUtils.KEY_TABULAREDITDETAIL, typeof(D).ToString())))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, string.Join(",", ServiceUtils.KEY_TABULAREDITDETAIL, typeof(D).ToString())));
        viewmodel._servicesInternal.Add(string.Join(",", ServiceUtils.KEY_TABULAREDITDETAIL, typeof(D).ToString()), service);
        return viewmodel;
    }


    /// <summary>
    /// Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.
    /// </summary>
    public static ViewModel<T> RemoveTabularEditDetail<T, D>(this ViewModel<T> viewmodel)
        where T : class
        where D : class
    {
        TabularEditDetail<T, D> service = (TabularEditDetail<T, D>)viewmodel.Services[string.Join(",", ServiceUtils.KEY_TABULAREDITDETAIL, typeof(D).ToString())];
        service.Dispose();
        return viewmodel;
    }

    public static TabularEditDetail<T, D> GetTabularEditDetail<T, D>(this ViewModel<T> viewmodel)
        where T : class
        where D : class
    {
        return (TabularEditDetail<T, D>)viewmodel.Services[string.Join(",", ServiceUtils.KEY_TABULAREDITDETAIL, typeof(D).ToString())];
    }

}
