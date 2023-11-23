using AntDesign.Controls.Interfaces;

namespace AntDesign.Controls;
public class AntDesignMenu : SelectingItemsControl, ISubItem, ISubSelectable
{
    static AntDesignMenu()
    {
        SelectedItemProperty.Changed.AddClassHandler<AntDesignMenu, object?>((s, e) =>
        {
            if (e.OldValue.Value is ISelectable selectable)
            {
                if (selectable.IsSelected)
                    selectable.IsSelected = false;
            }

            if (e.NewValue.Value is ISelectable selectable1)
            {
                if (!selectable1.IsSelected)
                    selectable1.IsSelected = true;
            }


        });
    }

    public AntDesignMenu()
    {

    }

    IEnumerable? ISubItem.SubItems => Items;

    bool ISubItem.IsSubOpened { get; set; }
    object? ISubSelectable.SelectedSubItem
    {
        get => SelectedItem;
        set => SelectedItem = value;
    }

    //bool ISubSelectable.IsSubSelected => SelectedItem is not null;
    //object? ISubSelectable.SelectedSubItem 
    //{ 
    //    get => SelectedItem; 
    //    set => SelectedItem = value; 
    //}

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignMenuItem();
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
    }
}
