namespace Avalonia.Toolkit;

public static class AvaloniaAppBuilderExtensions
{
    public static AppBuilder UseAvaloniaToolkit([DisallowNull] this AppBuilder app)
    {
        app.AfterSetup( builder =>
        {

        });
        return app;
    }
}