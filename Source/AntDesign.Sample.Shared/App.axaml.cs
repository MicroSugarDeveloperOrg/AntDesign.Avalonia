using AntDesign.Sample.ViewModels;
using AntDesign.Sample.Views;
using Avalonia.Toolkit.Media;

namespace AntDesign.Sample;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this); 
    }

    public override void RegisterServices()
    {
        AvaloniaLocator.CurrentMutable.Bind<IFontManagerImpl>().ToConstant(new ToolkitFontManagerImpl());
        base.RegisterServices();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}