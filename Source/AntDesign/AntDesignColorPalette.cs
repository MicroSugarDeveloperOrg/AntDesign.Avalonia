namespace AntDesign;
public partial class AntDesignColorPalette : AvaloniaObject, IResourceNode
{
    public AntDesignColorPalette()
    {
        PrimaryColor = Color.Parse("#e84749");
    }

    readonly Dictionary<string, Color> _mapColors = new(StringComparer.InvariantCulture);

    public bool HasResources => _mapColors.Count > 0;

    Color GetColor(string key)
    {
        if (_mapColors.TryGetValue(key, out var color))
            return color;

        return default;
    }

    void SetColor(string key, Color value)
    {
        if (value == default)
            _mapColors.Remove(key);
        else
            _mapColors[key] = value;
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
    }

    public bool TryGetResource(object key, ThemeVariant? theme, out object? value)
    {
        value = default;
        if (key is not string strKey)
            return false;

        if (strKey.Equals(g_AntDesignPrimaryColor, StringComparison.InvariantCulture))
            value = _defaultAntDesignPrimaryColor;
        else if (strKey.Equals(g_AntDesignSecondlyColor, StringComparison.InvariantCulture))
            value = _defaultAntDesignSecondlyColor;
        else if (strKey.Equals(g_AntDesignThirdlyColor, StringComparison.InvariantCulture))
            value = _defaultAntDesignThirdlyColor;
        else if (strKey.Equals(g_AntDesignAssistColor5, StringComparison.InvariantCulture))
            value = _defaultAntDesignAssistColor5;
        else if (strKey.Equals(g_RippleColor, StringComparison.InvariantCulture))
            value = _defaultRippleColor;
        else
            return false;
 
        return true;
    }
}
