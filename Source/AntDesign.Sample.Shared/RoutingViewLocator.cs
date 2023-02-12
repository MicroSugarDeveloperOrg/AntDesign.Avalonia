namespace AntDesign.Sample;
public class RoutingViewLocator : IViewLocator
{
    public RoutingViewLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    readonly IServiceProvider _serviceProvider;


    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        throw new NotImplementedException();
    }
}
