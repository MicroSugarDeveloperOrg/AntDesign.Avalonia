using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Expander, AntDesignPseudoNameHelpers.PC_Coloring)]
public class AntDesignTreeViewItem : TreeViewItem
{
    static AntDesignTreeViewItem()
    {
        IsColoringProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) =>
        {
            s.UpdatePseudoClasses();
        });

        IsExpandedProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) =>
        {
            s.UpdateExpanderPseudoClasses();
        });
    }

    public AntDesignTreeViewItem()
    {

    }

    bool _isColoring = false;

    protected AntDesignTreeView? _antDesignTreeView;
    protected Control? _header;

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsColoringProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsColoring), b => b.IsColoring);

    public bool IsColoring
    {
        get => _isColoring;
        internal set => SetAndRaise(IsColoringProperty, ref _isColoring, value);
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
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

        UpdatePseudoClasses();
        UpdateExpanderPseudoClasses();
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);

        if (_header is not null)
            _header.PointerPressed -= Header_PointerPressed;
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
        base.OnHeaderDoubleTapped(e);
    }

    private void Header_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (ItemCount > 0)
            IsExpanded = !IsExpanded;
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
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Coloring, IsColoring);
    }

    void UpdateExpanderPseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Expander, IsExpanded);
    }
}


