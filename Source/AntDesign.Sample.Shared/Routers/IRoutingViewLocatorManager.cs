using System.Globalization;

namespace AntDesign.Sample.Routers;
public interface IRoutingViewLocatorManager : INotifyPropertyChanged
{
    CultureInfo CurrentCulture { get; set; }
}
