namespace AntDesign.Assists;

public static class ButtonAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PointerOverBackground", typeof(ButtonAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PointerOverForeground", typeof(ButtonAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PointerOverBorderBrush", typeof(ButtonAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PressedBackground", typeof(ButtonAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PressedForeground", typeof(ButtonAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PressedBorderBrush", typeof(ButtonAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly AvaloniaProperty<ITransform?> PressedRenderTransformProperty = AvaloniaProperty.RegisterAttached<Button, ITransform?>("PressedRenderTransform", typeof(ButtonAssists));
    public static void SetPressedPressedRenderTransform(AvaloniaObject dependencyObject, ITransform value) => dependencyObject.SetValue(PressedRenderTransformProperty, value);
    public static ITransform? GetPressedPressedRenderTransform(AvaloniaObject dependencyObject) => dependencyObject.GetValue<ITransform?>(PressedRenderTransformProperty);

    public static readonly AvaloniaProperty<Color> RippleColorProperty = AvaloniaProperty.RegisterAttached<Button, Color>("RippleColor", typeof(ButtonAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty = AvaloniaProperty.RegisterAttached<Button, double>("RippleColorAlpha", typeof(ButtonAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);

}
