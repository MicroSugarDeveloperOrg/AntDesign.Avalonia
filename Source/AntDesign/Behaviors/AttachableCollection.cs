using System.Collections.ObjectModel;

namespace AntDesign.Behaviors;
public abstract class AttachableCollection<T> : AvaloniaList<T>, IAttachedObject where T : AvaloniaObject, IAttachedObject
{
    internal AttachableCollection()
    {
        _snapshot = new();
        CollectionChanged += AttachableCollection_CollectionChanged;
    }

    private Collection<T> _snapshot;
    protected AvaloniaObject? _associatedObject;

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
        CollectionChanged -= AttachableCollection_CollectionChanged;
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

    private void AttachableCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {

    }
}
