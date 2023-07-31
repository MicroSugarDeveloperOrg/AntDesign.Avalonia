using Avalonia.Media;

namespace AntDesign.Sample.Converters;
public class DataGridRowAlternatingRowColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is DataGridRow row)
        {
            var index = row.GetIndex();
            if (index % 2 == 0)
                return Brushes.Yellow;

        }

        return AvaloniaProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
