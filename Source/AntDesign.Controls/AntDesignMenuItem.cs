using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Coloring)]
public class AntDesignMenuItem : TreeViewItem
{
    static AntDesignMenuItem()
    {
        IsColorProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {
            s.UpdatePseudoClasses();
        });

        IsMenuOpenProperty.Changed.AddClassHandler<AntDesignMenuItem, bool>((s, e) =>
        {
            s.PopupShowCore(e.NewValue.Value);
        });
    }

    public AntDesignMenuItem()
    {
    }

    bool _isColor = false;
    bool _isPanelClosing = false;
    bool _isMenuOpen = false;
    protected Control? _header;
    protected AntDesignMenu? _antDesignTreeView;
    protected Popup? _popup;

    protected Menu? _menu;


    public static readonly DirectProperty<AntDesignMenuItem, bool> IsColorProperty =
           AvaloniaProperty.RegisterDirect<AntDesignMenuItem, bool>(nameof(IsColor), b => b.IsColor);

    public static readonly DirectProperty<AntDesignMenuItem, bool> IsPanelClosingProperty =
           AvaloniaProperty.RegisterDirect<AntDesignMenuItem, bool>(nameof(IsPanelClosing), b => b.IsPanelClosing);

    public static readonly DirectProperty<AntDesignMenuItem, bool> IsMenuOpenProperty =
           AvaloniaProperty.RegisterDirect<AntDesignMenuItem, bool>(nameof(IsMenuOpen), b => b.IsMenuOpen);


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
        _antDesignTreeView = this.GetLogicalAncestors().OfType<AntDesignMenu>().FirstOrDefault();
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
        if (_popup is not null)
            _popup.Placement = PlacementMode.RightEdgeAlignedTop;

        UpdatePseudoClasses();
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);

        if (_header is not null)
            _header.PointerPressed -= Header_PointerPressed;

        IsMenuOpen = false;
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

    public void Clear()
    {
        IsColor = false;
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

        if (_antDesignTreeView?.IsPanelExpanded == true)
            return;

        _popup.IsOpen = isOpen;
    }
}
