using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace EficazFramework.Components.Panels;
public partial class StartMenu : MudBlazor.MudComponentBase
{
    private bool _isOpen = false;
    [Parameter] public bool IsOpen
    {
        get => _isOpen;
        set
        {
            _isOpen = value;
        }
    }

    [Parameter] public string Icon { get; set; } = EficazFramework.Icons.Brands.Eficaz;

    [Parameter] public int Elevation { get; set; } = 8;

    [Parameter] public RenderFragment? Header { get; set; }
    [Parameter] public RenderFragment? Content { get; set; }
    [Parameter] public RenderFragment? Footer { get; set; }

    [Parameter] public string Tooltip { get; set; } = Resources.Strings.Components.MDIContainer_StartTab;

    [Parameter] public MudBlazor.Origin AnchorOrigin { get; set; } = MudBlazor.Origin.TopLeft;

    [Parameter] public MudBlazor.Origin TransformOrigin { get; set; } = MudBlazor.Origin.BottomLeft;

    /// <summary>
    /// Css builder for the Start Menu Button
    /// </summary>
    private string ToggleButtonClass() =>
            new CssBuilder()
                .AddClass("ef-mdi-buttons-toolbar")
                .AddClass(Class)
                .Build();

    /// <summary>
    /// Style builder for the Start Menu Button
    /// </summary>
    private string ToggleButtonStyle() =>
            new StyleBuilder()
                .AddStyle("padding", "8px")
                .AddStyle("padding-left", "12px")
                .AddStyle("padding-right", "12px")
                .AddStyle("border-radius", "0px")
                .AddStyle("border", "solid 3px transparent")
                .AddStyle(Style)
                .Build();

    /// <summary>
    /// Toggle the Start Menu into Opened/Closed states.
    /// </summary>
    /// <param name="onlyClose">Just act as closing the menu</param>
    public void ToggleOpen(bool onlyClose = false)
    {
        if (onlyClose)
            _isOpen = false;
        else
            _isOpen = !_isOpen;

        StateHasChanged();
    }


}
