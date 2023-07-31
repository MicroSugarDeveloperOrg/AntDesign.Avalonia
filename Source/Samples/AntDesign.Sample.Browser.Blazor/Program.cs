using Avalonia;
using Avalonia.Browser.Blazor;
using Avalonia.ReactiveUI;
using AntDesign.FontManager;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Runtime.Versioning;
using antdesignApp = AntDesign.Sample.App;
using blazorApp = AntDesign.Sample.Browser.Blazor.App;

[assembly: SupportedOSPlatform("browser")]
public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        await StartAvaloniaApp();
        await host.RunAsync();
    }

    public static async Task StartAvaloniaApp()
    {
        await AppBuilder.Configure<antdesignApp>()
                        .UseReactiveUI()
                        .UseAntDesignFontManager()
                        .StartBlazorAppAsync();
    }

    public static WebAssemblyHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.RootComponents.Add<blazorApp>("#app");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        return builder;
    }
}
