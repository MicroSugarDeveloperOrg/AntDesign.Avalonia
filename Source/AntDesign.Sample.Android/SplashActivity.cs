using Android.Content;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using Avalonia.Toolkit;
using Application = Android.App.Application;

namespace AntDesign.Sample;

[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
public class SplashActivity : AvaloniaSplashActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
                   .UseReactiveUI()
                   .UseAvaloniaToolkit();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }

    protected override void OnResume()
    {
        base.OnResume();

        StartActivity(new Intent(Application.Context, typeof(MainActivity)));
    }
}