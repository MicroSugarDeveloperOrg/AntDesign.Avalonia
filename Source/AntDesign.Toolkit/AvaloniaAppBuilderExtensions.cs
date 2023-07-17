using AntDesign.Toolkit.Settings;

namespace AntDesign.Toolkit;

public static class AvaloniaAppBuilderExtensions
{
    public static AppBuilder UseAntDesignToolkit([DisallowNull] this AppBuilder builder, Action<FontSettings>? configDelegate = default)
    {
        var setting = new FontSettings();
        configDelegate?.Invoke(setting);

        //this setting can make app crash when publish for NativeAOT
        return builder.With(new FontManagerOptions
        {
            DefaultFamilyName = setting.DefaultFontFamily,
            FontFallbacks = new[]
            {
                new FontFallback
                {
                    FontFamily = new FontFamily(setting.DefaultFontFamily)
                }
            }

        }).ConfigureFonts(manager => manager.AddFontCollection(new EmbeddedFontCollection(setting.Key, setting.Source)));

        //return builder.ConfigureFonts(manager => manager.AddFontCollection(new EmbeddedFontCollection(setting.Key, setting.Source)));
    }
}