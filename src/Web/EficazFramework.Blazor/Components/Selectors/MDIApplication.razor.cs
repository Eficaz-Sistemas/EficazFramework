using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Components;

public partial class MDIApplication
{
    [CascadingParameter(Name = "MDIContainer")] EficazFramework.Components.MDIContainer Parent { get; set; }
    [CascadingParameter(Name = "MDIApplication")] EficazFramework.Application.ApplicationInstance Application { get; set; }
    [CascadingParameter] MudBlazor.MudTabs Tabs { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment CustomToolBarActions { get; set; }

    private string ResolvedIcon()
    {
        if (Application == null)
            return "";

        string resolved = (string)(Application.Attributes.FirstOrDefault((e) => e.Key == $"Blazor:{EficazFramework.Application.ApplicationDefinitions.ICON}").Value ?? "");
        if (string.IsNullOrEmpty(resolved))
            resolved = (string)(Application.Icon ?? "");

        return resolved;
    }

    private void Close()
    {
        Parent?.CloseApp(Application);
    }

    public void SetToolBarContent(RenderFragment tools)
    {
        CustomToolBarActions = tools;
    }

    public void UpdateState()
    {
        StateHasChanged();
    }

}
