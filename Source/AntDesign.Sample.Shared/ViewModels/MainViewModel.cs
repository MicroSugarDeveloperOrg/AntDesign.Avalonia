using AntDesign.Sample.Routers;

namespace AntDesign.Sample.ViewModels;

public class MainViewModel : ViewModelBase, IScreen
{
    public MainViewModel(IMainRoutingViewLocator viewLocator)
    {
        ViewLocator = viewLocator;
        Router = viewLocator.Make(this);
    }

    public RoutingState Router { get; }
    public IMainRoutingViewLocator ViewLocator { get; }

    protected override void Activating()
    {
        base.Activating();
    }

    protected override void Disposing()
    {
        base.Disposing();
    }
}