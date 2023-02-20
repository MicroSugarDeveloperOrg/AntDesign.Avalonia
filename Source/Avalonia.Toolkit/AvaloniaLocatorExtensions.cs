using Avalonia.Toolkit.Extensions;
using Avalonia.Toolkit.Media;

namespace Avalonia.Toolkit;
public static class AvaloniaLocatorExtensions
{
    public static AvaloniaLocator UseToolkitFontManager([DisallowNull] this AvaloniaLocator locator)
    {
       return locator.BindToConstant<IFontManagerImpl, ToolkitFontManagerImpl>();
    }
}
