namespace AntDesign.Sample.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddViewWithViewModelSingleton<View, ViewModel>(this IServiceCollection contaniner)
        where View : class where ViewModel : class, INotifyPropertyChanged
    {
      return  contaniner.AddSingleton<View>().AddSingleton<ViewModel>();
    }

    public static IServiceCollection AddViewWithViewModelScoped<View, ViewModel>(this IServiceCollection contaniner)
        where View : class where ViewModel : class, INotifyPropertyChanged
    {
        return contaniner.AddScoped<View>().AddScoped<ViewModel>();
    }

    public static IServiceCollection AddViewWithViewModelTransient<View, ViewModel>(this IServiceCollection contaniner)
        where View : class where ViewModel : class, INotifyPropertyChanged
    {
        return contaniner.AddTransient<View>().AddTransient<ViewModel>();
    }
}
