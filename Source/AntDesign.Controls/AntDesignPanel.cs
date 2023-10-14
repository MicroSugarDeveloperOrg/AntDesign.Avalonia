using AntDesign.Controls.Helpers;
using AntDesign.Controls.Interactivity;
using AntDesign.Controls.Metadata;

namespace AntDesign.Controls;

//[PseudoClasses(pcLayoutModeChanged)]
//[PseudoClasses(AntDesignPseudoNameHelpers.PC_PanelSideMenuOpened, AntDesignPseudoNameHelpers.PC_PanelTopMenuOpened)]
[PseudoClasses(AntDesignPseudoNameHelpers.PC_PanelTopMenu, AntDesignPseudoNameHelpers.PC_PanelSideMenu, AntDesignPseudoNameHelpers.PC_PanelMixMenu)]
[TemplatePart(AntDesignPARTNameHelpers._PART_MenuPresent, typeof(ContentPresenter))]
[TemplatePart(AntDesignPARTNameHelpers._PART_HeaderPresenter, typeof(ContentPresenter))]
public class AntDesignPanel : HeaderedContentControl
{
    static AntDesignPanel()
    {
        //MenuProperty.Changed.AddClassHandler<AntDesignPanel>((x, e) => x.MenuChanged(e));
        LayoutModeProperty.Changed.AddClassHandler<AntDesignPanel, PanelLayoutMode>((s, e) =>
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

    /// <summary>
    /// 布局模式
    /// </summary>
    public static readonly StyledProperty<PanelLayoutMode> LayoutModeProperty =
           AvaloniaProperty.Register<AntDesignPanel, PanelLayoutMode>(nameof(LayoutMode), defaultValue:PanelLayoutMode.MixMenu);

    /// <summary>
    /// 是否启用标头
    /// </summary>
    public static readonly StyledProperty<bool> IsHeaderProperty =
           AvaloniaProperty.Register<AntDesignPanel, bool>(nameof(IsHeader), defaultValue: true);

    //包含header and headerTemplate
    public static readonly StyledProperty<IBrush?> TopHeaderBackgroundProperty =
           AvaloniaProperty.Register<AntDesignPanel, IBrush?>(nameof(TopHeaderBackground));

    public static readonly StyledProperty<BoxShadows> TopHeaderBoxShadowProperty =
           AvaloniaProperty.Register<AntDesignPanel, BoxShadows>(nameof(TopHeaderBoxShadow));

    /// <summary>
    /// 是否启用菜单
    /// </summary>
    public static readonly StyledProperty<bool> IsMenuProperty =
           AvaloniaProperty.Register<AntDesignPanel, bool>(nameof(IsMenu), defaultValue: true);

    //Side Menu
    public static readonly StyledProperty<IBrush?> SideMenuBackgroundProperty =
          AvaloniaProperty.Register<AntDesignPanel, IBrush?>(nameof(SideMenuBackground));

    public static readonly StyledProperty<BoxShadows> SideMenuBoxShadowProperty =
           AvaloniaProperty.Register<AntDesignPanel, BoxShadows>(nameof(SideMenuBoxShadow));

    public static readonly StyledProperty<object?> SideMenuContentProperty =
           AvaloniaProperty.Register<AntDesignPanel, object?>(nameof(SideMenuContent));

    public static readonly StyledProperty<IDataTemplate?> SideMenuContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignPanel, IDataTemplate?>(nameof(SideMenuContentTemplate));

    public static readonly StyledProperty<object?> SideMenuBottomProperty =
       AvaloniaProperty.Register<AntDesignPanel, object?>(nameof(SideMenuBottom));

    public static readonly StyledProperty<IDataTemplate?> SideMenuBottomTemplateProperty =
           AvaloniaProperty.Register<AntDesignPanel, IDataTemplate?>(nameof(SideMenuBottomTemplate));

    //Top Menu
    public static readonly StyledProperty<object?> TopMenuContentProperty =
           AvaloniaProperty.Register<AntDesignPanel, object?>(nameof(TopMenuContent));

    public static readonly StyledProperty<IDataTemplate?> TopMenuContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignPanel, IDataTemplate?>(nameof(TopMenuContentTemplate));

    /// <summary>
    /// 是否启用菜单头 Logo
    /// </summary>
    public static readonly StyledProperty<bool> IsMenuHeaderProperty =
           AvaloniaProperty.Register<AntDesignPanel, bool>(nameof(IsMenuHeader), defaultValue: true);

    //Side MenuHeader
    public static readonly StyledProperty<object?> SideMenuHeaderProperty =
           AvaloniaProperty.Register<AntDesignPanel, object?>(nameof(SideMenuHeader));

    public static readonly StyledProperty<IDataTemplate?> SideMenuHeaderTemplateProperty =
           AvaloniaProperty.Register<AntDesignPanel, IDataTemplate?>(nameof(SideMenuHeaderTemplate));

    //Top MenuHeader
    public static readonly StyledProperty<object?> TopMenuHeaderProperty =
           AvaloniaProperty.Register<AntDesignPanel, object?>(nameof(TopMenuHeader));

    public static readonly StyledProperty<IDataTemplate?> TopMenuHeaderTemplateProperty =
           AvaloniaProperty.Register<AntDesignPanel, IDataTemplate?>(nameof(TopMenuHeaderTemplate));

    #endregion

    #region Event

    public static readonly RoutedEvent<PanelLayoutModeEventArgs> LayoutModeChangedEvent =
           RoutedEvent.Register<AntDesignPanel, PanelLayoutModeEventArgs>(nameof(LayoutModeChanged), RoutingStrategies.Direct);

    #endregion

    #region Property

    public ContentPresenter MenuPresent => _menuPresent;

    public PanelLayoutMode LayoutMode
    {
        get => GetValue(LayoutModeProperty);
        set => SetValue(LayoutModeProperty, value);
    }

    public bool IsHeader
    {
        get => GetValue(IsHeaderProperty);
        set => SetValue(IsHeaderProperty, value);
    }

    public IBrush? TopHeaderBackground
    {
        get => GetValue(TopHeaderBackgroundProperty);
        set => SetValue(TopHeaderBackgroundProperty, value);
    }

    public BoxShadows TopHeaderBoxShadow
    {
        get => GetValue(TopHeaderBoxShadowProperty);
        set => SetValue(TopHeaderBoxShadowProperty, value);
    }

    public bool IsMenu
    {
        get => GetValue(IsMenuProperty);
        set => SetValue(IsMenuProperty, value);
    }

    public IBrush? SideMenuBackground
    {
        get => GetValue(SideMenuBackgroundProperty);
        set => SetValue(SideMenuBackgroundProperty, value);
    }

    public BoxShadows SideMenuBoxShadow
    {
        get => GetValue(SideMenuBoxShadowProperty);
        set => SetValue(SideMenuBoxShadowProperty, value);
    }

    public object? SideMenuContent
    {
        get => GetValue(SideMenuContentProperty);
        set => SetValue(SideMenuContentProperty, value);
    }

    public IDataTemplate? SideMenuContentTemplate
    {
        get => GetValue(SideMenuContentTemplateProperty);
        set => SetValue(SideMenuContentTemplateProperty, value);
    }

    public object? SideMenuBottom
    {
        get => GetValue(SideMenuBottomProperty);
        set => SetValue(SideMenuBottomProperty, value);
    }

    public IDataTemplate? SideMenuBottomTemplate
    {
        get => GetValue(SideMenuBottomTemplateProperty);
        set => SetValue(SideMenuBottomTemplateProperty, value);
    }

    public object? TopMenuContent
    {
        get => GetValue(TopMenuContentProperty);
        set => SetValue(TopMenuContentProperty, value);
    }

    public IDataTemplate? TopMenuContentTemplate
    {
        get => GetValue(TopMenuContentTemplateProperty);
        set => SetValue(TopMenuContentTemplateProperty, value);
    }

    public bool IsMenuHeader
    {
        get => GetValue(IsMenuHeaderProperty);
        set => SetValue(IsMenuHeaderProperty, value);
    }

    public object? SideMenuHeader
    {
        get => GetValue(SideMenuHeaderProperty);
        set => SetValue(SideMenuHeaderProperty, value);
    }

    public IDataTemplate? SideMenuHeaderTemplate
    {
        get => GetValue(SideMenuHeaderTemplateProperty);
        set => SetValue(SideMenuHeaderTemplateProperty, value);
    }

    public object? TopMenuHeader
    {
        get => GetValue(TopMenuHeaderProperty);
        set => SetValue(TopMenuHeaderProperty, value);
    }

    public IDataTemplate? TopMenuHeaderTemplate
    {
        get => GetValue(TopMenuHeaderTemplateProperty);
        set => SetValue(TopMenuHeaderTemplateProperty, value);
    }

    #endregion

    #region Event

    public event EventHandler<PanelLayoutModeEventArgs>? LayoutModeChanged
    {
        add { AddHandler(LayoutModeChangedEvent, value); }
        remove { RemoveHandler(LayoutModeChangedEvent, value); }
    }

    #endregion

    #region Method

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        UpdatePanelLayoutModePseudoClasses(LayoutMode);
    }

    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);

        if (presenter.Name == PART_MenuPresent)
        {
            _menuPresent = presenter;
            result &= true;
        }

        //if (_menuPresent is null)
            //throw new NullReferenceException(nameof(_menuPresent));

        return result;
    }

    void MenuChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.OldValue is ILogical oldChild)
            LogicalChildren.Remove(oldChild);

        if (e.NewValue is ILogical newChild)
            LogicalChildren.Add(newChild);
    }

    void LayoutMode_Changed(AvaloniaPropertyChangedEventArgs<PanelLayoutMode> e)
    {
        UpdatePanelLayoutModePseudoClasses(e.NewValue.Value);
        RaiseEvent(new PanelLayoutModeEventArgs(e.NewValue.Value));
    }

    void UpdatePanelLayoutModePseudoClasses(PanelLayoutMode mode)
    {
        switch (mode)
        {
            case PanelLayoutMode.TopMenu:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelTopMenu, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelSideMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelMixMenu, false);
                }
                break;
            case PanelLayoutMode.SideMenu:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelTopMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelSideMenu, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelMixMenu, false);
                }
                break;
            case PanelLayoutMode.MixMenu:
            default:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelTopMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelSideMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelMixMenu, true);
                }
                break;
        }
    }

    #endregion
}
