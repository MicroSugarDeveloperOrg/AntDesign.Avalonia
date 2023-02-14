namespace AntDesign.Assists;
public static class CheckBoxAssists
{
    public static readonly AvaloniaProperty<IBrush?> HoverBackgroundProperty = AvaloniaProperty.RegisterAttached<CheckBox, IBrush?>("HoverBackground", typeof(CheckBoxAssists));
    public static void SetHoverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HoverBackgroundProperty, value);
    public static IBrush? GetHoverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HoverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> HoverForegroundProperty = AvaloniaProperty.RegisterAttached<CheckBox, IBrush?>("HoverForeground", typeof(CheckBoxAssists));
    public static void SetHoverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HoverForegroundProperty, value);
    public static IBrush? GetHoverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HoverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> HoverBorderBrushProperty = AvaloniaProperty.RegisterAttached<CheckBox, IBrush?>("HoverBorderBrush", typeof(CheckBoxAssists));
    public static void SetHoverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HoverBorderBrushProperty, value);
    public static IBrush? GetHoverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HoverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<CheckBox, IBrush?>("PressedBackground", typeof(CheckBoxAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<CheckBox, IBrush?>("PressedForeground", typeof(CheckBoxAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<CheckBox, IBrush?>("PressedBorderBrush", typeof(CheckBoxAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> GlyphFillProperty = AvaloniaProperty.RegisterAttached<CheckBox, IBrush?>("GlyphFill", typeof(CheckBoxAssists));
    public static void SetGlyphFill(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(GlyphFillProperty, value);
    public static IBrush? GetGlyphFill(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(GlyphFillProperty);

    public static readonly AvaloniaProperty<Color> RippleColorProperty = AvaloniaProperty.RegisterAttached<CheckBox, Color>("RippleColor", typeof(CheckBoxAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty = AvaloniaProperty.RegisterAttached<CheckBox, double>("RippleColorAlpha", typeof(CheckBoxAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);
}
