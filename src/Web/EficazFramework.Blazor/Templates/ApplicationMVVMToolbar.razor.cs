using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EficazFramework.ViewModels.Services;

namespace EficazFramework.Templates;

public partial class ApplicationMVVMToolbar<T>
    where T : class
{
    [Parameter] public Components.MDIApplication Application { get; set; }
    [Parameter] public ViewModels.ViewModel<T> ViewModel { get; set; }

    [Parameter] public bool Filter_Input { get; set; }
    private string _filtertext;
    [Parameter]
    public string Filter_Text
    {
        get => _filtertext;
        set
        {
            _filtertext = value;
            Filter_TextChanged.InvokeAsync(value);
        }
    }
    [Parameter] public EventCallback<string> Filter_TextChanged { get; set; }



    [Parameter] public bool Command_Refresh { get; set; }
    [Parameter] public bool Command_AddNew { get; set; }

    [Parameter] public bool Command_Save { get; set; }
    [Parameter] public bool Command_SaveAll { get; set; }
    [Parameter] public bool Command_Cancel { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    private string GetDetailName()
    {
        var navigator = ViewModel.GetIndexNavigator();
        if (navigator == null)
            return string.Empty;

        return navigator.CurrentDetail;
    }


}
