namespace AntDesign.Animations.Base;

public abstract class Animatable<T> : Animatable where T : AvaloniaObject
{
    protected Animatable() : base(typeof(T))
    {

    }

    protected new T? AssociatedObject => (T?)base.AssociatedObject;

}
