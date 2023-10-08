using AntDesign.Controls.Metadata;
using Avalonia.Interactivity;

namespace AntDesign.Controls.Interactivity;
public class LayoutModeEventArgs : RoutedEventArgs
{
    public LayoutModeEventArgs(LayoutMode layoutMode)
        : base(AntDesignLayout.LayoutModeChangedEvent)
    {
        LayoutMode = layoutMode;
    }

    public LayoutMode LayoutMode { get; }
}
