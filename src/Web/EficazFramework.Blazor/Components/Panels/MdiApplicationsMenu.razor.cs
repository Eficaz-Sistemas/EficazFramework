using EficazFramework.Application;
using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using System.Collections.ObjectModel;

namespace EficazFramework.Components.Panels;

public partial class MdiApplicationsMenu
{

    private string _appSearchFilter = "";
    /// <summary>
    /// The literal for searching for applications on the list
    /// </summary>
    [Parameter]
    public string AppSearchFilter
    {
        get => _appSearchFilter;
        set
        {
            _appSearchFilter = value;
            StateHasChanged();
        }
    }


    /// <summary>
    /// Aplication source for menu.
    /// </summary>
    [Parameter] public ObservableCollection<ApplicationDefinition> ApplicationsSource { get; set; } = new();


    /// <summary>
    /// Raised when Application's menu button is clicked.
    /// </summary>
    public Action<ApplicationDefinition>? ApplicationSelectedCallBack { get; set; } = null;


    private bool _startMenuIsOpen = false;
    public bool StartMenuIsOpen => _startMenuIsOpen;


    private bool _startMenuIsCompact = false;
    /// <summary>
    /// Toggle between Full and Compact (list) Application Menu
    /// </summary>
    public void ToggleStartMenuView()
    {
        _startMenuIsCompact = !_startMenuIsCompact;
        StateHasChanged();
    }


    /// <summary>
    /// Style builder for the Application Menu
    /// </summary>
    private string StartMenuAppsHostStyle() =>
        new StyleBuilder()
            .AddStyle("overflow-y", "auto")
            .AddStyle("overflow-x", "hidden")
            .Build();


    /// <summary>
    /// Get's the filtered application list for Menu. Uses the AppSearchFilter as literal.
    /// </summary>
    private IEnumerable<IGrouping<string, ApplicationDefinition>> FilteredApplications() =>
        ApplicationsSource.Where(app => (app.Title ?? "").ToLower().Contains((_appSearchFilter ?? "").ToString().ToLower())).GroupBy(app => app.Group).ToList();


}
