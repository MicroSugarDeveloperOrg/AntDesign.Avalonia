 namespace AntDesign.Behaviors;

public static class Interaction
{
    static Interaction()
    {
        BehaviorsProperty.Changed.AddClassHandler<AvaloniaObject, Behavior?>((s, e) =>
        {
            if (s == null) 
                return;

            if (e.OldValue.Value is not null)
                e.OldValue.Value.Detach(s);

            if (e.NewValue.Value is not null)
                e.NewValue.Value.Attach(s);
        });
    }

    public static readonly AvaloniaProperty<Behavior?> BehaviorsProperty = AvaloniaProperty.RegisterAttached<AvaloniaObject, Behavior?>("Behaviors", typeof(Interaction));
    public static void SetBehaviors(AvaloniaObject dependencyObject, Behavior? value) => dependencyObject.SetValue(BehaviorsProperty, value);
    public static Behavior? GetBehaviors(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Behavior?>(BehaviorsProperty);

}
