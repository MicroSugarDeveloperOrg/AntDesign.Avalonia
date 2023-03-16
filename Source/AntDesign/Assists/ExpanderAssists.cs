namespace AntDesign.Assists;
public class ExpanderAssists
{
    static ExpanderAssists()
    {

    }

    public static readonly StyledProperty<IBrush?> HeaderBackgroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderBackground", typeof(ExpanderAssists));
    public static void SetHeaderBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderBackgroundProperty, value);
    public static IBrush? GetHeaderBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderBackgroundProperty);

    public static readonly StyledProperty<IBrush?> HeaderForegroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderForeground", typeof(ExpanderAssists));
    public static void SetHeaderForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderForegroundProperty, value);
    public static IBrush? GetHeaderForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderForegroundProperty);


    public static readonly StyledProperty<IBrush?> HeaderPointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderPointerOverBackground", typeof(ExpanderAssists));
    public static void SetHeaderPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderPointerOverBackgroundProperty, value);
    public static IBrush? GetHeaderPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderPointerOverBackgroundProperty);

    public static readonly StyledProperty<IBrush?> HeaderPointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderPointerOverForeground", typeof(ExpanderAssists));
    public static void SetHeaderPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderPointerOverForegroundProperty, value);
    public static IBrush? GetHeaderPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderPointerOverForegroundProperty);


    public static readonly StyledProperty<IBrush?> HeaderPressedBackgroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderPressedBackground", typeof(ExpanderAssists));
    public static void SetHeaderPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderPressedBackgroundProperty, value);
    public static IBrush? GetHeaderPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderPressedBackgroundProperty);

    public static readonly StyledProperty<IBrush?> HeaderPressedForegroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderPressedForeground", typeof(ExpanderAssists));
    public static void SetHeaderPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderPressedForegroundProperty, value);
    public static IBrush? GetHeaderPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderPressedForegroundProperty);


    public static readonly StyledProperty<IBrush?> HeaderSelectedBackgroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderSelectedBackground", typeof(ExpanderAssists));
    public static void SetHeaderSelectedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderSelectedBackgroundProperty, value);
    public static IBrush? GetHeaderSelectedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderSelectedBackgroundProperty);

    public static readonly StyledProperty<IBrush?> HeaderSelectedForegroundProperty = AvaloniaProperty.RegisterAttached<Expander, IBrush?>("HeaderSelectedForeground", typeof(ExpanderAssists));
    public static void SetHeaderSelectedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderSelectedForegroundProperty, value);
    public static IBrush? GetHeaderSelectedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderSelectedForegroundProperty);

}
