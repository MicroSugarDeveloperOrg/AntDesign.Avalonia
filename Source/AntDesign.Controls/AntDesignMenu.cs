
namespace AntDesign.Controls;
public class AntDesignMenu : Menu
{
    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignMenuItem();
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        //base.OnPointerMoved(e);
    }
}
