namespace AntDesign.Assists;
public class ColorSliderAssists
{
    public static readonly AvaloniaProperty<BoxShadows> ThumbBoxShadowProperty = AvaloniaProperty.RegisterAttached<ColorSlider, BoxShadows>("ThumbBoxShadow", typeof(ColorSliderAssists));
    public static void SetThumbBoxShadow(AvaloniaObject dependencyObject, BoxShadows value) => dependencyObject.SetValue(ThumbBoxShadowProperty, value);
    public static BoxShadows GetThumbBoxShadow(AvaloniaObject dependencyObject) => dependencyObject.GetValue<BoxShadows>(ThumbBoxShadowProperty);

    public static readonly AvaloniaProperty<BoxShadows> BoxShadowProperty = AvaloniaProperty.RegisterAttached<ColorSlider, BoxShadows>("BoxShadow", typeof(ColorSliderAssists));
    public static void SetBoxShadow(AvaloniaObject dependencyObject, BoxShadows value) => dependencyObject.SetValue(BoxShadowProperty, value);
    public static BoxShadows GetBoxShadow(AvaloniaObject dependencyObject) => dependencyObject.GetValue<BoxShadows>(BoxShadowProperty);
}
