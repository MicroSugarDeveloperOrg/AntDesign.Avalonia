
namespace AntDesign.Controls;

public class AntDesignTreeView : TreeView
{
    static AntDesignTreeView()
    {
    }

    public AntDesignTreeView()
    {
        ScrollViewer.SetVerticalScrollBarVisibility(this, ScrollBarVisibility.Disabled);
        ScrollViewer.SetHorizontalScrollBarVisibility(this, ScrollBarVisibility.Disabled);
        //AntDesignTreeViewItem.IsSelectedProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) => AntDesignTreeViewItemSelected(s, e.NewValue.Value));
        //AntDesignTreeViewItem.IsExpandedProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) => AntDesignTreeViewItemExpanded(s,e.NewValue.Value));
    }

    List<AntDesignTreeViewItem> _isExpandedViewItems = new();

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

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);
    }

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new AntDesignTreeViewItem();
    }

    void AntDesignTreeViewItemExpanded(AntDesignTreeViewItem item, bool isExpanded)
    {
        if (!Items.Contains(item))
            return;

        //if (isExpanded)
        //    _isExpandedViewItems.Add(item);
        //else
        //    _isExpandedViewItems.Remove(item);
    }

    void AntDesignTreeViewItemSelected(AntDesignTreeViewItem item, bool isSelected)
    {
        if (!Items.Contains(item))
            return;

        if (isSelected)
        {
            
            _isExpandedViewItems.Add(item);
        }
        else
        {

            _isExpandedViewItems.Remove(item);
        }

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
        if (item is null)
            return;

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

}
