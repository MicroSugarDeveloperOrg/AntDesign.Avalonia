namespace AntDesign.Converters;
public class PopupSizeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is null)
            return default;

        if (values.Count < 2)
            return default;

        if (values[1] is not Thickness thickness)
            return default;

        double.TryParse(values[0]?.ToString(), out var width);
        return width + thickness.Left + thickness.Right;
    }
}
