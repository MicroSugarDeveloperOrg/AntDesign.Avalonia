namespace AntDesign.Converters;

public class AutoSizeConverter : IValueConverter
{
    public double Default { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        double newValue = Default;
        if (!double.TryParse(parameter?.ToString(), out var paraValue))
            newValue = paraValue;

        if (value is not Rect rect)
            return newValue;

        if (rect.Width == 0 && rect.Height == 0)
            return newValue;

        return Math.Min(rect.Width, rect.Height);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
