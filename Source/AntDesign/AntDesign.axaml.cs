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
                case Colours.DustRed:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#f5222d");
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#ff4d4f");
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#a8071a");
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#fff1f0");
                        app.Resources[g_RippleColor] = Color.Parse("#ff4d4f");
                    }
                    break;
                case Colours.Volcano:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#fa541c");
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#ff7a45");
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#ad2102");
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#fff2e8");
                        app.Resources[g_RippleColor] = Color.Parse("#ff7a45");
                    }
                    break;
                case Colours.SunsetOrange:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#fa8c16");
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#ffa940");
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#ad4e00");
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#fff7e6");
                        app.Resources[g_RippleColor] = Color.Parse("#ffa940");
                    }
                    break;
                case Colours.Cyan:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#13c2c2");//6
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#36cfc9");//5
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#006d75");//8
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#e6fffb"); //1
                        app.Resources[g_RippleColor] = Color.Parse("#36cfc9");//5
                    }
                    break;
                case Colours.PolarGreen:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#52c41a");//6
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#73d13d");//5
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#237804");//8
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#f6ffed"); //1
                        app.Resources[g_RippleColor] = Color.Parse("#73d13d");//5
                    }
                    break;
                case Colours.GeekBlue:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#2f54eb");//6
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#597ef7");//5
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#10239e");//8
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#f0f5ff"); //1
                        app.Resources[g_RippleColor] = Color.Parse("#597ef7");//5
                    }
                    break;
                case Colours.GoldenPurple:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = Color.Parse("#722ed1");//6
                        app.Resources[g_AntDesignSecondlyColor] = Color.Parse("#9254de");//5
                        app.Resources[g_AntDesignThirdlyColor] = Color.Parse("#391085");//8
                        app.Resources[g_AntDesignAssistColor5] = Color.Parse("#f9f0ff"); //1
                        app.Resources[g_RippleColor] = Color.Parse("#9254de");//5
                    }
                    break;
                default:
                    {
                        app.Resources[g_AntDesignPrimaryColor] = s._defaultAntDesignPrimaryColor;
                        app.Resources[g_AntDesignSecondlyColor] = s._defaultAntDesignSecondlyColor;
                        app.Resources[g_AntDesignThirdlyColor] = s._defaultAntDesignThirdlyColor;
                        app.Resources[g_AntDesignAssistColor5] = s._defaultAntDesignAssistColor5;
                        app.Resources[g_RippleColor] = s._defaultRippleColor;
                    }
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

    Color _defaultAntDesignPrimaryColor = Color.Parse("#FF1677FF"); //6
    Color _defaultAntDesignSecondlyColor = Color.Parse("#FF4096FF");//5
    Color _defaultAntDesignThirdlyColor = Color.Parse("#FF1668DC");//8
    Color _defaultAntDesignAssistColor5 = Color.Parse("#4F9ad2ff");//1
    Color _defaultRippleColor = Color.Parse("#9B40a9ff");//5


    //Color _defaultAntDesignPrimaryColor = Color.Parse("#FF1677FF"); //6
    //Color _defaultAntDesignSecondlyColor = Color.Parse("#FF4096FF");//5
    //Color _defaultAntDesignThirdlyColor = Color.Parse("#ff003eb3");//8
    //Color _defaultAntDesignAssistColor5 = Color.Parse("#4F9ad2ff");//1
    //Color _defaultRippleColor = Color.Parse("#FF4096FF");//5

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
