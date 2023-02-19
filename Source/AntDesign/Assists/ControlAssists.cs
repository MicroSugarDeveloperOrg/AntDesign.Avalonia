namespace AntDesign.Assists;
public class ControlAssists
{
    public static readonly StyledProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("PointerOverBackground", typeof(ControlAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly StyledProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("PointerOverForeground", typeof(ControlAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly StyledProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("PointerOverBorderBrush", typeof(ControlAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly StyledProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("PressedBackground", typeof(ControlAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly StyledProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("PressedForeground", typeof(ControlAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly StyledProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("PressedBorderBrush", typeof(ControlAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly StyledProperty<ITransform?> PressedRenderTransformProperty = AvaloniaProperty.RegisterAttached<Control, ITransform?>("PressedRenderTransform", typeof(ControlAssists));
    public static void SetPressedPressedRenderTransform(AvaloniaObject dependencyObject, ITransform? value) => dependencyObject.SetValue(PressedRenderTransformProperty, value);
    public static ITransform? GetPressedPressedRenderTransform(AvaloniaObject dependencyObject) => dependencyObject.GetValue<ITransform?>(PressedRenderTransformProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBackgroundProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("SelectedBackground", typeof(ControlAssists));
    public static void SetSelectedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBackgroundProperty, value);
    public static IBrush? GetSelectedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedForegroundProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("SelectedForeground", typeof(ControlAssists));
    public static void SetSelectedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedForegroundProperty, value);
    public static IBrush? GetSelectedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBorderBrushProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("SelectedBorderBrush", typeof(ControlAssists));
    public static void SetSelectedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBorderBrushProperty, value);
    public static IBrush? GetSelectedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> TiggerStatusForegroundProperty = AvaloniaProperty.RegisterAttached<Control, IBrush?>("TiggerStatusForeground", typeof(ControlAssists));
    public static void SetTiggerStatusForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(TiggerStatusForegroundProperty, value);
    public static IBrush? GetTiggerStatusForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(TiggerStatusForegroundProperty);

}
