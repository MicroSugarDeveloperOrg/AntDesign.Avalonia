namespace AntDesign.Behaviors;
public class PointerBehavior : Behavior<MenuItem>
{
    static PointerBehavior()
    {
        MenuItem.PointerPressedEvent.AddClassHandler<MenuItem>((s, e) =>
        {
            if (s.Tag is not nameof(PointerBehavior))
                return;

            if (s.Items is null)
                return;

            if (s.ItemCount <= 0)
                return;
 
            e.Handled = true;
        }, Avalonia.Interactivity.RoutingStrategies.Tunnel);
    }

    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject is null)
            return;
        AssociatedObject.Tag = nameof(PointerBehavior);
        AssociatedObject.PointerEntered += AssociatedObject_PointerEntered;
        AssociatedObject.PointerExited += AssociatedObject_PointerExited;
       // AssociatedObject.PointerReleased += AssociatedObject_PointerReleased;
        AssociatedObject.PointerPressed += AssociatedObject_PointerPressed;
    }

    protected override void OnDetaching(AvaloniaObject avaloniaObject)
    {
        base.OnDetaching(avaloniaObject);
        if (AssociatedObject is null)
            return;
        AssociatedObject.PointerEntered -= AssociatedObject_PointerEntered;
        AssociatedObject.PointerExited -= AssociatedObject_PointerExited;
        AssociatedObject.PointerPressed -= AssociatedObject_PointerPressed;
    }

    private void AssociatedObject_PointerEntered(object sender, PointerEventArgs e)
    {
        if (sender != AssociatedObject)
            return;

        if (AssociatedObject.Items is null)
            return;

        if (AssociatedObject.ItemCount <= 0)
            return;

        AssociatedObject.IsSubMenuOpen = true;
    }

    private void AssociatedObject_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (sender != AssociatedObject)
            return;

        if (AssociatedObject.Items is null)
            return;

        if (AssociatedObject.ItemCount <= 0)
            return;

        //AssociatedObject.IsSubMenuOpen = true;
    }

    private void AssociatedObject_PointerExited(object sender, PointerEventArgs e)
    {
       
    }

    private void AssociatedObject_PointerReleased(object sender, PointerReleasedEventArgs e)
    {
        if (sender != AssociatedObject)
            return;

        if (AssociatedObject.Items is null)
            return;

        if (AssociatedObject.ItemCount <= 0)
            return;

        AssociatedObject.IsSubMenuOpen = false;
    }

}
