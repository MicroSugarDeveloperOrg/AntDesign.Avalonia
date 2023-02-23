namespace AntDesign.Behaviors;
public class MenuItemBehaviors : Behavior<MenuItem>
{
    public MenuItemBehaviors()
    {
        _snapshot = new();
    }
    protected Dictionary<MenuItem, PointerBehavior> _snapshot;

    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject is null)
            return;

        if (_snapshot.ContainsKey(AssociatedObject))
            return;

        var pointer = new PointerBehavior();
        pointer.Attach(AssociatedObject);
        _snapshot.Add(AssociatedObject, pointer);
    }

    protected override void OnDetaching(AvaloniaObject avaloniaObject)
    {
        base.OnDetaching(avaloniaObject);
        if (avaloniaObject is not MenuItem menuItem)
            return;

        _snapshot.TryGetValue(menuItem, out var pointer);
        pointer.Detach(menuItem);
    }


}
