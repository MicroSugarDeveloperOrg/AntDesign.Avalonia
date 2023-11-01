using AntDesign.Controls.Metadata;

namespace AntDesign.Controls.Interactivity;
public class PanelLayoutModeEventArgs : RoutedEventArgs
{
    public PanelLayoutModeEventArgs(PanelLayoutMode layoutMode)
        : base(AntDesignContainer.LayoutModeChangedEvent)
    {
        LayoutMode = layoutMode;
    }

    public PanelLayoutMode LayoutMode { get; }
}
