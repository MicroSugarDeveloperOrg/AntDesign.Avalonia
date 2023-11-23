using AntDesign.Controls.Helpers;
using AntDesign.Controls.Interfaces;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Coloring, AntDesignPseudoNameHelpers.PC_Opened, AntDesignPseudoNameHelpers.PC_Selected)]
public class AntDesignMenuItem : HeaderedItemsControl, IColorable, ISubItem, ISelectable, ISubSelectable
{
    static AntDesignMenuItem()
    {
        IsSelectedProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {
            s.SelectedChanged(e.NewValue.Value);
            s.UpdateSelectedPsudoClasses();
        });

        IsColoringProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {
            s.UpdateColoringPseudoClasses();
        });

        SelectedItemProperty.Changed.AddClassHandler<AntDesignMenuItem, object?>((s, e) => 
        {

        });

        IsSubMenuOpenProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {
            s.SubMenuOpenChanged(e);
        });

        SubmenuOpenedEvent.AddClassHandler<AntDesignMenuItem>((s, e) =>
        {
            s.OnSubmenuOpened(e);
        });
    }

    public AntDesignMenuItem()
    {
         
    }

    protected AntDesignMenu? _antDesignMenu;

    bool _isColoring = false;

    internal object? _linked;

    public static readonly DirectProperty<AntDesignMenuItem, bool> IsColoringProperty =
           AvaloniaProperty.RegisterDirect<AntDesignMenuItem, bool>(nameof(IsColoring), b => b.IsColoring);

    public static readonly StyledProperty<bool> IsSubMenuOpenProperty =
           AvaloniaProperty.Register<AntDesignMenuItem, bool>(nameof(IsSubMenuOpen));

    public static readonly StyledProperty<bool> IsSelectedProperty =
           AvaloniaProperty.Register<AntDesignMenuItem, bool>(nameof(IsSelected));

    public static readonly StyledProperty<object?> SelectedItemProperty =
           AvaloniaProperty.Register<AntDesignMenuItem, object?>(nameof(SelectedItem));

    public static readonly StyledProperty<int> SelectedIndexProperty =
           AvaloniaProperty.Register<AntDesignMenuItem, int>(nameof(SelectedIndex));


    public static readonly RoutedEvent<RoutedEventArgs> SubmenuOpenedEvent =
           RoutedEvent.Register<AntDesignMenuItem, RoutedEventArgs>(nameof(SubmenuOpened), RoutingStrategies.Bubble);


    bool IColorable.IsColoring
    {
        get => IsColoring;
        set => IsColoring = value;  
    }

    public bool IsColoring
    {
        get => _isColoring;
        internal set => SetAndRaise(IsColoringProperty, ref _isColoring, value);
    }

    public bool IsSubMenuOpen
    {
        get => GetValue(IsSubMenuOpenProperty);
        set => SetValue(IsSubMenuOpenProperty, value);
    }

    IEnumerable? ISubItem.SubItems => Items;

    bool ISubItem.IsSubOpened
    {
        get => IsSubMenuOpen;
        set => IsSubMenuOpen = value;
    }

    public bool IsSelected
    {
        get => GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public object? SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public int SelectedIndex
    {
        get => GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    bool ISelectable.IsSelected
    {
        get => IsSelected;
        set => IsSelected = value;
    }
    object? ISubSelectable.SelectedSubItem
    {
        get => SelectedItem;
        set => SelectedItem = value;
    }
 
    public event EventHandler<RoutedEventArgs>? SubmenuOpened
    {
        add => AddHandler(SubmenuOpenedEvent, value);
        remove => RemoveHandler(SubmenuOpenedEvent, value);
    }

    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnAttachedToLogicalTree(e);
        _antDesignMenu = this.GetLogicalAncestors().OfType<AntDesignMenu>().FirstOrDefault();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        UpdateColoringPseudoClasses();
        UpdateOpendPseudoClasses();
        UpdateSelectedPsudoClasses();
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignMenuItem();
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        //e.Handled = true;
        if (Items.Count > 0)
            return;

        IsSelected = true; 
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);
        if (Items.Count > 0)
            IsSubMenuOpen = true;

        CloseSubMenuOpen();
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);
    }

    protected virtual void OnSubmenuOpened(RoutedEventArgs e)
    {
        var menuItem = e.Source as AntDesignMenuItem;
        if (menuItem is null)
            return;

        var parentMenuItem = menuItem.Parent as ISubItem;
        if (parentMenuItem is null || parentMenuItem.SubItems is null)
            return;

        foreach (var item in parentMenuItem.SubItems)
        {
            if (item is not ISubItem childMenuItem)
                continue;

            if (childMenuItem != menuItem && childMenuItem.IsSubOpened)
                childMenuItem.IsSubOpened = false;
        }
    }

    void CloseSubMenuOpen()
    {
        var parentMenuItem = Parent as ISubItem;
        if (parentMenuItem is null || parentMenuItem.SubItems is null)
            return;

        foreach (var item in parentMenuItem.SubItems)
        {
            if (item is not ISubItem childMenuItem)
                continue;

            if (childMenuItem != this && childMenuItem.IsSubOpened)
                childMenuItem.IsSubOpened = false;
        }
    }

    private void SubMenuOpenChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (!bool.TryParse(e.NewValue?.ToString(), out var bRet))
            return;

        if (bRet)
        {
            RaiseEvent(new RoutedEventArgs(SubmenuOpenedEvent));
            //SetCurrentValue(SelectingItemsControl.IsSelectedProperty, value: true);
        }
        else
        {
            CloseSubmenus();
            //SelectedIndex = -1;
        }

        UpdateOpendPseudoClasses();
    }


    public void Open() => SetCurrentValue(IsSubMenuOpenProperty, true);

    private void CloseSubmenus()
    {
        foreach (var item in Items)
        {
            if (item is not AntDesignMenuItem antDesignMenuItem)
                continue;

            antDesignMenuItem.IsSubMenuOpen = false;
        }
    }

    void SelectedChanged(bool isSelected)
    {
        if (_antDesignMenu is not null && isSelected)
            _antDesignMenu.SelectedItem = this;
    }

    void UpdateColoringPseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Coloring, IsColoring);
    }

    void UpdateOpendPseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Opened, IsSubMenuOpen);
    }

    void UpdateSelectedPsudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Selected, IsSelected);
    }


}
