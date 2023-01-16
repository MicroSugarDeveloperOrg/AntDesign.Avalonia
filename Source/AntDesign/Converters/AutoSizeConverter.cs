using Avalonia.Data.Converters;
using System.Globalization;

namespace AntDesign.Converters;
public class AutoSizeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is null || values.Count < 2)
            return AvaloniaProperty.UnsetValue;

        double.TryParse(values[0]?.ToString(), out var value1);
        double.TryParse(values[1]?.ToString(), out var value2);

        if (double.IsNaN(value1) || double.IsNaN(value2))
            return 20d;

        return Math.Min(value1, value2);
    }
}
