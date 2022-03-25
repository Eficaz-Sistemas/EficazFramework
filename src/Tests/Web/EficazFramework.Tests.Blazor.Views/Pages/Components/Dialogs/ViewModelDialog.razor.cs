using Microsoft.AspNetCore.Components;

namespace EficazFramework.Tests.Blazor.Views.Pages.Components.Dialogs;

public partial class ViewModelDialog
{
    [Inject] MudBlazor.IDialogService DialogService {get; set;}

    private string _title = "MessageBox Title";
    private string _content = "Hello World!";
    private Events.MessageType _type = Events.MessageType.Default;
    private Events.MessageButtons _buttons = Events.MessageButtons.OK;

    private async Task ShowDialog()
    {
        Events.MessageEventArgs e = new()
        {
            Title = _title,
            Content = _content,
            Buttons = _buttons,
            Type = _type
        };
        await EficazFramework.Components.Dialogs.ViewModelDialog.ShowAsync(DialogService, e);
    }
}
