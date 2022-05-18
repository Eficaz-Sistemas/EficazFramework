using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace EficazFramework.Components;
public partial class GroupPanel : MudBlazor.MudComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public string Title { get; set; } = "Group Title";

    protected string Classname =>
                    new CssBuilder()
                        .AddClass(Class)
                        .AddClass("ma-2 px-2 pb-2")
                        .Build();

    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .AddStyle("background-color: var(--mud-palette-background-grey)")
                    .Build();


}
