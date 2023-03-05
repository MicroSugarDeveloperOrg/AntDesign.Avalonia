namespace AntDesign.Converters;

public class Double2MarginConverters : IValueConverter
{
    public Direction Direction { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Rect rect)
            return new Thickness(0);

        double.TryParse(parameter?.ToString(), out var offset);
        if (double.IsNaN(offset))
            return new Thickness(0);

        var min = Math.Min(rect.Width, rect.Height);

        switch (Direction)
        {
            case Direction.Left:
                return new Thickness(min + offset, 0, offset, 0 ); 
            case Direction.Right:
                return new Thickness(offset, 0, min + offset, 0 );
            case Direction.Top:
                return new Thickness(0, min + offset, 0, offset);
            case Direction.Bottom:
                return new Thickness(0, offset, 0, min + offset);
            default:
                break;
        }

        return new Thickness(0);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
