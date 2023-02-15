namespace Avalonia.ReactiveUI.Toolkit.Routers;

public interface IRoutingViewLocatorManager : INotifyPropertyChanged
{
    CultureInfo CurrentCulture { get; set; }
}
