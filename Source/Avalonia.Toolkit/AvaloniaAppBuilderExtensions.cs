using Avalonia.Toolkit.Media;
using Avalonia.Toolkit.Settings;

namespace Avalonia.Toolkit;

public static class AvaloniaAppBuilderExtensions
{
    public static AppBuilder UseAvaloniaToolkit([DisallowNull] this AppBuilder builder, Action<FontSettings>? configDelegate = default)
    {
        var setting = new FontSettings();
        configDelegate?.Invoke(setting);

        //this setting can make app crash when publish for NativeAOT
        //return builder.With(new FontManagerOptions
        //{
        //    DefaultFamilyName = setting.DefaultFontFamily,
        //    FontFallbacks = new[]
        //    {
        //        new FontFallback
        //        {
        //            FontFamily = new FontFamily(setting.DefaultFontFamily)
        //        }
        //    }

        //}).ConfigureFonts(manager => manager.AddFontCollection(new AntDesignFontCollection(setting.Key, setting.Source)));

        return builder.ConfigureFonts(manager => manager.AddFontCollection(new AntDesignFontCollection(setting.Key, setting.Source)));
    }
}