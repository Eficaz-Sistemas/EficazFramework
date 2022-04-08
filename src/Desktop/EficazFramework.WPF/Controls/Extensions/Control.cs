namespace EficazFramework.Controls.AttachedProperties;

public partial class Control
{

    #region Tip Text

    public static string GetTipText([DisallowNull] DependencyObject element) =>
        (string)element.GetValue(TipTextProperty);

    public static void SetTipText([DisallowNull] DependencyObject element, string value) =>
        element.SetValue(TipTextProperty, value);

    public static readonly DependencyProperty TipTextProperty = DependencyProperty.RegisterAttached("TipText", typeof(string), typeof(Control), new PropertyMetadata(null, OnTipTextChanged));

    private static void OnTipTextChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        if (source is PasswordBox)
        {
            if (!string.IsNullOrEmpty((string)e.NewValue))
                ((PasswordBox)source).PasswordChanged += OnPasswordChanged;
            else
                ((PasswordBox)source).PasswordChanged -= OnPasswordChanged;
        }
    }

    private static void OnPasswordChanged(object sender, RoutedEventArgs e) =>
        SetIsEmpty((DependencyObject)sender, string.IsNullOrEmpty(((PasswordBox)sender).Password));

    #endregion

    
    #region Show Label

    public static bool GetShowLabel([DisallowNull] DependencyObject element) =>
        (bool)element.GetValue(ShowLabelProperty);

    public static void SetShowLabel([DisallowNull] DependencyObject element, bool value) =>
        element.SetValue(ShowLabelProperty, value);

    public static readonly DependencyProperty ShowLabelProperty = DependencyProperty.RegisterAttached("ShowLabel", typeof(bool), typeof(Control), new PropertyMetadata(true));

    #endregion

    
    #region CornerRadius

    public static CornerRadius GetCornerRadius([DisallowNull] DependencyObject element) =>
        (CornerRadius)element.GetValue(CornerRadiusProperty);

    public static void SetCornerRadius([DisallowNull] DependencyObject element, CornerRadius value) =>
        element.SetValue(CornerRadiusProperty, value);

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(Control), new PropertyMetadata(new CornerRadius(0D)));

    #endregion

    
    #region Elevation

    public static int GetElevation([DisallowNull] DependencyObject element) =>
        (int)element.GetValue(ElevationProperty);

    public static void SetElevation([DisallowNull] DependencyObject element, int value) =>
        element.SetValue(ElevationProperty, value);

    public static readonly DependencyProperty ElevationProperty = DependencyProperty.RegisterAttached("Elevation", typeof(int), typeof(Control), new PropertyMetadata(0));

    #endregion

    
    #region Blur

    public static bool GetBlur([DisallowNull] DependencyObject element) =>
        (bool)element.GetValue(BlurProperty);

    public static void SetBlurBlur([DisallowNull] DependencyObject element, bool value) =>
        element.SetValue(BlurProperty, value);

    public static readonly DependencyProperty BlurProperty = DependencyProperty.RegisterAttached("Blur", typeof(bool), typeof(Control), new PropertyMetadata(false));

    #endregion

    
    #region PassowordBox IsEmpty

    public static bool GetIsEmpty([DisallowNull] DependencyObject element) =>
        (bool)element.GetValue(IsEmptyProperty);

    public static void SetIsEmpty([DisallowNull] DependencyObject element, bool value) =>
        element.SetValue(IsEmptyProperty, value);

    public static readonly DependencyProperty IsEmptyProperty = DependencyProperty.RegisterAttached("IsEmpty", typeof(bool), typeof(Control), new PropertyMetadata(true));

    #endregion

    
    #region Color Zone

    public static Color GetColor([DisallowNull] DependencyObject element) =>
        (Color)element.GetValue(ColorProperty);

    public static void SetColor([DisallowNull] DependencyObject element, Color value) =>
        element.SetValue(ColorProperty, value);

    public static readonly DependencyProperty ColorProperty = DependencyProperty.RegisterAttached("Color", typeof(Color), typeof(Control), new FrameworkPropertyMetadata(Color.Primary, FrameworkPropertyMetadataOptions.Inherits));

    #endregion

}

public enum Color
{
    Surface,
    SurfaceAlternate,
    Primary,
    PrimaryDarken,
    PrimaryLighten,
    Secondary,
    Tertiary
}
