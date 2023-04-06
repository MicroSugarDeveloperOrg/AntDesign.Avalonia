namespace AntDesign.Assists;
public class ColorSliderAssists
{
    public static readonly AvaloniaProperty<BoxShadows> BoxShadowProperty = AvaloniaProperty.RegisterAttached<ColorSlider, BoxShadows>("BoxShadow", typeof(ColorSliderAssists));
    public static void SetBoxShadow(AvaloniaObject dependencyObject, BoxShadows value) => dependencyObject.SetValue(BoxShadowProperty, value);
    public static BoxShadows GetBoxShadow(AvaloniaObject dependencyObject) => dependencyObject.GetValue<BoxShadows>(BoxShadowProperty);
}
