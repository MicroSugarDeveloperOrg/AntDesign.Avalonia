namespace AntDesign.Behaviors;
public class ToggleSwitchBehaviors : Behavior<ToggleSwitch>
{
    public ToggleSwitchBehaviors()
    {
        _snapshot = new();
    }
    protected Dictionary<ToggleSwitch, SwitchBehavior> _snapshot;

    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject is null)
            return;

        if (_snapshot.ContainsKey(AssociatedObject))
            return;

        var switcher = new SwitchBehavior();
        switcher.Attach(AssociatedObject);
        _snapshot.Add(AssociatedObject, switcher);
    }

    protected override void OnDetaching(AvaloniaObject avaloniaObject)
    {
        base.OnDetaching(avaloniaObject);
        if (avaloniaObject is not ToggleSwitch toggleSwitch)
            return;

        _snapshot.TryGetValue(toggleSwitch, out var pointer);
        pointer.Detach(toggleSwitch);
    }
}
