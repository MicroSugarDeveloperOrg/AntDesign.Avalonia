namespace AntDesign.Controls.Interactivity;
public class PanelSizeModeChangedEventArgs : RoutedEventArgs
{
    public PanelSizeModeChangedEventArgs(bool isMobile)
      : base(AntDesignContainer.SizeModeChangedEvent)
    {
        IsMobile = isMobile;
    }

    public bool IsMobile { get; }
}
