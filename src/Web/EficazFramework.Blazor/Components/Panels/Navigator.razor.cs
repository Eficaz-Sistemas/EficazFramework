using Microsoft.AspNetCore.Components;

namespace EficazFramework.Components;

public partial class Navigator : MudBlazor.MudBaseItemsControl<NavigatorPage>
{
    //HANDLERS:


    //FRAGMENTS:
    [Parameter]    public RenderFragment HeaderContent { get; set; }

    protected internal List<NavigatorPage> Pages = new();


    [Parameter] public RenderFragment FooterContent { get; set; }

    //HELPERS:

}
