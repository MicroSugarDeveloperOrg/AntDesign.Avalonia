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
    }

    public AntDesignTreeViewItem()
    {
        //ItemsSource
    }

    bool _isColor = false;
    bool _isPanelClosing = false;
    protected Control? _header;
    protected AntDesignTreeView? _antDesignTreeView;

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsColorProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsColor), b => b.IsColor);

    public static readonly DirectProperty<AntDesignTreeViewItem, bool> IsPanelClosingProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTreeViewItem, bool>(nameof(IsPanelClosing), b => b.IsPanelClosing);

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
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromLogicalTree(e);
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
                {

                    //ContextFlyout = new Fla
                    if (ContextMenu is null)
                    {
                        ContextMenu = new ContextMenu();
                        ContextMenu.Items.Add(new MenuItem() { Header = "123" });
                        ContextMenu.Items.Add(new MenuItem() { Header = "123" });
                        ContextMenu.Items.Add(new MenuItem() { Header = "123" });
                        ContextMenu.Items.Add(new MenuItem() { Header = "123" });

                      
                    }

                    
                    //ContextMenu.Open();

                    return;
                }
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
}
