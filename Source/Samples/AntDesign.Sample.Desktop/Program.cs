using Avalonia;
using Avalonia.Controls;
using AntDesign.FontManager;
using Avalonia.ReactiveUI;

namespace AntDesign.Sample;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) =>BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args, shutdownMode: ShutdownMode.OnMainWindowClose);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
                     .UsePlatformDetect()
                     .UseAntDesignFontManager()
                     .LogToTrace()
                     .UseReactiveUI();
}
