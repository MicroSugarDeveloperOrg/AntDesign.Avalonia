using Avalonia.Data.Converters;
using System.Globalization;

namespace AntDesign.Controls.Converters;
public class BooleansAndConverter : IMultiValueConverter
{
    object? IMultiValueConverter.Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values is null)
            return default;

        if (values.Count < 2)
            return default;

        bool.TryParse(values[0]?.ToString(), out var bRet1);
        bool.TryParse(values[1]?.ToString(), out var bRet2);
        if (!bRet1)
            return false;

        return bRet1 & bRet2;
    }
}
