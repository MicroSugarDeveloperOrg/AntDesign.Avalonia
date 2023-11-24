using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

public class AntDesignTreeView : TreeView
{
    static AntDesignTreeView()
    {
        AutoScrollToSelectedItemProperty.OverrideDefaultValue<AntDesignTreeView>(false);
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

    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnAttachedToLogicalTree(e);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
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

    bool ExpanderOrCloseItems(object? item, bool isExpanded)
    {
        if (item is not TreeViewItem treeViewItem)
            return false;

        if (treeViewItem.ItemCount <= 0)
            return treeViewItem.IsSelected;

        bool bFlag = false;
        foreach (var subItem in treeViewItem.Items)
            bFlag |= ExpanderOrCloseItems(subItem, isExpanded);

        if (bFlag && isExpanded)
            treeViewItem.IsExpanded = true;
        else
            treeViewItem.IsExpanded = false;

        return bFlag;
    }

    void ExpandingOrColoring()
    {
        foreach (var item in Items)
            ExpandingOrColoring(item);
    }

    bool ExpandingOrColoring(object? item)
    {
        if (item is not AntDesignTreeViewItem antDesignTreeViewItem)
            return false;

        if (antDesignTreeViewItem.ItemCount > 0)
        {
            bool isFlag = false;
            foreach (var subitem in antDesignTreeViewItem.Items)
                isFlag |= ExpandingOrColoring(subitem);

            antDesignTreeViewItem.IsColoring = isFlag;
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
    }
}
