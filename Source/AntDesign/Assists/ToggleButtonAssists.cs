namespace AntDesign.Assists;

public class ToggleButtonAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("PointerOverBackground", typeof(ToggleButtonAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("PointerOverForeground", typeof(ToggleButtonAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("PointerOverBorderBrush", typeof(ToggleButtonAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("PressedBackground", typeof(ToggleButtonAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("PressedForeground", typeof(ToggleButtonAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("PressedBorderBrush", typeof(ToggleButtonAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedBackgroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("CheckedBackground", typeof(ToggleButtonAssists));
    public static void SetCheckedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedBackgroundProperty, value);
    public static IBrush? GetCheckedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedForegroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("CheckedForeground", typeof(ToggleButtonAssists));
    public static void SetCheckedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedForegroundProperty, value);
    public static IBrush? GetCheckedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedBorderBrushProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("CheckedBorderBrush", typeof(ToggleButtonAssists));
    public static void SetCheckedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedBorderBrushProperty, value);
    public static IBrush? GetCheckedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> IndeterminateBackgroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("IndeterminateBackground", typeof(ToggleButtonAssists));
    public static void SetIndeterminateBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(IndeterminateBackgroundProperty, value);
    public static IBrush? GetIndeterminateBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(IndeterminateBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> IndeterminateForegroundProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("IndeterminateForeground", typeof(ToggleButtonAssists));
    public static void SetIndeterminateForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(IndeterminateForegroundProperty, value);
    public static IBrush? GetIndeterminateForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(IndeterminateForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> IndeterminateBorderBrushProperty = AvaloniaProperty.RegisterAttached<ToggleButton, IBrush?>("IndeterminateBorderBrush", typeof(ToggleButtonAssists));
    public static void SetIndeterminateBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(IndeterminateBorderBrushProperty, value);
    public static IBrush? GetIndeterminateBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(IndeterminateBorderBrushProperty);

    public static readonly AvaloniaProperty<ITransform?> PressedRenderTransformProperty = AvaloniaProperty.RegisterAttached<ToggleButton, ITransform?>("PressedRenderTransform", typeof(ToggleButtonAssists));
    public static void SetPressedPressedRenderTransform(AvaloniaObject dependencyObject, ITransform? value) => dependencyObject.SetValue(PressedRenderTransformProperty, value);
    public static ITransform? GetPressedPressedRenderTransform(AvaloniaObject dependencyObject) => dependencyObject.GetValue<ITransform?>(PressedRenderTransformProperty);

    public static readonly AvaloniaProperty<bool> IsRippleProperty = AvaloniaProperty.RegisterAttached<ToggleButton, bool>("IsRipple", typeof(ToggleButtonAssists));
    public static void SetIsRipple(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(IsRippleProperty, value);
    public static bool GetIsRipple(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(IsRippleProperty);

    public static readonly AvaloniaProperty<Color> RippleColorProperty = AvaloniaProperty.RegisterAttached<ToggleButton, Color>("RippleColor", typeof(ToggleButtonAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty = AvaloniaProperty.RegisterAttached<ToggleButton, double>("RippleColorAlpha", typeof(ToggleButtonAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);
}
