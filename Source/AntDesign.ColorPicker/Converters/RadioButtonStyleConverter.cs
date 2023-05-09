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
}
