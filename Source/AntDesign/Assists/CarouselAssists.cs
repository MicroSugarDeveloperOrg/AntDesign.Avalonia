namespace AntDesign.Assists;
public class CarouselAssists
{
    public static readonly StyledProperty<bool> ShowButtonsProperty = AvaloniaProperty.RegisterAttached<Carousel, bool>("ShowButtons", typeof(CarouselAssists));
    public static void SetShowButtons(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ShowButtonsProperty, value);
    public static bool GetShowButtons(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowButtonsProperty);

    public static readonly AvaloniaProperty<bool> ShowDotsProperty = AvaloniaProperty.RegisterAttached<Carousel, bool>("ShowDots", typeof(CarouselAssists));
    public static void SetShowDots(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ShowDotsProperty, value);
    public static bool GetShowDots(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowDotsProperty);
}
