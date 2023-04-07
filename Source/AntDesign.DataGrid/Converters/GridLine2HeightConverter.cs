namespace AntDesign.Converters;
public class GridLine2HeightConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (Enum.TryParse<DataGridGridLinesVisibility>(value?.ToString(), out var gridLine))
        {
            switch (gridLine)
            {
                case DataGridGridLinesVisibility.Vertical:
                case DataGridGridLinesVisibility.All:
                    return double.NaN;
                case DataGridGridLinesVisibility.None:
                case DataGridGridLinesVisibility.Horizontal: 
                default:
                    return 20d;
            }
        }

        return double.NaN;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
