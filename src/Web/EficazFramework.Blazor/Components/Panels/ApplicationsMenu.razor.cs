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
    [Parameter] public IEnumerable<IApplicationDefinition> ItemsSource { get; set; } = [];


    /// <summary>
    /// Raised when Application's menu button is clicked.
    /// </summary>
    [Parameter] public Action<ApplicationDefinition>? SelectionCallBack { get; set; } = null;

    /// <summary>
    /// The function to group applications. Default is by <see cref="ApplicationDefinition.Group"/> property.
    /// Since C# 14 you can use Exntesion Properties here and have custom grouping logic.
    /// </summary>
    [Parameter] public Func<IApplicationDefinition, string> GroupingExpression { get; set; } = app => app.Group ?? "";


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
    private IList<IGrouping<string, IApplicationDefinition>> FilteredApplications()
    {
        if (string.IsNullOrEmpty(_searchFilter))
        {
            return [.. ItemsSource.Where(app => app.IsEnabled).GroupBy(GroupingExpression)];
        }
        else
        {
            return [.. ItemsSource.Where(app => (app.Title ?? "").Contains((_searchFilter ?? "").ToString(), StringComparison.CurrentCultureIgnoreCase) ||
                                        ((app as GroupApplicationDefinition)?.Applications.Any((sApp) => (sApp.Title ?? "").Contains((_searchFilter ?? "").ToString(), StringComparison.CurrentCultureIgnoreCase)) ?? false))
                                  .GroupBy(GroupingExpression)];
        }
    }

    private void MenuButtonClick(IApplicationDefinition iApp, GroupApplicationDefinition? gMainApp = null) 
    {
        if (iApp is ApplicationDefinition app)
        {
            SelectionCallBack?.Invoke(app);

            if (gMainApp is not null)
                gMainApp.IsExpanded = false;
        }
        else if (iApp is GroupApplicationDefinition gApp)
            ToggleMenuButton(gApp);
    }

    private void ToggleMenuButton(GroupApplicationDefinition gApp)
    {
        gApp.IsExpanded = !gApp.IsExpanded;
    }
}
