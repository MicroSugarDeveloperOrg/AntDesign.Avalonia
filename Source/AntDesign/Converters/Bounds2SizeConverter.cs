namespace AntDesign.Converters;
public class Bounds2SizeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count < 4)
            return default;

        double max = 0;
        if (values[0] is Rect offContentRect)
            max = Math.Max(max, offContentRect.Width);

        if (values[1] is Rect onContentRect)
            max = Math.Max(max, onContentRect.Width);

        double.TryParse(values[2]?.ToString(), out var size);
 
        var width = max + size;
        var doubleSize = 2 * size;
        
        return Math.Max(width, doubleSize);
    }
}
