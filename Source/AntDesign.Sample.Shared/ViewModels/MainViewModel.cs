using AntDesign.Sample.Routers;
using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;
using Avalonia.ReactiveUI.Toolkit.Routers;

namespace AntDesign.Sample.ViewModels;

public class MainViewModel : ViewModelBase, IScreen
{
    public MainViewModel(IMainRoutingViewLocator viewLocator)
    {
        ViewLocator = viewLocator;
        Router = viewLocator.Make(this);
        Routers = viewLocator.Routers();
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