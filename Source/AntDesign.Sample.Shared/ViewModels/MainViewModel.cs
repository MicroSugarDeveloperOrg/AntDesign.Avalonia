using AntDesign.Sample.Routers;
using AntDesign.Sample.Services;
using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;

public class MainViewModel : ViewModelBase, IScreen
{
    public MainViewModel(IMainRoutingViewLocator viewLocator, IThemeService themeService)
    {
        ViewLocator = viewLocator;
        Router = viewLocator.Make(this);
        Routers = viewLocator.Routers();

        themeService.ActualThemeVariantChanged += (s, e) =>
        {
            if (themeService.ActualThemeName is "Light" or "Default")
                IsVisible = true;
            else
                IsVisible = false;
        };

        ToolPopOpenCommand = ReactiveCommand.Create(() => 
        {
            IsPopupOpen = !IsPopupOpen;
        });

        SwitchThemeCommand = ReactiveCommand.Create(() =>
        {
            if (themeService.ActualThemeName is "Light" or "Default")
                themeService.Switch("Dark");
            else
                themeService.Switch("Light");
        });

        StartGitHubCommand = ReactiveCommand.Create(() =>
        {

        });
    }

    public RoutingState Router { get; }
    public ObservableCollection<Router> Routers { get; }
    public IMainRoutingViewLocator ViewLocator { get; }

    Router? _selectedItem = default;
    public Router? SelectedItem
    {
        get => _selectedItem;
        set => SetProperty(ref _selectedItem, value, (o, n) =>
        {
            if (n is null)
                return;

            ViewLocator.Navigate(n.Token);
        });
    }

    private bool _isPopupOpen = false;
    public bool IsPopupOpen
    {
        get => _isPopupOpen;
        set => SetProperty(ref _isPopupOpen, value);
    }

    private bool _isVisible = true;
    public bool IsVisible
    {
        get => _isVisible;
        set => SetProperty(ref _isVisible, value);
    }

    public ReactiveCommand<Unit, Unit> ToolPopOpenCommand { get; }
    public ReactiveCommand<Unit, Unit> SwitchThemeCommand { get; }
    public ReactiveCommand<Unit, Unit> StartGitHubCommand { get; }

    protected override void Activating()
    {
        base.Activating();
        SelectedItem = Routers.FirstOrDefault();
    }

    protected override void Disposing()
    {
        base.Disposing();
    }
}