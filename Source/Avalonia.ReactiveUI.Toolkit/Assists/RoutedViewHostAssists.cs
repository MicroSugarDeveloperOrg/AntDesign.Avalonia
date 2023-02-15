namespace Avalonia.ReactiveUI.Toolkit.Assists;

public static class RoutedViewHostAssists
{
    static RoutedViewHostAssists()
    {
        ViewLocatorProperty.Changed.AddClassHandler<RoutedViewHost, IViewLocator?>((r, e) =>
        {
            r.ViewLocator = e.NewValue.Value;
        });
    }

    public static readonly AvaloniaProperty<IViewLocator?> ViewLocatorProperty =
            AvaloniaProperty.RegisterAttached<RoutedViewHost, IViewLocator?>("ViewLocator", typeof(RoutedViewHostAssists));

    public static void SetViewLocator(AvaloniaObject dependencyObject, IViewLocator? value) => dependencyObject.SetValue(ViewLocatorProperty, value);
    public static IViewLocator? GetViewLocator(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IViewLocator?>(ViewLocatorProperty);

}
