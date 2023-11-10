
namespace AntDesign.Controls;
public class AntDesignMenuItem : MenuItem
{
    static AntDesignMenuItem()
    {
        IsSelectedProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {

        });
    }


    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    { 
        return new AntDesignMenuItem();
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
    }
}
