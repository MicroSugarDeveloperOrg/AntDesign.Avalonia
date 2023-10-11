namespace AntDesign.Animations.Base;

public interface IAnimatable
{
    AvaloniaObject? AssociatedObject { get; }
    void Attach(AvaloniaObject avaloniaObject);
    void Detach(AvaloniaObject avaloniaObject);
}
