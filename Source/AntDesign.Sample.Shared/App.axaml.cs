using AntDesign.Sample.Extensions;
using AntDesign.Sample.ViewModels;
using AntDesign.Sample.Views;
using Avalonia.Toolkit.Extensions;
using Avalonia.Toolkit.Media;

namespace AntDesign.Sample;

public partial class App : Application
{
    public App()
    {
        _container = new ServiceCollection();
    }

    IServiceCollection _container;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void RegisterServices()
    {
        base.RegisterServices();
        AvaloniaLocator.CurrentMutable.BindToConstant<IFontManagerImpl, ToolkitFontManagerImpl>();
        _container.AddSingleton<IViewLocator, RoutingViewLocator>();
        _container.AddSingleton<MainWindow>();
        _container.AddViewWithViewModelSingleton<MainView, MainViewModel>();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        //ServiceProvider
        var serviceProvider = _container.BuildServiceProvider();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            desktop.MainWindow = mainWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var mainView = serviceProvider.GetRequiredService<MainView>();
            mainView.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            singleViewPlatform.MainView = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }
}