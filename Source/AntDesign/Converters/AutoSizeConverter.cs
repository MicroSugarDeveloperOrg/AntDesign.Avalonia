namespace AntDesign.Converters;

public class AutoSizeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Rect rect)
            return 23d;

        if (rect.Width == 0 && rect.Height == 0)
            return 23d;

        return Math.Min(rect.Width, rect.Height);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
