using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;
using System.Collections.Generic;

namespace AntDesign.Sample.Routers;

public class MainRoutingViewLocator : IMainRoutingViewLocator
{
    public MainRoutingViewLocator(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
        _router = new();
        _mapViewModelViews = new();
        _mapRoutingTokenCallBack = new();
        _mapRoutingViewViewModels = new();
    }

    readonly IServiceCollection _serviceCollection;
    readonly RoutingState _router;

    IServiceProvider? _serviceProvider;
    protected IServiceProvider ServiceProvider => _serviceProvider ??= _serviceCollection.BuildServiceProvider();

    bool _isMake = false;
    IScreen _screen = default!;

    readonly Dictionary<Type, Type> _mapViewModelViews;
    readonly Dictionary<string, (Type view, Type viewModel)> _mapRoutingViewViewModels;
    readonly Dictionary<string, Func<string>?> _mapRoutingTokenCallBack;

    public RoutingState Make(IScreen screen)
    {
        _isMake = true;
        _screen = screen;
        return _router;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Trimming", "IL2087:Target parameter argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to target method. The generic parameter of the source method or type does not have matching annotations.", Justification = "<Pending>")]
    public bool AddRouter<TView, TViewModel>(string? token = default, Func<string>? routerNameCallBack = default)
        where TView : IViewFor
        where TViewModel : ViewModelRoutableBase
    {
        var viewType = typeof(TView);
        var viewModelType = typeof(TViewModel);

        if (string.IsNullOrWhiteSpace(token))
            token = viewModelType.Name;

        _serviceCollection.AddSingleton(viewType);
        _serviceCollection.AddSingleton(viewModelType);

        _mapViewModelViews.TryAdd(viewModelType, viewType);
        _mapRoutingTokenCallBack.TryAdd(token, routerNameCallBack);
        _mapRoutingViewViewModels.TryAdd(token, (viewType, viewModelType));

        return true;
    }

    public bool AddGroupRouter(Func<string>? routerNameCallBack)
    {
        if (routerNameCallBack is null)
            return false;

        var token = Guid.NewGuid().ToString();
        _mapRoutingViewViewModels.TryAdd(token, (typeof(Guid), default!));
        _mapRoutingTokenCallBack.TryAdd(token, routerNameCallBack);

        return true;
    }

    public bool Navigate(string token)
    {
        if (!_isMake)
            return false;

        if (!_mapRoutingViewViewModels.TryGetValue(token, out var view_viewModel))
            return false;

        if (view_viewModel.viewModel is null)
            return false;

        var serviceProvider = ServiceProvider;
        var viewModel = serviceProvider.GetRequiredService(view_viewModel.viewModel);
        if (viewModel is not ViewModelRoutableBase routableViewModel)
            return false;

        routableViewModel.HostScreen = _screen;
        _router.Navigate.Execute(routableViewModel);
        return true;
    }

    public bool NavigateWithView<TView>() where TView : IViewFor
    {
        if (!_isMake)
            return false;

        var viewModelType = _mapViewModelViews.FirstOrDefault(pair => pair.Value == typeof(TView));
        if (viewModelType.Key is null)
            return false;

        var serviceProvider = ServiceProvider;
        var viewModel = serviceProvider.GetRequiredService(viewModelType.Key);
        if (viewModel is not ViewModelRoutableBase routableViewModel)
            return false;

        routableViewModel.HostScreen = _screen;
        _router.Navigate.Execute(routableViewModel);
        return true;
    }

    public bool NavigateWithViewModel<TViewModel>() where TViewModel : ViewModelRoutableBase
    {
        if (!_isMake)
            return false;

        var serviceProvider = ServiceProvider;
        var viewModel = serviceProvider.GetRequiredService<TViewModel>();

        viewModel.HostScreen = _screen;
        _router.Navigate.Execute(viewModel);
        return true;
    }

    public bool GoBack()
    {
        _router.NavigateBack.Execute();
        return true;
    }

    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        if (viewModel is null)
            return default;

        var serviceProvider = ServiceProvider;
        var viewModelType = viewModel.GetType();
        _mapViewModelViews.TryGetValue(viewModelType, out var viewType);
        if (viewType is null)
            return default;

        var viewIn = serviceProvider.GetService(viewType);
        if (viewIn is not IViewFor view)
            return default;

        view.ViewModel = viewModel;
        return view;
    }

    public ObservableCollection<Router> Routers()
    {
        var collection = new ObservableCollection<Router>();
        foreach (var viewModel in _mapRoutingViewViewModels)
        {
            var pair = _mapRoutingTokenCallBack.FirstOrDefault(pair => pair.Key == viewModel.Key);
            var func = pair.Value;
            var router = new Router(viewModel.Key, func)
            {
                ViewType = viewModel.Value.view,
                ViewModelType = viewModel.Value.viewModel,
            };

            if (viewModel.Value.view == typeof(Guid))
                router.IsPlaceholder = true;

            collection.Add(router);
        }

        return collection;
    }
}
