namespace Avalonia.Toolkit.Behaviors;
public abstract class Behavior: AvaloniaObject, IAttachedObject
{
    internal Behavior(Type associatedType)
    {
        _associatedType = associatedType;
    }

    private Type _associatedType;
    private AvaloniaObject? _associatedObject;

    protected Type AssociatedType
    {
        get 
        {
            VerifyAccess();
            return _associatedType;
        }
    }

    public AvaloniaObject? AssociatedObject => _associatedObject;

    public void Attach(AvaloniaObject avaloniaObject)
    {
        if (_associatedObject != avaloniaObject)
        {
            OnAttaching();
            _associatedObject = avaloniaObject;
            OnAttached();
        }
    }

    public void Detach()
    {
        OnDetaching();
        _associatedObject = default;
        OnDetached();
    }

    protected virtual void OnAttaching()
    {

    }

    protected virtual void OnAttached()
    {

    }

    protected virtual void OnDetaching()
    {

    }

    protected virtual void OnDetached() 
    {

    }

}
