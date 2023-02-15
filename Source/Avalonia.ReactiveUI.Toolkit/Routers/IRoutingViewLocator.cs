namespace Avalonia.ReactiveUI.Toolkit.Routers;
public interface IRoutingViewLocator : IViewLocator
{
    RoutingState Make(IScreen screen);
}
