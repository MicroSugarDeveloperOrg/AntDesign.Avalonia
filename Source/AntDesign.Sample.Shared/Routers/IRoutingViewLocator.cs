namespace AntDesign.Sample.Routers;
public interface IRoutingViewLocator : IViewLocator
{
    RoutingState Make(IScreen screen);
}
