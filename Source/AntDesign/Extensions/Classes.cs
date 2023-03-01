namespace AntDesign.Extensions;
public static class Classes
{
    static Classes()
    {
        errorProperty.Changed.AddClassHandler<Control, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (!e.NewValue.Value)
            {
                if (s.Classes.Contains(_errorClass))
                    s.Classes.Remove(_errorClass);
            }
            else
            {
                if (!s.Classes.Contains(_errorClass))
                    s.Classes.Add(_errorClass);
            }
        });
    }

    private const string _errorClass = "error";


    public static readonly AvaloniaProperty<bool> errorProperty = AvaloniaProperty.RegisterAttached<Control, bool>(_errorClass, typeof(Classes));
    public static void Seterror(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(errorProperty, value);
    public static bool Geterror(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(errorProperty);


}
