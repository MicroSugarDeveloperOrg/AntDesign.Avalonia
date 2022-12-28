namespace AntDesign.Extensions;

public static class ServiceProviderExtensions
{
    public static T? GetService<T>(this IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        var tObject = serviceProvider.GetService(typeof(T));

        if (tObject is T tValue)
            return tValue;

        return default;
    }

    public static T GetRequiredService<T>(this IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        var tObject = serviceProvider.GetService(typeof(T));
        ArgumentNullException.ThrowIfNull(tObject);

        return (T)tObject;
    }

}
