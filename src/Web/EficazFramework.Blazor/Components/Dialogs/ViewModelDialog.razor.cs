using Microsoft.AspNetCore.Components;
namespace EficazFramework.Components.Dialogs;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public partial class ViewModelDialog
{
    [CascadingParameter] MudBlazor.MudDialogInstance MudDialog { get; set; }
    [Parameter] public EficazFramework.Events.MessageEventArgs Args { get; set; }

    public static async Task<Events.MessageResult> ShowAsync(MudBlazor.IDialogService dialogService,
                                                             Events.MessageEventArgs messageArgs,
                                                             MudBlazor.DialogParameters? mudDialogParams = null,
                                                             MudBlazor.DialogOptions? mudDialogOptions = null)
    {
        if (messageArgs.Type != Events.MessageType.Default)
            return Events.MessageResult.Cancel;

        mudDialogParams ??= new();

        mudDialogOptions ??= new() { DisableBackdropClick = true};

        mudDialogParams?.Add("Args", messageArgs);

        MudBlazor.IDialogReference _dialog = dialogService.Show<ViewModelDialog>(messageArgs.Title,
                                                                                 mudDialogParams,
                                                                                 mudDialogOptions);

        Events.MessageResult result = (Events.MessageResult)(await _dialog.Result).Data;
        messageArgs.ModalAssist.Release(result);
        return result;
    }
}
