namespace Avalonia.Toolkit.Behaviors;
public abstract class Behavior<T> : Behavior where T : AvaloniaObject
{
    protected Behavior() :base(typeof(T))
    {

    }

    protected new T? AssociatedObject => (T?)base.AssociatedObject;

}
