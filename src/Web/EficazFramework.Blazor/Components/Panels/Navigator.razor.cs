using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EficazFramework.Components;

public partial class Navigator : MudBlazor.MudBaseItemsControl<NavigatorPage>
{
    //HANDLERS:


    //FRAGMENTS:
    [Parameter]
    public RenderFragment HeaderContent { get; set; }

    protected internal List<NavigatorPage> Pages = new();
    public RenderFragment FooterContent { get; set; }

    //HELPERS:

}
