using AntDesign.Controls.Helpers;
using Avalonia.Controls;
using Avalonia.Controls.Diagnostics;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Threading;

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
        //ItemsSource
        //ToolTip.SetTip(this, "123123");
    }

    bool _isColor = false;
    bool _isPanelClosing = false;
    bool _isMenuOpen = false;
    protected Control? _header;
    protected AntDesignTreeView? _antDesignTreeView; 
    protected Popup? _popup;
   

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsColorProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsColor), b => b.IsColor);

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsPanelClosingProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsPanelClosing), b => b.IsPanelClosing);

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsMenuOpenProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsMenuOpen), b => b.IsMenuOpen);


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
        _antDesignTreeView = this.GetLogicalAncestors().OfType<AntDesignTreeView>().FirstOrDefault();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        if (_header is not null)
        {
            _header.PointerPressed -= Header_PointerPressed;
            _header.PointerMoved -= Header_PointerMoved;
            _header.PointerExited -= Header_PointerExited;
            _header.PointerEntered -= Header_PointerEntered;
            _header = null;
        }

        _header = e.NameScope.Find<Control>("PART_Header");
        if (_header is not null)
        {
            _header.PointerPressed += Header_PointerPressed;
            _header.PointerMoved += Header_PointerMoved;
            _header.PointerExited += Header_PointerExited;
            _header.PointerEntered += Header_PointerEntered;
        }

        if (_popup is not null)
        {
            _popup.PointerEntered -= Popup_PointerEntered;
            _popup.PointerExited -= Popup_PointerExited;
            _popup = null;
        }

        _popup = e.NameScope.Find<Popup>("PART_Popup");
        if (_popup is not null)
        {
            _popup.Placement = PlacementMode.RightEdgeAlignedTop;
            _popup.PointerEntered += Popup_PointerEntered;
            _popup.PointerExited += Popup_PointerExited;
        }

        UpdatePseudoClasses();
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);

        if (_header is not null)
        {
            _header.PointerPressed -= Header_PointerPressed;
            _header.PointerMoved -= Header_PointerMoved;
            _header.PointerExited -= Header_PointerExited;
            _header.PointerEntered -= Header_PointerEntered;
        }

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

    private void Header_PointerMoved(object sender, PointerEventArgs e)
    {

    }

    private void Header_PointerEntered(object sender, PointerEventArgs e)
    {
        if (_antDesignTreeView is not null)
        {
            if (_antDesignTreeView.IsPanelExpanded)
                return;
        }
        //PopupShowCore(true);
    }

    void Popup_PointerEntered(object sender, PointerEventArgs e)
    {

    }

    void Popup_PointerExited(object sender, PointerEventArgs e)
    {
        PopupShowCore(false);
    }

    private void Header_PointerExited(object sender, PointerEventArgs e)
    {
        //if (_menu is not null)
            //_menu.Close();
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
