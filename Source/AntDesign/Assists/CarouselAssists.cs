namespace AntDesign.Assists;
public class CarouselAssists
{
    public static readonly StyledProperty<bool> ShowButtonsProperty = AvaloniaProperty.RegisterAttached<Control, bool>("ShowButtons", typeof(ControlAssists));
    public static void SetShowButtons(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ShowButtonsProperty, value);
    public static bool GetShowButtons(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowButtonsProperty);
}
