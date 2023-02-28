namespace AntDesign.Assists;
public class TreeViewAssists
{
    public static readonly AvaloniaProperty<bool> ShowLineProperty
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, bool>("ShowLine", typeof(TreeViewAssists));
    public static void SetShowLine(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(ShowLineProperty, value);
    public static bool GetShowLine(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowLineProperty);

    public static readonly AvaloniaProperty<bool> ShowIconProperty
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, bool>("ShowIcon", typeof(TreeViewAssists));
    public static void SetShowIcon(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(ShowIconProperty, value);
    public static bool GetShowIcon(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowIconProperty);

    public static readonly AvaloniaProperty<bool> ShowLeafIconProperty
        = AvaloniaProperty.RegisterAttached<ToggleSwitch, bool>("ShowLeafIcon", typeof(TreeViewAssists));
    public static void SetShowLeafIcon(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(ShowLeafIconProperty, value);
    public static bool GetShowLeafIcon(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowLeafIconProperty);
}
