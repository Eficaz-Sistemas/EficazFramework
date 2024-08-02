using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Components;

[ExcludeFromCodeCoverage]
public partial class ChatMessageField : MudTextField<string>
{
    private ChatInput _elementReference;

    [Parameter] public EventCallback<ClipboardEventArgs> OnPaste { get; set; }

    protected virtual void InvokePaste(ClipboardEventArgs obj)
    {
        _isFocused = true;
        OnPaste.InvokeAsync(obj);
    }
}
