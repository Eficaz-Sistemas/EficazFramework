using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using static MudBlazor.CategoryTypes;

namespace EficazFramework.Components.Dialogs;
public partial class AbsoluteDialogContainer
{
    private ElementReference _dialogContainerReference;

    protected string TitleClassname =>
        new CssBuilder("mud-dialog-title")
        .AddClass("ef-dialog-title")
            .Build();

    protected string Classname =>
        new CssBuilder("mud-dialog")
            .AddClass("ef-dialog")
            .Build();

    protected string BackgroundClassname =>
        new CssBuilder("mud-overlay-dialog")
            .AddClass($"mud-skip-overlay-section") // dialog overlay remains outside of Section
            .AddClass("mud-skip-overlay-positioning") // popovers try to position the overlay by zindex, this skips that behavior if a user puts the dialog provider above the popover provider
            .Build();

    /// <summary>
    /// The options used for this dialog.
    /// </summary>
    /// <remarks>
    /// Defaults to the options in the <see cref="MudDialog"/> or options passed during <see cref="DialogService.ShowAsync(Type)"/> methods.
    /// </remarks>
    [Parameter]
    [Category(CategoryTypes.Dialog.Misc)] // Behavior and Appearance
    public DialogOptions Options { get; set; } = new MudBlazor.DialogOptions();

    /// <summary>
    /// The text displayed at the top of this dialog if <see cref="TitleContent" /> is not set.
    /// </summary>
    [Parameter]
    [Category(CategoryTypes.Dialog.Behavior)]
    public string? Title { get; set; }

    /// <summary>
    /// The custom content at the top of this dialog.
    /// </summary>
    /// <remarks>
    /// This content will display so long as <see cref="Title"/> is not set.
    /// </remarks>
    [Parameter]
    [Category(CategoryTypes.Dialog.Behavior)]
    public RenderFragment? TitleContent { get; set; }

    /// <summary>
    /// The content within this dialog.
    /// </summary>
    /// <remarks>
    /// Defaults to the content of the <see cref="MudDialog"/> being displayed.
    /// </remarks>
    [Parameter]
    [Category(CategoryTypes.Dialog.Behavior)]
    public RenderFragment? Content { get; set; }
}
