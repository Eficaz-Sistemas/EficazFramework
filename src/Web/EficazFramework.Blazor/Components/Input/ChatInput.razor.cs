using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace EficazFramework.Components;

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
