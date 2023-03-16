namespace AntDesign.Sample.Services;
public interface IThemeService
{
    string ActualThemeName { get; }
    event EventHandler? ActualThemeVariantChanged;
    bool Switch(string themeName);

}
