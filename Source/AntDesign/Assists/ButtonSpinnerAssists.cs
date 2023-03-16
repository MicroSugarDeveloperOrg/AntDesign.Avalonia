namespace AntDesign.Assists;
public class ButtonSpinnerAssists
{
    public static readonly AvaloniaProperty<IBrush?> BackgroundProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("Background", typeof(ButtonSpinnerAssists));
    public static void SetBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BackgroundProperty, value);
    public static IBrush? GetBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> ForegroundProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("Foreground", typeof(ButtonSpinnerAssists));
    public static void SetForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ForegroundProperty, value);
    public static IBrush? GetForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> BorderBrushProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("BorderBrush", typeof(ButtonSpinnerAssists));
    public static void SetBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BorderBrushProperty, value);
    public static IBrush? GetBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("PointerOverBackground", typeof(ButtonSpinnerAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("PointerOverForeground", typeof(ButtonSpinnerAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("PointerOverBorderBrush", typeof(ButtonSpinnerAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("PressedBackground", typeof(ButtonSpinnerAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("PressedForeground", typeof(ButtonSpinnerAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, IBrush?>("PressedBorderBrush", typeof(ButtonSpinnerAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly AvaloniaProperty<object?> LeftSpinnerContentProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, object?>("LeftSpinnerContent", typeof(ButtonSpinnerAssists));
    public static void SetLeftSpinnerContent(AvaloniaObject dependencyObject, object value) => dependencyObject.SetValue(LeftSpinnerContentProperty, value);
    public static object? GetLeftSpinnerContent(AvaloniaObject dependencyObject) => dependencyObject.GetValue<object?>(LeftSpinnerContentProperty);

    public static readonly AvaloniaProperty<object?> RightSpinnerContentProperty = AvaloniaProperty.RegisterAttached<ButtonSpinner, object?>("RightSpinnerContent", typeof(ButtonSpinnerAssists));
    public static void SetRightSpinnerContent(AvaloniaObject dependencyObject, object value) => dependencyObject.SetValue(RightSpinnerContentProperty, value);
    public static object? GetRightSpinnerContent(AvaloniaObject dependencyObject) => dependencyObject.GetValue<object?>(RightSpinnerContentProperty);
}
