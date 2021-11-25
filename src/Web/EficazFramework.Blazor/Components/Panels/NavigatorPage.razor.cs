using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EficazFramework.Components;

public partial class NavigatorPage : ComponentBase
{
    protected string ClassNames =>
        new MudBlazor.Utilities.CssBuilder()
                                .AddClass(Parent?.Class, Parent != null)
                                .AddClass("navitem_main", Fit == true)
                                .AddClass("navitem_animate", IsAnimated == true)
                                .AddClass(Class)
                                .Build();

    [Parameter] public RenderFragment ChildContent { get; set; }
    [CascadingParameter] protected internal Navigator Parent { get; set; }

    [Parameter] public bool IsAnimated { get; set; } = true;
    [Parameter] public bool Fit { get; set; } = true;
    public bool IsVisible => Parent.SelectedIndex == Parent.Pages.IndexOf(this);
    protected bool WasVisible { get; private set; }

    protected override void OnInitialized()
    {
        Parent.Pages.Add(this);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await PageRenderedAsync.InvokeAsync(firstRender);
    }

    [Parameter] public EventCallback<bool> PageRenderedAsync { get; set; }

}
