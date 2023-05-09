namespace AntDesign;

public partial class AntDesign : Styles
{
    static AntDesign()
    {
        ColoringProperty.Changed.AddClassHandler<AntDesign, Colours>((s, e) =>
        {
            var app = Application.Current;
            if (app is null)
                return;

            switch (e.NewValue.Value)
            {
                case Colours.None:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = s._defaultAntDesignPrimaryColor;
                        app.Resources[g_AntDesignSecondlyColor] = s._defaultAntDesignSecondlyColor;
                        app.Resources[g_AntDesignThirdlyColor] = s._defaultAntDesignThirdlyColor;
                        app.Resources[g_AntDesignAssistColor5] = s._defaultAntDesignAssistColor5;
                        app.Resources[g_RippleColor] = s._defaultRippleColor;
                    }
                    break;
                case Colours.Red:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#e84749");
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#f37370");
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#f89f9a");
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#fff1f0");
                        app.Resources[g_RippleColor] = Color.Parse("#ff4d4f");
                    }
                    break;
                default:
                    break;
            }
        });

        IsRoundedProperty.Changed.AddClassHandler<AntDesign, bool>((s, e) =>
        {
            var app = Application.Current;
            if (app is null)
                return;

            if (e.NewValue.Value)
                app.Resources[g_OverlayCornerRadius] = new CornerRadius(5);
            else
                app.Resources[g_OverlayCornerRadius] = new CornerRadius(0);
        });

        IsAnimableProperty.Changed.AddClassHandler<AntDesign, bool>((s, e) =>
        {
            var app = Application.Current;
            if (app is null)
                return;

            app.Resources[g_IsAnimable] = e.NewValue.Value;
        });
    }

    public AntDesign(IServiceProvider? serviceProvider = default)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
        AntDesignPalettes = Resources.MergedDictionaries.OfType<AntDesignColorPaletteCollection>().FirstOrDefault();
    }

    public IDictionary<ThemeVariant, AntDesignColorPalette> AntDesignPalettes { get; }

    const string g_AntDesignPrimaryColor = "AntDesignPrimaryColor";
    const string g_AntDesignSecondlyColor = "AntDesignSecondlyColor";
    const string g_AntDesignThirdlyColor = "AntDesignThirdlyColor";
    const string g_AntDesignAssistColor5 = "AntDesignAssistColor5";
    const string g_RippleColor = "RippleColor";
    const string g_OverlayCornerRadius = "OverlayCornerRadius";

    const string g_IsAnimable = "IsAnimable";

    Color _defaultAntDesignPrimaryColor = Color.Parse("#FF1677FF");
    Color _defaultAntDesignSecondlyColor = Color.Parse("#FF4096FF");
    Color _defaultAntDesignThirdlyColor = Color.Parse("#FF1668DC");
    Color _defaultAntDesignAssistColor5 = Color.Parse("#4F9ad2ff");
    Color _defaultRippleColor = Color.Parse("#9B40a9ff");

    public static readonly StyledProperty<Colours> ColoringProperty =
                       AvaloniaProperty.Register<AntDesign, Colours>(nameof(Coloring), defaultBindingMode: BindingMode.TwoWay, defaultValue: Colours.None);

    public Colours Coloring
    {
        get => GetValue(ColoringProperty);
        set => SetValue(ColoringProperty, value);
    }

    public static readonly StyledProperty<bool> IsRoundedProperty =
                       AvaloniaProperty.Register<AntDesign, bool>(nameof(IsRounded), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsRounded
    {
        get => GetValue(IsRoundedProperty);
        set => SetValue(IsRoundedProperty, value);
    }

    public static readonly StyledProperty<bool> IsAnimableProperty =
                   AvaloniaProperty.Register<AntDesign, bool>(nameof(IsAnimable), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsAnimable
    {
        get => GetValue(IsAnimableProperty);
        set => SetValue(IsAnimableProperty, value);
    }
}
