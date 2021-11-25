using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EficazFramework.Components;

public partial class Navigator : ComponentBase
{
    //PROPERTIES:
    [Parameter] public int SelectedIndex { get; set; } = -1;
    [Parameter] public EventCallback<int> SelectedIndexChanged { get; set; }

    //HANDLERS:


    //FRAGMENTS:
    [Parameter]
    public RenderFragment HeaderContent { get; set; }

    protected internal List<NavigatorPage> Pages = new();
    public RenderFragment FooterContent { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }


    //HELPERS:

}
