using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace EficazFramework.Components;
public partial class GroupPanel : MudBlazor.MudComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter] public string Title { get; set; } = "Group Title";

    [Parameter] public string TitleClass { get; set; }

    [Parameter] public string TitleStyle { get; set; }


    protected string Classname =>
                    new CssBuilder("ef-group-panel")
                        .AddClass(Class)
                        .Build();

    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .Build();

    protected string TitleClassName =>
                new CssBuilder()
                    .AddClass("mb-2")
                    .AddClass(TitleClass)
                    .Build();


    protected string TitleStyleName =>
            new StyleBuilder()
                .AddStyle("font-size: 0.65rem;")
                .AddStyle(TitleStyle)
                .Build();

}
