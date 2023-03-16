namespace AntDesign.Assists;
public class SplitButtonAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("PointerOverBackground", typeof(SplitButtonAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("PointerOverForeground", typeof(SplitButtonAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("PointerOverBorderBrush", typeof(SplitButtonAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("PressedBackground", typeof(SplitButtonAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("PressedForeground", typeof(SplitButtonAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("PressedBorderBrush", typeof(SplitButtonAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedBackgroundProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("CheckedBackground", typeof(SplitButtonAssists));
    public static void SetCheckedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedBackgroundProperty, value);
    public static IBrush? GetCheckedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedForegroundProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("CheckedForeground", typeof(SplitButtonAssists));
    public static void SetCheckedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedForegroundProperty, value);
    public static IBrush? GetCheckedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> CheckedBorderBrushProperty = AvaloniaProperty.RegisterAttached<SplitButton, IBrush?>("CheckedBorderBrush", typeof(SplitButtonAssists));
    public static void SetCheckedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(CheckedBorderBrushProperty, value);
    public static IBrush? GetCheckedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(CheckedBorderBrushProperty);

    public static readonly StyledProperty<double> SpacingProperty = AvaloniaProperty.RegisterAttached<SplitButton, double>("Spacing", typeof(SplitButtonAssists));
    public static void SetSpacing(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(SpacingProperty, value);
    public static double GetSpacing(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(SpacingProperty);


    public static readonly StyledProperty<object?> PlugContentProperty = AvaloniaProperty.RegisterAttached<SplitButton, object?>("PlugContent", typeof(SplitButtonAssists));
    public static void SetPlugContent(AvaloniaObject dependencyObject, object? value) => dependencyObject.SetValue(PlugContentProperty, value);
    public static object? GetPlugContent(AvaloniaObject dependencyObject) => dependencyObject.GetValue<object?>(PlugContentProperty);

    public static readonly StyledProperty<IDataTemplate?> PlugContentTemplateProperty = AvaloniaProperty.RegisterAttached<SplitButton, IDataTemplate?>("PlugContentTemplate", typeof(SplitButtonAssists));
    public static void SetPlugContentTemplate(AvaloniaObject dependencyObject, IDataTemplate? value) => dependencyObject.SetValue(PlugContentTemplateProperty, value);
    public static IDataTemplate? GetPlugContentTemplate(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IDataTemplate?>(PlugContentTemplateProperty);

}
