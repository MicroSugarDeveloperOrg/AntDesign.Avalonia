using AntDesign.Controls.Interactivity;
using AntDesign.Controls.Metadata;

namespace AntDesign.Controls;

//[PseudoClasses(pcLayoutModeChanged)]
[TemplatePart(PART_MenuPresent, typeof(ContentPresenter))]
[TemplatePart("PART_HeaderPresenter", typeof(ContentPresenter))]
public class AntDesignPanel : HeaderedContentControl
{
    static AntDesignPanel()
    {
        MenuProperty.Changed.AddClassHandler<AntDesignPanel>((x, e) => x.MenuChanged(e));
        LayOutModeProperty.Changed.AddClassHandler<AntDesignPanel, LayoutMode>((s, e) =>
        {
            s.LayoutMode_Changed(e);
        });
    }

    public AntDesignPanel()
    {
        //ContentPresenter.BoundsProperty
        //LayoutTransformControl
        //TranslateTransform   
        //SplitView
    }

    //const string pcLayoutModeChanged = ":layoutmode-changed";
    private const string PART_MenuPresent = nameof(PART_MenuPresent);
    private ContentPresenter _menuPresent = default!;

    #region DependencyProperty

    public static readonly StyledProperty<LayoutMode> LayOutModeProperty =
           AvaloniaProperty.Register<AntDesignPanel, LayoutMode>(nameof(LayOutMode));

    public static readonly StyledProperty<bool> IsHeaderProperty =
           AvaloniaProperty.Register<AntDesignPanel, bool>(nameof(IsHeader));

    public static readonly StyledProperty<bool> IsMenuProperty =
          AvaloniaProperty.Register<AntDesignPanel, bool>(nameof(IsMenu));

    public static readonly StyledProperty<object?> MenuProperty =
           AvaloniaProperty.Register<AntDesignPanel, object?>(nameof(Menu));

    public static readonly StyledProperty<IDataTemplate?> MenuTemplateProperty =
           AvaloniaProperty.Register<AntDesignPanel, IDataTemplate?>(nameof(MenuTemplate));

    public static readonly StyledProperty<object?> MenuHeaderProperty =
           AvaloniaProperty.Register<AntDesignPanel, object?>(nameof(MenuHeader));

    public static readonly StyledProperty<IDataTemplate?> MenuHeaderTemplateProperty =
           AvaloniaProperty.Register<AntDesignPanel, IDataTemplate?>(nameof(MenuHeaderTemplate));

    #endregion

    #region Event

    public static readonly RoutedEvent<LayoutModeEventArgs> LayoutModeChangedEvent =
           RoutedEvent.Register<AntDesignPanel, LayoutModeEventArgs>(nameof(LayoutModeChanged), RoutingStrategies.Direct);

    #endregion

    #region Property

    public ContentPresenter MenuPresent => _menuPresent;

    public LayoutMode LayOutMode
    {
        get { return GetValue(LayOutModeProperty); }
        set { SetValue(LayOutModeProperty, value); }
    }

    public bool IsHeader
    {
        get { return GetValue(IsHeaderProperty); }
        set { SetValue(IsHeaderProperty, value); }
    }

    public bool IsMenu
    {
        get { return GetValue(IsMenuProperty); }
        set { SetValue(IsMenuProperty, value); }
    }

    [DependsOn(nameof(MenuTemplate))]
    public object? Menu
    {
        get { return GetValue(MenuProperty); }
        set { SetValue(MenuProperty, value); }
    }

    public IDataTemplate? MenuTemplate
    {
        get { return GetValue(MenuTemplateProperty); }
        set { SetValue(MenuTemplateProperty, value); }
    }

    public object? MenuHeader
    {
        get { return GetValue(MenuHeaderProperty); }
        set { SetValue(MenuHeaderProperty, value); }
    }

    public IDataTemplate? MenuHeaderTemplate
    {
        get { return GetValue(MenuHeaderTemplateProperty); }
        set { SetValue(MenuHeaderTemplateProperty, value); }
    }

    #endregion

    #region Event

    public event EventHandler<LayoutModeEventArgs>? LayoutModeChanged
    {
        add { AddHandler(LayoutModeChangedEvent, value); }
        remove { RemoveHandler(LayoutModeChangedEvent, value); }
    }

    #endregion

    #region Method
    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);

        if (presenter.Name == PART_MenuPresent)
        {
            _menuPresent = presenter;
            result &= true;
        }

        if (_menuPresent is null)
            throw new NullReferenceException(nameof(_menuPresent));

        return result;
    }

    void MenuChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.OldValue is ILogical oldChild)
            LogicalChildren.Remove(oldChild);

        if (e.NewValue is ILogical newChild)
            LogicalChildren.Add(newChild);
    }

    void LayoutMode_Changed(AvaloniaPropertyChangedEventArgs<LayoutMode> e)
    {
        switch (e.NewValue.Value)
        {
            case LayoutMode.Top:
                break;
            case LayoutMode.BroadSide:
                break;
            case LayoutMode.Mix:
                break;
            default:
                break;
        }

        RaiseEvent(new LayoutModeEventArgs(e.NewValue.Value));
    }

    void UpdatePseudoClasses()
    {
        //PseudoClasses.Set(pcLayoutModeChanged, this.LayOutMode);
    }

    #endregion
}
