using AntDesign.Controls.Helpers;
using Avalonia.VisualTree;

namespace AntDesign.Controls;


[PseudoClasses(AntDesignPseudoNameHelpers.PC_Expander)]
public class AntDesignTreeView : TreeView
{
    static AntDesignTreeView()
    {
        IsPanelExpandedProperty.Changed.AddClassHandler<AntDesignTreeView, bool>((s, e) =>
        {
            s.ExpanderOrClose(e.NewValue.Value);
            s.UpdatePseudoClasses();
        });

        SelectedItemProperty.Changed.AddClassHandler<AntDesignTreeView, object?>((s, e) =>
        {
            s.ExpandingOrColoring();
        });

        WidthBeforeClosingProperty.Changed.AddClassHandler<AntDesignTreeView, double>((s, e) =>
        {
            s.UpdateScaleX();
        });

        WidthAfterClosingProperty.Changed.AddClassHandler<AntDesignTreeView, double>((s, e) =>
        {
            s.UpdateScaleX();
        });
    }

    public AntDesignTreeView()
    {
        ScrollViewer.SetVerticalScrollBarVisibility(this, ScrollBarVisibility.Hidden);
        ScrollViewer.SetHorizontalScrollBarVisibility(this, ScrollBarVisibility.Hidden);
    }

    AntDesignTreeViewItem? _lastMenuOpenItem;
    TopLevel? _topLevel;

    double _scaleX = 0d;

    public static readonly DirectProperty<AntDesignTreeView, double> ScaleXProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeView, double>(nameof(ScaleX), b => b.ScaleX);

    public static readonly StyledProperty<bool> IsMenuModeProperty =
           AvaloniaProperty.Register<AntDesignTreeView, bool>(nameof(IsMenuMode), defaultValue: false);

    public static readonly StyledProperty<bool> IsPanelExpandedProperty =
           AvaloniaProperty.Register<AntDesignTreeView, bool>(nameof(IsPanelExpanded), defaultValue: true);

    public static readonly StyledProperty<double> WidthBeforeClosingProperty =
           AvaloniaProperty.Register<AntDesignTreeView, double>(nameof(WidthBeforeClosing), defaultValue: double.NaN);

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignTreeView, double>(nameof(WidthAfterClosing), defaultValue: double.NaN);

    public double ScaleX
    {
        get => _scaleX;
        internal set => SetAndRaise(ScaleXProperty, ref _scaleX, value);
    }

    public bool IsMenuMode
    {
        get => GetValue(IsMenuModeProperty);
        set => SetValue(IsMenuModeProperty, value);
    }

    public bool IsPanelExpanded
    {
        get => GetValue(IsPanelExpandedProperty);
        set
        {
            //foreach (var item in Items)
            //    ExpanderOrCloseItems(item, value);

            //if (value)
            //    HideMenuItemCore();

            SetValue(IsPanelExpandedProperty, value);
        }
    }

    public double WidthBeforeClosing
    {
        get => GetValue(WidthBeforeClosingProperty);
        set => SetValue(WidthBeforeClosingProperty, value);
    }

    public double WidthAfterClosing
    {
        get => GetValue(WidthAfterClosingProperty);
        set => SetValue(WidthAfterClosingProperty, value);
    }

    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnAttachedToLogicalTree(e);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        OnSelectedFirstValidItem(Items.FirstOrDefault());
        UpdatePseudoClasses();
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignTreeViewItem();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        Width = double.NaN; 
        _topLevel = TopLevel.GetTopLevel(this);
        if (_topLevel is not null)
        {
            _topLevel.PointerPressed += TopLevel_PointerPressed;
            _topLevel.PointerExited += TopLevel_PointerExited;
        }
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        if (_topLevel is not null)
        {
            _topLevel.PointerPressed -= TopLevel_PointerPressed;
            _topLevel.PointerExited -= TopLevel_PointerExited;
            _topLevel = default;
        }

        base.OnUnloaded(e);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        //if (change.Property == IsPanelExpandedProperty)
        //{
        //    if (!bool.TryParse(change.NewValue?.ToString(), out var bRet))
        //        return;

        //    foreach (var item in Items)
        //        ExpanderOrCloseItems(item, bRet);

        //    if (bRet)
        //        HideMenuItemCore();
        //}
    }

    void ExpanderOrCloseItems(object? item, bool isExpanded)
    {
        if (item is not TreeViewItem treeViewItem)
            return;

        if (isExpanded)
        {
            if (treeViewItem.IsSelected)
            {
                if (treeViewItem.Parent is TreeViewItem parentTreeViewItem)
                    parentTreeViewItem.IsExpanded = true;
            }
        }
        else
            treeViewItem.IsExpanded = false;

        if (treeViewItem.ItemCount <= 0)
            return;

        foreach (var subItem in treeViewItem.Items)
            ExpanderOrCloseItems(subItem, isExpanded);
    }

    void ExpandingOrColoring()
    {
        foreach (var item in Items)
            ExpandingOrColoringParents(item);
    }

    bool ExpandingOrColoringParents(object? item)
    {
        if (item is not AntDesignTreeViewItem antDesignTreeViewItem)
            return false;

        if (antDesignTreeViewItem.ItemCount > 0)
        {
            bool isFlag = false;
            foreach (var subitem in antDesignTreeViewItem.Items)
                isFlag |= ExpandingOrColoringParents(subitem);

            antDesignTreeViewItem.IsColor = isFlag;
            antDesignTreeViewItem.IsExpanded = IsPanelExpanded ? isFlag : false;
            return isFlag;
        }
        else
            return antDesignTreeViewItem.IsSelected;
    }

    void OnSelectedFirstValidItem(object? item)
    {
        if (item is not AntDesignTreeViewItem antDesignTreeViewItem)
            return;

        if (antDesignTreeViewItem.ItemCount <= 0)
            antDesignTreeViewItem.IsSelected = true;
        else
            OnSelectedFirstValidItem(antDesignTreeViewItem.Items.FirstOrDefault());
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        if (e.Source is null)
            return;

        var container = GetContainerFromEventSource(e.Source);
        if (container is null)
            return;

        if (container.ItemCount > 0)
            return;

        base.OnPointerPressed(e);
    }

    protected override void OnPointerEntered(PointerEventArgs e)
    {
        base.OnPointerEntered(e);
    }

    protected override void OnPointerExited(PointerEventArgs e)
    {
        base.OnPointerExited(e);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);

        if (IsPanelExpanded)
            return;

        if (e.Source is null)
            return;

        var container = GetContainerFromEventSource(e.Source);
        if (container is not AntDesignTreeViewItem antDesignTreeViewItem)
            return;

        if (_lastMenuOpenItem == container && _lastMenuOpenItem.IsMenuOpen)
            return;

        if (_lastMenuOpenItem is not null)
        {
            _lastMenuOpenItem.IsMenuOpen = false;
            _lastMenuOpenItem = default;
        }

        antDesignTreeViewItem.IsMenuOpen = true;
        _lastMenuOpenItem = antDesignTreeViewItem;
    }

    void HideMenuItemCore()
    {
        if (_lastMenuOpenItem is null)
            return;

        _lastMenuOpenItem.IsMenuOpen = false;
        _lastMenuOpenItem = default;
    }

    private void TopLevel_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (e.Source is null)
            return;

        if (e.Source is not Visual visual)
            return;

        var visualRoot = visual.GetVisualRoot();
        if (visualRoot is PopupRoot)
            return;

        var antDesignTreeView = ((Visual)e.Source).GetSelfAndVisualAncestors().OfType<AntDesignTreeView>().FirstOrDefault();
        if (antDesignTreeView is not null)
            return;

        HideMenuItemCore();
    }

    private void TopLevel_PointerExited(object sender, PointerEventArgs e)
    {
        //HideMenuItemCore();
    }

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Expander, IsPanelExpanded);
    }

    void UpdateScaleX()
    {
        double width = double.IsNaN(WidthBeforeClosing) ? 0 : WidthBeforeClosing;
        double afterWidth = double.IsNaN(WidthAfterClosing) ? 0 : WidthAfterClosing;
        ScaleX = afterWidth / width;
    }

    void ExpanderOrClose(bool isExpander)
    {
        foreach (var item in Items)
            ExpanderOrCloseItems(item, isExpander);

        if (isExpander)
            HideMenuItemCore();
    }
}
