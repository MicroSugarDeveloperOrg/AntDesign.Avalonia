namespace Avalonia.Toolkit.Behaviors;
public interface IAttachedObject
{
    AvaloniaObject? AssociatedObject { get; }
    void Attach(AvaloniaObject avaloniaObject);
    void Detach();
}
