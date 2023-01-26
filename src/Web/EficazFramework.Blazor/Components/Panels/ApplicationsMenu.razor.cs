using EficazFramework.Application;
using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using System.Collections.ObjectModel;

namespace EficazFramework.Components;

public partial class ApplicationsMenu : MudBlazor.MudComponentBase
{

    private string _searchFilter = "";
    /// <summary>
    /// The literal for searching for applications on the list
    /// </summary>
    [Parameter]
    public string SearchFilter
    {
        get => _searchFilter;
        set
        {
            _searchFilter = value;
            StateHasChanged();
        }
    }


    /// <summary>
    /// Aplication source for menu.
    /// </summary>
    [Parameter] public ObservableCollection<ApplicationDefinition> ItemsSource { get; set; } = new();


    /// <summary>
    /// Raised when Application's menu button is clicked.
    /// </summary>
    [Parameter] public Action<ApplicationDefinition>? SelectionCallBack { get; set; } = null;


    private bool _isCompact = false;
    /// <summary>
    /// Toggle between Full and Compact (list) Application Menu
    /// </summary>
    public void ToggleHostView()
    {
        _isCompact = !_isCompact;
        StateHasChanged();
    }


    /// <summary>
    /// Css builder for the main div
    /// </summary>
    private string ClassName() =>
            new CssBuilder()
                .AddClass("d-flex")
                .AddClass("flex-column")
                .AddClass("overflow-auto")
                .AddClass("overflow-x-hidden")
                .AddClass(Class)
                .Build();


    /// <summary>
    /// Style builder for the Application Menu
    /// </summary>
    private string HostStyle() =>
        new StyleBuilder()
            .AddStyle("overflow-y", "auto")
            .AddStyle("overflow-x", "hidden")
            .Build();


    /// <summary>
    /// Get's the filtered application list for Menu. Uses the AppSearchFilter as literal.
    /// </summary>
    private IEnumerable<IGrouping<string, ApplicationDefinition>> FilteredApplications() =>
        ItemsSource.Where(app => (app.Title ?? "").ToLower().Contains((_searchFilter ?? "").ToString().ToLower())).GroupBy(app => app.Group ?? "").ToList();


}
