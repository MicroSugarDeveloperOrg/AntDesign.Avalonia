namespace AntDesign;

partial class AntDesignColorPalette
{
    const string g_AntDesignPrimaryColor = "AntDesignPrimaryColor";
    const string g_AntDesignSecondlyColor = "AntDesignSecondlyColor";
    const string g_AntDesignThirdlyColor = "AntDesignThirdlyColor";
    const string g_AntDesignAssistColor5 = "AntDesignAssistColor5";
    const string g_RippleColor = "RippleColor";
    const string g_OverlayCornerRadius = "OverlayCornerRadius";

    Color _defaultAntDesignPrimaryColor = Color.Parse("#FF1677FF");
    Color _defaultAntDesignSecondlyColor = Color.Parse("#FF4096FF");
    Color _defaultAntDesignThirdlyColor = Color.Parse("#FF1668DC");
    Color _defaultAntDesignAssistColor5 = Color.Parse("#4F9ad2ff");
    Color _defaultRippleColor = Color.Parse("#9B40a9ff");

    Color _primaryAccentColor;

    public static readonly DirectProperty<AntDesignColorPalette, Color> PrimaryAccentProperty = AvaloniaProperty.RegisterDirect<AntDesignColorPalette, Color>(nameof(PrimaryAccent), r => r.PrimaryAccent, (r, v) => r.PrimaryAccent = v);
    public Color PrimaryAccent
    {
        get => _primaryAccentColor;
        set => SetAndRaise(PrimaryAccentProperty, ref _primaryAccentColor, value);
    }

    public Color PrimaryColor
    {
        get => GetColor(g_AntDesignPrimaryColor);
        set => SetColor(g_AntDesignPrimaryColor, value);
    }
}
