﻿using Microsoft.AspNetCore.Components;

namespace EficazFramework.Tests.Blazor.Views.Pages.Components.Dialogs;

public partial class ViewModelDialog
{
    [Inject] MudBlazor.IDialogService? DialogService { get; set; }
    [Inject] MudBlazor.ISnackbar? Snackbar { get; set; }


    public string _title = "MessageBox Title";
    public string _content = "Hello World!";
    public Events.MessageType _type = Events.MessageType.Default;
    public Events.MessageButtons _buttons = Events.MessageButtons.OK;

    private readonly Events.MessageEventArgs _labs = new()
    {
        Title = "Teste",
        Content = "Funciona?",
        Buttons = Events.MessageButtons.YesNo,
        Type = Events.MessageType.Default
    };

    public async Task ShowDialog()
    {
        Events.MessageEventArgs e = new()
        {
            Title = _title,
            Content = _content,
            Buttons = _buttons,
            Type = _type
        };
        var result = await EficazFramework.Components.Dialogs.MudViewModelDialog.ShowAsync(DialogService!, e);
        Snackbar!.Add(result.ToString());
    }
}
