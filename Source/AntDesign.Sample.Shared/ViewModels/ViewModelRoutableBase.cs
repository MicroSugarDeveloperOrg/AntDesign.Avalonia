namespace AntDesign.Sample.ViewModels;
public abstract class ViewModelRoutableBase : ViewModelBase, IRoutableViewModel
{
    public ViewModelRoutableBase(IAvaloniaDependencyResolver serviceProvider)
    {
        _serviceProvider = serviceProvider;
        HostScreen = serviceProvider.GetRequiredService<IScreen>();
    }

    protected readonly IAvaloniaDependencyResolver _serviceProvider;

    public string? UrlPathSegment { get; protected set; }

    public IScreen HostScreen { get; protected set; }
}
