using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EficazFramework.Components;

public partial class NavigatorPage : MudBlazor.MudComponentBase
{
    protected string ClassNames =>
        new MudBlazor.Utilities.CssBuilder()
                                .AddClass(Parent?.Class, Parent != null)
                                .AddClass("d-flex", Fit == true)
                                .AddClass("flex-grow-1", Fit == true)
                                .AddClass(Class)
                                .Build();

    [Parameter] public RenderFragment ChildContent { get; set; }
    [CascadingParameter] protected internal Navigator Parent { get; set; }

    [Parameter] public bool Fit { get; set; } = true;
    public bool IsVisible => Parent.SelectedIndex == Parent.Pages.IndexOf(this);

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
