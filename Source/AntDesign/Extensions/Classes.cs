namespace AntDesign.Extensions;
public static class Classes
{
    static Classes()
    {
        errorProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_errorClass, e.NewValue.Value));
        endProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_endClass, e.NewValue.Value));
        groupProperty.Changed.AddClassHandler<Control, bool>((s, e) => 
        {
            s.Classes.Set(_groupClass, e.NewValue.Value);
        });
    }

    private const string _errorClass = "error";
    private const string _endClass = "end";
    private const string _groupClass = "group";

    public static readonly StyledProperty<bool> errorProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_errorClass, typeof(Classes));
    public static void Seterror(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(errorProperty, value);
    public static bool Geterror(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(errorProperty);

    public static readonly StyledProperty<bool> endProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_endClass, typeof(Classes));
    public static void Setend(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(endProperty, value);
    public static bool Getend(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(endProperty);

    public static readonly StyledProperty<bool> groupProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_groupClass, typeof(Classes));
    public static void Setgroup(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(groupProperty, value);
    public static bool Getgroup(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(groupProperty);
}
