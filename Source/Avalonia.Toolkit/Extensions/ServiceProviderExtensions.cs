namespace Avalonia.Toolkit.Extensions;

internal static class ServiceProviderExtensions
{
    public static T? GetService<T>([DisallowNull] this IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        var tObject = serviceProvider.GetService(typeof(T));

        if (tObject is T tValue)
            return tValue;

        return default;
    }

    public static T GetRequiredService<T>([DisallowNull] this IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        var tObject = serviceProvider.GetService(typeof(T));
        ArgumentNullException.ThrowIfNull(tObject);

        return (T)tObject;
    }

}
