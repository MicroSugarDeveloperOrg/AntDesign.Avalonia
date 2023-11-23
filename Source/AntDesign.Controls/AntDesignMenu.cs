using AntDesign.Controls.Interfaces;
using System;

namespace AntDesign.Controls;
public class AntDesignMenu : ItemsControl, ISubItem, ISubSelectable
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

            s.ColoringOrSelected();
        });
    }

    public AntDesignMenu()
    {

    }

    public static readonly StyledProperty<object?> SelectedItemProperty =
           AvaloniaProperty.Register<AntDesignMenu, object?>(nameof(SelectedItem));


    public static readonly RoutedEvent<SelectionChangedEventArgs> SelectionChangedEvent =
           RoutedEvent.Register<SelectingItemsControl, SelectionChangedEventArgs>(nameof(SelectionChanged), RoutingStrategies.Bubble);



    public object? SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    IEnumerable? ISubItem.SubItems => Items;

    bool ISubItem.IsSubOpened { get; set; }
    object? ISubSelectable.SelectedSubItem
    {
        get => SelectedItem;
        set => SelectedItem = value;
    }


    public event EventHandler<SelectionChangedEventArgs>? SelectionChanged
    {
        add => AddHandler(SelectionChangedEvent, value);
        remove => RemoveHandler(SelectionChangedEvent, value);
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignMenuItem();
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e); 
    }

    void ColoringOrSelected()
    {
        RaiseEvent(new SelectionChangedEventArgs(SelectionChangedEvent, Array.Empty<object>(), Array.Empty<object>()));

        foreach (var item in Items)
            ColoringOrSelectedItems(item);
    }

    bool ColoringOrSelectedItems(object? item)
    {
        if (item is not AntDesignMenuItem menuItem)
            return false;

        if (menuItem.ItemCount > 0)
        {
            bool isFlag = false;
            foreach (var subitem in menuItem.Items)
                isFlag |= ColoringOrSelectedItems(subitem);

            menuItem.IsColoring = isFlag;
            return isFlag;
        }
        else
            return menuItem.IsSelected;
    }
}
