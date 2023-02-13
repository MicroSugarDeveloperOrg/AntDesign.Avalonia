namespace AntDesign.Sample.ViewModels;

public class MainViewModel : ViewModelBase, IScreen
{
    public MainViewModel(IViewLocator viewLocator)
    {
        ViewLocator = viewLocator;
    }
 
    public RoutingState Router { get; } = new();
    public IViewLocator ViewLocator { get; }

    
    
    protected override void Activating()
    {
        base.Activating();
    }

    protected override void Disposing()
    {
         base.Disposing();
    }
}