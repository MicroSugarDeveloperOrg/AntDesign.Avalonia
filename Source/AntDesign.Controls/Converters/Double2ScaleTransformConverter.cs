using Avalonia.Data.Converters;
using System.Globalization;

namespace AntDesign.Controls.Converters;
public class Double2ScaleTransformConverter : IValueConverter
{
    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (double.TryParse(value?.ToString(), out var scale))
        {
            if (scale > 1)
                scale = 1;
            else if (scale < 0)
                scale = 0;

            int.TryParse(parameter?.ToString(), out var index);

            if (index == -1)
                return new ScaleTransform(scale, 1.0);
            else if (index == 1)
                return new ScaleTransform(1.0, scale);

            return new ScaleTransform(scale, scale);
        }

        return default;
    }

    object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
