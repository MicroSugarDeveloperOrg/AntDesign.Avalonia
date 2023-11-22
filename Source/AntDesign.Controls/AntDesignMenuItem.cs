using AntDesign.Controls.Helpers;
using Avalonia.Controls;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Coloring)]
public class AntDesignMenuItem : HeaderedSelectingItemsControl
{
    static AntDesignMenuItem()
    {
        IsSelectedProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {

        });

        IsSubMenuOpenProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {

        });
    }

    public AntDesignMenuItem()
    {

    }

    bool _isColor = false;

    public static readonly DirectProperty<AntDesignMenuItem, bool> IsColorProperty =
           AvaloniaProperty.RegisterDirect<AntDesignMenuItem, bool>(nameof(IsColor), b => b.IsColor);

    public static readonly StyledProperty<bool> IsSubMenuOpenProperty =
           AvaloniaProperty.Register<AntDesignMenuItem, bool>(nameof(IsSubMenuOpen));

    public bool IsColor
    {
        get => _isColor;
        internal set => SetAndRaise(IsColorProperty, ref _isColor, value);
    }

    public bool IsSubMenuOpen
    {
        get { return GetValue(IsSubMenuOpenProperty); }
        set { SetValue(IsSubMenuOpenProperty, value); }
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    { 
        return new AntDesignMenuItem();
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        //base.OnPointerMoved(e);
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);
        if (Items.Count > 0)
            Open();
    }

    protected virtual void OnSubmenuOpened(RoutedEventArgs e)
    {
        var menuItem = e.Source as MenuItem;

        //if (menuItem != null && menuItem.Parent == this)
        //{
        //    foreach (var child in Items)
        //    {
        //        if (child != menuItem && child.IsSubMenuOpen)
        //        {
        //            child.IsSubMenuOpen = false;
        //        }
        //    }
        //}
    }

    public void Open() => SetCurrentValue(IsSubMenuOpenProperty, true);

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Coloring, IsColor);
    }

}
