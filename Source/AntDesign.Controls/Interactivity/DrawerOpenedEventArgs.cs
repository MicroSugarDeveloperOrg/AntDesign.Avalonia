namespace AntDesign.Controls.Interactivity;
public class DrawerOpenedEventArgs : RoutedEventArgs
{
    public DrawerOpenedEventArgs(bool isOpened)
       : base(AntDesignDrawer.DrawerOpenedEvent)
    {
        IsOpened = isOpened;
    }

    public bool IsOpened { get; }

}
