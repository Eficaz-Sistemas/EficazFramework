using Microsoft.AspNetCore.Components;

namespace EficazFramework.Components.Dialogs;

public partial class ViewModelDialog
{
    [CascadingParameter] MudBlazor.MudDialogInstance MudDialog { get; set; }
    [Parameter] public EficazFramework.Events.MessageEventArgs Args { get; set; }
}
