﻿namespace AntDesign.Controls;

public class AntDesignTreeView : TreeView
{
    static AntDesignTreeView()
    {
      
    }

    public AntDesignTreeView()
    {
        AntDesignTreeViewItem.IsExpandedProperty.Changed.AddClassHandler<AntDesignTreeViewItem, bool>((s, e) => AntDesignTreeViewItemExpanded(s,e.NewValue.Value));
    }


    public static readonly StyledProperty<bool> IsPanelExpandedProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsPanelExpanded));

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(WidthAfterClosing), defaultValue: 0d);


    public bool IsPanelExpanded
    {
        get => GetValue(IsPanelExpandedProperty);
        set => SetValue(IsPanelExpandedProperty, value);
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


    }
}