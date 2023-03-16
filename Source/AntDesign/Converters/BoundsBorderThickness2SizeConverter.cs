using AntDesign.Enums;
using Avalonia.Layout;
using System.Runtime.CompilerServices;

namespace AntDesign.Converters;
public class BoundsBorderThickness2SizeConverter : IMultiValueConverter
{
    public BorderEdges Edges { get; set; }
    public Orientation Orientation { get; set; }
    public bool Minus { get; set; }

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

        switch (Orientation)
        {
            case Orientation.Horizontal:
                if (Minus)
                    return rect.Width - (Edges.HasFlag(BorderEdges.Left) ? thickness.Left : 0) - (Edges.HasFlag(BorderEdges.Right) ? thickness.Right : 0);
                else
                    return rect.Width + (Edges.HasFlag(BorderEdges.Left) ? thickness.Left : 0) + (Edges.HasFlag(BorderEdges.Right) ? thickness.Right : 0);
            case Orientation.Vertical:
                if (Minus)
                    return rect.Height - (Edges.HasFlag(BorderEdges.Top) ? thickness.Top : 0) - (Edges.HasFlag(BorderEdges.Bottom) ? thickness.Bottom : 0);
                else
                    return rect.Height + (Edges.HasFlag(BorderEdges.Top) ? thickness.Top : 0) + (Edges.HasFlag(BorderEdges.Bottom) ? thickness.Bottom : 0);
            default:
                break;
        }

        return default;
    }
}
