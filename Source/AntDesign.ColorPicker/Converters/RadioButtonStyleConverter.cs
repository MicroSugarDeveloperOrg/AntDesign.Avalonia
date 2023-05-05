using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml.XamlIl.Runtime;
using System.Globalization;

namespace AntDesign.Converters;
internal class RadioButtonStyleConverter : IValueConverter
{
    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null && parameter is not null)
            return parameter;

        return value;
    }

    object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    internal static ThemeVariant? GetDictionaryVariant(IAvaloniaXamlIlParentStackProvider service)
    {
        IEnumerable<object>? enumerable = service?.Parents;
        if (enumerable == null)
            return null;

        foreach (var item in enumerable)
        {
            var themeVariantProvider = item as IThemeVariantProvider;
            if (themeVariantProvider != null)
            {
                var key = themeVariantProvider.Key;
                if (key != null)
                    return key;
            }
        }

        return null;
    }

}
