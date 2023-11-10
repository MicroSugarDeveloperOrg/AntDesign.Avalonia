using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Coloring)]
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
    }

    public AntDesignTreeViewItem()
    {

    }

    bool _isColor = false;
    bool _isPanelClosing = false;
    bool _isMenuOpen = false;
    protected Control? _header;
    protected AntDesignTreeView? _antDesignMenu;
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

    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnAttachedToLogicalTree(e);
        _antDesignMenu = this.GetLogicalAncestors().OfType<AntDesignTreeView>().FirstOrDefault();
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
        if (_antDesignMenu is not null)
        {
            if (!_antDesignMenu.IsPanelExpanded)
                return;
        }

        base.OnHeaderDoubleTapped(e);
    }

    private void Header_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (ItemCount > 0)
        {
            if (_antDesignMenu is not null)
            {
                if (!_antDesignMenu.IsPanelExpanded)
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

    void PopupShowCore(bool isOpen)
    {
        if (_popup is null)
            return;

        if (_popup.IsOpen && !isOpen)
            _popup.IsOpen = false;

        if (_antDesignMenu?.IsPanelExpanded == true)
            return;

        if (_menu is null)
        {
            _menu = new AntDesignMenu()
            {
                //Theme = 
                ItemsPanel = new FuncTemplate<Panel?>(() => new StackPanel() { Orientation = Orientation.Vertical, Spacing = 3 }),
            };

            var menuItem = new AntDesignMenuItem() { Header = "1231233" };
            menuItem.Items.Add(new AntDesignMenuItem() { Header = "234343434" });
            menuItem.Items.Add(new AntDesignMenuItem() { Header = "234343434" });
            menuItem.Items.Add(new AntDesignMenuItem() { Header = "234343434" });
            menuItem.Items.Add(new AntDesignMenuItem() { Header = "234343434" });

            _menu.Items.Add(menuItem);
            _menu.Items.Add(new AntDesignMenuItem() { Header = "1231233" });
            _menu.Items.Add(new AntDesignMenuItem() { Header = "1231233" });
            _menu.Items.Add(new AntDesignMenuItem() { Header = "1231233" });
            _menu.Items.Add(new AntDesignMenuItem() { Header = "1231233" });
            _menu.Items.Add(new AntDesignMenuItem() { Header = "1231233" });
            _menu.Items.Add(new AntDesignMenuItem() { Header = "1231233" });

            PopupContent = _menu;
        }


        _popup.IsOpen = isOpen;
    }
}
