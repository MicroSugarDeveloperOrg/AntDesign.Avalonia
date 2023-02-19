namespace AntDesign.Assists;

public class TextBoxAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<TextBox, IBrush?>("PointerOverBorderBrush", typeof(TextBoxAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> FocusBorderBrushProperty = AvaloniaProperty.RegisterAttached<TextBox, IBrush?>("FocusBorderBrush", typeof(TextBoxAssists));
    public static void SetFocusBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(FocusBorderBrushProperty, value);
    public static IBrush? GetFocusBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(FocusBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> FloatingForegroundProperty = AvaloniaProperty.RegisterAttached<TextBox, IBrush?>("FloatingForeground", typeof(TextBoxAssists));
    public static void SetFloatingForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(FloatingForegroundProperty, value);
    public static IBrush? GetFloatingForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(FloatingForegroundProperty);

    public static readonly AvaloniaProperty<Thickness> FloatingMarginProperty = AvaloniaProperty.RegisterAttached<TextBox, Thickness>("FloatingMargin", typeof(TextBoxAssists));
    public static void SetFloatingMargin(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(FloatingMarginProperty, value);
    public static Thickness GetFloatingMargin(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(FloatingMarginProperty);

    public static readonly StyledProperty<Color> RippleColorProperty = AvaloniaProperty.RegisterAttached<TextBox, Color>("RippleColor", typeof(TextBoxAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue<Color>(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty = AvaloniaProperty.RegisterAttached<TextBox, double>("RippleColorAlpha", typeof(TextBoxAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);

}
