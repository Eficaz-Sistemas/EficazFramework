using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EficazFramework.Utilities;

namespace EficazFramework.Components;

public partial class ObservableElement : ComponentBase, IDisposable
{
    [Inject] public IJSRuntime JSRuntime { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public bool Permanent { get; set; } = false;
    [Parameter] public bool AutoStart { get; set; } = false;
    [Parameter] public string ObserverQuery { get; set; }
    [Parameter] public string? TargetQuery { get; set; }

    protected string Classname =>
                new CssBuilder()
                    .AddClass(Class)
                    .Build();

    private bool _started = false;
    private ElementReference _elementReference;

    public static string ActiveClass { get; set; } = "on-screen";

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && AutoStart)
            StartObserve();
        return base.OnAfterRenderAsync(firstRender);
    }

    public void StartObserve()
    {
        if (_started == true)
            return;
        _started = true;
        JSRuntime.StartObserve(ObserverQuery, ActiveClass, Permanent, null, TargetQuery);
    }

    public void StopObserve()
    {
        if (_started == false)
            return;
        _started = false;
        //Utilities.JsInterop.StopObserve(JSRuntime, ObserverQuery);
    }

    public void Dispose()
    {
        if (JSRuntime != null)
            StopObserve();
        //stops observer
    }
}
