using AntDesign.Controls.Metadata;

namespace AntDesign.Controls.Interactivity;
public class PanelLayoutModeEventArgs : RoutedEventArgs
{
    public PanelLayoutModeEventArgs(PanelLayoutMode layoutMode)
        : base(AntDesignPanel.LayoutModeChangedEvent)
    {
        LayoutMode = layoutMode;
    }

    public PanelLayoutMode LayoutMode { get; }
}
