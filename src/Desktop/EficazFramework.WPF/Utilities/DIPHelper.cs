using System.Globalization;

namespace EficazFramework.Utilities;

/// <summary>
/// A helper class for DIP (Device Independent Pixels) conversion and scaling operations.
/// </summary>
public sealed partial class DipHelper
{
    private DipHelper()
    {
    }
    /// <summary>
    /// Converts millimeters to DIP (Device Independant Pixels).
    /// </summary>
    /// <param name="mm">A millimeter value.</param>
    /// <returns>A DIP value.</returns>
    public static double MmToDip(double mm) =>
        CmToDip(mm / 10.0d);

    /// <summary>
    /// Converts centimeters to DIP (Device Independant Pixels).
    /// </summary>
    /// <param name="cm">A centimeter value.</param>
    /// <returns>A DIP value.</returns>
    public static double CmToDip(double cm) =>
        cm * 96.0d / 2.54d;

    /// <summary>
    /// Converts inches to DIP (Device Independant Pixels).
    /// </summary>
    /// <param name="inch">An inch value.</param>
    /// <returns>A DIP value.</returns>
    public static double InchToDip(double inch) =>
        inch * 96.0d;

    /// <summary>
    /// Converts DIP (Device Independant Pixels) to inches.
    /// </summary>
    /// <param name="dip">A DIP value.</param>
    /// <returns>An inch value.</returns>
    public static double DipToInch(double dip) =>
        dip / 96.0d;

    /// <summary>
    /// Converts font points to DIP (Device Independant Pixels).
    /// </summary>
    /// <param name="pt">A font point value.</param>
    /// <returns>A DIP value.</returns>
    public static double PtToDip(double pt) =>
        pt * 96.0d / 72.0d;

    /// <summary>
    /// Converts DIP (Device Independant Pixels) to centimeters.
    /// </summary>
    /// <param name="dip">A DIP value.</param>
    /// <returns>A centimeter value.</returns>
    public static double DipToCm(double dip) =>
        dip * 2.54d / 96.0d;

    /// <summary>
    /// Converts DIP (Device Independant Pixels) to millimeters.
    /// </summary>
    /// <param name="dip">A DIP value.</param>
    /// <returns>A millimeter value.</returns>
    public static double DipToMm(double dip) =>
        DipToCm(dip) * 10.0d;

    /// <summary>
    /// Gets the system DPI scale factor (compared to 96 dpi).
    /// From http://blogs.msdn.com/jaimer/archive/2007/03/07/getting-system-dpi-in-wpf-app.aspx
    /// Should not be called before the Loaded event (else XamlException mat throw)
    /// </summary>
    /// <returns>A Point object containing the X- and Y- scale factor.</returns>
    private static System.Windows.Point GetSystemDpiFactor()
    {
        PresentationSource source = PresentationSource.FromVisual(System.Windows.Application.Current.MainWindow);
        Matrix m = source.CompositionTarget.TransformToDevice;
        return new System.Windows.Point(m.M11, m.M22);
    }

    private const double DpiBase = 96.0d;

    /// <summary>
    /// Gets the system configured DPI.
    /// </summary>
    /// <returns>A Point object containing the X- and Y- DPI.</returns>
    public static System.Windows.Point GetSystemDpi()
    {
        var sysDpiFactor = GetSystemDpiFactor();
        return new System.Windows.Point((int)Math.Round(sysDpiFactor.X * DpiBase), (int)Math.Round(sysDpiFactor.Y * DpiBase));
    }

    /// <summary>
    /// Gets the physical pixel density (DPI) of the screen.
    /// </summary>
    /// <param name="diagonalScreenSize">Size - in inch - of the diagonal of the screen.</param>
    /// <returns>A Point object containing the X- and Y- DPI.</returns>
    public static System.Windows.Point GetPhysicalDpi(double diagonalScreenSize)
    {
        var sysDpiFactor = GetSystemDpiFactor();
        double pixelScreenWidth = SystemParameters.PrimaryScreenWidth * sysDpiFactor.X;
        double pixelScreenHeight = SystemParameters.PrimaryScreenHeight * sysDpiFactor.Y;
        double formatRate = pixelScreenWidth / pixelScreenHeight;
        double inchHeight = diagonalScreenSize / Math.Sqrt(formatRate * formatRate + 1.0d);
        double inchWidth = formatRate * inchHeight;
        double xDpi = Math.Round(pixelScreenWidth / inchWidth);
        double yDpi = Math.Round(pixelScreenHeight / inchHeight);
        return new System.Windows.Point((int)Math.Round(xDpi), (int)Math.Round(yDpi));
    }

    /// <summary>
    /// Converts a DPI into a scale factor (compared to system DPI).
    /// </summary>
    /// <param name="dpi">A Point object containing the X- and Y- DPI to convert.</param>
    /// <returns>A Point object containing the X- and Y- scale factor.</returns>
    public static System.Windows.Point DpiToScaleFactor(System.Windows.Point dpi)
    {
        var sysDpi = GetSystemDpi();
        return new System.Windows.Point((int)Math.Round(dpi.X / (double)sysDpi.X), (int)Math.Round(dpi.Y / (double)sysDpi.Y));
    }

    /// <summary>
    /// Gets the scale factor to apply to a WPF application
    /// so that 96 DIP always equals 1 inch on the screen (whatever the system DPI).
    /// </summary>
    /// <param name="diagonalScreenSize">Size - in inch - of the diagonal of the screen</param>
    /// <returns>A Point object containing the X- and Y- scale factor.</returns>
    public static System.Windows.Point GetScreenIndependentScaleFactor(double diagonalScreenSize) =>
        DpiToScaleFactor(GetPhysicalDpi(diagonalScreenSize));

    private static int tier = 0;

    public static int PrimaryScreenResolutionTier
    {
        get
        {
            int h = 0;
            if (tier == 0)
                h = (int)SystemParameters.VirtualScreenHeight;
            else
                return tier;

            if (h <= 768) // min supported screen (notebooks, desktops, servers) 
                tier = 1;
            else if (h <= 1080) // full HD screens (16:9, 21:9)
                tier = 2;
            else if (h <= 2160) // 4k screens and up (16:9, 21:9)
                tier = 3;
            else
                tier = 3;

            return tier;
        }
    }

    private static FontSizeConverter conv = new FontSizeConverter();

    public static object FontSize_DataGridColumnText =>
        PrimaryScreenResolutionTier switch
        {
            1 => (object)conv.ConvertFrom(default, new CultureInfo("en-US"), "9pt"),
            2 => (object)conv.ConvertFrom(default, new CultureInfo("en-US"), "10pt"),
            _ => (object)conv.ConvertFrom(default, new CultureInfo("en-US"), "10pt"),
        };

    public static object FontSize_DefaultText =>
        PrimaryScreenResolutionTier switch
        {
            1 => (object)conv.ConvertFrom(default, new CultureInfo("en-US"), "11.25pt"),
            2 => (object)conv.ConvertFrom(default, new CultureInfo("en-US"), "11.25pt"),
            _ => (object)conv.ConvertFrom(default, new CultureInfo("en-US"), "11.75pt"),
        };
}

