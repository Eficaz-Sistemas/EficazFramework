﻿using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EficazFramework.Templates;

public partial class NavBarApps
{
    [Inject] public EficazFramework.Application.IApplicationManager AppManager { get; set; }
    [CascadingParameter] private EficazFramework.Layouts.MudAppBarDrawerLayout DrawerLayout { get; set; }

    //internal MudBlazor.MudTextField<string> searchTb;
    private string _search;
    public string Search
    {
        get => _search;
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
            return AppManager.AllApplications.Where(eapp =>
                CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.TooltipTilte, Search ?? "", CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) >= 0 ||
                CultureInfo.InvariantCulture.CompareInfo.IndexOf(eapp.Group, Search ?? "", CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) >= 0).ToList();
        }
    }

    private string ResolvedIcon(EficazFramework.Application.ApplicationDefinition app)
    {
        if (app == null)
            return "";

        string resolved = (string)((app.Attributes.Where((e) => e.Key == $"Blazor:{EficazFramework.Application.ApplicationDefinitions.ICON}").FirstOrDefault()?.Value) ?? "");
        if (string.IsNullOrEmpty(resolved))
            resolved = (string)(app.Icon ?? "");

        return resolved;
    }

    private string ResolveGroupTitleClass(string targeClass = "d-none")
    {
        return !(DrawerLayout?.DrawerOpen ?? false) ? targeClass : "";
    }

}
