using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Components;
public partial class Dialog : MudComponentBase
{
    protected string ContentClassname => new CssBuilder("mud-dialog-content")
    .AddClass(ContentClass)
    .Build();

    protected string ActionsClassname => new CssBuilder("mud-dialog-actions")
        .AddClass(ActionsClass)
        .Build();

    [CascadingParameter] MdiWindow? MdiWindow { get; set; }

    /// <summary>
    /// The content within this dialog.
    /// </summary>
    /// <remarks>
    /// Defaults to the content of the <see cref="MudDialog"/> being displayed.
    /// </remarks>
    [Parameter]
    [Category(CategoryTypes.Dialog.Behavior)]
    public RenderFragment? DialogContent { get; set; }

    /// <summary>
    /// The custom actions for this dialog.
    /// </summary>
    [Parameter]
    [Category(CategoryTypes.Dialog.Behavior)]
    public RenderFragment? DialogActions { get; set; }

    /// <summary>
    /// The CSS classes applied to the main dialog content.
    /// </summary>
    /// <remarks>
    /// Multiple classes must be separated by spaces.
    /// </remarks>
    [Parameter]
    [Category(CategoryTypes.Dialog.Appearance)]
    public string? ContentClass { get; set; }

    /// <summary>
    /// The CSS classes applied to the action buttons content.
    /// </summary>
    /// <remarks>
    /// Multiple classes must be separated by spaces.
    /// </remarks>
    [Parameter]
    [Category(CategoryTypes.Dialog.Appearance)]
    public string? ActionsClass { get; set; }

    /// <summary>
    /// The CSS styles applied to the main dialog content.
    /// </summary>
    [Parameter]
    [Category(CategoryTypes.Dialog.Appearance)]
    public string? ContentStyle { get; set; }

    public DefaultFocus DefaultFocus { get; set; } = MudGlobal.DialogDefaults.DefaultFocus;

    public void Close(MudBlazor.DialogResult? result) =>
        MdiWindow?.Close(result);

    public DialogInfo? Reference => (DialogInfo?)MdiWindow?.ApplicationInstance.Services[MdiWindow.DIALOGSVC];
}
