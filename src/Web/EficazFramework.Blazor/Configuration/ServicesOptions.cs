namespace EficazFramework.Configuration;

public class ServiceConfiguration
{
    public MudBlazor.MudTheme Theme { get; set; } = new MudBlazor.MudTheme()
    {
        PaletteLight = new MudBlazor.PaletteLight()
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
        PaletteDark = new MudBlazor.PaletteDark()
        {
            TextDisabled = "#404040ff",

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
            
            Surface = "#002b49",
            Background = "#002844",
            BackgroundGray = "#00223a",

            AppbarText = "#c8c8d7",
            AppbarBackground = "#00223a",

            DrawerIcon = "#c8c8d7",
            DrawerText = "#c8c8d7",
            DrawerBackground = "#002844",
            
            ActionDefault = "#fff",
            ActionDisabled = "#99994d99",
            ActionDisabledBackground = "#808080ff",
            
            LinesDefault = "#163c56",
            TableLines = "#163c56",


            GrayLight = "#2a2833",
            GrayLighter = "#1e1e2d",
            Info = "#4a86ff",
            Success = "#3dcb6c",
            Warning = "#ffb545",
            Error = "#ff3f5f",
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

    public Action<MudBlazor.Services.MudServicesConfiguration> MudBlazorConfigurations { get; set; } = new(config => { });
}
