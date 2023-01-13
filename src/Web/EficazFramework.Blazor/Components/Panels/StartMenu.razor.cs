using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace EficazFramework.Components.Panels;
public partial class StartMenu : MudBlazor.MudComponentBase
{

    private bool _isMouseOver = false;
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

    [Parameter] public bool ShowHeader { get; set; } = true;
    [Parameter] public bool ShowFooter { get; set; } = true;

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
                .AddStyle(Style)
                .Build();

    private string ContentStyle() =>
            new StyleBuilder()
                .AddStyle("border-top-left-radius", "10px", !ShowHeader)
                .AddStyle("border-top-right-radius", "10px", !ShowHeader)
                .AddStyle("border-bottom-left-radius", "10px", !ShowFooter)
                .AddStyle("border-bottom-right-radius", "10px", !ShowFooter)
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
