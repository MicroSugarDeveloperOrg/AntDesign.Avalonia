 
namespace AntDesign.Converters;
internal class MarginMultipliersConverter : IValueConverter
{
    public double Indent { get; set; }

    public bool Left { get; set; } = false;

    public bool Top { get; set; } = false;

    public bool Right { get; set; } = false;

    public bool Bottom { get; set; } = false;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Thickness thickness = new();
        if (parameter is Thickness thick)
            thickness = thick;

        if (value is int scalarDepth)
        {
            return new Thickness(
                Left ? Indent * scalarDepth + thickness.Left : 0,
                Top ? Indent * scalarDepth + thickness.Top : 0,
                Right ? Indent * scalarDepth + thickness.Right : 0,
                Bottom ? Indent * scalarDepth + thickness.Bottom : 0);
        }
        else if (value is Thickness thicknessDepth)
        {
            return new Thickness(
                Left ? Indent * thicknessDepth.Left + thickness.Left : 0,
                Top ? Indent * thicknessDepth.Top + thickness.Top : 0,
                Right ? Indent * thicknessDepth.Right + thickness.Right : 0,
                Bottom ? Indent * thicknessDepth.Bottom + thickness.Bottom : 0);
        }
        return new Thickness(0);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new System.NotImplementedException();
    }
}
