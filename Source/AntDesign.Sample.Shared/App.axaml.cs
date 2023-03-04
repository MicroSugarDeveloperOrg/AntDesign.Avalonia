using AntDesign.Sample.Routers;
using AntDesign.Sample.Services;
using AntDesign.Sample.ViewModels;
using AntDesign.Sample.Views;
using Avalonia.Toolkit.Extensions;
using Avalonia.Toolkit;

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
        AvaloniaLocator.CurrentMutable.UseToolkitFontManager();
        _container.AddSingleton<IServiceCollection>(_container);
        _container.AddSingleton<IGlobalThemeVariantProvider>(provider => AvaloniaLocator.Current.GetRequiredService<IGlobalThemeVariantProvider>());
        _container.AddSingleton<IThemeService, ThemeService>();

        return true;
    }

    bool RegisterRoutings()
    {
        var routingViewLocator = new MainRoutingViewLocator(_container);
        _container.AddSingleton<IMainRoutingViewLocator>(routingViewLocator);

        routingViewLocator.AddRouter<OverviewView, OverviewViewModel>(routerNameCallBack: () => "组件总览");

        //通用
        routingViewLocator.AddRouter<ButtonView, ButtonViewModel>(routerNameCallBack: () => "Button 按钮");

        //数据录入
        routingViewLocator.AddRouter<AutoCompleteView, AutoCompleteViewModel>(routerNameCallBack: () => "AutoComplete 自动完成");
        routingViewLocator.AddRouter<CheckBoxView, CheckBoxViewModel>(routerNameCallBack: () => "Checkbox 多选框");
        routingViewLocator.AddRouter<InputView, InputViewModel>(routerNameCallBack: () => "Input 输入框");


        routingViewLocator.AddRouter<CalendarView, CalendarViewModel>(routerNameCallBack: () => "Calendar 日历");
        routingViewLocator.AddRouter<CollapseView, CollapseViewModel>(routerNameCallBack: () => "Collapse 折叠面板");
        routingViewLocator.AddRouter<MenuView, MenuViewModel>(routerNameCallBack: () => "Menu 菜单");
        routingViewLocator.AddRouter<TabsView, TabsViewModel>(routerNameCallBack: () => "Tabs 标签页");
        routingViewLocator.AddRouter<TreesView, TreesViewModel>(routerNameCallBack: () => "Tree 树形控件");
        routingViewLocator.AddRouter<DialogsView, DialogsViewModel>(routerNameCallBack: () => "Dialogs 窗口");

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