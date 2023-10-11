namespace AntDesign.Animations.Base;
public abstract class Transformable<T> : Transformable where T : AvaloniaObject
{
    protected Transformable() : base(typeof(T))
    {

    }

    protected new T? AssociatedObject => (T?)base.AssociatedObject;
}
