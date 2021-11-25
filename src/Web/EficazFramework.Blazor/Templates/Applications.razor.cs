using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EficazFramework.Templates;

public partial class Applications
{
    [CascadingParameter] MudBlazor.MudDialogInstance MudDialog { get; set; }
    [CascadingParameter(Name = "MDIContainer")] Components.MDIContainer MDI { get; set; }

    internal MudBlazor.MudTextField<string> searchTb;
    private string _search;
    public string Search
    {
        get { return _search; }
        set
        {
            _search = value;
            OnSearchChanged(value);
        }
    }
    private void OnSearchChanged(string e)
    {
        StateHasChanged();
    }

    IEnumerable<string> AppGroups
    {
        get
        {
            return FilteredApps.GroupBy((e) => e.Group).Select((e) => e.Key).OrderBy((e) => e).ToList();
        }
    }

    IEnumerable<EficazFramework.Application.ApplicationDefinition> FilteredApps
    {
        get
        {
            return SessionManager.ApplicationManager.AllAplications.Where(eapp =>
                                                                            CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.TooltipTilte, Search ?? "", CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) >= 0 ||
                                                                            CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.Group, Search ?? "", CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) >= 0).ToList();
        }
    }

    private void OpenApp_Button_Click(EficazFramework.Application.ApplicationDefinition app)
    {
        MDI?.Activate(app);
    }

    private string ResolvedIcon(EficazFramework.Application.ApplicationDefinition app)
    {
        if (app == null)
            return "";

        string resolved = (string)(app.Attributes.Where((e) => e.Key == $"Blazor:{EficazFramework.Application.ApplicationDefinitions.ICON}").FirstOrDefault().Value ?? "");
        if (string.IsNullOrEmpty(resolved))
            resolved = (string)(app.Icon ?? "");

        return resolved;
    }

}
