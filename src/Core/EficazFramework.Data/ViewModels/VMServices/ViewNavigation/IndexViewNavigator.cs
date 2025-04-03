using EficazFramework.Navigation;
using System;
using System.Collections.Generic;

namespace EficazFramework.ViewModels.Services;

public class IndexViewNavigator<T> : ViewModelService<T>, IIndexViewNavigator where T : class
{
    public IndexViewNavigator(ViewModel<T> viewmodel) : base(viewmodel)
    {
        viewmodel.Commands.Add("GoToFindPage", new Commands.CommandBase(GoToFindPage_Executed));
        viewmodel.StateChanged += OnViewModel_StateChanged;
    }

    private int _searchIndex = -1;
    public int SearchIndex
    {
        get { return _searchIndex; }
        set
        {
            _searchIndex = value;
            RaisePropertyChanged(nameof(SearchIndex));
        }
    }

    private int _entryListIndex = 0;
    public int EntriesIndex
    {
        get
        {
            return _entryListIndex;
        }

        set
        {
            _entryListIndex = value;
            RaisePropertyChanged(nameof(EntriesIndex));
        }
    }

    private int _formIndex = 0;
    public int FormIndex
    {
        get
        {
            return _formIndex;
        }

        set
        {
            _formIndex = value;
            RaisePropertyChanged(nameof(FormIndex));
        }
    }

    public Dictionary<string, int> DetailFormIndex { get; } = new Dictionary<string, int>();

    private string _currentDetail;
    public string CurrentDetail
    {
        get
        {
            return _currentDetail;
        }

        set
        {
            _currentDetail = value;
            RaisePropertyChanged(nameof(CurrentDetail));
        }
    }

    public bool DetailHasOwnPage { get; internal set; } = false;

    public int SelectedIndex { get; private set; } = 0;

    /// <summary>
    /// Altera o índice selecionado pelo estado do ViewModel
    /// </summary>
    private void OnViewModel_StateChanged(object sender, EventArgs e)
    {
        switch (ViewModelInstance.State)
        {
            case Enums.CRUD.State.Bloqueado:
                {
                    if (SearchIndex > -1)
                    {
                        if (SelectedIndex != SearchIndex)
                        {
                            SelectedIndex = SearchIndex;
                            RaisePropertyChanged(nameof(SelectedIndex));
                        }
                    }
                    else
                    {
                        if (SelectedIndex != EntriesIndex)
                        {
                            SelectedIndex = EntriesIndex;
                            RaisePropertyChanged(nameof(SelectedIndex));
                        }
                    }

                    break;
                }
            case Enums.CRUD.State.Leitura:
                {
                    if (SelectedIndex != EntriesIndex)
                    {
                        SelectedIndex = EntriesIndex;
                        RaisePropertyChanged(nameof(SelectedIndex));
                    }

                    break;
                }

            case Enums.CRUD.State.Novo:
            case Enums.CRUD.State.Edicao:
                {
                    if (SelectedIndex != FormIndex)
                    {
                        SelectedIndex = FormIndex;
                        RaisePropertyChanged(nameof(SelectedIndex));
                    }

                    break;
                }

            case Enums.CRUD.State.NovoDetalhe:
            case Enums.CRUD.State.EdicaoDeDelhe:
                {
                    if (DetailHasOwnPage == false)
                        return;

                    if (!DetailFormIndex.TryGetValue(CurrentDetail, out int value))
                        return;

                    if (SelectedIndex != value)
                    {
                        SelectedIndex = value;
                        RaisePropertyChanged(nameof(SelectedIndex));
                    }

                    break;
                }

            default:
                {
                    return;
                }
        }
    }

    /// <summary>
    /// Ações do comando GoToFindPage
    /// </summary>
    private void GoToFindPage_Executed(object sender, Events.ExecuteEventArgs e)
    {
        ViewModelInstance.State = Enums.CRUD.State.Bloqueado;
    }


    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        ViewModelInstance.StateChanged -= OnViewModel_StateChanged;
        ViewModelInstance.Commands.Remove("GoToFindPage");
        ViewModelInstance.Services.Remove(ServiceUtils.KEY_INDEXVIEWNAVIGATOR);

    }

}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona o serviço de orientação de navegação da View por Índice de página.
    /// </summary>
    public static ViewModel<T> WithNavigationByIndex<T>(this ViewModel<T> viewmodel, int entries = 0, int form = 1) where T : class
    {
        var service = new IndexViewNavigator<T>(viewmodel) { EntriesIndex = entries, FormIndex = form };
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_INDEXVIEWNAVIGATOR))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_INDEXVIEWNAVIGATOR));
        viewmodel.Services.Add(ServiceUtils.KEY_INDEXVIEWNAVIGATOR, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove o serviço de orientação de navegação da View por Índice de página.
    /// </summary>
    public static ViewModel<T> RemoveNavigationByIndex<T>(this ViewModel<T> viewmodel) where T : class
    {
        IndexViewNavigator<T> service = (IndexViewNavigator<T>)viewmodel.Services[ServiceUtils.KEY_INDEXVIEWNAVIGATOR];
        service.Dispose();
        return viewmodel;
    }

    public static IndexViewNavigator<T> GetIndexNavigator<T>(this ViewModel<T> viewmodel) where T : class
    {
        return viewmodel.Services.ContainsKey(KEY_INDEXVIEWNAVIGATOR) == true ? (IndexViewNavigator<T>)viewmodel.Services[ServiceUtils.KEY_INDEXVIEWNAVIGATOR] : null;
    }

}
