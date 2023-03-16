namespace AntDesign.Converters;
public class PopupSizeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is null)
            return default;

        if (values.Count < 2)
            return default;

        if (values[0] is not Rect rect)
            return default;

        if (values[1] is not Thickness thickness)
            return default;
    
        return rect.Width + thickness.Left + thickness.Right;
    }
}
