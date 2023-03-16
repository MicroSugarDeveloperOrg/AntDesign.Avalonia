namespace AntDesign.Converters;
public class Size2RoundConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Rect rect)
            return value;
        var max = Math.Max(rect.Width, rect.Height);
        return new CornerRadius(max);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
