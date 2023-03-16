namespace AntDesign.Assists;

public class ToggleSwitchAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("PointerOverBackground", typeof(ToggleSwitchAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("PointerOverForeground", typeof(ToggleSwitchAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("PointerOverBorderBrush", typeof(ToggleSwitchAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedBackgroundProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("CheckedBackground", typeof(ToggleSwitchAssists));
    public static void SetCheckedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedBackgroundProperty, value);
    public static IBrush? GetCheckedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedForegroundProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("CheckedForeground", typeof(ToggleSwitchAssists));
    public static void SetCheckedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedForegroundProperty, value);
    public static IBrush? GetCheckedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedBorderBrushProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("CheckedBorderBrush", typeof(ToggleSwitchAssists));
    public static void SetCheckedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedBorderBrushProperty, value);
    public static IBrush? GetCheckedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedPointerOverBackgroundProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("CheckedPointerOverBackground", typeof(ToggleSwitchAssists));
    public static void SetCheckedPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedPointerOverBackgroundProperty, value);
    public static IBrush? GetCheckedPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedPointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedPointerOverForegroundProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("CheckedPointerOverForeground", typeof(ToggleSwitchAssists));
    public static void SetCheckedPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedPointerOverForegroundProperty, value);
    public static IBrush? GetCheckedPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedPointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedPointerOverBorderBrushProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("CheckedPointerOverBorderBrush", typeof(ToggleSwitchAssists));
    public static void SetCheckedPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedPointerOverBorderBrushProperty, value);
    public static IBrush? GetCheckedPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedPointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<double?> ToggleSwitchWidthProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, double?>("ToggleSwitchWidth", typeof(ToggleSwitchAssists));
    public static void SetToggleSwitchWidth(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(ToggleSwitchWidthProperty, value);
    public static double? GetToggleSwitchWidth(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double?>(ToggleSwitchWidthProperty);

    public static readonly AvaloniaProperty<double?> ToggleSwitchHeightProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, double?>("ToggleSwitchHeight", typeof(ToggleSwitchAssists));
    public static void SetToggleSwitchHeight(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(ToggleSwitchHeightProperty, value);
    public static double? GetToggleSwitchHeight(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double?>(ToggleSwitchHeightProperty);

    public static readonly AvaloniaProperty<IBrush?> KnobOnBackgroundProperty
       = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("KnobOnBackground", typeof(ToggleSwitchAssists));
    public static void SetKnobOnBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(KnobOnBackgroundProperty, value);
    public static IBrush? GetKnobOnBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(KnobOnBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> KnobOffBackgroundProperty
   = AvaloniaProperty.RegisterAttached<ToggleSwitch, IBrush?>("KnobOffBackground", typeof(ToggleSwitchAssists));
    public static void SetKnobOffBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(KnobOffBackgroundProperty, value);
    public static IBrush? GetKnobOffBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(KnobOffBackgroundProperty);

    public static readonly AvaloniaProperty<object?> KnobContentProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, object?>("KnobContent", typeof(ToggleSwitchAssists));
    public static void SetKnobContent(AvaloniaObject dependencyObject, object value) => dependencyObject.SetValue(KnobContentProperty, value);
    public static object? GetKnobContent(AvaloniaObject dependencyObject) => dependencyObject.GetValue<object?>(KnobContentProperty);

    public static readonly AvaloniaProperty<IDataTemplate?> KnobContentTemplateProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, IDataTemplate?>("KnobContentTemplate", typeof(ToggleSwitchAssists));
    public static void SetKnobContentTemplate(AvaloniaObject dependencyObject, IDataTemplate value) => dependencyObject.SetValue(KnobContentTemplateProperty, value);
    public static IDataTemplate? GetKnobContentTemplate(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IDataTemplate?>(KnobContentTemplateProperty);

    public static readonly AvaloniaProperty<bool> IsRippleProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, bool>("IsRipple", typeof(ToggleSwitchAssists));
    public static void SetIsRipple(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(IsRippleProperty, value);
    public static bool GetIsRipple(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(IsRippleProperty);

    public static readonly AvaloniaProperty<Color> RippleColorProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, Color>("RippleColor", typeof(ToggleSwitchAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty 
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, double>("RippleColorAlpha", typeof(ToggleSwitchAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);
}
