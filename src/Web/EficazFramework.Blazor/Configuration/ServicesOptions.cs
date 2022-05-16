namespace EficazFramework.Configuration;

public class ServiceConfiguration
{
    public MudBlazor.MudTheme Theme { get; set; } = new MudBlazor.MudTheme()
    {
        Palette = new MudBlazor.Palette()
        {
            PrimaryDarken = "#00172b",
            Primary = "#0060ad",
            PrimaryLighten = "#008dff",
            PrimaryContrastText = "#fff",

            SecondaryDarken = "#008071",
            Secondary = "#3cdbc0",
            SecondaryLighten = "#47ffe0",
            SecondaryContrastText = "#fff",

            TertiaryDarken = "#687e86",
            Tertiary = "#869CAE",
            TertiaryLighten = "#869CAE",
            TertiaryContrastText = "#FF000000",

            AppbarBackground = "#0078d7",
            AppbarText = "#fff",
        },
        PaletteDark = new MudBlazor.Palette()
        {
            PrimaryDarken = "#00172b",
            Primary = "#0060ad",
            PrimaryLighten = "#008dff",
            PrimaryContrastText = "#fff",
            TextPrimary = "#fff",

            SecondaryDarken = "#008071",
            Secondary = "#3cdbc0",
            SecondaryLighten = "#47ffe0",
            SecondaryContrastText = "#fff",
            TextSecondary = "#fff",

            TertiaryDarken = "#687e86",
            Tertiary = "#869CAE",
            TertiaryLighten = "#869CAE",
            TertiaryContrastText = "#000000",
            
            Surface = "#002844",
            Background = "#002b49",
            BackgroundGrey = "#00223a",

            AppbarText = "#c8c8d7",
            AppbarBackground = "#00223a",
            DrawerBackground = "#002844",
            
            ActionDefault = "#74718e",
            ActionDisabled = "#99994d99",
            ActionDisabledBackground = "#808080ff",
            TextDisabled = "#404040ff",
            
            DrawerIcon = "#92929f",
            DrawerText = "#92929f",
            GrayLight = "#2a2833",
            GrayLighter = "#1e1e2d",
            Info = "#4a86ff",
            Success = "#3dcb6c",
            Warning = "#ffb545",
            Error = "#ff3f5f",
            LinesDefault = "#33323e",
            TableLines = "#33323e",
            Divider = "#292838",
            OverlayLight = "#1e1e2d80"
        },
        Typography= new()
        {
            Default = new()
            {
                FontFamily = new[] { "Public Sans", "Source Sans Pro", "Roboto", "sans-serif" },
                LetterSpacing = "normal"
            },
            H1 = new()
            {
                FontSize = "4rem",
                FontWeight = 700,
            },
            H3 = new()
            {
                FontSize = "3rem",
                FontWeight = 600,
                LineHeight = 1.8,
            },
            H4 = new()
            {
                FontSize = "1.8rem",
                FontWeight = 700,
            },
            H5 = new()
            {
                FontSize = "1.8rem",
                FontWeight = 700,
                LineHeight = 2,
            },
            H6 = new()
            {
                FontSize = "1.125rem",
                FontWeight = 700,
                LineHeight = 2,
            },
            Subtitle1 = new()
            {
                FontSize = "1.1rem",
                FontWeight = 500
            },
            Subtitle2 = new()
            {
                FontSize = "1rem",
                FontWeight = 600,
                LineHeight = 1.8,
            },
            Body1 = new()
            {
                FontSize = "1rem",
                FontWeight = 400
            },
            Button = new()
            {
                TextTransform = "none"
            }
        }
    };

    public bool ThemeIsDarkMode { get; set; } = false;

    public bool UseApplicationManager { get; set; } = false;

    public MudBlazor.Services.MudServicesConfiguration MudBlazorConfigurations { get; set; }
}
