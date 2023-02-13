using AntDesign.Sample.ViewModels;
using AntDesign.Sample.Views;

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
        if (viewModel is null)
            return default;
        
        IViewFor? view = default;
        switch (typeof(T).Name)
        {
            case nameof(OverviewViewModel):
                view= _serviceProvider.GetService<OverviewView>();
                break;
            default:
                break;
        }

        if (view is not null)
            view.ViewModel = viewModel;

        return view;
    }
}
