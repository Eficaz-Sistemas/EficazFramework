namespace EficazFramework.Services;

public interface IThemeProvider
{
    public MudBlazor.MudTheme Theme { get; set; }
    public bool IsDarkMode { get; set; }
}

internal class ThemeProvider : IThemeProvider
{
    internal ThemeProvider(MudBlazor.MudTheme theme)
    {
        Theme = theme;
    }

    public MudBlazor.MudTheme Theme { get; set; }
    public bool IsDarkMode { get; set; } = false;

}
