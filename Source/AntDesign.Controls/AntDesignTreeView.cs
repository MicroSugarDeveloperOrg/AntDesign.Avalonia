using Avalonia.Controls.Primitives;

namespace AntDesign.Controls;

public class AntDesignTreeView : TreeView
{
    static AntDesignTreeView()
    {
        IsPanelExpandedProperty.Changed.AddClassHandler<AntDesignTreeView, bool>((s, e) =>
        {

        });

        SelectedItemProperty.Changed.AddClassHandler<AntDesignTreeView, object?>((s, e) =>
        {
            s.ExpandingOrColoring();
        });
    }

    public AntDesignTreeView()
    {
        ScrollViewer.SetVerticalScrollBarVisibility(this, ScrollBarVisibility.Hidden);
        ScrollViewer.SetHorizontalScrollBarVisibility(this, ScrollBarVisibility.Hidden);
    }

    Popup? _popup;

    public static readonly StyledProperty<bool> IsMenuModeProperty =
       AvaloniaProperty.Register<AntDesignTreeView, bool>(nameof(IsMenuMode), defaultValue: false);

    public static readonly StyledProperty<bool> IsPanelExpandedProperty =
           AvaloniaProperty.Register<AntDesignTreeView, bool>(nameof(IsPanelExpanded), defaultValue: true);

    public static readonly StyledProperty<double> WidthBeforeClosingProperty =
           AvaloniaProperty.Register<AntDesignTreeView, double>(nameof(WidthBeforeClosing), defaultValue: 0d);

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignTreeView, double>(nameof(WidthAfterClosing), defaultValue: 0d);


    public bool IsMenuMode
    {
        get => GetValue(IsMenuModeProperty);
        set => SetValue(IsMenuModeProperty, value);
    }

    public bool IsPanelExpanded
    {
        get => GetValue(IsPanelExpandedProperty);
        set => SetValue(IsPanelExpandedProperty, value);
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

        _popup = e.NameScope.Find<Popup>("PART_Popup");

        OnSelectedFirstValidItem(Items.FirstOrDefault());
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

        if (WidthBeforeClosing <= 0)
            WidthBeforeClosing = Bounds.Width;

        Width = double.NaN;
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsPanelExpandedProperty)
        {
            if (!bool.TryParse(change.NewValue?.ToString(), out var bRet))
                return;

            foreach (var item in Items)
                ExpanderOrCloseItems(item, bRet);
        }
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
            {
                isFlag = ExpandingOrColoringParents(subitem);
                if (isFlag)
                    break;
            }

            antDesignTreeViewItem.IsColor = isFlag;
            antDesignTreeViewItem.IsExpanded = isFlag;
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
            SelectedItem = item;
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

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);

        if (IsPanelExpanded)
            return;

        //if (_popup is null)
            //return;

        if (e.Source is null)
            return;

        var container = GetContainerFromEventSource(e.Source);
        if (container is null)
            return;

        //if (container.ItemCount > 0)
        //{
        //    _popup.Placement = PlacementMode.Right;
        //    _popup.PlacementTarget = container;
        //    _popup.HorizontalOffset = 10;
        //    _popup.IsOpen = true;
        //}
        
    }
}
