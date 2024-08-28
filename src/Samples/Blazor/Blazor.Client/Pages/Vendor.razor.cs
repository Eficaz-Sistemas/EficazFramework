using Microsoft.AspNetCore.Components;

namespace Blazor.Client.Pages;

public partial class Vendor
{

    [Inject] HttpClient? HttpClient { get; set; }
    [Inject] MudBlazor.ISnackbar? Snackbar { get; set; }
    [Inject] MudBlazor.IDialogService? Dialog {  get; set; }
    [CascadingParameter] EficazFramework.Components.MdiWindow? MdiWindow { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _viewModel = new(HttpClient!);
        _viewModel.PropertyChanged += VM_PropertyChanged;
        _viewModel.StateChanged += VM_StateChanged;
        _viewModel.ShowMessage += ViewModel_Message;
        _viewModel.Commands["Get"].Execute(null);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender)
            MdiWindow?.OverrideFrameParameters(CustomHeader(), false);
    }

    private ViewModels.Vendor? _viewModel;


    private async void ViewModel_Message(object sender, EficazFramework.Events.MessageEventArgs e)
    {
        if (e.Type == EficazFramework.Events.MessageType.SnackBar)
        {
            Snackbar!.Configuration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomCenter;
            Snackbar!.Add((e.Content ?? "").ToString(), MudBlazor.Severity.Normal, config => { config.ShowCloseIcon = false; });
        }
        else
        {
            //var bp = await BrowserViewportService.GetCurrentBreakpointAsync();
            MudBlazor.DialogParameters argsParams = new()
            {
                { "Args", e }
            };
            var dialog = Dialog!.Show<EficazFramework.Components.Dialogs.ViewModelDialog>(e.Title, argsParams, new MudBlazor.DialogOptions() { BackdropClick = false, Position = MudBlazor.DialogPosition.Center });
            EficazFramework.Events.MessageResult result = (EficazFramework.Events.MessageResult)(await dialog.Result)!.Data!;
            e.ModalAssist.Release(result);
            StateHasChanged();
        }
    }


    private void VM_StateChanged(object? sender, EventArgs e)
    {
        MdiWindow?.OverrideFrameParameters(CustomHeader(), false);
        StateHasChanged();
    }


    private void VM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsLoading")
        {
            StateHasChanged();
        }
    }


    string? _searchString;

    private Func<Shared.DTOs.VendorDto, bool> _quickFilter => x =>
    {
        if (string.IsNullOrWhiteSpace(_searchString))
            return true;

        if (x.Name?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
            return true;

        return false;
    };

}
