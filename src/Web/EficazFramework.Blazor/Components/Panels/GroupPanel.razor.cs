using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace EficazFramework.Components;
public partial class GroupPanel : MudBlazor.MudComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public string Title { get; set; } = "Group Title";

    protected string Classname =>
                    new CssBuilder("ef-group-panel")
                        .AddClass(Class)
                        .Build();

    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .Build();


}
