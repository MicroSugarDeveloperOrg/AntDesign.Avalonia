namespace AntDesign.FontManager.Settings;
public class FontSettings
{
    public string DefaultFontFamily = "fonts:AntDesignFontFamilies#Alibaba PuHuiTi 3.0";
    public Uri Key { get; set; } = new Uri("fonts:AntDesignFontFamilies", UriKind.Absolute);
    public Uri Source { get; set; } = new Uri("avares://AntDesign.FontManager/Assets/Fonts/AliBaba", UriKind.Absolute);
}
