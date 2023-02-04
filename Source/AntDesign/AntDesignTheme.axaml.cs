using AntDesign.Extensions;
using Avalonia.Markup.Xaml.Styling;

namespace AntDesign;

public class AntDesignTheme : Styles
{
    public AntDesignTheme(IServiceProvider serviceProvider)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
