using Microsoft.AspNetCore.Components;

namespace EficazFramework.Components.Dialogs;

public partial class ViewModelDialog
{
    [CascadingParameter] MudBlazor.MudDialogInstance MudDialog { get; set; }
    [Parameter] public EficazFramework.Events.MessageEventArgs Args { get; set; }

    public static async Task ShowAsync(MudBlazor.IDialogService dialogService,
                                       Events.MessageEventArgs messageArgs, 
                                       MudBlazor.DialogParameters? mudDialogParams = null,
                                       MudBlazor.DialogOptions? mudDialogOptions = null)
    {
        if (messageArgs.Type != Events.MessageType.Default)
            return;

        if (mudDialogParams == null)
            mudDialogParams = new();

        mudDialogParams?.Add("Args", messageArgs);

        MudBlazor.IDialogReference _dialog = dialogService.Show<ViewModelDialog>(messageArgs.Title, 
                                                                                 mudDialogParams,
                                                                                 mudDialogOptions);

        Events.MessageResult result = (Events.MessageResult)(await _dialog.Result).Data;
        messageArgs.ModalAssist.Release(result);
    }
}
