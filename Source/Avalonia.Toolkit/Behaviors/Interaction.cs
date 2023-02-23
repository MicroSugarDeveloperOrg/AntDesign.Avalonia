using Avalonia.Controls;

namespace Avalonia.Toolkit.Behaviors;
public static class Interaction
{
    static Interaction()
    {

    }

    //public static readonly AvaloniaProperty<IBrush?> TriggersProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("Triggers", typeof(Interaction));
    //public static void SetTriggers(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(TriggersProperty, value);
    //public static IBrush? GetTriggers(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(TriggersProperty);

    public static readonly AvaloniaProperty<IBrush?> BehaviorsProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("Behaviors", typeof(Interaction));
    public static void SetBehaviors(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BehaviorsProperty, value);
    public static IBrush? GetBehaviors(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BehaviorsProperty);
}
