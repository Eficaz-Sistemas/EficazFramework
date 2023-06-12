using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Utilities;

namespace EficazFramework.Components;
public partial class FocusTrapEx : MudFocusTrap
{

    protected string HostClassName =>
        new CssBuilder()
            .AddClass(Class)
            .Build();

    /// <summary>
    /// User class names, separated by space, the the ChildContent host.
    /// </summary>
    [Parameter]
    [Category(CategoryTypes.ComponentBase.Common)]
    public string? HostClass { get; set; }

    private bool _shiftDown;
    private bool _initialized;
    private bool _shouldRender = true;


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
            await SaveFocusAsync();

        if (!_initialized)
            await InitializeFocusAsync();
    }

    private Task OnBottomFocusAsync(FocusEventArgs args)
    {
        return FocusLastAsync();
    }

    private Task OnBumperFocusAsync(FocusEventArgs args)
    {
        return _shiftDown ? FocusLastAsync() : FocusFirstAsync();
    }

    private Task OnRootFocusAsync(FocusEventArgs args)
    {
        return FocusFallbackAsync();
    }

    internal void OnRootKeyDown(KeyboardEventArgs args)
    {
        HandleKeyEvent(args);
    }

    private void OnRootKeyUp(KeyboardEventArgs args)
    {
        HandleKeyEvent(args);
    }

    private Task OnTopFocusAsync(FocusEventArgs args)
    {
        return FocusFirstAsync();
    }

    private Task InitializeFocusAsync()
    {
        _initialized = true;

        if (!Disabled)
        {
            switch (DefaultFocus)
            {
                case DefaultFocus.Element: return FocusFallbackAsync();
                case DefaultFocus.FirstChild: return FocusFirstAsync();
                case DefaultFocus.LastChild: return FocusLastAsync();
            }
        }
        return Task.CompletedTask;
    }

    private Task FocusFallbackAsync()
    {
        return _fallback.FocusAsync().AsTask();
    }

    private Task FocusFirstAsync()
    {
        return _root.MudFocusFirstAsync(2, 4).AsTask();
    }

    private Task FocusLastAsync()
    {
        return _root.MudFocusLastAsync(2, 4).AsTask();
    }

    private void HandleKeyEvent(KeyboardEventArgs args)
    {
        _shouldRender = false;
        if (args.Key == "Tab")
            _shiftDown = args.ShiftKey;
    }

    private Task RestoreFocusAsync()
    {
        return _root.MudRestoreFocusAsync().AsTask();
    }

    private Task SaveFocusAsync()
    {
        return _root.MudSaveFocusAsync().AsTask();
    }


    protected override bool ShouldRender()
    {
        if (_shouldRender)
            return true;
        _shouldRender = true; // auto-reset _shouldRender to true
        return false;
    }
}
