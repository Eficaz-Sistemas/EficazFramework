namespace EficazFramework.Controls.AttachedProperties;

public partial class Button
{

    #region Icon Size
    
    public static double GetIconSize([DisallowNull] DependencyObject element) =>
        (double)element.GetValue(IconSizeProperty);
    public static void SetIconSize(DependencyObject element, double value) =>
        element.SetValue(IconSizeProperty, value);

    public static readonly DependencyProperty IconSizeProperty = DependencyProperty.RegisterAttached("IconSize", typeof(double), typeof(Button), new FrameworkPropertyMetadata(20D, FrameworkPropertyMetadataOptions.Inherits));

    #endregion

    
    #region Mouse Over Color

    public static Brush GetMouseOver([DisallowNull] DependencyObject element) =>
        (Brush)element.GetValue(MouseOverProperty);

    public static void SetMouseOver([DisallowNull] DependencyObject element, Brush value) =>
        element.SetValue(MouseOverProperty, value);

    public static readonly DependencyProperty MouseOverProperty = DependencyProperty.RegisterAttached("MouseOver", typeof(Brush), typeof(Button), new PropertyMetadata(null));

    #endregion

}
