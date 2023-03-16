using Avalonia.Threading;

namespace AntDesign.Sample.Services;
internal class ThemeService : IThemeService
{
    IDispatcher _dispatcher => Dispatcher.UIThread;

    private Application? _application;
    protected Application? Application
    {
        get
        {
            if (_application == null)
            {
                _application = Application.Current;
                if (_application is not null)
                    _application.ActualThemeVariantChanged += Application_ActualThemeVariantChanged;
            }

            return _application;
        }
    }

    public event EventHandler? ActualThemeVariantChanged;

    public string ActualThemeName => Application?.ActualThemeVariant.Key.ToString() ?? "Default";

    public bool Switch(string themeName)
    {
        if (Application is null)
            return false;

        if (_dispatcher.CheckAccess())
        {
            var themeVariant = ThemeVariant.Default;
            switch (themeName)
            {
                case nameof(ThemeVariant.Dark):
                    themeVariant = ThemeVariant.Dark;
                    break;
                case nameof(ThemeVariant.Light):
                    themeVariant = ThemeVariant.Light;
                    break;
                default:
                    themeVariant = new ThemeVariant(themeName, default);
                    break;
            }

            Application.RequestedThemeVariant = themeVariant;
        }
        else
            _dispatcher.Post(() => Switch(themeName));

        return true;
    }

    private void Application_ActualThemeVariantChanged(object? sender, EventArgs e) => ActualThemeVariantChanged?.Invoke(this, e);
}
