using AntDesign.Controls.Metadata;

namespace AntDesign.Controls.Interactivity;
public class LayoutModeEventArgs : RoutedEventArgs
{
    public LayoutModeEventArgs(LayoutMode layoutMode)
        : base(AntDesignPanel.LayoutModeChangedEvent)
    {
        LayoutMode = layoutMode;
    }

    public LayoutMode LayoutMode { get; }
}
