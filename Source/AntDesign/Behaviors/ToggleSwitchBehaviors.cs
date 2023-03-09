using Avalonia.VisualTree;

namespace AntDesign.Behaviors;
public class ToggleSwitchBehaviors : Behavior<Panel>
{
    public ToggleSwitchBehaviors()
    {
        ToggleSwitchCheckedProperty.Changed.AddClassHandler<ToggleSwitchBehaviors, bool?>((s, e) =>
        {
            
        });
    }

    public static readonly StyledProperty<bool?> ToggleSwitchCheckedProperty =
                           AvaloniaProperty.Register<ToggleSwitchBehaviors, bool?>(nameof(ToggleSwitchChecked), defaultBindingMode:BindingMode.TwoWay);

    public bool? ToggleSwitchChecked
    {
        get => GetValue(ToggleSwitchCheckedProperty);
        set => SetValue(ToggleSwitchCheckedProperty, value);
    }

    Canvas? _parentCanvas;
    Panel? _grandparentPanel;

    bool _isLoaded = false;

    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject is null)
            return;

        var canvas = AssociatedObject.GetVisualParent<Canvas>();
        if (canvas is null)
            return;

        _parentCanvas = canvas;

        var panel = _parentCanvas.GetVisualParent<Panel>();
        if (panel is null) 
            return;

        _grandparentPanel = panel;
        Resize();

        _grandparentPanel.SizeChanged += GrandparentPanel_SizeChanged; 
        AssociatedObject.Loaded += AssociatedObject_Loaded;
    }


    protected override void OnDetaching(AvaloniaObject avaloniaObject)
    {
        base.OnDetaching(avaloniaObject);
        if (AssociatedObject is not null)
            AssociatedObject.Unloaded -= AssociatedObject_Loaded;

        if (_grandparentPanel is not null)
            _grandparentPanel.SizeChanged -= GrandparentPanel_SizeChanged;
    }

    private void GrandparentPanel_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        Resize();
    }


    private void AssociatedObject_Loaded(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!_isLoaded)
        {
            Dispatcher.UIThread.Post(() => MoveingKnobs());
            _isLoaded = true;
        }
    }

    bool Resize()
    {
        if (_grandparentPanel is null)
            return false;

        if (_parentCanvas is null)
            return false;

        if (AssociatedObject is null)
            return false;

        var width = _grandparentPanel.Bounds.Width;
        var height = _grandparentPanel.Bounds.Height;

        if (double.IsNaN(width) || double.IsNaN(height))
            return false;

        if (width == 0 || height == 0)
            return false;

        if (width <= height)
            return false;

        _parentCanvas.Width = width - height;
        _parentCanvas.Height = height;

        AssociatedObject.Width = height;
        AssociatedObject.Height = height;

        return true;
    }

    bool MoveingKnobs()
    {
        if (AssociatedObject is null)
            return false;

        if (_parentCanvas is null)
            return false;

        if (!AssociatedObject.IsLoaded)
            return false;

        if (ToggleSwitchChecked != true)
            return false;

        var lastChecked = ToggleSwitchChecked;
        if (lastChecked == true)
        {
            ToggleSwitchChecked = false;
            ToggleSwitchChecked = true;
        }

        return true;
    }

}
