
namespace AntDesign.Controls;
public class AntDesignMenu : SelectingItemsControl
{
    static AntDesignMenu()
    {
        SelectedItemProperty.Changed.AddClassHandler<AntDesignMenu, object?>((s, e) =>
        {

        });
    }

    public AntDesignMenu()
    {
      
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignMenuItem();
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        //base.OnPointerMoved(e);
    }
}
