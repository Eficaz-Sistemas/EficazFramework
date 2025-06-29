using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace EficazFramework.Components;

public class DialogInfo
{
    internal string Title { get; set; } = string.Empty;
    internal RenderFragment? TitleContent { get; set; }
    internal Type Type { get; set; }
    internal Dictionary<string, object?> Parameters { get; set; } = [];
    internal MudBlazor.DialogOptions? Options { get; set; }


    private readonly TaskCompletionSource<DialogResult?> _resultCompletion = new();
    public Task<MudBlazor.DialogResult?> Result  => _resultCompletion.Task;

    public void Close(MudBlazor.DialogResult? result)
    {
        _resultCompletion.TrySetResult(result);
    }
}
