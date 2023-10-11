namespace AntDesign.Animations.Base;
public abstract class Transformable : AvaloniaObject, ITransformable
{
    internal Transformable(Type associatedType)
    {
        _associatedType = associatedType;
    }

    private Type _associatedType;
    private AvaloniaObject? _associatedObject;

    protected Type AssociatedType
    {
        get
        { 
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

    public void Detach(AvaloniaObject avaloniaObject)
    {
        OnDetaching(avaloniaObject);
        _associatedObject = default;
        OnDetached();
    }

    protected virtual void OnAttaching()
    {

    }

    protected virtual void OnAttached()
    {

    }

    protected virtual void OnDetaching(AvaloniaObject avaloniaObject)
    {

    }

    protected virtual void OnDetached()
    {

    }

}
