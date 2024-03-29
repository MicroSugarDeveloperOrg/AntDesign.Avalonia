using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;
using Avalonia.ReactiveUI.Toolkit.Routers;

namespace AntDesign.Sample.Routers;

public interface IMainRoutingViewLocator : IRoutingViewLocator
{
    //bool AddHandler<>
    ObservableCollection<Router> Routers();
    bool AddRouter<TView, TViewModel>(string? token = default, Func<string>? routerNameCallBack = default)
        where TView : IViewFor
        where TViewModel : ViewModelRoutableBase;

    bool AddGroupRouter(Func<string>? routerNameCallBack);

    bool Navigate(string token);
    bool NavigateWithView<TView>() where TView : IViewFor;
    bool NavigateWithViewModel<TViewModel>() where TViewModel : ViewModelRoutableBase;

    bool GoBack();
}