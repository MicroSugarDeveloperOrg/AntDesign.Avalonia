namespace AntDesign.Assists;
public class ComboBoxAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PointerOverBackground", typeof(ComboBoxAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PointerOverForeground", typeof(ComboBoxAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PointerOverBorderBrush", typeof(ComboBoxAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PressedBackground", typeof(ComboBoxAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PressedForeground", typeof(ComboBoxAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PressedBorderBrush", typeof(ComboBoxAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBackgroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("SelectedBackground", typeof(ComboBoxAssists));
    public static void SetSelectedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBackgroundProperty, value);
    public static IBrush? GetSelectedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedForegroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("SelectedForeground", typeof(ComboBoxAssists));
    public static void SetSelectedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedForegroundProperty, value);
    public static IBrush? GetSelectedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBorderBrushProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("SelectedBorderBrush", typeof(ComboBoxAssists));
    public static void SetSelectedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBorderBrushProperty, value);
    public static IBrush? GetSelectedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBorderBrushProperty);

    public static readonly AvaloniaProperty<bool> IsRippleProperty = AvaloniaProperty.RegisterAttached<ComboBox, bool>("IsRipple", typeof(ComboBoxAssists));
    public static void SetIsRipple(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(IsRippleProperty, value);
    public static bool GetIsRipple(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(IsRippleProperty);

    public static readonly AvaloniaProperty<Color> RippleColorProperty = AvaloniaProperty.RegisterAttached<ComboBox, Color>("RippleColor", typeof(ComboBoxAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty = AvaloniaProperty.RegisterAttached<ComboBox, double>("RippleColorAlpha", typeof(ComboBoxAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);

    public static readonly AvaloniaProperty<IBrush?> PopupBackgroundProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PopupBackground", typeof(ComboBoxAssists));
    public static void SetPopupBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PopupBackgroundProperty, value);
    public static IBrush? GetPopupBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PopupBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PopupBorderBrushProperty = AvaloniaProperty.RegisterAttached<ComboBox, IBrush?>("PopupBorderBrush", typeof(ComboBoxAssists));
    public static void SetPopupBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PopupBorderBrushProperty, value);
    public static IBrush? GetPopupBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PopupBorderBrushProperty);

    public static readonly AvaloniaProperty<Thickness> PopupBorderThicknessProperty = AvaloniaProperty.RegisterAttached<ComboBox, Thickness>("PopupBorderThickness", typeof(ComboBoxAssists));
    public static void SetPopupBorderThickness(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(PopupBorderThicknessProperty, value);
    public static Thickness GetPopupBorderThickness(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(PopupBorderThicknessProperty);

    public static readonly AvaloniaProperty<Thickness> PopupMarginProperty = AvaloniaProperty.RegisterAttached<ComboBox, Thickness>("PopupMargin", typeof(ComboBoxAssists));
    public static void SetPopupMargin(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(PopupMarginProperty, value);
    public static Thickness GetPopupMargin(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(PopupMarginProperty);

    public static readonly AvaloniaProperty<CornerRadius> PopupCornerRadiusProperty = AvaloniaProperty.RegisterAttached<ComboBox, CornerRadius>("PopupCornerRadius", typeof(ComboBoxAssists));
    public static void SetPopupCornerRadius(AvaloniaObject dependencyObject, CornerRadius value) => dependencyObject.SetValue(PopupCornerRadiusProperty, value);
    public static CornerRadius GetPopupCornerRadius(AvaloniaObject dependencyObject) => dependencyObject.GetValue<CornerRadius>(PopupCornerRadiusProperty);
}
