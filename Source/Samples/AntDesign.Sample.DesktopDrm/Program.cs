using AntDesign.FontManager;
using Avalonia;
using Avalonia.ReactiveUI;

namespace AntDesign.Sample.DesktopDrm;

class Program
{
    [STAThread]
    public static int Main(string[] args)
    {
        var builder = BuildAvaloniaApp();
        if (args.Contains("--drm"))
        {
            SilenceConsole();

            // If Card0, Card1 and Card2 all don't work. You can also try:                 
            // return builder.StartLinuxFbDev(args);
            // return builder.StartLinuxDrm(args, "/dev/dri/card1");
            return builder.StartLinuxDrm(args, "/dev/dri/card1", 1D);
        }

        return builder.StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
       => AppBuilder.Configure<App>()
                    .UsePlatformDetect()
                    .UseAntDesignFontManager()
                    .LogToTrace()
                    .UseReactiveUI();

    private static void SilenceConsole()
    {
        new Thread(() =>
        {
            Console.CursorVisible = false;
            while (true)
                Console.ReadKey(true);
        })
        { IsBackground = true }.Start();
    }
}
