namespace EficazFramework.Localization;

public class CultureAssist
{
    public static void SetCulture(string culture)
    {
        System.Globalization.CultureInfo c = new(culture);
        System.Threading.Thread.CurrentThread.CurrentCulture = c;
        System.Threading.Thread.CurrentThread.CurrentUICulture = c;
        System.Globalization.CultureInfo.CurrentCulture = c;
        System.Globalization.CultureInfo.CurrentUICulture = c;
        System.Windows.FrameworkElement.LanguageProperty.OverrideMetadata(typeof(System.Windows.FrameworkElement), new System.Windows.FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage(c.IetfLanguageTag)));

    }
}
