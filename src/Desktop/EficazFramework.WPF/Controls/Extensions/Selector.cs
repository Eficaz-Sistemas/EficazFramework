namespace EficazFramework.Controls.AttachedProperties;

public partial class Selector
{

    #region Default Background

    [ExcludeFromCodeCoverage]
    public static Brush GetContainerBackground(DependencyObject element) =>
        (Brush)element.GetValue(GetContainerBackgroundProperty);

    [ExcludeFromCodeCoverage]
    public static void SetContainerBackground(DependencyObject element, Brush value) =>
        element.SetValue(GetContainerBackgroundProperty, value);

    public static readonly DependencyProperty GetContainerBackgroundProperty = DependencyProperty.RegisterAttached("ContainerBackground", typeof(Brush), typeof(Selector), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

    #endregion


    #region Default Border

    [ExcludeFromCodeCoverage]
    public static Brush GetContainerBorderBrush(DependencyObject element) =>
        (Brush)element.GetValue(ContainerBorderBrushProperty);

    [ExcludeFromCodeCoverage]
    public static void SetContainerBorderBrush(DependencyObject element, Brush value) =>
        element.SetValue(ContainerBorderBrushProperty, value);

    public static readonly DependencyProperty ContainerBorderBrushProperty = DependencyProperty.RegisterAttached("ContainerBorderBrush", typeof(Brush), typeof(Selector), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

    #endregion


    #region Default Thickness

    [ExcludeFromCodeCoverage]
    public static Thickness GetContainerBorderThickness(DependencyObject element) =>
        (Thickness)element.GetValue(ContainerBorderThicknessProperty);

    [ExcludeFromCodeCoverage]
    public static void SetContainerBorderThickness(DependencyObject element, Thickness value) =>
        element.SetValue(ContainerBorderThicknessProperty, value);

    public static readonly DependencyProperty ContainerBorderThicknessProperty = DependencyProperty.RegisterAttached("ContainerBorderThickness", typeof(Thickness), typeof(Selector), new FrameworkPropertyMetadata(new Thickness(2), FrameworkPropertyMetadataOptions.Inherits));

    #endregion


    #region Inactive Selection

    [ExcludeFromCodeCoverage]
    public static bool GetAllowInactiveSelection(DependencyObject element) =>
        (bool)element.GetValue(AllowInactiveSelectionProperty);

    [ExcludeFromCodeCoverage]
    public static void SetAllowInactiveSelection(DependencyObject element, bool value) =>
        element.SetValue(AllowInactiveSelectionProperty, value);

    public static readonly DependencyProperty AllowInactiveSelectionProperty = DependencyProperty.RegisterAttached("AllowInactiveSelection", typeof(bool), typeof(Selector), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

    #endregion


    #region Hide Selected

    [ExcludeFromCodeCoverage]
    public static bool GetHideSelection(DependencyObject element) =>
        (bool)element.GetValue(HideSelectionProperty);

    [ExcludeFromCodeCoverage]
    public static void SetHideSelection(DependencyObject element, bool value) =>
        element.SetValue(HideSelectionProperty, value);

    public static readonly DependencyProperty HideSelectionProperty = DependencyProperty.RegisterAttached("HideSelection", typeof(bool), typeof(Selector), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

    #endregion

}