using AntDesign.Sample.Routers;
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
        RegisterInternalServices();
        RegisterRoutings();
        RegisterViewViewModels();
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

    bool RegisterInternalServices()
    {
        AvaloniaLocator.CurrentMutable.BindToConstant<IFontManagerImpl, ToolkitFontManagerImpl>();
        _container.AddSingleton<IServiceCollection>(_container);
        _container.AddSingleton<IGlobalThemeVariantProvider>(provider => AvaloniaLocator.Current.GetRequiredService<IGlobalThemeVariantProvider>());
        return true;
    }

    bool RegisterRoutings()
    {
        var routingViewLocator = new MainRoutingViewLocator(_container);
        _container.AddSingleton<IMainRoutingViewLocator>(routingViewLocator);

        routingViewLocator.AddRouter<OverviewView, OverviewViewModel>(routerNameCallBack: () => "组件总览");
        routingViewLocator.AddRouter<ButtonView, ButtonViewModel>(routerNameCallBack: () => "Button 按钮");

        return true;
    }

    bool RegisterViewViewModels()
    {
        _container.AddSingleton<MainWindow>();
        _container.AddSingleton<MainView>();
        _container.AddSingleton<MainViewModel>();

        return true;
    }
}