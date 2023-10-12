namespace AntDesign;

public partial class AntDesignControlsStyle : Styles, IResourceNode
{
    static AntDesignControlsStyle()
    {
        ColoringProperty.Changed.AddClassHandler<AntDesignControlsStyle, Colours>((s, e) => s._antdesign.Coloring = e.NewValue.Value);
        IsRoundedProperty.Changed.AddClassHandler<AntDesignControlsStyle, bool>((s, e) => s._antdesign.IsRounded = e.NewValue.Value);
        IsAnimableProperty.Changed.AddClassHandler<AntDesignControlsStyle, bool>((s, e) => s._antdesign.IsAnimable = e.NewValue.Value);
    }

    public AntDesignControlsStyle(IServiceProvider? serviceProvider = default)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
        _antdesign = new AntDesign();
        Add(_antdesign);
    }

    AntDesign _antdesign;

    public static readonly StyledProperty<Colours> ColoringProperty =
           AntDesign.ColoringProperty.AddOwner<AntDesignControlsStyle>();

    public Colours Coloring
    {
        get => GetValue(ColoringProperty);
        set => SetValue(ColoringProperty, value);
    }

    public static readonly StyledProperty<bool> IsRoundedProperty =
           AntDesign.IsRoundedProperty.AddOwner<AntDesignControlsStyle>();

    public bool IsRounded
    {
        get => GetValue(IsRoundedProperty);
        set => SetValue(IsRoundedProperty, value);
    }

    public static readonly StyledProperty<bool> IsAnimableProperty =
           AntDesign.IsAnimableProperty.AddOwner<AntDesignControlsStyle>();

    public bool IsAnimable
    {
        get => GetValue(IsAnimableProperty);
        set => SetValue(IsAnimableProperty, value);
    }
}
