﻿namespace Avalonia.Toolkit.Extensions;

public static class AvaloniaLocatorExtensions
{
    public static AvaloniaLocator BindToSingleton<T, TImpl>([DisallowNull] this AvaloniaLocator locator) where TImpl : class , T, new() 
    {
        return locator.Bind<T>().ToSingleton<TImpl>();
    }

    public static AvaloniaLocator BindToTransient<T, TImpl>([DisallowNull] this AvaloniaLocator locator) where TImpl : class, T, new()
    {
        return locator.Bind<T>().ToSingleton<TImpl>();
    }

    public static AvaloniaLocator BindToConstant<T, TImpl>([DisallowNull] this AvaloniaLocator locator) where TImpl : T, new()
    {
        return locator.Bind<T>().ToConstant<TImpl>(new TImpl());
    }
}