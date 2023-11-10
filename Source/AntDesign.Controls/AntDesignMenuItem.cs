using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Coloring)]
public class AntDesignMenuItem : MenuItem
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


    public bool IsColor
    {
        get => _isColor;
        internal set => SetAndRaise(IsColorProperty, ref _isColor, value);
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

    protected override void OnSubmenuOpened(RoutedEventArgs e)
    {
        base.OnSubmenuOpened(e);
    }

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Coloring, IsColor);
    }

}
