using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EficazFramework.Navigation;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.ViewModels.Services;

public class PagedViewNavigator<T> : Services.ViewModelService<T>, IPagedViewNavigator where T : class
{
    public PagedViewNavigator(ViewModels.ViewModel<T> viewmodel) : base(viewmodel)
    {
        viewmodel.StateChanged += OnViewModel_StateChanged;
    }

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private object _entryListPage = null;
    public object EntriesPage
    {
        get
        {
            return _entryListPage;
        }

        set
        {
            _entryListPage = value;
            RaisePropertyChanged(nameof(EntriesPage));
            if (SelectedPage is null)
            {
                SelectedPage = EntriesPage;
                RaisePropertyChanged(nameof(SelectedPage));
            }
        }
    }

    private object _formPage = null;
    public object FormPage
    {
        get
        {
            return _formPage;
        }

        set
        {
            _formPage = value;
            RaisePropertyChanged(nameof(FormPage));
        }
    }

    public Dictionary<string, object> DetailFormPages { get; } = new Dictionary<string, object>();

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

    public object SelectedPage { get; private set; } = null;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Altera o índice selecionado pelo estado do ViewModel
    /// </summary>
    private void OnViewModel_StateChanged(object sender, EventArgs e)
    {
        switch (ViewModelInstance.State)
        {
            case Enums.CRUD.State.Bloqueado:
            case Enums.CRUD.State.Leitura:
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(SelectedPage, EntriesPage, false)))
                    {
                        SelectedPage = EntriesPage;
                        RaisePropertyChanged(nameof(SelectedPage));
                    }

                    break;
                }

            case Enums.CRUD.State.Novo:
            case Enums.CRUD.State.Edicao:
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(SelectedPage, FormPage, false)))
                    {
                        SelectedPage = FormPage;
                        RaisePropertyChanged(nameof(SelectedPage));
                    }

                    break;
                }

            case Enums.CRUD.State.NovoDetalhe:
            case Enums.CRUD.State.EdicaoDeDelhe:
                {
                    if (!DetailFormPages.ContainsKey(CurrentDetail))
                        return;
                    if (!ReferenceEquals(SelectedPage, DetailFormPages[CurrentDetail]))
                    {
                        SelectedPage = DetailFormPages[CurrentDetail];
                        RaisePropertyChanged(nameof(SelectedPage));
                    }

                    break;
                }

            default:
                {
                    return;
                }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    internal override void DisposeManagedCallerObjects()
    {
        base.DisposeManagedCallerObjects();
        ViewModelInstance.StateChanged -= OnViewModel_StateChanged;
        ViewModelInstance.Services.Remove(ServiceUtils.KEY_PAGEDVIEWNAVIGATOR);
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

}

public static partial class ServiceUtils
{

    /// <summary>
    /// Adiciona o serviço de orientação de navegação da View por Índice de página.
    /// </summary>
    public static ViewModel<T> WithNavigationByPage<T>(this ViewModel<T> viewmodel) where T : class
    {
        var service = new PagedViewNavigator<T>(viewmodel);
        if (viewmodel.Services.ContainsKey(ServiceUtils.KEY_PAGEDVIEWNAVIGATOR))
            throw new ArgumentException(string.Format(Resources.Strings.ViewModel.ServiceAlreadyAdded, ServiceUtils.KEY_PAGEDVIEWNAVIGATOR));
        viewmodel.Services.Add(ServiceUtils.KEY_PAGEDVIEWNAVIGATOR, service);
        return viewmodel;
    }


    /// <summary>
    /// Remove o serviço de orientação de navegação da View por Índice de página.
    /// </summary>
    public static ViewModel<T> RemoveNavigationByPage<T>(this ViewModel<T> viewmodel) where T : class
    {
        PagedViewNavigator<T> service = (PagedViewNavigator<T>)viewmodel.Services[ServiceUtils.KEY_PAGEDVIEWNAVIGATOR];
        service.Dispose();
        return viewmodel;
    }
}
