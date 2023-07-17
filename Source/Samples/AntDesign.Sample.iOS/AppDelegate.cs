using Avalonia;
using Avalonia.iOS;
using Avalonia.ReactiveUI;
using AntDesign.Toolkit;

namespace AntDesign.Sample;

// The UIApplicationDelegate for the application. This class is responsible for launching the 
// User Interface of the application, as well as listening (and optionally responding) to 
// application events from iOS.
[Register("AppDelegate")]
public partial class AppDelegate : AvaloniaAppDelegate<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return builder.UseReactiveUI().UseAntDesignToolkit();
    }
}