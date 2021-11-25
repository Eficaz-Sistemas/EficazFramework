using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace EficazFramework.Templates;

public partial class Footer
{
    [Parameter]
    public bool Fixed { get; set; } = true;

    protected string Classname =>
                        new CssBuilder("footer")
                            .AddClass("footer-fixed", Fixed)
                            .AddClass("d-flex")
                            .Build();
    //.AddClass($"mud-appbar-drawer-open", LayoutState?.DrawerOpen)
    //.AddClass($"mud-appbar-drawer-clipped", LayoutState?.DrawerClipped)
    //.AddClass($"d-flex jjustify-space-between", LayoutState?.DrawerClipped)

    [Parameter] public string Style { get; set; }

}
