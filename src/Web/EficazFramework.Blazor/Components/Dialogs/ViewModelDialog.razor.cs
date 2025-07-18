﻿using Microsoft.AspNetCore.Components;
namespace EficazFramework.Components.Dialogs;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public partial class ViewModelDialog
{
    [Parameter] public EficazFramework.Events.MessageEventArgs Args { get; set; }
    private Dialog? RefDialog;

    public static async Task<Events.MessageResult> ShowAsync(MdiWindow mdiWindow,
                                                             Events.MessageEventArgs messageArgs,
                                                             MudBlazor.DialogParameters? mudDialogParams = null,
                                                             MudBlazor.DialogOptions? mudDialogOptions = null)
    {
        if (messageArgs.Type != Events.MessageType.Default)
            return Events.MessageResult.Cancel;

        mudDialogParams ??= [];

        mudDialogOptions ??= new() { BackdropClick = false, CloseButton = false, CloseOnEscapeKey = false};

        mudDialogParams?.Add("Args", messageArgs);

        var _dialog = await mdiWindow.ShowDialogAsync<ViewModelDialog>(messageArgs.Title,
                                                                       mudDialogParams!,
                                                                       mudDialogOptions);

        Events.MessageResult result = (Events.MessageResult)(await _dialog!.Result)!.Data!;
        messageArgs.ModalAssist.Release(result);
        return result;
    }
}
