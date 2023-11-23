using AntDesign.Controls.Helpers;
using Avalonia.Controls.Shapes;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Expander, AntDesignPseudoNameHelpers.PC_Coloring)]
public class AntDesignTreeViewItem : TreeViewItem
{
    static AntDesignTreeViewItem()
    {
        IsColorProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) =>
        {
            s.UpdatePseudoClasses();
        });

        IsMenuOpenProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) =>
        {
            s.PopupShowCore(e.NewValue.Value);
        });

        IsExpandedProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) =>
        {
            s.UpdateExpanderPseudoClasses();
        });
    }

    public AntDesignTreeViewItem()
    {
        //LayoutTransformControl.RenderTransformProperty
        //LayoutTransformControl.LayoutTransformProperty
    }

    bool _isLoaded = false;
    Rect _bounds;
    double _offset = 5;

    bool _isColor = false;
    bool _isPanelClosing = false;
    bool _isMenuOpen = false;
    protected Control? _header;
    protected AntDesignTreeView? _antDesignTreeView;
    protected Popup? _popup;
    protected AntDesignMenu? _menu;

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsColorProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsColor), b => b.IsColor);

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsPanelClosingProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsPanelClosing), b => b.IsPanelClosing);

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsMenuOpenProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsMenuOpen), b => b.IsMenuOpen);

    public static readonly StyledProperty<object?> PopupContentProperty =
           AvaloniaProperty.Register<AntDesignTreeViewItem, object?>(nameof(PopupContent));

    public static readonly StyledProperty<IDataTemplate?> PopupContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignTreeViewItem, IDataTemplate?>(nameof(PopupContentTemplate));


    [DependsOn(nameof(PopupContentTemplate))]
    public object? PopupContent
    {
        get { return GetValue(PopupContentProperty); }
        set { SetValue(PopupContentProperty, value); }
    }

    /// <summary>
    /// Gets or sets the data template used to display the content of the control.
    /// </summary>
    public IDataTemplate? PopupContentTemplate
    {
        get { return GetValue(PopupContentTemplateProperty); }
        set { SetValue(PopupContentTemplateProperty, value); }
    }


    public bool IsColor
    {
        get => _isColor;
        internal set => SetAndRaise(IsColorProperty, ref _isColor, value);
    }

    public bool IsPanelClosing
    {
        get => _isPanelClosing;
        internal set => SetAndRaise(IsColorProperty, ref _isPanelClosing, value);
    }

    public bool IsMenuOpen
    {
        get => _isMenuOpen;
        internal set => SetAndRaise(IsMenuOpenProperty, ref _isMenuOpen, value);
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (!_isLoaded)
        {
            _isLoaded = true;
            _bounds = Bounds;
        }
    }

    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnAttachedToLogicalTree(e);
        _antDesignTreeView = this.GetLogicalAncestors().OfType<AntDesignTreeView>().FirstOrDefault();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        if (_header is not null)
        {
            _header.PointerPressed -= Header_PointerPressed;
            _header = null;
        }

        _header = e.NameScope.Find<Control>("PART_Header");
        if (_header is not null)
            _header.PointerPressed += Header_PointerPressed;

        _popup = e.NameScope.Find<Popup>("PART_Popup");

        UpdatePseudoClasses();
        UpdateExpanderPseudoClasses();
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);

        if (_header is not null)
            _header.PointerPressed -= Header_PointerPressed;

        IsMenuOpen = false;
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignTreeViewItem();
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
    }

    protected override void OnHeaderDoubleTapped(TappedEventArgs e)
    {
        if (_antDesignTreeView is not null)
        {
            if (!_antDesignTreeView.IsPanelExpanded)
                return;
        }

        base.OnHeaderDoubleTapped(e);
    }

    private void Header_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (ItemCount > 0)
        {
            if (_antDesignTreeView is not null)
            {
                if (!_antDesignTreeView.IsPanelExpanded)
                    return;
            }

            IsExpanded = !IsExpanded;
        }
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
    }

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Coloring, IsColor);
    }

    void UpdateExpanderPseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Expander, IsExpanded);
    }


    void PopupShowCore(bool isOpen)
    {
        if (_popup is null)
            return;

        if (isOpen)
        {
            if (_antDesignTreeView?.IsPanelExpanded == true)
                return;
        }

        if (_menu is null)
        {
            _menu = new AntDesignMenu()
            {
                Width = _bounds.Width,
                ItemsPanel = new FuncTemplate<Panel?>(() => new StackPanel() { Orientation = Orientation.Vertical, Spacing = 3 }),
            };
            _menu.SelectionChanged += Menu_SelectionChanged;
            PopupContent = _menu;
        }

        if (_menu.Items.Count > 0)
        {
            CloseMenus(_menu.Items);
            _menu.Items.Clear();
        }

        foreach (var item in Items)
            CreateMenuItem(item, _menu.Items);

        var closeWidth = _antDesignTreeView?.WidthAfterClosing ?? 0;
        //_popup.PlacementConstraintAdjustment = PopupPositionerConstraintAdjustment.SlideX;
        if (closeWidth > 0)
            _popup.HorizontalOffset = closeWidth + _offset - _bounds.Width;

        _popup.IsOpen = isOpen;
    }

    private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    protected internal void CloseMenus(ItemCollection itemCollection)
    {
        if (itemCollection is null || itemCollection.Count <= 0)
            return;

        foreach (var item in itemCollection)
        {
            if (item is not AntDesignMenuItem menuItem)
                continue;

            CloseMenus(menuItem.Items);
            menuItem.IsSubMenuOpen = false;
        }
    }

    void CreateMenuItem(object? item, ItemCollection itemCollection)
    {
        if (item is not TreeViewItem treeViewItem)
            return;

        AntDesignMenuItem menuItem = new();
        if (treeViewItem.Header is Control control)
        {
            var menuItemFill = new Rectangle
            {
                Width = control.DesiredSize.Width,
                Height = control.DesiredSize.Height,
                Fill = new VisualBrush
                {
                    Visual = control,
                    Stretch = Stretch.None,
                    AlignmentX = AlignmentX.Left
                }
            };
            menuItem.Header = menuItemFill;
        }
        else if (treeViewItem.Header is string strValue)
        {
            menuItem.Header = strValue;
        }

        itemCollection.Add(menuItem);

        foreach (var subItem in treeViewItem.Items)
            CreateMenuItem(subItem, menuItem.Items);
    }


    void CreateContainerForItemOverride(string content)
    {




    }

}
