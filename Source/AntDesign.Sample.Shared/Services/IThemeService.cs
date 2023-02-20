namespace AntDesign.Sample.Services;
public interface IThemeService
{
    string ActualThemeName { get; }

     bool Switch(string themeName);
 
}
