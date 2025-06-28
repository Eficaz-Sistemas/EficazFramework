using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;

namespace EficazFramework.Components;

public partial class SnackbarProvider : MudComponentBase, IDisposable
{
    [Parameter]  public MudBlazor.ISnackbar? SnackbarService { get; set; }

    [CascadingParameter(Name = "RightToLeft")]
    public bool RightToLeft { get; set; }

    protected IEnumerable<MudBlazor.Snackbar> Snackbar => SnackbarService?.Configuration.NewestOnTop ?? true
        ? SnackbarService?.ShownSnackbars.Reverse()
        : SnackbarService?.ShownSnackbars;

    protected string Classname =>
        new CssBuilder(Class)
            .AddClass(GetPositionClass())
            .Build();

    protected string Stylename =>
        new StyleBuilder()
            .AddStyle(Style)
            .AddStyle("position", "absolute")
            .Build();

    private string GetPositionClass()
    {
        var positionClass = SnackbarService?.Configuration.PositionClass;
        return positionClass switch
        {
            MudBlazor.Defaults.Classes.Position.BottomStart => RightToLeft ? MudBlazor.Defaults.Classes.Position.BottomRight : MudBlazor.Defaults.Classes.Position.BottomLeft,
            MudBlazor.Defaults.Classes.Position.BottomEnd => RightToLeft ? MudBlazor.Defaults.Classes.Position.BottomLeft : MudBlazor.Defaults.Classes.Position.BottomRight,
            MudBlazor.Defaults.Classes.Position.TopStart => RightToLeft ? MudBlazor.Defaults.Classes.Position.TopRight : MudBlazor.Defaults.Classes.Position.TopLeft,
            MudBlazor.Defaults.Classes.Position.TopEnd => RightToLeft ? MudBlazor.Defaults.Classes.Position.TopLeft : MudBlazor.Defaults.Classes.Position.TopRight,
            _ => positionClass
        };
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SnackbarService!.OnSnackbarsUpdated += OnSnackbarsUpdated;
    }


    private void OnSnackbarsUpdated() =>
        InvokeAsync(StateHasChanged);

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            SnackbarService!.OnSnackbarsUpdated -= OnSnackbarsUpdated;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
