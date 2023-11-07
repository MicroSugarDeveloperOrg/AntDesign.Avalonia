using AntDesign.Controls.Helpers;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

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
    protected MenuFlyout? _menuFlyout; 

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
                    return;
            }


            if (ContextMenu is not null)
                ContextMenu = default;

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
            {
               
                return;
            }
        }



        //Menu

        //if (_popup is null)
        //{
        //    _popup = new Popup();
        //    _popup.PlacementTarget = this;

        //    _popup.Child = new Border
        //    {
        //        Width = 100,
        //        Height = 100,
        //        Background = Brushes.Red,
        //    };
        //}

        //_popup.Placement = PlacementMode.Right;
        //_popup.IsLightDismissEnabled = true;
        //_popup.IsOpen = true;


        //if (_menu is null)
        //{
        //    _menu = new ContextMenu() 
        //    {

        //    };
        //    _menu.Items.Add(new MenuItem() { Header = "123" });
        //    _menu.Items.Add(new MenuItem() { Header = "123" });
        //    _menu.Items.Add(new MenuItem() { Header = "123" });
        //    _menu.Items.Add(new MenuItem() { Header = "123" });
        //}

        //_menu.Placement = PlacementMode.RightEdgeAlignedTop;
        //_menu.HorizontalOffset = 5;  
        //_menu.Open(this); 

        if (_menuFlyout is null)
        {
            _menuFlyout = new MenuFlyout()
            { };



            _menuFlyout.Items.Add(new MenuItem() { Header = "123" });
            _menuFlyout.Items.Add(new MenuItem() { Header = "123" });
            _menuFlyout.Items.Add(new MenuItem() { Header = "123" });
            _menuFlyout.Items.Add(new MenuItem() { Header = "123" });




        }

        _menuFlyout.ShowMode = FlyoutShowMode.TransientWithDismissOnPointerMoveAway;

        _menuFlyout.ShowAt(this);
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
}
