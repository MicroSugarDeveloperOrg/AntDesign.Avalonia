namespace AntDesign.Converters;

public class BorderOffsetMarginConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Thickness margin)
            return value;

        int.TryParse(parameter?.ToString(), out int offset);
        var step = -(margin.Bottom + offset);
        return new Thickness(0, 0, 0, step);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
