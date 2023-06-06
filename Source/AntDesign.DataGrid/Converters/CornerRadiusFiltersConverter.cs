using Avalonia.Controls.Converters;

namespace AntDesign.Converters;

public class CornerRadiusFiltersConverter : IMultiValueConverter
{
    public Corners Filter { get; set; }

    public double Scale { get; set; } = 1.0;

    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Count < 2)
            return AvaloniaProperty.UnsetValue;

        if (values[0] is not CornerRadius cornerRadius)
            return AvaloniaProperty.UnsetValue;

        double.TryParse(values[1]?.ToString(), out var width);

        if (width > 0)
            return new CornerRadius(0.0, Filter.HasFlag(Corners.TopRight) ? (cornerRadius.TopRight * Scale) : 0.0, Filter.HasFlag(Corners.BottomRight) ? (cornerRadius.BottomRight * Scale) : 0.0, Filter.HasFlag(Corners.BottomLeft) ? (cornerRadius.BottomLeft * Scale) : 0.0);
        else
            return new CornerRadius(Filter.HasFlag(Corners.TopLeft) ? (cornerRadius.TopLeft * Scale) : 0.0, Filter.HasFlag(Corners.TopRight) ? (cornerRadius.TopRight * Scale) : 0.0, Filter.HasFlag(Corners.BottomRight) ? (cornerRadius.BottomRight * Scale) : 0.0, Filter.HasFlag(Corners.BottomLeft) ? (cornerRadius.BottomLeft * Scale) : 0.0);
    }
}
