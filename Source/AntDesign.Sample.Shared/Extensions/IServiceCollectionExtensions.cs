namespace AntDesign.Sample.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddViewWithViewModelSingleton<View, ViewModel>([DisallowNull] this IServiceCollection container)
        where View : class where ViewModel : class, INotifyPropertyChanged
    {
      return container.AddSingleton<View>().AddSingleton<ViewModel>();
    }

    public static IServiceCollection AddViewWithViewModelScoped<View, ViewModel>([DisallowNull] this IServiceCollection container)
        where View : class where ViewModel : class, INotifyPropertyChanged
    {
        return container.AddScoped<View>().AddScoped<ViewModel>();
    }

    public static IServiceCollection AddViewWithViewModelTransient<View, ViewModel>([DisallowNull]this IServiceCollection container)
        where View : class where ViewModel : class, INotifyPropertyChanged
    {
        return container.AddTransient<View>().AddTransient<ViewModel>();
    }
}
