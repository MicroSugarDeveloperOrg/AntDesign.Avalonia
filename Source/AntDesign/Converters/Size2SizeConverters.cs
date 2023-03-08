namespace AntDesign.Converters;
public class Size2SizeConverters : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Rect rect)
            return default;

        var width = rect.Width;
        var height = rect.Height;

        if (bool.TryParse(parameter?.ToString(), out var bRet))
        {
            if (bRet)
            {
                var max = Math.Max(width, height);
                var min = Math.Min(width, height);
                return max - min;
            }
        }

        return Math.Min(width, height);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
