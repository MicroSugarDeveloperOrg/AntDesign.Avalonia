using Avalonia.Controls;

namespace AntDesign.Assists;
public class ColorViewAssists
{
    public static readonly AvaloniaProperty<ControlTheme?> RadioButtonStyleProperty = AvaloniaProperty.RegisterAttached<ColorView, ControlTheme?>("RadioButtonStyle", typeof(ColorViewAssists));
    public static void SetRadioButtonStyle(AvaloniaObject dependencyObject, ControlTheme? value) => dependencyObject.SetValue(RadioButtonStyleProperty, value);
    public static ControlTheme? GetRadioButtonStyle(AvaloniaObject dependencyObject) => dependencyObject.GetValue<ControlTheme?>(RadioButtonStyleProperty);
}
