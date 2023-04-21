namespace Avalonia.Toolkit.Settings;
public class FontSettings
{
    public Uri DefaultFontFamily = new Uri("avares://Avalonia.Toolkit/Assets/Fonts/AliBaba/AlibabaPuHuiTi-Regular.ttf#Alibaba PuHuiTi 2.0", UriKind.Absolute);
    public Uri Key { get; set; } = new Uri("fonts:AntDesignFontFamilies", UriKind.Absolute);
    public Uri Source { get; set; } = new Uri("avares://Avalonia.Toolkit/Assets/Fonts/AliBaba", UriKind.Absolute);
}
