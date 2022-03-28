using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Components;

[ExcludeFromCodeCoverage]
public partial class ChatInput : MudBlazor.MudInput<string>
{
    private ElementReference _elementReference;

    [Parameter] public new EventCallback<ClipboardEventArgs> OnPaste { get; set; }

    protected virtual void InvokePaste(ClipboardEventArgs obj)
    {
        _isFocused = true;
        OnPaste.InvokeAsync(obj).AndForget();
    }
}
