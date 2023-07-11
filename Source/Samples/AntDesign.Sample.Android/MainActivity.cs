using Android.Content.PM;
using AntDesign.Toolkit;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;

namespace AntDesign.Sample;

[Activity(Label = "AntDesign.Avalonia.Android",
          Theme = "@style/MyTheme.NoActionBar",
          Icon = "@drawable/icon",
          MainLauncher = true,
          ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
                   .UseReactiveUI()
                   .UseAntDesignToolkit();
    }

}