
namespace AntDesign.Controls;

public class AntDesignTreeView : TreeView
{
    static AntDesignTreeView()
    {
    }

    public AntDesignTreeView()
    {
        //AntDesignTreeViewItem.IsSelectedProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) => AntDesignTreeViewItemSelected(s, e.NewValue.Value));
        //AntDesignTreeViewItem.IsExpandedProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) => AntDesignTreeViewItemExpanded(s,e.NewValue.Value));
    }

    List<AntDesignTreeViewItem> _isExpandedViewItems = new();

    public static readonly StyledProperty<bool> IsPanelExpandedProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsPanelExpanded), defaultValue: true);

    public static readonly StyledProperty<double> WidthBeforeClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(WidthBeforeClosing), defaultValue: 0d);

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(WidthAfterClosing), defaultValue: 0d);


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

            if (bRet)
            {
                foreach (var item in _isExpandedViewItems)
                {
                    item.IsExpanded = true;
                }
            }
            else
            {
                foreach (var item in _isExpandedViewItems)
                {
                    item.IsExpanded = false;
                }
            }


        }

    } 
}
