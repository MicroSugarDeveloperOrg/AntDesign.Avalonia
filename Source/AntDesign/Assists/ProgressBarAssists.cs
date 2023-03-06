namespace AntDesign.Assists;
public class ProgressBarAssists
{
    public static readonly AvaloniaProperty<double> BarWidthProperty = AvaloniaProperty.RegisterAttached<ProgressBar, double>("BarWidth", typeof(ProgressBarAssists));
    public static void SetBarWidth(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(BarWidthProperty, value);
    public static double GetBarWidth(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(BarWidthProperty);

    public static readonly AvaloniaProperty<double> BarHeightProperty = AvaloniaProperty.RegisterAttached<ProgressBar, double>("BarHeight", typeof(ProgressBarAssists));
    public static void SetBarHeight(AvaloniaObject dependencyObject, object value) => dependencyObject.SetValue(BarHeightProperty, value);
    public static double GetBarHeight(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(BarHeightProperty);

    public static readonly AvaloniaProperty<object?> ContentProperty = AvaloniaProperty.RegisterAttached<ProgressBar, object?>("Content", typeof(ProgressBarAssists));
    public static void SetContent(AvaloniaObject dependencyObject, object value) => dependencyObject.SetValue(ContentProperty, value);
    public static object? GetContent(AvaloniaObject dependencyObject) => dependencyObject.GetValue<object?>(ContentProperty);

    public static readonly StyledProperty<IBrush?> ContentForegroundProperty = AvaloniaProperty.RegisterAttached<ProgressBar, IBrush?>("ContentForeground", typeof(ProgressBarAssists));
    public static void SetContentForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ContentForegroundProperty, value);
    public static IBrush? GetContentForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ContentForegroundProperty);
}
