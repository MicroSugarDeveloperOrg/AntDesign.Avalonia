namespace AntDesign.Assists;

public static class TextBoxAssists
{
    public static readonly AvaloniaProperty<AntStatus> StatusProperty = AvaloniaProperty.RegisterAttached<TextBox, AntStatus>("Status", typeof(TextBoxAssists));
    public static void SetStatus(AvaloniaObject dependencyObject, AntStatus value) => dependencyObject.SetValue(StatusProperty, value);
    public static AntStatus GetStatus(AvaloniaObject dependencyObject) => dependencyObject.GetValue<AntStatus>(StatusProperty);
}
