using Avalonia.Toolkit.Media;
using Avalonia.Toolkit.Settings;

namespace Avalonia.Toolkit;

public static class AvaloniaAppBuilderExtensions
{
    public static AppBuilder UseAvaloniaToolkit([DisallowNull] this AppBuilder builder, Action<FontSettings>? configDelegate = default)
    {
        var setting = new FontSettings();
        configDelegate?.Invoke(setting);
        return builder.With(new FontManagerOptions
        {
            DefaultFamilyName = setting.DefaultFontFamily.ToString(),
            FontFallbacks = new[]
            {
                new FontFallback
                {
                    FontFamily = new FontFamily(setting.DefaultFontFamily.ToString())
                }
            }

        }).ConfigureFonts(manager => manager.AddFontCollection(new AntDesignFontCollection(setting.Key, setting.Source)));   
    }
}