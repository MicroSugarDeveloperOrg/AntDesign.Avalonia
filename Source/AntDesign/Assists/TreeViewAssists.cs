namespace AntDesign.Assists;
public class TreeViewAssists
{
    public static readonly AvaloniaProperty<bool> ShowLineProperty
    = AvaloniaProperty.RegisterAttached<ToggleSwitch, bool>("ShowLine", typeof(ToggleSwitchAssists));
    public static void SetShowLine(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ShowLineProperty, value);
    public static bool GetShowLine(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowLineProperty);

    public static readonly AvaloniaProperty<bool> ShowIconProperty
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, bool>("ShowIcon", typeof(ToggleSwitchAssists));
    public static void SetShowIcon(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ShowIconProperty, value);
    public static bool GetShowIcon(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowIconProperty);

    public static readonly AvaloniaProperty<bool> ShowLeafIconProperty
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, bool>("ShowLeafIcon", typeof(ToggleSwitchAssists));
    public static void SetShowLeafIcon(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ShowLeafIconProperty, value);
    public static bool GetShowLeafIcon(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowLeafIconProperty);
}
