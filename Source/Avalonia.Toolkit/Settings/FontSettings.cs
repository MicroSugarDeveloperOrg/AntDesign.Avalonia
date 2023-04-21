namespace Avalonia.Toolkit.Settings;
public class FontSettings
{
    public string DefaultFontFamily = "fonts:AntDesignFontFamilies#Alibaba PuHuiTi 2.0";
    public Uri Key { get; set; } = new Uri("fonts:AntDesignFontFamilies", UriKind.Absolute);
    public Uri Source { get; set; } = new Uri("avares://Avalonia.Toolkit/Assets/Fonts/AliBaba", UriKind.Absolute);
}
