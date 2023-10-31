
namespace AntDesign.Controls;
public class AntDesignTreeViewItem : TreeViewItem
{
    static AntDesignTreeViewItem()
    {
        IsSelectedProperty.AddOwner<AntDesignTreeViewItem>(new StyledPropertyMetadata<bool>(coerce: (s, e) =>
        {
            if (s is not AntDesignTreeViewItem antDesignTreeViewItem)
                return e;

            if (antDesignTreeViewItem.ItemCount > 0 && antDesignTreeViewItem._antDesignTreeView?.IsMenuMode == true)
                return false;

            return e;
        }));
    }

    public AntDesignTreeViewItem()
    {

    }

    protected Control? _header;
    protected AntDesignTreeView? _antDesignTreeView;

    public static readonly StyledProperty<bool> IsColourProperty =
           AvaloniaProperty.Register<AntDesignTreeViewItem, bool>(nameof(IsColour), defaultValue: false);

 
    public bool IsColour
    {
        get => GetValue(IsColourProperty);
        set => SetValue(IsColourProperty, value);
    }

    protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        base.OnAttachedToLogicalTree(e);
        _antDesignTreeView = this.GetLogicalAncestors().OfType<AntDesignTreeView>().FirstOrDefault();
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _header = e.NameScope.Find<Control>("PART_Header");
        //if (_header is not null)
            //_header.PointerPressed += Header_PointerPressed;
    }

    private void Header_PointerPressed(object sender, PointerPressedEventArgs e)
    {
         //if(ItemCount > 0)
            //IsExpanded = !IsExpanded;
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsSelectedProperty)
        {
            if (!bool.TryParse(change.NewValue?.ToString(), out var bRet))
                return;

            if (bRet)
            {
                IsColour = true;
                if (Parent is not AntDesignTreeViewItem parentTreeViewItem)
                    return;

                parentTreeViewItem.IsColour = true;
            }
            else
            {

            }
        }

    }
}
