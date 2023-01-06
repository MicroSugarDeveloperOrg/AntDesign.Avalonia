using Avalonia.Media;

namespace AntDesign.Assists;

public static class AutoCompleteBoxAssists
{
    public static readonly AvaloniaProperty<IBrush?> HoverBorderBrushProperty = AvaloniaProperty.RegisterAttached<AutoCompleteBox, IBrush?>("HoverBorderBrush", typeof(AutoCompleteBoxAssists));
    public static void SetHoverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HoverBorderBrushProperty, value);
    public static IBrush? GetHoverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HoverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> FocusBorderBrushProperty = AvaloniaProperty.RegisterAttached<AutoCompleteBox, IBrush?>("FocusBorderBrush", typeof(AutoCompleteBoxAssists));
    public static void SetFocusBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(FocusBorderBrushProperty, value);
    public static IBrush? GetFocusBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(FocusBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> FloatingForegroundProperty = AvaloniaProperty.RegisterAttached<AutoCompleteBox, IBrush?>("FloatingForeground", typeof(AutoCompleteBoxAssists));
    public static void SetFloatingForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(FloatingForegroundProperty, value);
    public static IBrush? GetFloatingForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(FloatingForegroundProperty);

    public static readonly AvaloniaProperty<Color> RippleColorProperty = AvaloniaProperty.RegisterAttached<AutoCompleteBox, Color>("RippleColor", typeof(AutoCompleteBoxAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty = AvaloniaProperty.RegisterAttached<AutoCompleteBox, double>("RippleColorAlpha", typeof(AutoCompleteBoxAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);
}
