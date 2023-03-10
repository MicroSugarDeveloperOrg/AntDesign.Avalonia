namespace AntDesign.Extensions;
public static class Classes
{
    static Classes()
    {
        errorProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_errorClass, e.NewValue.Value));
        endProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_endClass, e.NewValue.Value));
        groupProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_groupClass, e.NewValue.Value));
        leftProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_leftClass, e.NewValue.Value));
        centerProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_centerClass, e.NewValue.Value));
        rightProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_rightClass, e.NewValue.Value));
        roundProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_roundClass, e.NewValue.Value));
        dangerProperty.Changed.AddClassHandler<Control, bool>((s, e) => s.Classes.Set(_dangerClass, e.NewValue.Value));
    }

    private const string _errorClass = "error";
    private const string _endClass = "end";
    private const string _groupClass = "group";
    private const string _leftClass = "left";
    private const string _centerClass = "center";
    private const string _rightClass = "right";
    private const string _roundClass = "round";
    private const string _dangerClass = "danger";

    public static readonly StyledProperty<bool> errorProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_errorClass, typeof(Classes));
    public static void Seterror(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(errorProperty, value);
    public static bool Geterror(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(errorProperty);

    public static readonly StyledProperty<bool> endProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_endClass, typeof(Classes));
    public static void Setend(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(endProperty, value);
    public static bool Getend(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(endProperty);

    public static readonly StyledProperty<bool> groupProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_groupClass, typeof(Classes));
    public static void Setgroup(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(groupProperty, value);
    public static bool Getgroup(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(groupProperty);

    public static readonly StyledProperty<bool> leftProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_leftClass, typeof(Classes));
    public static void Setleft(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(leftProperty, value);
    public static bool Getleft (AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(leftProperty);

    public static readonly StyledProperty<bool> centerProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_centerClass, typeof(Classes));
    public static void Setcenter(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(centerProperty, value);
    public static bool Getcenter(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(centerProperty);

    public static readonly StyledProperty<bool> rightProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_rightClass, typeof(Classes));
    public static void Setright(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(rightProperty, value);
    public static bool Getright(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(rightProperty);

    public static readonly StyledProperty<bool> roundProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_roundClass, typeof(Classes));
    public static void Setround(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(roundProperty, value);
    public static bool Getround(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(roundProperty);

    public static readonly StyledProperty<bool> dangerProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_dangerClass, typeof(Classes));
    public static void Setdanger(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(dangerProperty, value);
    public static bool Getdanger(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(dangerProperty);
}
